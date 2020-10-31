﻿#region Using

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using Emotion.Common.Threading;
using Emotion.Game.Time.Routines;
using Emotion.Graphics;
using Emotion.IO;
using Emotion.Platform;
using Emotion.Platform.Implementation.Null;
using Emotion.Platform.Implementation.Win32;
using Emotion.Scenography;
using Emotion.Standard.Logging;
using Emotion.Utility;

#if GLFW
using Emotion.Platform.Implementation.GlfwImplementation;

#endif

#endregion

namespace Emotion.Common
{
    public static class Engine
    {
        /// <summary>
        /// The default engine configuration.
        /// </summary>
        public static Configurator Configuration { get; private set; } = new Configurator();

        #region Modules

        public static LoggingProvider Log { get; private set; } = new PreSetupLogger();

        /// <summary>
        /// Handles loading assets and storing assets.
        /// </summary>
        public static AssetLoader AssetLoader { get; private set; }

        /// <summary>
        /// The platform reference.
        /// </summary>
        public static PlatformBase Host { get; private set; }

        /// <summary>
        /// Handles rendering.
        /// </summary>
        public static RenderComposer Renderer { get; private set; }

        /// <summary>
        /// The legacy input manager.
        /// </summary>
        public static IInputManager InputManager { get; private set; }

        /// <summary>
        /// Module which manages loading and unloading of scenes.
        /// </summary>
        public static SceneManager SceneManager { get; private set; }

        /// <summary>
        /// The audio context of the platform. A redirect of Host.Audio.
        /// </summary>
        public static AudioContext Audio { get; private set; }

        /// <summary>
        /// The global coroutine manager.
        /// </summary>
        public static CoroutineManager CoroutineManager { get; private set; } = new CoroutineManager();

        #endregion

        /// <summary>
        /// The status of the engine.
        /// </summary>
        public static EngineStatus Status { get; private set; } = EngineStatus.Initial;

        /// <summary>
        /// The time you should assume passed between ticks (in milliseconds), for smoothest operation.
        /// Depends on the Configuration's TPS, and should always be constant.
        /// </summary>
        public static float DeltaTime { get; set; }

        /// <summary>
        /// The total time passed since the start of the engine, in milliseconds.
        /// </summary>
        public static float TotalTime { get; set; }

#if DEBUG

        public static event EventHandler DebugOnUpdateStart;
        public static event EventHandler DebugOnUpdateEnd;
        public static event EventHandler DebugOnFrameStart;
        public static event EventHandler DebugOnFrameEnd;

#endif

        static Engine()
        {
            Helpers.AssociatedAssemblies = new List<Assembly>
            {
                Assembly.GetCallingAssembly(), // This is the assembly which called this function. Can be the game or the engine.
                Assembly.GetExecutingAssembly(), // Is the engine.
                Assembly.GetEntryAssembly() // Is game or debugger.
            }.Distinct().Where(x => x != null).ToArray();
        }

