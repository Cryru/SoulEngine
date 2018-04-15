﻿// Emotion - https://github.com/Cryru/Emotion

#if SDL2

#region Using

using System;
using Emotion.Game.Objects.Camera;
using Emotion.Platform.Base;
using Emotion.Platform.SDL2.Assets;
using Emotion.Platform.SDL2.Base;
using Emotion.Platform.SDL2.Objects;
using Emotion.Primitives;
using SDL2;

#endregion

namespace Emotion.Platform.SDL2
{
    /// <inheritdoc cref="IRenderer" />
    public sealed class Renderer : NativeObject, IRenderer
    {
        #region Properties

        /// <summary>
        /// The resolution to render at.
        /// </summary>
        public Vector2 RenderSize { get; private set; }

        #endregion

        #region Declarations

        internal IntPtr GLContext;
        internal CameraBase Camera;

        #endregion

        internal Renderer(Context context)
        {
            // Create a renderer.
            Pointer = ErrorHandler.CheckError(SDL.SDL_CreateRenderer(context.Window.Pointer, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED));

            // Create an OpenGL Context.
            GLContext = ErrorHandler.CheckError(SDL.SDL_GL_CreateContext(context.Window.Pointer));

            // Set the render size.
            ErrorHandler.CheckError(SDL.SDL_RenderSetLogicalSize(Pointer, context.Settings.RenderWidth, context.Settings.RenderHeight));

            RenderSize = new Vector2(context.Settings.RenderWidth, context.Settings.RenderHeight);
        }

        internal void Destroy()
        {
            SDL.SDL_DestroyRenderer(Pointer);
        }

        #region Primary Functions

        /// <summary>
        /// Clears everything drawn on the screen.
        /// </summary>
        public void Clear(Color color)
        {
            // Set color.
            SDL.SDL_SetRenderDrawColor(Pointer, color.R, color.G, color.B, color.A);

            SDL.SDL_RenderClear(Pointer);

            // Return default black.
            SDL.SDL_SetRenderDrawColor(Pointer, 0, 0, 0, 255);
        }

        /// <summary>
        /// Displays everything drawn.
        /// </summary>
        public void Present()
        {
            SDL.SDL_RenderPresent(Pointer);
        }

        public void SetScale(float scale)
        {
            SDL.SDL_RenderSetScale(Pointer, scale, scale);
        }

        #endregion

        #region Texture Functions

        /// <summary>
        /// Draws a texture.
        /// </summary>
        /// <param name="texture">The texture to draw.</param>
        /// <param name="location">Where to draw the texture.</param>
        /// <param name="source">Which part of the texture to draw.</param>
        /// <param name="camera">Whether to draw through the current camera, or on the screen.</param>
        public void DrawTexture(Texture texture, Rectangle location, Rectangle source, bool camera = true)
        {
            SDL.SDL_Rect des = new SDL.SDL_Rect { x = (int)location.X, y = (int)location.Y, h = (int)location.Height, w = (int)location.Width };
            SDL.SDL_Rect src = new SDL.SDL_Rect { x = (int)source.X, y = (int)source.Y, h = (int)source.Height, w = (int)source.Width };

            // Add camera.
            if (Camera != null && camera)
            {
                des.x -= (int)Camera.Bounds.X;
                des.y -= (int)Camera.Bounds.Y;
            }

            ErrorHandler.CheckError(SDL.SDL_RenderCopy(Pointer, texture.Pointer, ref src, ref des), true);
        }

        /// <summary>
        /// Draws a texture.
        /// </summary>
        /// <param name="texture">The texture to draw.</param>
        /// <param name="location">Where to draw the texture.</param>
        /// <param name="camera">Whether to draw through the current camera, or on the screen.</param>
        public void DrawTexture(Texture texture, Rectangle location, bool camera = true)
        {
            SDL.SDL_Rect des = new SDL.SDL_Rect { x = (int)location.X, y = (int)location.Y, h = (int)location.Height, w = (int)location.Width };

            // Add camera.
            if (Camera != null && camera)
            {
                des.x -= (int)Camera.Bounds.X;
                des.y -= (int)Camera.Bounds.Y;
            }

            ErrorHandler.CheckError(SDL.SDL_RenderCopy(Pointer, texture.Pointer, IntPtr.Zero, ref des), true);
        }

