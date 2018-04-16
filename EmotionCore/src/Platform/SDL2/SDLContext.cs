﻿// Emotion - https://github.com/Cryru/Emotion

#if SDL2

#region Using

using System;
using System.Diagnostics;
using Emotion.Engine;
using Emotion.Engine.Enums;
using Emotion.Engine.Objects;
using Emotion.External;
using Emotion.Platform.Base;
using Emotion.Platform.SDL2.Assets;
using Emotion.Primitives;
using SDL2;
#if DEBUG
using Debugger = Emotion.Engine.Debugging.Debugger;
using Emotion.Engine.Debugging;

#endif

#endregion

namespace Emotion.Platform.SDL2
{
    public sealed class SDLContext : Context
    {
        #region Declarations

        #region Platform Modules

        /// <summary>
        /// SDL2 Renderer.
        /// </summary>
        public new SDLRenderer Renderer { get; private set; }

        /// <summary>
        /// SDL2 Input.
        /// </summary>
        public new SDLInput Input { get; private set; }

        /// <summary>
        /// The context's window.
        /// </summary>
        public SDLWindow Window { get; private set; }

        /// <summary>
        /// Handles loading assets and storing assets.
        /// </summary>
        public Loader AssetLoader { get; private set; }

        #endregion

        #region Variables

        /// <summary>
        /// The performance frequency of the current frame.
        /// </summary>
        private ulong _now;

        /// <summary>
        /// The performance frequency of the last frame.
        /// </summary>
        private ulong _last;

        #endregion

        #endregion

        /// <summary>
        /// Initiates external libraries and pre-initialization. Is run once for all instances.
        /// </summary>
        static SDLContext()
        {
            // Set the DLL path on Windows.
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                Windows.SetDllDirectory(Environment.CurrentDirectory + "\\Libraries\\External\\" + (Environment.Is64BitProcess ? "x64" : "x86"));

                // Bypass an issue with SDL and debugging on Windows.
                if (System.Diagnostics.Debugger.IsAttached)
                    SDL.SDL_SetHint("SDL_WINDOWS_DISABLE_THREAD_NAMING", "1");
            }
        }

        /// <summary>
        /// Create a new Emotion context.
        /// </summary>
        public SDLContext(Action<Settings> config = null)
        {
#if DEBUG
            Debugger = new Debugger(this);
            Debugger.Log(MessageType.Info, MessageSource.Engine, "Starting Emotion version " + Meta.Version);
            Debugger.Log(MessageType.Info, MessageSource.PlatformCore, "SDL Context created!");
#endif

            // Apply settings.
            Settings = new Settings();
            config?.Invoke(Settings);

            // Initialize SDL.
            ErrorHandler.CheckError(SDL.SDL_Init(SDL.SDL_INIT_VIDEO));
            ErrorHandler.CheckError(SDLTtf.TTF_Init());

            // Enable double buffering.
            ErrorHandler.CheckError(SDL.SDL_GL_SetAttribute(SDL.SDL_GLattr.SDL_GL_DOUBLEBUFFER, 1));
            // Ensure pixel perfect drawing.
            ErrorHandler.CheckError(SDL.SDL_SetHint(SDL.SDL_HINT_RENDER_SCALE_QUALITY, "0") == SDL.SDL_bool.SDL_TRUE ? 1 : 0);

            // Create a window.
            Window = new SDLWindow(this);

            // Create a renderer.
            Renderer = new SDLRenderer(this);
            base.Renderer = Renderer;

            // Load modules.
            AssetLoader = new Loader(this);
            Input = new SDLInput(this);
            base.Input = Input;
            ScriptingEngine = new ScriptingEngine(this);
            LayerManager = new LayerManager(this);
        }

        public override void ApplySettings()
        {
            // Apply window mode.
            switch (Settings.WindowMode)
            {
                case WindowMode.Borderless:
                    SDL.SDL_SetWindowFullscreen(Window.Pointer, (uint)SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN_DESKTOP);
                    break;
                case WindowMode.Fullscreen:
                    SDL.SDL_SetWindowFullscreen(Window.Pointer, (uint)SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN);
                    break;
                default:
                    SDL.SDL_SetWindowFullscreen(Window.Pointer, 0);
                    break;
            }


        }

        public override void Start()
        {
            Loop();
        }

        public override void Quit()
        {
            // Stop running.
            Running = false;
        }

        #region Loop Parts

        private void Loop()
        {
            Running = true;
            Stopwatch frameCapTimer = new Stopwatch();

            while (Running)
            {
                frameCapTimer.Restart();

                // Calculate delta time.
                _last = _now;
                _now = SDL.SDL_GetPerformanceCounter();
                // Minimum is 1ms, maximum is 1s.
                FrameTime = GameMath.Clamp((_now - _last) * 1000 / SDL.SDL_GetPerformanceFrequency(), 1, 1000);

                // Run layer updates.
                LayerManager.Update();

                // Clear the screen.
                Renderer.Clear(Settings.ClearColor);

                // Run layer draws.
                LayerManager.Draw();
#if DEBUG
                // Debug drawing.
                Debugger.DebugLoop();
#endif
                // Update input module. This is done before events are handled so it can clear states from the previous frame.
                Input.UpdateInputs();

                // Update SDL events.
                HandleEvents();

                // Swap buffers.
                Renderer.Present();

                // Check if capping fps, and not enough time has passed.
                if (Settings.CapFPS > 0)
                {
                    // Get difference between expected and actual.
                    float difference = 1000 / Settings.CapFPS - frameCapTimer.ElapsedMilliseconds;

                    // Wait for the amount of different to smooth out fps.
                    if (difference > 0) SDL.SDL_Delay((uint)difference);
                }
                else
                {
                    SDL.SDL_Delay(1);
                }
            }

            // Context has stopped running - cleanup.
            Window.Destroy();
            Renderer.Destroy();

            // Dereference objects.
            Window = null;
            Renderer = null;
            Settings = null;

            // Cleanup external.
            SDL.SDL_Quit();

            // Close application.
            Environment.Exit(1);
        }

        private void HandleEvents()
        {
            // Loop while there are events to process.
            while (SDL.SDL_PollEvent(out SDL.SDL_Event currentEvent) == 1)
            {
                // Check the type.
                switch (currentEvent.type)
                {
                    case SDL.SDL_EventType.SDL_QUIT:
                        Quit();
                        break;
                    case SDL.SDL_EventType.SDL_MOUSEBUTTONUP:
                        Input.MouseStatePressed[currentEvent.button.button - 1] = false;
                        break;
                    case SDL.SDL_EventType.SDL_MOUSEBUTTONDOWN:
                        Input.MouseStatePressed[currentEvent.button.button - 1] = true;
                        break;
                    case SDL.SDL_EventType.SDL_MOUSEMOTION:
                        Input.MousePosition = new Vector2(currentEvent.motion.x, currentEvent.motion.y);
                        break;
                }
            }
        }

        #endregion
    }
}

#endif