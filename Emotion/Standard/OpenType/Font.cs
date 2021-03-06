﻿#region Using

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Emotion.Common;
using Emotion.Common.Threading;
using Emotion.Game;
using Emotion.Primitives;
using Emotion.Standard.Logging;
using Emotion.Standard.OpenType.FontTables;
using Emotion.Utility;

#if StbTrueType
using Emotion.Primitives;
using StbTrueTypeSharp;
#endif

#if FreeType
using System.IO;
using System.Reflection;
#endif

#endregion

namespace Emotion.Standard.OpenType
{
    /// <summary>
    /// Represents an OpenType font.
    /// </summary>
    public class Font
    {
        /// <summary>
        /// Whether the font was successfully parsed.
        /// </summary>
        public bool Valid;

        #region Meta

        /// <summary>
        /// The font's family name.
        /// </summary>
        public string FontFamily;

        /// <summary>
        /// The font's sub family name.
        /// </summary>
        public string FontSubFamily;

        /// <summary>
        /// The full name of the font.
        /// </summary>
        public string FullName;

        /// <summary>
        /// The font's version.
        /// </summary>
        public string Version;

        /// <summary>
        /// The font's copyright.
        /// </summary>
        public string Copyright;

        /// <summary>
        /// The font's uniqueId.
        /// </summary>
        public string UniqueId;

        #endregion

        /// <summary>
        /// The font's format.
        /// This will be either "truetype" or "cff".
        /// </summary>
        public string Format { get; protected set; }

        /// <summary>
        /// Glyphs found in the font.
        /// </summary>
        public Glyph[] Glyphs;

        /// <summary>
        /// The character index of the first glyph.
        /// </summary>
        public uint FirstCharIndex { get; protected set; }

        /// <summary>
        /// The largest character index found in the font.
        /// </summary>
        public uint LastCharIndex { get; protected set; }

        /// <summary>
        /// The font's ascender minus its descender. Is used as the distance between lines and is regarded as the safe space.
        /// </summary>
        public int Height
        {
            get => Ascender - Descender;
        }

        /// <summary>
        /// The highest a glyph can reach.
        /// </summary>
        public short Ascender { get; protected set; }

        /// <summary>
        /// The lowest a glyph can reach.
        /// </summary>
        public short Descender { get; protected set; }

        /// <summary>
        /// The font's defined resolution. Is used for scaling glyphs.
        /// </summary>
        public ushort UnitsPerEm { get; protected set; }

        #region Parsing

        /// <summary>
        /// The font's magic tag from which the format was inferred.
        /// Generally this is useless to users.
        /// </summary>
        public string Tag { get; protected set; }

        /// <summary>
        /// Font tables found within the font.
        /// After the initial parsing these aren't used.
        /// </summary>
        public List<FontTable> Tables = new List<FontTable>();

        /// <summary>
        /// The number of horizontal metrics found in the font.
        /// </summary>
        public ushort NumberOfHMetrics { get; protected set; }

        #endregion

#if FreeType
        private static IntPtr _freeTypeLib;
        private static dynamic _freeTypeLibrary;
        private static Type _freeTypeFaceType;
        private object _freeTypeFace;

        private static MethodInfo _setCharSizeMethod;
        private static MethodInfo _renderGlyphMethod;
        private static PropertyInfo _facePropertySize;

