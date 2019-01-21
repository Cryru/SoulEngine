﻿// Emotion - https://github.com/Cryru/Emotion

#region Using

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Emotion.Engine.Configuration;
using Emotion.Graphics;
using Emotion.Libraries;
using OpenTK;
using OpenTK.Graphics;
using Vector2 = System.Numerics.Vector2;

#endregion

namespace Emotion.Engine.Hosting.Desktop
{
    /// <summary>
    /// An OpenTK window.
    /// </summary>
    public sealed class OtkWindow : GameWindow, IHost
    {
        #region Properties

        /// <summary>
        /// The size of the window.
        /// </summary>
        public new Vector2 Size
        {
            get => new Vector2(ClientSize.Width, ClientSize.Height);
            set
            {
                Width = (int) value.X;
                Height = (int) value.Y;
            }
        }

        /// <summary>
        /// The context's mode.
        /// </summary>
        private static GraphicsContextFlags _contextMode = GraphicsContextFlags.ForwardCompatible;

        #endregion

        #region Hooks and Trackers

        private Action<float> _updateHook;
        private Action _drawHook;
        private Action _resizeHook;
        private Action _closeHook;
        private OtkInputManager _inputManager;

        private bool _isFirstApplySettings = true;

        private static TimeSpan _accumulator;
        private static long _prevTick;
        private static TimeSpan _maxDelta = TimeSpan.FromMilliseconds(100);

        #endregion

        /// <inheritdoc />
        static OtkWindow()
        {
#if DEBUG
            // Debug context breaks on Macs.
            if (CurrentPlatform.OS != PlatformName.Mac) _contextMode = GraphicsContextFlags.Debug;
#endif
        }

        /// <summary>
        /// An OpenTK window host. Is created automatically.
        /// </summary>
        public OtkWindow() : base(960, 540, GraphicsMode.Default, "Emotion Desktop Host",
            GameWindowFlags.Default, DisplayDevice.Default, Engine.Context.Flags.RenderFlags.OpenGLMajorVersion, Engine.Context.Flags.RenderFlags.OpenGLMinorVersion, _contextMode, null, true)
        {
            OnUpdateThreadStarted += (a, b) => Thread.CurrentThread.Name = "Update Thread";
            _inputManager = new OtkInputManager(this);
            Engine.Context.InputManager = _inputManager;

            Visible = true;
            OnLoad(EventArgs.Empty);
        }

        #region Host API

        /// <inheritdoc />
        public void SetHooks(Action<float> onUpdate, Action onDraw, Action onResize, Action onClose)
        {
            _updateHook = onUpdate;
            _drawHook = onDraw;
            _resizeHook = onResize;
            _closeHook = onClose;
        }

        /// <inheritdoc />
        public void ApplySettings(HostSettings settings)
        {
            // OSX and Linux error if settings are updated on another thread.
            if (!_isFirstApplySettings && (!GLThread.IsGLThread() || CurrentPlatform.OS != PlatformName.Windows))
                Task.Run(() => GLThread.ExecuteGLThread(() => InternalApplySettings(settings)));
            else
                InternalApplySettings(settings);
        }

        private void InternalApplySettings(HostSettings settings)
        {
            Title = settings.Title;

            // Apply window mode.
            switch (settings.WindowMode)
            {
                case WindowMode.Borderless:
                    WindowBorder = WindowBorder.Hidden;
                    WindowState = WindowState.Normal;
                    Width = DisplayDevice.Default.Width;
                    Height = DisplayDevice.Default.Height;
                    if (CurrentPlatform.OS == PlatformName.Linux && _isFirstApplySettings) return;
                    X = 0;
                    Y = 0;
                    break;
                case WindowMode.Fullscreen:
                    WindowBorder = WindowBorder.Fixed;
                    WindowState = WindowState.Fullscreen;
                    break;
                default:
                    WindowBorder = WindowBorder.Fixed;
                    WindowState = WindowState.Normal;
                    Width = settings.Width;
                    Height = settings.Height;
                    if (CurrentPlatform.OS == PlatformName.Linux && _isFirstApplySettings) return;
                    X = DisplayDevice.Default.Width / 2 - settings.Width / 2;
                    Y = DisplayDevice.Default.Height / 2 - settings.Height / 2;
                    break;
            }

            _isFirstApplySettings = false;
        }

        /// <inheritdoc />
        public new void Run()
        {
            OnResize(EventArgs.Empty);

            bool fixedStep = Engine.Context.Settings.RenderSettings.CapFPS > 0;
            float targetTime = fixedStep ? (float) Math.Floor(1000f / Engine.Context.Settings.RenderSettings.CapFPS) : 0;

            // Start the main loop.
            Stopwatch deltaTimer = Stopwatch.StartNew();
            while (Engine.Context.IsRunning)
            {
                // Advance the accumulator.
                long curTick = deltaTimer.Elapsed.Ticks;
                _accumulator += TimeSpan.FromTicks(curTick - _prevTick);
                _prevTick = curTick;

                // Check if the time elapsed has surpassed the max.
                if (_accumulator > _maxDelta) _accumulator = _maxDelta;

                while (_accumulator.Milliseconds > targetTime)
                {
                    ProcessEvents();
                    _inputManager.Update();
                    _updateHook?.Invoke(fixedStep ? targetTime : _accumulator.Milliseconds);
                    _accumulator = _accumulator.Subtract(TimeSpan.FromMilliseconds(targetTime));

                    if (fixedStep) continue;
                    _accumulator = TimeSpan.Zero;
                    break;
                }

                _drawHook?.Invoke();
            }
        }

        #endregion

        #region Event Wrapping

        /// <inheritdoc />
        protected override void OnResize(EventArgs e)
        {
            _resizeHook();
        }

        /// <inheritdoc />
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            _closeHook();
        }

        #endregion
    }
}