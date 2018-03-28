﻿// Emotion - https://github.com/Cryru/Emotion

#if SDL2

#region Using

using System;
using System.Runtime.InteropServices;
using Emotion.Objects.Bases;
using Emotion.Primitives;
using SDL2;

#endregion

namespace Emotion.Engine
{
    public class Input
    {
        private byte[] _keyStateArray = new byte[512];

        internal void UpdateInputs()
        {
            // Get the keyboard state for the current frame.
            IntPtr keyState = SDL.SDL_GetKeyboardState(out int keyLength);
            Marshal.Copy(keyState, _keyStateArray, 0, keyLength);
        }

        #region Keyboard

        /// <summary>
        /// Returns whether the key is pressed down or not.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns>Whether the key is pressed or not.</returns>
        public bool IsKeyDown(string key)
        {
            // Get the scan code of the key.
            int scanCode = (int) SDL.SDL_GetScancodeFromName(key);
            return _keyStateArray[scanCode] != 0;
        }

        #endregion

        #region Mouse

        /// <summary>
        /// Returns the mouse position.
        /// </summary>
        /// <returns>The mouse position.</returns>
        public Vector2 GetMousePosition(Camera camera = null)
        {
            SDL.SDL_GetMouseState(out int x, out int y);

            return camera == null ? new Vector2(x, y) : new Vector2(x + camera.Bounds.X, y + camera.Bounds.Y);
        }

        public bool IsMouseKeyDown(uint mouseButton = 1)
        {
            // Left - 1
            // Right - 4
            // Middle - 3
            return SDL.SDL_GetMouseState(IntPtr.Zero, IntPtr.Zero) == mouseButton;
        }

        #endregion
    }
}

#endif