        #endregion

        #region Rectangle Drawing

        public void DrawRectangleOutline(Rectangle rect, Color color, bool camera = true)
        {
            // Set color.
            SDL.SDL_SetRenderDrawColor(Pointer, color.R, color.G, color.B, color.A);

            // Transform rect to sdl rect.
            SDL.SDL_Rect re = new SDL.SDL_Rect { x = (int)rect.X, y = (int)rect.Y, h = (int)rect.Height, w = (int)rect.Width };

            // Add camera.
            if (Camera != null && camera)
            {
                re.x -= (int)Camera.Bounds.X;
                re.y -= (int)Camera.Bounds.Y;
            }

            SDL.SDL_RenderDrawRect(Pointer, ref re);

            // Return default black.
            SDL.SDL_SetRenderDrawColor(Pointer, 0, 0, 0, 255);
        }

        /// <summary>
        /// Draws a rectangle on the screen.
        /// </summary>
        /// <param name="rect">The rectangle to draw.</param>
        /// <param name="color">The color of the rectangle.</param>
        /// <param name="camera">Whether to draw through the current camera, or on the screen.</param>
        public void DrawRectangle(Rectangle rect, Color color, bool camera = true)
        {
            // Set color.
            SDL.SDL_SetRenderDrawColor(Pointer, color.R, color.G, color.B, color.A);

            // Transform rect to sdl rect.
            SDL.SDL_Rect re = new SDL.SDL_Rect { x = (int)rect.X, y = (int)rect.Y, h = (int)rect.Height, w = (int)rect.Width };

            // Add camera.
            if (Camera != null && camera)
            {
                re.x -= (int)Camera.Bounds.X;
                re.y -= (int)Camera.Bounds.Y;
            }

            SDL.SDL_RenderFillRect(Pointer, ref re);

            // Return original black.
            SDL.SDL_SetRenderDrawColor(Pointer, 0, 0, 0, 255);
        }

        #endregion

        #region Line Drawing

        public void DrawLine(Vector2 start, Vector2 end, Color color, bool camera = true)
        {
            // Set color.
            SDL.SDL_SetRenderDrawColor(Pointer, color.R, color.G, color.B, color.A);

            // Add camera.
            if (Camera != null && camera)
            {
                start.X -= (int)Camera.Bounds.X;
                end.X -= (int)Camera.Bounds.X;
                start.Y -= (int)Camera.Bounds.Y;
                end.Y -= (int)Camera.Bounds.Y;
            }

            // Draw the line.
            SDL.SDL_RenderDrawLine(Pointer, (int)start.X, (int)start.Y, (int)end.X, (int)end.Y);

            // Return original black.
            SDL.SDL_SetRenderDrawColor(Pointer, 0, 0, 0, 255);
        }

        #endregion

        #region Text Drawing

        private TextDrawingSession _session;

        public void TextSessionStart(Font font, int size, int width, int height)
        {
            // Get a pointer to the font at the specified size.
            _session = new TextDrawingSession
            {
                Font = font.GetSize(size),
                Surface = SDL.SDL_CreateRGBSurface(0, width, height, 32, 0xff000000, 0x00ff0000, 0x0000ff00, 0x000000ff),
                Cache = new Texture(width, height)
            };
            _session.FontAscent = SDLTtf.TTF_FontAscent(_session.Font);
        }

        public void TextSessionAddGlyph(char glyphChar, Color color, int xOffset, int yOffset)
        {
            // Convert color to platform color.
            SDL.SDL_Color platformColor = new SDL.SDL_Color
            {
                r = color.R,
                g = color.G,
                b = color.B
            };

            IntPtr glyph = SDLTtf.TTF_RenderGlyph_Solid(_session.Font, glyphChar, platformColor);

            // Get glyph data.
            ErrorHandler.CheckError(SDLTtf.TTF_GlyphMetrics(_session.Font, glyphChar, out int minX, out int maxX, out int minY, out int maxY, out int advance));

            SDL.SDL_Rect des = new SDL.SDL_Rect {x = xOffset + _session.XOffset + minX, y = yOffset + _session.YOffset + (_session.FontAscent - maxY), w = 0, h = SDLTtf.TTF_FontHeight(_session.Font)};
            _session.XOffset += advance;
            SDL.SDL_BlitSurface(glyph, IntPtr.Zero, _session.Surface, ref des);
        }

