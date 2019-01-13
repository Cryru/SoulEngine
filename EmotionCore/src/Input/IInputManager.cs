﻿// Emotion - https://github.com/Cryru/Emotion

#region Using

using System.Numerics;

#endregion

namespace Emotion.Input
{
    /// <summary>
    /// A class which manages input from a mouse and keyboard, regardless of whether they are physical or virtual.
    /// On a device with a touchscreen for instance the mouse would be the touches.
    /// </summary>
    public interface IInputManager
    {
        /// <summary>
        /// The amount the scroll wheel is scrolled.
        /// </summary>
        /// <returns>The amount the scroll wheel is scrolled.</returns>
        float GetMouseScroll();

        /// <summary>
        /// The amount the mouse has scrolled since the last check.
        /// </summary>
        /// <returns>The amount the mouse has scrolled since the last check.</returns>
        float GetMouseScrollRelative();

        /// <summary>
        /// Returns the position of the mouse cursor within the window.
        /// </summary>
        /// <returns>The position of the mouse cursor within the window.</returns>
        Vector2 GetMousePosition();

        /// <summary>
        /// Returns whether the mouse key was pressed down.
        /// </summary>
        /// <param name="key">The mouse key to check.</param>
        /// <returns>Whether the mouse key was pressed down.</returns>
        bool IsMouseKeyDown(MouseKeys key);

        /// <summary>
        /// Returns whether the mouse key was let go.
        /// </summary>
        /// <param name="key">The mouse key to check.</param>
        /// <returns>Whether the mouse key was let go.</returns>
        bool IsMouseKeyUp(MouseKeys key);

        /// <summary>
        /// Returns whether the mouse key is being held down.
        /// </summary>
        /// <param name="key">The mouse key to check.</param>
        /// <returns>Whether the mouse key is being held down.</returns>
        bool IsMouseKeyHeld(MouseKeys key);

        /// <summary>
        /// Returns whether the key is being held down, using its name.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns>Whether the key is being held down.</returns>
        bool IsKeyHeld(string key);

        /// <summary>
        /// Returns whether the key was pressed down, using its name.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns>Whether the key was pressed down.</returns>
        bool IsKeyDown(string key);

        /// <summary>
        /// Returns whether the key was let go, using its name.
        /// </summary>
        /// <param name="key">The key code to check.</param>
        /// <returns>Whether the key was let go.</returns>
        bool IsKeyUp(string key);

        /// <summary>
        /// Returns whether the key is being held down, using its key code.
        /// </summary>
        /// <param name="key">The key code to check.</param>
        /// <returns>Whether the key is being held down.</returns>
        bool IsKeyHeld(short key);

        /// <summary>
        /// Returns whether the key was pressed down, using its key code.
        /// </summary>
        /// <param name="key">The key code to check.</param>
        /// <returns>Whether the key was pressed down.</returns>
        bool IsKeyDown(short key);

        /// <summary>
        /// Returns whether the key was let go, using its key code.
        /// </summary>
        /// <param name="key">The key code to check.</param>
        /// <returns>Whether the key was let go.</returns>
        bool IsKeyUp(short key);

        /// <summary>
        /// Returns the name of a key from its key code.
        /// </summary>
        /// <param name="key">The key code whose name to return.</param>
        /// <returns>The name of the key under the provided key code.</returns>
        string GetKeyNameFromCode(short key);
    }
}