        public Font(byte[] fontData, bool freeTypeRasterizer = true)
        {
            if (freeTypeRasterizer)
            {
                try
                {
                    if (_freeTypeLib == IntPtr.Zero)
                    {
                        Assembly freeTypeSupportAssembly = Assembly.LoadFrom(Path.Combine("AssetsNativeLibs", "Emotion.Standard.FreeType.dll"));
                        MethodInfo initFunc = freeTypeSupportAssembly.GetType("SharpFont.FT").GetMethod("Init");
                        _freeTypeLib = Engine.Host.LoadLibrary(Path.Combine("Standard", "OpenType", "Freetype", "freetype6"));
                        if (_freeTypeLib != IntPtr.Zero)
                        {
                            initFunc?.Invoke(null, new object[] { _freeTypeLib });
                            Type freeTypeWrapperType = freeTypeSupportAssembly.GetType("Emotion.Standard.FreeType.Wrapper");
                            Type freeTypeLibraryType = freeTypeSupportAssembly.GetType("SharpFont.Library");
                            _freeTypeLibrary = Activator.CreateInstance(freeTypeLibraryType);

                            _freeTypeFaceType = freeTypeSupportAssembly.GetType("SharpFont.Face");
                            _facePropertySize = _freeTypeFaceType.GetProperty("Size");

                            _setCharSizeMethod = freeTypeWrapperType?.GetMethod("SetCharSize");
                            _renderGlyphMethod = freeTypeWrapperType?.GetMethod("RenderGlyphDefaultOptions");
                        }
                        else
                        {
                            Engine.Log.Warning("Couldn't load the native FreeType library through the host.", MessageSource.FontParser);
                            return;
                        }
                    }

                    _freeTypeFace = Activator.CreateInstance(_freeTypeFaceType, _freeTypeLibrary, fontData, 0);
                }
                catch (Exception)
                {
                    // Suppress errors.
                    Engine.Log.Error("Couldn't load FreeType.", "Emotion.Standard.FreeType");
                }
            }
#else
        /// <summary>
        /// Create a new OpenType font from a font file.
        /// </summary>
        /// <param name="fontData">The bytes that make up the font file.</param>
        public Font(ReadOnlyMemory<byte> fontData)
        {
#endif

            // Note: OpenType fonts use big endian byte ordering.
            using var r = new ByteReader(fontData);
            Tag = new string(r.ReadChars(4));

            switch (Tag)
            {
                case "\0\u0001\0\0":
                case "true":
                case "typ1":
                {
                    Format = "truetype";
                    ushort numTables = r.ReadUShortBE();
                    r.ReadBytes(6);
                    Tables = GetTables(r, numTables);
                    break;
                }

                case "OTTO":
                {
                    Format = "cff";
                    ushort numTables = r.ReadUShortBE();
                    r.ReadBytes(6);
                    Tables = GetTables(r, numTables);
                    break;
                }
                case "wOFF":
                {
                    Format = new string(r.ReadChars(4)) == "OTTO" ? "cff" : "truetype";
                    r.ReadBytes(4);
                    r.ReadUShortBE();
                    // todo: Read wOFF tables.
                    break;
                }
            }

            // Header
            FontTable table = GetTable("head");
            short indexToLocFormat;
            if (table != null)
            {
                var head = new HeadTable(r.Branch(table.Offset, true, table.Length));
                UnitsPerEm = head.UnitsPerEm;
                indexToLocFormat = head.IndexToLocFormat;
            }
            else
            {
                Engine.Log.Warning("Font head table not found.", MessageSource.FontParser);
                return;
            }

            // Horizontal header - information about horizontal layout of glyphs.
            table = GetTable("hhea");
            if (table != null)
            {
                var hhea = new HheaTable(r.Branch(table.Offset, true, table.Length));

                Ascender = hhea.Ascender;
                Descender = hhea.Descender;
                NumberOfHMetrics = hhea.NumberOfHMetrics;
            }
            else
            {
                Engine.Log.Warning("Font hhea table not found.", MessageSource.FontParser);
                return;
            }

            // Name table - contains meta information about the font.
            table = GetTable("name");
            if (table != null)
            {
                // todo: ltag parsing
                Dictionary<string, Dictionary<string, string>> names = NameTable.ParseName(r.Branch(table.Offset, true, table.Length), null);

                FontFamily = NameTable.GetDefaultValue(names, "fontFamily");
                FontSubFamily = NameTable.GetDefaultValue(names, "fontSubfamily");
                FullName = NameTable.GetDefaultValue(names, "fullName");
                Version = NameTable.GetDefaultValue(names, "version");
                Copyright = NameTable.GetDefaultValue(names, "copyright");
                UniqueId = NameTable.GetDefaultValue(names, "uniqueID");
            }
            else
            {
                Engine.Log.Warning("Font name table not found.", MessageSource.FontParser);
                return;
            }

            // MaxP - contains information about the font's memory footprint.
            table = GetTable("maxp");
            ushort numGlyphs;
            if (table != null)
            {
                var maxp = new MaxpTable(r.Branch(table.Offset, true, table.Length));
                numGlyphs = maxp.NumGlyphs;
            }
            else
            {
                Engine.Log.Warning("Font maxp table not found.", MessageSource.FontParser);
                return;
            }

            // Get the cmap table which defines glyph indices.
            table = GetTable("cmap");
            CMapTable cMap = table != null ? new CMapTable(r.Branch(table.Offset, true, table.Length)) : null;

            // Glyf - glyph data.
            // Also reads loca for locations, and post for glyph names.
            Glyph[] glyphs;
            table = GetTable("glyf");
            if (table != null)
            {
                FontTable locaTable = GetTable("loca");
                int[] locaOffsets = LocaTable.ParseLoca(r.Branch(locaTable.Offset, true, locaTable.Length), numGlyphs, indexToLocFormat == 0);
                glyphs = GlyfTable.ParseGlyf(r.Branch(table.Offset, true, table.Length), locaOffsets);
            }
            else
            {
                table = GetTable("CFF ");
                if (table == null)
                {
                    Engine.Log.Warning("Font - neither glyf nor cff table found.", MessageSource.FontParser);
                    return;
                }

                var cff = new CffTable(r.Branch(table.Offset, true, table.Length));
                glyphs = new Glyph[cff.NumberOfGlyphs];
                for (var i = 0; i < glyphs.Length; i++)
                {
                    glyphs[i] = cff.CffGlyphLoad(i);
                }
            }

            // Apply the character map.
            if (cMap?.GlyphIndexMap != null)
            {
                var smallestCharIdx = uint.MaxValue;
                uint highestCharIdx = 0;
                Glyphs = new Glyph[cMap.GlyphIndexMap.Count];

                // Add glyph names if present.
                string[] names = null;
                FontTable postTable = GetTable("post");
                if (postTable != null)
                {
                    var post = new PostTable(r.Branch(postTable.Offset, true, postTable.Length));
                    names = post.Names;
                }

                var idx = 0;
                foreach ((uint key, uint value) in cMap.GlyphIndexMap)
                {
                    var valInt = (int) value;
                    if (valInt >= glyphs.Length) continue; // Should never happen, but it's outside data, soo...

                    Glyph glyph = glyphs[valInt];
                    if (names != null) glyph.Name = names[valInt];

                    smallestCharIdx = Math.Min(smallestCharIdx, key);
                    highestCharIdx = Math.Max(highestCharIdx, key);

                    glyph.CharIndex.Add((char) key);
                    glyph.MapIndex = value;
                    Glyphs[idx++] = glyph;
                }

                FirstCharIndex = smallestCharIdx;
                LastCharIndex = highestCharIdx;
            }
            else
            {
                Glyphs = glyphs;
                for (var i = 0; i < Glyphs.Length; i++)
                {
                    Glyphs[i].CharIndex.Add((char) i);
                }
            }

            // Add metrics. This requires the glyph's to have MapIndices
            table = GetTable("hmtx");
            if (table != null) HmtxTable.ParseHmtx(r.Branch(table.Offset, true, table.Length), NumberOfHMetrics, Glyphs);

            // os/2 parsed, but unused
            // cvt parsed, but unused
            // todo: kern
            // todo: gsub
            // todo: gpos
            // todo: fvar
            // todo: meta

            Valid = true;
        }

        #region Atlas Rasterization

        /// <summary>
        /// The renderer for glyph vertices.
        /// </summary>
        public enum GlyphRasterizer
        {
            /// <summary>
            /// The default renderer.
            /// Based on the Stb renderer, but has some differences.
            /// If everything is well it should produce the same results as the Stb renderer.
            /// Fastest
            /// </summary>
            Emotion,
#if StbTrueType
            /// <summary>
            /// A more mature rasterizer to be used if the Emotion rasterizer produces bugs/unwanted results.
            /// Is sort of a fallback.
            /// Fast
            /// </summary>
            StbTrueType,
#endif
#if FreeType
            /// <summary>
            /// The most mature and advanced renderer, but it isn't portable as it is a native library.
            /// Emotion.Standard includes the MacOS64, Windows64 and Linux64 freetype libraries, but this
            /// should be used for reference only. Please don't use this.
            ///
            /// Additionally this rasterizer will reload the font as the information parsed from Emotion is not
            /// transferable.
            ///
            /// The rasterizer isn't slow itself, but due to how everything is implemented this is the slowest option.
            /// </summary>
            FreeType
#endif
        }

        /// <summary>
        /// Create a rasterized atlas from the font.
        /// </summary>
        /// <param name="fontSize">The size of glyphs in the font.</param>
        /// <param name="firstChar">The codepoint of the first character to include in the atlas.</param>
        /// <param name="numChars">The number of characters to include in the atlas, after the first character.</param>
        /// <param name="rasterizer">The rasterizer to use.</param>
        /// <returns>A single channel image representing the rendered glyphs at the specified size.</returns>
        public FontAtlas GetAtlas(float fontSize, uint firstChar = 0, int numChars = -1, GlyphRasterizer rasterizer = GlyphRasterizer.Emotion)
        {
#if RASTERIZER_PROFILER
            var sw = Stopwatch.StartNew();
#endif

            if (Glyphs == null || Glyphs.Length == 0) return null;
            if (firstChar < FirstCharIndex) firstChar = FirstCharIndex;
            if (numChars == -1) numChars = (int) (LastCharIndex - firstChar);
            var lastIdx = (int) (firstChar + numChars);

            // The scale to render at.
            float scale = fontSize / Height;

            var canvases = new ConcurrentDictionary<int, GlyphRenderer.GlyphCanvas>();
            ParallelWork.FastLoops(Glyphs.Length, (start, end) =>
            {
                for (int i = start; i < end; i++)
                {
                    Glyph g = Glyphs[i];
                    bool inIndex = g.CharIndex.Any(charIdx => charIdx >= firstChar && charIdx < lastIdx);
                    if (!inIndex) continue;

                    GlyphRenderer.GlyphCanvas renderedGlyph = null;
                    switch (rasterizer)
                    {
                        case GlyphRasterizer.Emotion:
                            renderedGlyph = RenderGlyph(this, g, scale);
                            break;
#if StbTrueType
                        case GlyphRasterizer.StbTrueType:
                            renderedGlyph = RenderGlyphStb(this, g, scale);
                            break;
#endif
#if FreeType
                        case GlyphRasterizer.FreeType:
                            renderedGlyph = RenderGlyphFreeType(g, fontSize);
                            break;
#endif
                    }

                    if (renderedGlyph == null) continue;
                    canvases.TryAdd(i, renderedGlyph);
                }
            }).Wait();

            // Fit glyphs into an atlas.
            const int glyphSpacing = 1;
            var glyphSpacing2 = new Vector2(glyphSpacing);
            var glyphRects = new Rectangle[canvases.Count];
            foreach ((int key, GlyphRenderer.GlyphCanvas canvas) in canvases)
            {
                if (canvas == null || canvas.Data.Length == 0) continue;

                // Inflate for spacing on all sides.
                var r = new Rectangle(0, 0, canvas.Width + glyphSpacing * 2, canvas.Height + glyphSpacing * 2);
                glyphRects[key] = r;
            }
            Vector2 atlasSize = Binning.FitRectangles(glyphRects);

            // Copy glyphs to atlas.
            var atlas = new byte[(int) atlasSize.X * (int) atlasSize.Y];
            var atlasObj = new FontAtlas(atlasSize, atlas, rasterizer.ToString(), scale, this);
            var atlasWidth = (int) atlasSize.X;
            foreach ((int key, GlyphRenderer.GlyphCanvas canvas) in canvases)
            {
                if (canvas == null) continue;
                AtlasGlyph canvasGlyph = canvas.Glyph;

                // Associate canvas with all representing chars.
                List<char> representingChars = canvasGlyph.FontGlyph.CharIndex;
                for (var j = 0; j < representingChars.Count; j++)
                {
                    atlasObj.Glyphs[representingChars[j]] = canvasGlyph;
                }

                // Empty glyph, no need to paste to atlas.
                if (canvas.Data.Length == 0) continue;

                Rectangle atlasRect = glyphRects[key];
                atlasRect.Position += glyphSpacing2;
                atlasRect.Size -= glyphSpacing2;

                // Copy pixels and record the location of the glyph.
                for (var row = 0; row < canvas.Height; row++)
                {
                    for (var col = 0; col < canvas.Width; col++)
                    {
                        var x = (int) (atlasRect.X + col);
                        var y = (int) (atlasRect.Y + row);
                        atlas[y * atlasWidth + x] = canvas.Data[row * canvas.Stride + col];
                    }
                }

                canvasGlyph.UVLocation = atlasRect.Position;
                canvasGlyph.UVSize = new Vector2(canvas.Width, canvas.Height);
            }

#if RASTERIZER_PROFILER
            Engine.Log.Warning($"Rasterized font {FullName} of size {fontSize} in {sw.ElapsedMilliseconds}ms", MessageSource.Debug);
#endif

            return atlasObj;
        }

        private static GlyphRenderer.GlyphCanvas RenderGlyph(Font f, Glyph g, float scale)
        {
            var atlasGlyph = new AtlasGlyph(g, scale, f.Ascender);
            var canvas = new GlyphRenderer.GlyphCanvas(atlasGlyph, (int) (atlasGlyph.Size.X + 1), (int) (atlasGlyph.Size.Y + 1));

            // Check if glyph can be rendered, and render it.
            if (g.Vertices != null && g.Vertices.Length != 0)
                GlyphRenderer.RenderGlyph(canvas, g, scale);

            // Remove padding.
            canvas.Width -= 1;
            canvas.Height -= 1;

            return canvas;
        }

#if StbTrueType
        private static unsafe GlyphRenderer.GlyphCanvas RenderGlyphStb(Font f, Glyph g, float scale)
        {
            var atlasGlyph = new AtlasGlyph(g, scale, f.Ascender);
            var canvas = new GlyphRenderer.GlyphCanvas(atlasGlyph, (int) atlasGlyph.Size.X + 1, (int) atlasGlyph.Size.Y + 1);

            // Check if glyph can be rendered.
            if (g.Vertices == null || g.Vertices.Length == 0)
                return canvas;

            // Render the current glyph.
            if ((int) atlasGlyph.Size.X == 0 || (int) atlasGlyph.Size.Y == 0) return canvas;
            GlyphVertex[] vertices = g.Vertices;

            fixed (byte* pixels = &canvas.Data[0])
            {
                var bitmap = new StbTrueType.stbtt__bitmap
                {
                    w = canvas.Width,
                    h = canvas.Height,
                    stride = canvas.Width,
                    pixels = pixels
                };

                var verts = new StbTrueType.stbtt_vertex[vertices.Length];
                for (var i = 0; i < vertices.Length; i++)
                {
                    verts[i].x = vertices[i].X;
                    verts[i].y = vertices[i].Y;
                    verts[i].cx = vertices[i].Cx;
                    verts[i].cy = vertices[i].Cy;
                    verts[i].cx1 = vertices[i].Cx1;
                    verts[i].cy1 = vertices[i].Cy1;
                    verts[i].type = (byte) vertices[i].TypeFlag;
                }

                Rectangle bbox = g.GetBBox(scale);

                fixed (StbTrueType.stbtt_vertex* vert = &verts[0])
                {
                    StbTrueType.stbtt_Rasterize(&bitmap, 0.35f, vert, vertices.Length, scale, scale, 0, 0, (int) bbox.X, (int) bbox.Y, 1);
                }
            }

            // Remove padding.
            canvas.Width -= 1;
            canvas.Height -= 1;

            return canvas;
        }
#endif

#if FreeType
        private GlyphRenderer.GlyphCanvas RenderGlyphFreeType(Glyph g, float scale)
        {
            if(_freeTypeFace == null)
            {
                return new GlyphRenderer.GlyphCanvas(new AtlasGlyph(g, scale, 0), 1, 1);
            }

            GlyphRenderer.GlyphCanvas glyphCanvas;
            lock (_freeTypeFace)
            {
                _setCharSizeMethod.Invoke(null, new[] { _freeTypeFace, scale, 0 });
                dynamic ftGlyph = _renderGlyphMethod.Invoke(null, new[] { _freeTypeFace, g.CharIndex });
                dynamic bitmap = ftGlyph.Bitmap;
                var bitmapWidth = (int)bitmap.Width;
                var bitmapHeight = (int)bitmap.Rows;
                var bitmapPitch = (int)bitmap.Pitch;

                //YBearing = (float) (face.Size.Metrics.Ascender.ToDouble() - face.Glyph.Metrics.HorizontalBearingY.ToDouble()),
                // Get metrics as the Emotion parsed ones don't fit the FreeType ones.
                var minX = (float)ftGlyph.Metrics.HorizontalBearingX.ToDouble();
                var advance = (float)ftGlyph.Metrics.HorizontalAdvance.ToDouble();

                dynamic faceSize = _facePropertySize.GetValue(_freeTypeFace);
                var ascender = (float)faceSize.Metrics.Ascender.ToDouble();
                float yBearing = ascender - (float)ftGlyph.Metrics.HorizontalBearingY.ToDouble();
                var glyph = new AtlasGlyph(g, scale, 0)
                {
                    Size = new Vector2(bitmapWidth, bitmapHeight),
                    Advance = advance,
                    XMin = minX,
                    YBearing = yBearing
                };

                glyphCanvas = new GlyphRenderer.GlyphCanvas(glyph, bitmapWidth, bitmapHeight);
                if (bitmapWidth == 0 || bitmapHeight == 0) return glyphCanvas;

                var bitmapData = (byte[])bitmap.BufferData;

                for (var row = 0; row < bitmapHeight; row++)
                {
                    for (var col = 0; col < bitmapWidth; col++)
                    {
                        glyphCanvas.Data[row * bitmapWidth + col] = bitmapData[row * bitmapPitch + col];
                    }
                }
            }

            return glyphCanvas;
        }
#endif

        #endregion

        #region Parse Helpers

        /// <summary>
        /// https://docs.microsoft.com/en-us/typography/opentype/spec/cvt
        /// Instructions for control over certain glyphs.
        /// </summary>
        private static short[] ParseCvt(ByteReader reader, uint length)
        {
            var cvt = new short[length / 2];

            for (uint i = 0; i < length / 2; i++)
            {
                cvt[i] = reader.ReadShortBE();
            }

            return cvt;
        }

        /// <summary>
        /// Finds all tables in the font and their data.
        /// </summary>
        private static List<FontTable> GetTables(ByteReader reader, ushort count)
        {
            var tables = new List<FontTable>();

            for (var i = 0; i < count; i++)
            {
                var t = new FontTable
                {
                    Tag = new string(reader.ReadChars(4)),
                    Checksum = (int) reader.ReadULongBE(),
                    Offset = (int) reader.ReadULongBE(),
                    Length = (int) reader.ReadULongBE()
                };
                tables.Add(t);
            }

            return tables;
        }

        /// <summary>
        /// Get the font table under the specified tag.
        /// </summary>
        /// <param name="tag">The tag of the table to get.</param>
        /// <returns>The table with the specified tag, or null if not found.</returns>
        public FontTable GetTable(string tag)
        {
            return Tables.FirstOrDefault(x => x.Tag == tag);
        }

        #endregion
    }
}