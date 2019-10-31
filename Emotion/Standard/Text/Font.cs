﻿#region Using

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Emotion.Primitives;
using Emotion.Standard.Text.FontTables;
using Emotion.Standard.Utility;
using StbTrueTypeSharp;

#if FreeType
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
#endif

#endregion

namespace Emotion.Standard.Text
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
        /// The largest character index found in the font.
        /// </summary>
        public uint LastCharIndex;

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
                        Assembly freeTypeSupportAssembly = Assembly.LoadFrom(Path.Combine("Standard", "Text", "Freetype", "Emotion.Standard.FreeType.dll"));
                        MethodInfo initFunc = freeTypeSupportAssembly.GetType("SharpFont.FT").GetMethod("Init");
                        bool loaded = NativeLibrary.TryLoad(Path.Combine("Standard", "Text", "Freetype", "freetype6"), out _freeTypeLib);
                        if (loaded)
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
        public Font(byte[] fontData)
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
                var head = new Head(r.Branch(table.Offset, true, table.Length));
                UnitsPerEm = head.UnitsPerEm;
                indexToLocFormat = head.IndexToLocFormat;
            }
            else
            {
                Console.WriteLine("Font: head table not found.");
                return;
            }

            // Horizontal header - information about horizontal layout of glyphs.
            table = GetTable("hhea");
            if (table != null)
            {
                var hhea = new Hhea(r.Branch(table.Offset, true, table.Length));

                Ascender = hhea.Ascender;
                Descender = hhea.Descender;
                NumberOfHMetrics = hhea.NumberOfHMetrics;
            }
            else
            {
                Console.WriteLine("Font: hhea table not found.");
                return;
            }

            // Name table - contains meta information about the font.
            table = GetTable("name");
            if (table != null)
            {
                // todo: ltag parsing
                Dictionary<string, Dictionary<string, string>> names = Name.ParseName(r.Branch(table.Offset, true, table.Length), null);

                FontFamily = Name.GetDefaultValue(names, "fontFamily");
                FontSubFamily = Name.GetDefaultValue(names, "fontSubfamily");
                FullName = Name.GetDefaultValue(names, "fullName");
                Version = Name.GetDefaultValue(names, "version");
                Copyright = Name.GetDefaultValue(names, "copyright");
                UniqueId = Name.GetDefaultValue(names, "uniqueID");
            }
            else
            {
                Console.WriteLine("Font: name table not found.");
                return;
            }

            // MaxP - contains information about the font's memory footprint.
            table = GetTable("maxp");
            ushort numGlyphs;
            if (table != null)
            {
                var maxp = new Maxp(r.Branch(table.Offset, true, table.Length));
                numGlyphs = maxp.NumGlyphs;
            }
            else
            {
                Console.WriteLine("Font: maxp table not found.");
                return;
            }

            // Glyf - glyph data.
            // Also reads loca for locations, cmap, and post for glyph names.
            table = GetTable("glyf");
            if (table != null)
            {
                bool shortVersion = indexToLocFormat == 0;
                FontTable locaTable = GetTable("loca");
                int[] locaOffsets = Loca.ParseLoca(r.Branch(locaTable.Offset, true, locaTable.Length), numGlyphs, shortVersion);

                Glyphs = Glyf.ParseGlyf(r.Branch(table.Offset, true, table.Length), locaOffsets);

                // Add glyph names.
                FontTable cmapTable = GetTable("cmap");
                FontTable postTable = GetTable("post");
                if (cmapTable != null && postTable != null)
                {
                    var cMap = new CMap(r.Branch(cmapTable.Offset, true, cmapTable.Length));
                    var post = new Post(r.Branch(postTable.Offset, true, postTable.Length));
                    AddGlyphNames(Glyphs, cMap.GlyphIndexMap, post.Names);
                }
            }
            else
            {
                table = GetTable("CFF ");
                if (table == null)
                {
                    Console.WriteLine("Font: Neither glyf nor cff table not found.");
                    return;
                }

                var cff = new Cff(r.Branch(table.Offset, true, table.Length));
                var cffGlyphs = new List<Glyph>();

                FontTable cmapTable = GetTable("cmap");
                if (cmapTable != null)
                {
                    // Using Cmap encoding.
                    var cMap = new CMap(r.Branch(cmapTable.Offset, true, cmapTable.Length));
                    foreach (KeyValuePair<uint, uint> glyph in cMap.GlyphIndexMap)
                    {
                        Glyph g = cff.CffGlyphLoad((int) glyph.Value);
                        g.Name = cff.Charset[(int) glyph.Value];
                        g.MapIndex = glyph.Value;
                        g.CharIndex = glyph.Key;
                        cffGlyphs.Add(g);
                    }

                    Glyphs = cffGlyphs.ToArray();
                }
                else
                {
                    // Using CFF encoding.
                    // todo
                    Debug.Assert(false);
                    for (var i = 0; i < cff.NumberOfGlyphs; i++)
                    {
                        byte[] s = cff.CharStringIndex[i];
                    }
                }
            }

            // Add metrics.
            table = GetTable("hmtx");
            if (table != null) Hmtx.ParseHmtx(r.Branch(table.Offset, true, table.Length), NumberOfHMetrics, Glyphs);

            // os/2 parsed, but unused
            // cvt parsed, but unused
            // todo: kern
            // todo: gsub
            // todo: gpos
            // todo: fvar
            // todo: meta

            // Calculate last char index.
            LastCharIndex = Glyphs.Max(x => x.CharIndex);

            Valid = true;
        }

        #region Atlas Rasterization

        public enum GlyphRasterizer
        {
            /// <summary>
            /// The default renderer.
            /// Based on the Stb renderer, but has some differences.
            /// If everything is well it should produce the same results as the Stb renderer.
            /// Fastest
            /// </summary>
            Emotion,

            /// <summary>
            /// A more mature rasterizer to be used if the Emotion rasterizer produces bugs/unwanted results.
            /// Is sort of a fallback.
            /// Fast
            /// </summary>
            StbTrueType,
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

        public FontAtlas GetAtlas(float fontSize, int firstChar = 0, int numChars = -1, GlyphRasterizer rasterizer = GlyphRasterizer.Emotion)
        {
            if (Glyphs == null || Glyphs.Length == 0) return null;
            if (numChars == -1) numChars = (int) (LastCharIndex - firstChar);

            // The scale to render at.
            float scale = fontSize / UnitsPerEm;
            var glyphRenders = new List<Task<GlyphRenderer.GlyphCanvas>>();

            for (var i = 0; i < numChars; i++)
            {
                Glyph g = Glyphs.FirstOrDefault(x => x.CharIndex == firstChar + i);

                // Check if glyph was found.
                if (g == null)
                    continue;

                // Start rendering this glyph.
                switch (rasterizer)
                {
                    case GlyphRasterizer.Emotion:
                        glyphRenders.Add(Task.Run(() => RenderGlyph(this, g, scale)));
                        break;
                    case GlyphRasterizer.StbTrueType:
                        glyphRenders.Add(Task.Run(() => RenderGlyphStb(this, g, scale)));
                        break;
#if FreeType
                    case GlyphRasterizer.FreeType:
                        glyphRenders.Add(Task.Run(() => RenderGlyphFreeType(g, fontSize)));
                        break;
#endif
                }
            }

            // Get rendered canvases.
            GlyphRenderer.GlyphCanvas[] canvases = Task.WhenAll(glyphRenders).Result;
            var glyphSpacing = 2;

            // The location of the brush within the bitmap.
            var pen = new Vector2(glyphSpacing, glyphSpacing);

            // Determine size of the atlas texture based on the largest atlases.
            int glyphCountSqrt = canvases.Length > 0 ? (int) Math.Ceiling(Math.Sqrt(canvases.Length)) : 0;
            int atlasWidth = canvases.Length > 0 ? glyphCountSqrt * (canvases.Max(x => x.Width) + glyphSpacing * 2) : 0;
            int atlasHeight = canvases.Length > 0 ? glyphCountSqrt * (canvases.Max(x => x.Height) + glyphSpacing * 2) : 0;
            int atlasSize = Math.Max(atlasWidth, atlasHeight); // Square
            var atlas = new byte[atlasSize * atlasSize];

            var atlasObj = new FontAtlas(new Vector2(atlasSize, atlasSize), atlas, rasterizer.ToString(), scale, this);
            var atlasGlyphs = new AtlasGlyph[canvases.Length];

            float atlasRowSpacing = MathF.Ceiling(Height * scale);

            // ReSharper disable once ForCanBeConvertedToForeach
            for (var i = 0; i < canvases.Length; i++)
            {
                atlasGlyphs[i] = canvases[i].Glyph;
                if (canvases[i].Data.Length == 0) continue;

                // Check if going over to a new line.
                if (pen.X + canvases[i].Width >= atlasSize - glyphSpacing)
                {
                    pen.X = glyphSpacing;
                    pen.Y += atlasRowSpacing + glyphSpacing;
                }

                // Copy pixels.
                for (var row = 0; row < canvases[i].Height; row++)
                {
                    for (var col = 0; col < canvases[i].Width; col++)
                    {
                        var x = (int) (pen.X + col);
                        var y = (int) (pen.Y + row);
                        atlas[y * atlasSize + x] = canvases[i].Data[row * canvases[i].Width + col];
                    }
                }

                atlasGlyphs[i].SetAtlasLocation(pen, new Vector2(canvases[i].Width, canvases[i].Height));

                // Increment pen. Leave space between glyphs.
                pen.X += canvases[i].Width + glyphSpacing;
            }

            foreach (AtlasGlyph glyph in atlasGlyphs)
            {
                atlasObj.Glyphs[glyph.CharIndex] = glyph;
            }

            return atlasObj;
        }

        private static GlyphRenderer.GlyphCanvas RenderGlyph(Font f, Glyph g, float scale)
        {
            var atlasGlyph = new AtlasGlyph(g, scale, f.Ascender);

            // Get glyph bounding box.
            Rectangle bbox = g.GetBBox(scale);
            var glyphWidth = (int) (bbox.Width - bbox.X);
            var glyphHeight = (int) (bbox.Height - bbox.Y);

            var canvas = new GlyphRenderer.GlyphCanvas(atlasGlyph, glyphWidth, glyphHeight);

            // Check if glyph can be rendered, and render it.
            if (g.Vertices != null && g.Vertices.Length != 0)
                GlyphRenderer.RenderGlyph(canvas, g, scale);

            return canvas;
        }

        private static unsafe GlyphRenderer.GlyphCanvas RenderGlyphStb(Font f, Glyph g, float scale)
        {
            var atlasGlyph = new AtlasGlyph(g, scale, f.Ascender);

            // Get glyph bounding box.
            Rectangle bbox = g.GetBBox(scale);
            var glyphWidth = (int) (bbox.Width - bbox.X);
            var glyphHeight = (int) (bbox.Height - bbox.Y);

            var canvas = new GlyphRenderer.GlyphCanvas(atlasGlyph, glyphWidth, glyphHeight);

            // Check if glyph can be rendered.
            if (g.Vertices == null || g.Vertices.Length == 0)
                return canvas;

            // Render the current glyph.
            if (glyphWidth == 0 || glyphHeight == 0) return canvas;
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

                fixed (StbTrueType.stbtt_vertex* vert = &verts[0])
                {
                    StbTrueType.stbtt_Rasterize(&bitmap, 0.35f, vert, vertices.Length, scale, scale, 0, 0, (int) bbox.X, (int) bbox.Y, 1);
                }
            }

            return canvas;
        }

