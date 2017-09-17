﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SoulEngine.Enums;
using System.Collections.Generic;

namespace SoulEngine
{
    //////////////////////////////////////////////////////////////////////////////
    // SoulEngine - A game engine based on the MonoGame Framework.              //
    // Public Repository: https://github.com/Cryru/SoulEngine                   //
    //////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// The engine's user settings.
    /// </summary>
    public partial class Settings
    {
        #region "Drawing Settings"
        /// <summary>
        /// The FPS target, if below 0 the FPS isn't capped.
        /// </summary>
        private static float _FPS = 60;
        /// <summary>
        /// Whether to synchronize the FPS to the screen's refresh rate. 
        /// Can be overwriten by GPU options.
        /// </summary>
        public static bool vSync = false;
        /// <summary>
        /// The width the game will be rendered at.
        /// </summary>
        public static int Width = 960;
        /// <summary>
        /// The height the game will be rendered at.
        /// </summary>
        public static int Height = 540;
        /// <summary>
        /// The color the screen will be cleared with.
        /// </summary>
        public static Color FillColor = Color.CornflowerBlue;
        /// <summary>
        /// Whether to apply anti-aliasing.
        /// </summary>
        public static bool AntiAlias = false;
        #endregion
        #region "Window Settings"
        /// <summary>
        /// The width of the window.
        /// </summary>
        private static int _WWidth = 960;
        /// <summary>
        /// The height of the window.
        /// </summary>
        private static int _WHeight = 540;
        /// <summary>
        /// The name of the window.
        /// </summary>
        public const string WName = "SoulEngine 2017";
        /// <summary>
        /// The way the engine should be displayed.
        /// </summary>
        private static DisplayMode _DisplayMode = DisplayMode.Windowed;
        /// <summary>
        /// Whether the mouse should be rendered.
        /// </summary>
        private static bool _RenderMouse = true;
        /// <summary>
        /// Whether the window can be resized, currently disables display modes other than windowed.
        /// </summary>
        public static bool ResizableWindow = false;
        #endregion
        #region "Security Settings"
        /// <summary>
        /// The key that will be used to encrypt and decrypt files.
        /// </summary>
        public static string SecurityKey = "standardkey";
        /// <summary>
        /// If true, the engine will check the hash of every asset. Requires a meta.soul file.
        /// </summary>
        public static bool EnforceAssetIntegrity = false;
        /// <summary>
        /// The MD5 hash of the meta.soul file.
        /// </summary>
        public static string MetaMD5 = "";
        #endregion
        #region "Module Settings"
        /// <summary>
        /// Any errors with severity above this will cause the engine to exit.
        /// </summary>
        public static byte ErrorSupressionLevel = 200;
        /// <summary>
        /// Whether to save logs. Cannot be changed at runtime.
        /// </summary>
        public static bool Log = true;
        /// <summary>
        /// Whether Jint scripting is enabled. Raises memory usage.
        /// </summary>
        public static bool Scripting = true;
        #endregion
        #region "Other Settings"
        /// <summary>
        /// Whether an external settings file should be loaded.
        /// </summary>
        public static bool ExternalSettings = false;
        /// <summary>
        /// Whether to stop drawing and updating when the game is not focused.
        /// </summary>
        public static bool PauseOnFocusLoss = true;
        #endregion
        #region "Sound Settings"
        /// <summary>
        /// Whether sound is on or off.
        /// </summary>
        public static bool Sound = true;
        /// <summary>
        /// The sound volume.
        /// </summary>
        public static int Volume = 100;
        #endregion
        #region "Debug Settings"
        /// <summary>
        /// Enables debug mode.
        /// </summary>
        public static bool Debug = true;
        /// <summary>
        /// Draws rectangles around all objects.
        /// </summary>
        public static bool DrawBounds = false;
        /// <summary>
        /// Draws rectangles around all draw components.
        /// </summary>
        public static bool DrawTextureBounds = false;
        /// <summary>
        /// The port the debug socket will be hosted on.
        /// </summary>
        public static int DebugSocketPort = 2345;
        #endregion
        #region "Android Settings"
#if ANDROID
        /// <summary>
        /// The orientation of the screen.
        /// </summary>
        public static DisplayOrientation Orientation = DisplayOrientation.LandscapeLeft;
#endif
        #endregion
        #region "Network Settings"
        /// <summary>
        /// Whether networking is allowed, requires a restart.
        /// </summary>
        public static bool Networking = true;
        /// <summary>
        /// The IP to connect by default.
        /// </summary>
        public static string IP = "";
        /// <summary>
        /// The port to connect to by default.
        /// </summary>
        public static string Port = "";
        /// <summary>
        /// The default timeout of the connection.
        /// </summary>
        public static int Timeout = 10;
        #endregion
    }
}
