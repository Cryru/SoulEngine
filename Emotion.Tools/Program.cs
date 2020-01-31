﻿#region Using

using System.Numerics;
using Emotion.Common;
using Emotion.Graphics;
using Emotion.Plugins.ImGuiNet;
using Emotion.Plugins.ImGuiNet.Windowing;
using Emotion.Primitives;
using Emotion.Scenography;
using Emotion.Tools.Windows;
using ImGuiNET;

#endregion

namespace Emotion.Tools
{
    internal class Program : IScene
    {
        #region UI Logic

        private static WindowManager _manager = new WindowManager();

        #endregion

        private static void Main()
        {
            var config = new Configurator
            {
                DebugMode = true,
                HostSize = new Vector2(1280, 720)
            };
            config.AddPlugin(new ImGuiNetPlugin());

            Engine.Setup(config);
            Engine.SceneManager.SetScene(new Program());
            Engine.Run();
        }

        public void Update()
        {
            _manager.Update();
        }

        public void Load()
        {

        }

        public void Unload()
        {

        }

        public void Draw(RenderComposer composer)
        {
            composer.SetUseViewMatrix(false);
            composer.RenderSprite(new Vector3(0, 0, 0), Engine.Renderer.CurrentTarget.Size, Color.CornflowerBlue);

            ImGui.NewFrame();
            composer.RenderToolsMenu(_manager);
            _manager.Render(composer);
            ImGuiNetPlugin.RenderUI(composer);
        }
    }
}