#if FreeType
        private GlyphRenderer.GlyphCanvas RenderGlyphFreeType(Glyph g, float scale)
        {
            if(_freeTypeFace == null)
            {
                return null;
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
                var glyph = new AtlasGlyph((char)g.CharIndex, advance, minX, yBearing);

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
        /// Add names and unicode indices to all the glyphs.
        /// </summary>
        /// <param name="glyphs">The glyphs themselves.</param>
        /// <param name="glyphIndexMap">Indices to glyph unicode symbols.</param>
        /// <param name="glyphNames">The glyph names read from the postscript table.</param>
        private static void AddGlyphNames(Glyph[] glyphs, Dictionary<uint, uint> glyphIndexMap, IReadOnlyList<string> glyphNames)
        {
            Dictionary<uint, uint> indexMap = glyphIndexMap;

            foreach ((uint key, uint value) in indexMap)
            {
                Glyph glyph = glyphs[value];
                glyph.MapIndex = value;

                if (glyph.CharIndex == default)
                    glyph.CharIndex = key;
            }

            if (glyphNames == null) return;

            for (var i = 0; i < glyphs.Length; i++)
            {
                Glyph glyph = glyphs[i];
                glyph.Name = glyphNames[i];
            }
        }

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
        private FontTable GetTable(string tag)
        {
            return Tables.FirstOrDefault(x => x.Tag == tag);
        }

        #endregion
    }
}