        /// <summary>
        /// Perform light setup - no platform is created. Only the logger and critical systems are initialized.
        /// </summary>
        /// <param name="configurator">Optional engine configuration.</param>
        public static void LightSetup(Configurator configurator = null)
        {
            if (Status >= EngineStatus.LightSetup) return;
            PerfProfiler.ProfilerEventStart("LightSetup", "Loading");

            // Correct the startup directory to the directory of the executable.
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

            // If no config provided - use default.
            Configuration = configurator ?? new Configurator();

            Log = Configuration.Logger ?? new DefaultLogger(Configuration.DebugMode);
            Log.Info($"Emotion V{MetaData.Version} [{MetaData.BuildConfig}] {MetaData.GitHash}", MessageSource.Engine);
            Log.Info("--------------", MessageSource.Engine);
            Log.Info($" CPU Cores: {Environment.ProcessorCount}, SIMD: {Vector.IsHardwareAccelerated}, x64 Process: {Environment.Is64BitProcess}", MessageSource.Engine);
            Log.Info($" Runtime: {Environment.Version} {RuntimeInformation.OSDescription} {(Environment.Is64BitOperatingSystem ? "x64" : "x86")}", MessageSource.Engine);
            Log.Info($" Debug Mode: {Configuration.DebugMode}, Debugger Attached: {Debugger.IsAttached}", MessageSource.Engine);
            Log.Info($" Execution Directory: {Environment.CurrentDirectory}", MessageSource.Engine);
            Log.Info($" Entry Assembly: {Assembly.GetEntryAssembly()}", MessageSource.Engine);

            // Attach to unhandled exceptions if the debugger is not attached.
            if (!Debugger.IsAttached)
                AppDomain.CurrentDomain.UnhandledException += (e, a) => { CriticalError((Exception) a.ExceptionObject); };

            // Ensure quit is called on exit.
            AppDomain.CurrentDomain.ProcessExit += (e, a) => { Quit(); };

            // Mount default assets. The platform should add it's own specific sources and stores.
            AssetLoader = LoadDefaultAssetLoader();
            NativeLibrary.SetDllImportResolver(typeof(Engine).Assembly, (libName, assembly, _) => Host?.LoadLibrary(libName) ?? NativeLibrary.Load(libName));
            Status = EngineStatus.LightSetup;

            PerfProfiler.ProfilerEventEnd("LightSetup", "Loading");
        }

        /// <summary>
        /// Perform engine setup.
        /// </summary>
        /// <param name="configurator">An optional engine configuration - will be passed to the light setup.</param>
        public static void Setup(Configurator configurator = null)
        {
            // Call light setup if needed.
            if (Status < EngineStatus.LightSetup) LightSetup(configurator);
            if (Status >= EngineStatus.Setup) return;
            PerfProfiler.ProfilerEventStart("Setup", "Loading");

            // Create the platform, window, audio, and graphics context.
            PerfProfiler.ProfilerEventStart("Platform Creation", "Loading");
            Host = GetInstanceOfDetectedPlatform(Configuration);
            if (Host == null)
            {
                CriticalError(new Exception("Platform couldn't initialize."));
                return;
            }

            Host.Setup(Configuration);
            InputManager = Host;
            Audio = Host.Audio;
            if (Status == EngineStatus.Stopped) return; // Errors in host initialization can cause this.
            PerfProfiler.ProfilerEventEnd("Platform Creation", "Loading");

            // Now that the context is created, the renderer can be created.
            GLThread.BindThread();
            Renderer = new RenderComposer();
            Renderer.Setup();

            // Now "game-mode" modules can be created.
            SceneManager = new SceneManager();

            // Setup plugins.
            PerfProfiler.ProfilerEventStart("Plugin Setup", "Loading");
            foreach (IPlugin p in Configuration.Plugins)
            {
                p.Initialize();
            }

            PerfProfiler.ProfilerEventEnd("Plugin Setup", "Loading");

            if (Status == EngineStatus.Stopped) return;
            Status = EngineStatus.Setup;

            PerfProfiler.ProfilerEventEnd("Setup", "Loading");
        }

        public static void Run()
        {
            // Some sanity checks before starting.

            // This will prevent running when stopped (as in a startup error) or not setup.
            if (Status != EngineStatus.Setup) return;

            // Just to make sure.
            if (Host == null) return;

            Status = EngineStatus.Running;
            if (Configuration.LoopFactory == null)
            {
                Log.Info("Using default loop.", MessageSource.Engine);
                Configuration.LoopFactory = DefaultMainLoop;
            }

            Log.Info("Starting loop...", MessageSource.Engine);
            Configuration.LoopFactory(RunTick, RunFrame);
        }