        public void TextSessionNewLine()
        {
            _session.XOffset = 0;
            _session.YOffset += SDLTtf.TTF_FontLineSkip(_session.Font);
        }

        public Texture TextSessionEnd()
        {
            // Get the resulting texture from the session.
            Texture resultTexture = _session.Cache;
            // Set it up.
            resultTexture.Pointer = SDL.SDL_CreateTextureFromSurface(Pointer, _session.Surface);

            // Free resources.
            SDL.SDL_FreeSurface(_session.Cache.Pointer);
            _session = null;

            // Return it.
            return resultTexture;
        }

        /// <summary>
        /// Draws text to the screen.
        /// </summary>
        /// <param name="font"></param>
        /// <param name="text"></param>
        /// <param name="color"></param>
        /// <param name="location"></param>
        /// <param name="size"></param>
        /// <param name="camera"></param>
        public void DrawText(Font font, string text, Color color, Vector2 location, int size, bool camera = true)
        {
            // Convert color to platform color.
            SDL.SDL_Color platformColor = new SDL.SDL_Color
            {
                r = color.R,
                g = color.G,
                b = color.B
            };

            // Add camera.
            if (Camera != null && camera)
            {
                location.X -= (int)Camera.Bounds.X;
                location.Y -= (int)Camera.Bounds.Y;
            }

            // Get a pointer to the font at the specified size.
            IntPtr fontPointer = font.GetSize(size);

            // Render the text to a surface, then copy it to a texture, and free the surface.
            IntPtr messageSurface = SDLTtf.TTF_RenderText_Solid(fontPointer, text, platformColor);
            IntPtr messageTexture = SDL.SDL_CreateTextureFromSurface(Pointer, messageSurface);
            SDL.SDL_FreeSurface(messageSurface);

            // Get the size of the text.
            Vector2 calcSize = font.MeasureString(text, size);

            // Determine the destination rectangle of the text.
            SDL.SDL_Rect des = new SDL.SDL_Rect { x = (int)location.X, y = (int)location.Y, h = (int)calcSize.Y, w = (int)calcSize.X };

            // Render the text texture.
            ErrorHandler.CheckError(SDL.SDL_RenderCopy(Pointer, messageTexture, IntPtr.Zero, ref des), true);

            // Cleanup.
            SDL.SDL_DestroyTexture(messageTexture);
        }

        /// <summary>
        /// Draws text to the screen.
        /// </summary>
        /// <param name="font"></param>
        /// <param name="text"></param>
        /// <param name="color"></param>
        /// <param name="location"></param>
        /// <param name="size"></param>
        /// <param name="camera"></param>
        public void DrawText(Font font, string[] text, Color color, Vector2 location, int size, bool camera = true)
        {
            // Get a pointer to the font at the specified size.
            IntPtr fontPointer = font.GetSize(size);

            int skip = SDLTtf.TTF_FontLineSkip(fontPointer);

            // Render each line.
            for (int i = 0; i < text.Length; i++)
            {
                location.Y += skip * i;

                DrawText(font, text[i], color, location, size, camera);
            }
        }

        #endregion

        #region RenderTarget Functions

        /// <summary>
        /// Starts rendering on the specified render target, or null to render to the window.
        /// </summary>
        /// <param name="target">The render target to render to, or null to render to the window.</param>
        public void SetRenderTarget(RenderTarget target)
        {
            SDL.SDL_SetRenderTarget(Pointer, target?.Pointer ?? IntPtr.Zero);
        }

        #endregion

        #region Camera

        public void SetCamera(CameraBase camera)
        {
            Camera = camera;
        }

        public CameraBase GetCamera()
        {
            return Camera;
        }

        #endregion
    }
}

#endif