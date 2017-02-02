﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SoulEngine
{
    public class ViewAdapter : ScalingViewportAdapter
    {
        private readonly GraphicsDeviceManager _graphicsDeviceManager;
        private readonly GameWindow _window;

        /// <summary>
        /// Size of horizontal bleed areas (from left and right edges) which can be safely cut off
        /// </summary>
        public int HorizontalBleed { get; }

        /// <summary>
        /// Size of vertical bleed areas (from top and bottom edges) which can be safely cut off
        /// </summary>
        public int VerticalBleed { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BoxingViewportAdapter"/>. 
        /// Note: If you're using DirectX please use the other constructor due to a bug in MonoGame.
        /// https://github.com/mono/MonoGame/issues/4018
        /// </summary>
        public ViewAdapter(GameWindow window, GraphicsDevice graphicsDevice, int virtualWidth, int virtualHeight, int horizontalBleed, int verticalBleed)
            : base(graphicsDevice, virtualWidth, virtualHeight)
        {
            _window = window;
            //window.ClientSizeChanged += OnClientSizeChanged;
            HorizontalBleed = horizontalBleed;
            VerticalBleed = verticalBleed;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BoxingViewportAdapter"/>. 
        /// Note: If you're using DirectX please use the other constructor due to a bug in MonoGame.
        /// https://github.com/mono/MonoGame/issues/4018
        /// </summary>
        public ViewAdapter(GameWindow window, GraphicsDevice graphicsDevice, int virtualWidth, int virtualHeight)
            : this(window, graphicsDevice, virtualWidth, virtualHeight, 0, 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BoxingViewportAdapter"/>. 
        /// Use this constructor only if you're using DirectX due to a bug in MonoGame.
        /// https://github.com/mono/MonoGame/issues/4018
        /// This constructor will be made obsolete and eventually removed once the bug has been fixed.
        /// </summary>
        public ViewAdapter(GameWindow window, GraphicsDeviceManager graphicsDeviceManager, int virtualWidth, int virtualHeight, int horizontalBleed, int verticalBleed)
            : this(window, graphicsDeviceManager.GraphicsDevice, virtualWidth, virtualHeight, horizontalBleed, verticalBleed)
        {
            _graphicsDeviceManager = graphicsDeviceManager;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BoxingViewportAdapter"/>. 
        /// Use this constructor only if you're using DirectX due to a bug in MonoGame.
        /// https://github.com/mono/MonoGame/issues/4018
        /// This constructor will be made obsolete and eventually removed once the bug has been fixed.
        /// </summary>
        public ViewAdapter(GameWindow window, GraphicsDeviceManager graphicsDeviceManager, int virtualWidth, int virtualHeight)
            : this(window, graphicsDeviceManager, virtualWidth, virtualHeight, 0, 0)
        {
        }

        public BoxingMode BoxingMode { get; private set; }

        public void Update()
        {
            var viewport = GraphicsDevice.Viewport;

            var worldScaleX = (float)viewport.Width / VirtualWidth;
            var worldScaleY = (float)viewport.Height / VirtualHeight;

            var safeScaleX = (float)viewport.Width / (VirtualWidth - HorizontalBleed);
            var safeScaleY = (float)viewport.Height / (VirtualHeight - VerticalBleed);

            float worldScale = MathHelper.Max(worldScaleX, worldScaleY);
            float safeScale = MathHelper.Min(safeScaleX, safeScaleY);
            float scale = MathHelper.Min(worldScale, safeScale);

            var width = (int)(scale * VirtualWidth + 0.5f);
            var height = (int)(scale * VirtualHeight + 0.5f);

            if (height >= viewport.Height && width < viewport.Width)
            {
                BoxingMode = BoxingMode.Pillarbox;
            }
            else if (width >= viewport.Height && height < viewport.Height)
            {
                BoxingMode = BoxingMode.Letterbox;
            }
            else
            {
                BoxingMode = BoxingMode.None;
            }

            var x = (viewport.Width / 2) - (width / 2);
            var y = (viewport.Height / 2) - (height / 2);
            GraphicsDevice.Viewport = new Viewport(x, y, width, height);

            // Needed for a DirectX bug in MonoGame 3.4. Hopefully it will be fixed in future versions
            // see http://gamedev.stackexchange.com/questions/68914/issue-with-monogame-resizing
            if (_graphicsDeviceManager != null &&
                    (_graphicsDeviceManager.PreferredBackBufferWidth != _window.ClientBounds.Width ||
                    _graphicsDeviceManager.PreferredBackBufferHeight != _window.ClientBounds.Height))
            {
                _graphicsDeviceManager.PreferredBackBufferWidth = _window.ClientBounds.Width;
                _graphicsDeviceManager.PreferredBackBufferHeight = _window.ClientBounds.Height;
                _graphicsDeviceManager.ApplyChanges();
            }
        }

        public override void Reset()
        {
            base.Reset();
            //OnClientSizeChanged(this, EventArgs.Empty);
        }

        public override Point PointToScreen(int x, int y)
        {
            var viewport = GraphicsDevice.Viewport;
            return base.PointToScreen(x - viewport.X, y - viewport.Y);
        }
    }
}