        /// <summary>
        /// The default main loop.
        /// For more information on how the timing of the loop works ->
        /// https://medium.com/@tglaiel/how-to-make-your-game-run-at-60fps-24c61210fe75
        /// </summary>
        public static void DefaultMainLoop(Action tick, Action frame)
        {
            DetectVSync();

            // Settings
            byte desiredStep = Configuration.DesiredStep;
            if (desiredStep == 0) desiredStep = 60;
            bool drawOnUpdate = Configuration.DrawOnUpdate;

            // Setup tick time trackers.
            var timer = Stopwatch.StartNew();
            double targetTime = 1000f / desiredStep;
            double accumulator = 0f;
            double lastTick = 0f;

            // Fuzzy time tracking, as no system has that kind of perfect timing.
            double targetTimeFuzzyLower = 1000d / (desiredStep - 1);
            double targetTimeFuzzyUpper = 1000d / (desiredStep + 1);

            DeltaTime = (float) targetTime;

            while (Status == EngineStatus.Running)
            {
#if SIMULATE_LAG
                Task.Delay(Helpers.GenerateRandomNumber(0, 16)).Wait();
#endif
                // Run the host events, and check whether it is closing.
                if (!Host.Update())
                {
                    Log?.Info("Host was closed.", MessageSource.Engine);
                    break;
                }

                double curTime = timer.ElapsedMilliseconds;
                double deltaTime = curTime - lastTick;
                lastTick = curTime;

                // Snap delta.
                if (Math.Abs(targetTime - deltaTime) <= 1) deltaTime = targetTime;

                // Add to the accumulator.
                accumulator += deltaTime;

                // Update as many times as needed.
                var updated = false;
                byte updates = 0;
                while (accumulator > targetTimeFuzzyUpper)
                {
                    tick();
                    accumulator -= targetTime;
                    updated = true;

                    if (accumulator < targetTimeFuzzyLower - targetTime) accumulator = 0;
                    updates++;
                    // Max updates are 5 - to prevent large spikes.
                    // This does somewhat break the simulation - but these shouldn't happen except as a last resort.
                    if (updates <= 5) continue;
                    accumulator = 0;
                    break;
                }

                if (!Host.IsOpen) break;

                if (!drawOnUpdate || updated) frame();
            }

            Quit();
        }

        #region Loop Parts

        private static void DetectVSync()
        {
            // Check if a host is available.
            if (Host == null || !Host.IsOpen) return;

            var timer = new Stopwatch();

            // Detect VSync (yes I know)
            // Because life is unfair and we cannot have nice things, in order to detect
            // whether the GPU lord has enforced VSync on us (not that we can do anything about it)
            // we have to swap buffers around while messing with the settings and see if it
            // changes anything. If it doesn't - it means VSync is either forced on or off.
            const int jitLoops = 5;
            const int loopCount = 15;
            var timings = new double[(loopCount - jitLoops) * 2];
            Host.Context.SwapInterval = 0;
            for (var i = 0; i < timings.Length + jitLoops; i++)
            {
                timer.Restart();
                Host.Context.SwapBuffers();
                // Run a couple of loops to get the JIT warmed up.
                if (i >= jitLoops)
                    timings[i - jitLoops] = timer.ElapsedMilliseconds;
                // Alright, now turn v-sync on.
                if (i == loopCount - 1)
                    Host.Context.SwapInterval = 1;
            }

            double averageTimeOff = timings.Take(loopCount - jitLoops).Sum() / (timings.Length / 2);
            double averageTimeOn = timings.Skip(loopCount - jitLoops).Sum() / (timings.Length / 2);
            Renderer.ForcedVSync = Math.Abs(averageTimeOff - averageTimeOn) <= 1;

            // Restore settings.
            Renderer.ApplySettings();
        }

        private static void RunTick()
        {
#if DEBUG
            DebugOnUpdateStart?.Invoke(null, EventArgs.Empty);
#endif

            TotalTime += DeltaTime;

            Host.UpdateInput();
            Renderer.Update();
            CoroutineManager.Update();
            SceneManager.Update();

            // Update plugins.
            foreach (IPlugin p in Configuration.Plugins)
            {
                p.Update();
            }

#if DEBUG
            DebugOnUpdateEnd?.Invoke(null, EventArgs.Empty);
#endif
        }

