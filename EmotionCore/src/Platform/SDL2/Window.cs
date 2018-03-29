﻿// Emotion - https://github.com/Cryru/Emotion

#if SDL2

#region Using

using System;
using Emotion.Platform.SDL2.Base;
using Emotion.Primitives;
using SDL2;

#endregion

namespace Emotion.Platform.SDL2
{
    public sealed class Window : NativeObject
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
        public Vector2 Size
        {
            get
            {
                SDL.SDL_GetWindowSize(Pointer, out int w, out int h);

                return new Vector2(w, h);
            }
            set => SDL.SDL_SetWindowSize(Pointer, (int) value.X, (int) value.Y);
        }

        #endregion

        #region Declarations

        internal IntPtr Surface;

        #endregion

        /// <summary>
        /// Create a new window.
        /// </summary>
        internal Window(Context context)
        {
            Context context1 = context;

            // Copy to properties.
            _title = context1.InitialSettings.WindowTitle;

            // Create the window within SDL.
            Pointer = ErrorHandler.CheckError(SDL.SDL_CreateWindow(
                context1.InitialSettings.WindowTitle,
                SDL.SDL_WINDOWPOS_CENTERED,
                SDL.SDL_WINDOWPOS_CENTERED,
                context1.InitialSettings.WindowWidth,
                context1.InitialSettings.WindowHeight,
                SDL.SDL_WindowFlags.SDL_WINDOW_OPENGL | SDL.SDL_WindowFlags.SDL_WINDOW_INPUT_FOCUS | SDL.SDL_WindowFlags.SDL_WINDOW_MOUSE_FOCUS
            ));

            // Get the window's surface.
            Surface = ErrorHandler.CheckError(SDL.SDL_GetWindowSurface(Pointer));
        }
    }
}

#endif