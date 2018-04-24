﻿// Emotion - https://github.com/Cryru/Emotion

#if SDL2

#region Using

using System;
using Emotion.Platform.Base.Assets;
using Emotion.Platform.Base.Objects;
using Emotion.Platform.SDL2.Assets;
using Emotion.Primitives;
using SDL2;

#endregion

namespace Emotion.Platform.SDL2.Objects
{
    /// <summary>
    /// A text drawing session. Used as an object holder by the Renderer when rendering text.
    /// </summary>
    /// <inheritdoc />
    public class SDLTextDrawingSession : TextDrawingSession
    {
        #region Properties

        internal SDLFont Font;
        internal SDLTexture Cache;
        internal SDLRenderer Renderer;
        internal int FontAscent;
        internal int FontSize;

        #endregion

        #region State

        internal IntPtr Surface;
        internal int YOffset;
        internal int XOffset;
        internal char PrevChar;

        #endregion

        public override void AddGlyph(char glyphChar, Color color, int xOffset = 0, int yOffset = 0)
        {
            IntPtr fontPointer = Font.GetSize(FontSize);

            // Convert color to platform color.
            SDL.SDL_Color platformColor = new SDL.SDL_Color
            {
                r = color.R,
                g = color.G,
                b = color.B
            };

            IntPtr glyph = SDLTtf.TTF_RenderGlyph_Solid(fontPointer, glyphChar, platformColor);

            // Check for SDL error. Randomly some characters will fail to render with an "Zero-width" error.
            if (glyph == IntPtr.Zero)
            {
                Console.WriteLine("Encountered weird error - zero width when reading font glyph " + glyphChar + ", retrying...");

                // Try to refresh font.
                fontPointer = Font.GetSize(FontSize, true);

                // Render again.
                glyph = SDLTtf.TTF_RenderGlyph_Solid(fontPointer, glyphChar, platformColor);
                if (glyph == IntPtr.Zero)
                {
                    Console.WriteLine("Retry failed, replacing with space.");
                    glyph = SDLTtf.TTF_RenderGlyph_Solid(fontPointer, ' ', platformColor);

                    glyphChar = ' ';
                }
            }

            int kerning = 0;
            if (PrevChar != default(char)) kerning = SDLTtf.TTF_GetFontKerningSizeGlyphs(fontPointer, PrevChar, glyphChar);
            PrevChar = glyphChar;

            // Get glyph data.
            ErrorHandler.CheckError(SDLTtf.TTF_GlyphMetrics(fontPointer, glyphChar, out int minX, out int _, out int _, out int _, out int advance));
            XOffset += minX + kerning;
            SDL.SDL_Rect des = new SDL.SDL_Rect {x = xOffset + XOffset, y = yOffset + YOffset, w = 0, h = 0};
            XOffset += advance;
            ErrorHandler.CheckError(SDL.SDL_BlitSurface(glyph, IntPtr.Zero, Surface, ref des));
            SDL.SDL_FreeSurface(glyph);
        }

        public override void NewLine()
        {
            IntPtr fontPointer = Font.GetSize(FontSize);

            XOffset = 0;
            YOffset += SDLTtf.TTF_FontLineSkip(fontPointer);
        }

        public override Texture GetTexture()
        {
            // Check if an old texture is loaded into the session, and destroy it.
            if (Cache.Pointer != IntPtr.Zero) Cache.Destroy();

            // Set up a new texture from the surface.
            Cache.Pointer = ErrorHandler.CheckError(SDL.SDL_CreateTextureFromSurface(Renderer.Pointer, Surface));

            // Return it.
            return Cache;
        }

        public override void Reset()
        {
            if (Cache == null) Cache = new SDLTexture((int) Size.X, (int) Size.Y);
            if (Cache.Pointer != IntPtr.Zero) Cache.Destroy();
            if (Surface != IntPtr.Zero) SDL.SDL_FreeSurface(Surface);
            Surface = SDL.SDL_CreateRGBSurface(0, (int) Size.X, (int) Size.Y, 32, 0xff000000, 0x00ff0000, 0x0000ff00, 0x000000ff);
            XOffset = 0;
            YOffset = 0;
        }

        /// <inheritdoc />
        public override void Destroy()
        {
            SDL.SDL_FreeSurface(Surface);
            Surface = IntPtr.Zero;
            Cache = null;
        }
    }
}

#endif