        private static void RunFrame()
        {
#if DEBUG
            DebugOnFrameStart?.Invoke(null, EventArgs.Empty);
#endif

            PerfProfiler.FrameStart();

            // Run the GLThread queued commands.
            PerfProfiler.FrameEventStart("GLThread.Run");
            GLThread.Run();
            PerfProfiler.FrameEventEnd("GLThread.Run");

            PerfProfiler.FrameEventStart("StartFrame");
            Renderer.StartFrame();
            PerfProfiler.FrameEventEnd("StartFrame");

            PerfProfiler.FrameEventStart("Scene.Draw");
            SceneManager.Draw(Renderer);
            PerfProfiler.FrameEventEnd("Scene.Draw");

            PerfProfiler.FrameEventStart("EndFrame");
            Renderer.EndFrame();
            PerfProfiler.FrameEventEnd("EndFrame");

#if DEBUG
            DebugOnFrameEnd?.Invoke(null, EventArgs.Empty);
#endif

            PerfProfiler.FrameEventStart("BufferSwap");
            Host.Context.SwapBuffers();
            PerfProfiler.FrameEventEnd("BufferSwap");

            PerfProfiler.FrameEnd();
        }

        #endregion

        public static void Quit()
        {
            if (Status == EngineStatus.Stopped) return;

            Status = EngineStatus.Stopped;
            Log?.Info("Quitting...", MessageSource.Engine);

            // This will close the host if it is open.
            // No additional cleanup is needed as the program is assumed to be stopping.
            Host?.Close();

            // Flush logs.
            Log?.Dispose();

            // Dispose of plugins.
            foreach (IPlugin p in Configuration.Plugins)
            {
                p.Dispose();
            }
        }

        #region Helpers

        /// <summary>
        /// Detect and return the correct platform instance for the engine host.
        /// </summary>
        /// <param name="engineConfig"></param>
        /// <returns></returns>
        public static PlatformBase GetInstanceOfDetectedPlatform(Configurator engineConfig)
        {
            // ReSharper disable once RedundantAssignment
            PlatformBase platform = null;
            if (engineConfig?.PlatformOverride != null) platform = engineConfig.PlatformOverride;
            if (platform != null) Log.Info($"Platform override accepted. Platform is {platform}", MessageSource.Engine);

#if GLFW
            platform = new GlfwPlatform();
#else
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) platform = new Win32Platform();
#endif

            // If none initialized - fallback to null.
            if (platform == null) platform = new NullPlatform();

            Log.Info($"Platform is: {platform}", MessageSource.Engine);
            return platform;
        }

        /// <summary>
        /// Create the default asset loader which loads the engine assembly, the game assembly, the setup calling assembly, and the
        /// file system.
        /// Duplicate assemblies are not loaded.
        /// </summary>
        /// <returns>The default asset loader.</returns>
        private static AssetLoader LoadDefaultAssetLoader()
        {
            var loader = new AssetLoader();

            // Create sources.
            for (var i = 0; i < Helpers.AssociatedAssemblies.Length; i++)
            {
                Assembly assembly = Helpers.AssociatedAssemblies[i];
                loader.AddSource(new EmbeddedAssetSource(assembly, "Assets"));
            }

            return loader;
        }

        #endregion

        /// <summary>
        /// Submit that an error has happened. Handles logging and closing of the engine safely.
        /// </summary>
        /// <param name="ex">The exception connected with the error occured.</param>
        public static void CriticalError(Exception ex)
        {
            if (Debugger.IsAttached) Debugger.Break();

            Log.Error(ex);
            Host?.DisplayMessageBox($"Fatal error occured!\n{ex}");
            Quit();
        }
    }
}