﻿// Emotion - https://github.com/Cryru/Emotion

#if SDL2

#region Using

using System;
using System.Drawing;
using SDL2;

#endregion

namespace Emotion.Engine
{
    public class Window
    {
        #region Properties

        /// <summary>
        /// The window's title.
        /// </summary>
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                SDL.SDL_SetWindowTitle(Pointer, value);
            }
        }

        private string _title;

        /// <summary>
        /// The size of the window.
        /// </summary>
        public Point Size
        {
            get
            {
                SDL.SDL_GetWindowSize(Pointer, out int w, out int h);

                return new Point(w, h);
            }
            set => SDL.SDL_SetWindowSize(Pointer, value.X, value.Y);
        }

        #endregion

        internal Context Context;
        internal IntPtr Pointer;
        internal IntPtr Surface;

        /// <summary>
        /// Create a new window.
        /// </summary>
        internal Window(Context context)
        {
            Context = context;

            // Copy to properties.
            _title = Context.InitialSettings.WindowTitle;

            // Create the window within SDL.
            Pointer = SDLErrorHandler.CheckError(SDL.SDL_CreateWindow(
                Context.InitialSettings.WindowTitle,
                SDL.SDL_WINDOWPOS_CENTERED,
                SDL.SDL_WINDOWPOS_CENTERED,
                Context.InitialSettings.WindowWidth,
                Context.InitialSettings.WindowHeight,
                SDL.SDL_WindowFlags.SDL_WINDOW_OPENGL | SDL.SDL_WindowFlags.SDL_WINDOW_INPUT_FOCUS | SDL.SDL_WindowFlags.SDL_WINDOW_MOUSE_FOCUS
            ));

            // Get the window's surface.
            Surface = SDLErrorHandler.CheckError(SDL.SDL_GetWindowSurface(Pointer));
        }
    }
}

#endif