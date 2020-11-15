﻿#region Using

using System;
using System.Collections.Generic;
using Emotion.Common;
using Emotion.Common.Threading;
using Emotion.Graphics.Shading;
using Emotion.Platform.Input;
using Emotion.Standard.Logging;

#endregion

namespace Emotion.IO
{
    public class ShaderDescription
    {
        /// <summary>
        /// The path to the fragment shader relative to the shader description asset.
        /// </summary>
        public string Frag { get; set; }

        /// <summary>
        /// The path to the fragment shader relative to the shader description asset.
        /// </summary>
        public string Vert { get; set; }

        /// <summary>
        /// The path to another shader description to fallback to if the creation of this shader fails.
        /// </summary>
        public string Fallback { get; set; } = "Shaders/DefaultShader.xml";
    }

    public class ShaderAsset : XMLAsset<ShaderDescription>
    {
        /// <summary>
        /// The description of the shader. Legacy property, redirect to Content.
        /// </summary>
        public ShaderDescription Description
        {
            get => Content;
        }

        /// <summary>
        /// Whether using the fallback shader.
        /// </summary>
        public bool IsFallback { get; set; }

        /// <summary>
        /// The name of the fallback shader used - if any.
        /// </summary>
        public string FallbackName { get; set; }

        /// <summary>
        /// The actual shader compiled from this asset.
        /// </summary>
        public ShaderProgram Shader { get; protected set; }

        #region Debug Shader Reload

        private static List<ShaderAsset> _activeShaderAssets;

        static ShaderAsset()
        {
            if (!Engine.Configuration.DebugMode) return;

            _activeShaderAssets = new List<ShaderAsset>();
            Engine.Host.OnKey.AddListener((k, s) =>
            {
                // The reload shaders shortcut is Ctrl + R
                if (k != Key.R || s != KeyStatus.Down || !Engine.InputManager.IsKeyHeld(Key.LeftControl)) return true;

                for (int i = _activeShaderAssets.Count - 1; i >= 0; i--)
                {
                    if (_activeShaderAssets[i].Disposed)
                        _activeShaderAssets.RemoveAt(i);
                    else
                        _activeShaderAssets[i].ReloadShader();
                }

                return true;
            });
        }

        public ShaderAsset()
        {
            _activeShaderAssets?.Add(this);
        }

        private void ReloadShader()
        {
            Engine.Log.Warning($"Reloading shader {Name}...", MessageSource.Debug);
            DisposeInternal();
            Compile();
        }

        #endregion

        protected override void CreateInternal(ReadOnlyMemory<byte> data)
        {
            // Deserialize the shader description.
            base.CreateInternal(data);
            // Fallback to default.
            Content ??= new ShaderDescription();
            Compile();
        }

        private void Compile()
        {
            // Get the text contents of the shader files referenced. If any of them are missing substitute with the default one.
            TextAsset vertShader = null;
            var ownVert = false;

            if (!string.IsNullOrEmpty(Content.Vert))
            {
                vertShader = Engine.AssetLoader.Get<TextAsset>(Content.Vert);
                ownVert = true;
            }

            if (vertShader == null)
            {
                vertShader = Engine.AssetLoader.Get<TextAsset>("Shaders/DefaultVert.vert");
                ownVert = false;

                if (vertShader == null) Engine.Log.Warning($"Couldn't find shader file {Content.Vert}. Using default.", MessageSource.AssetLoader);
            }

            TextAsset fragShader = null;
            var ownFrag = false;

            if (!string.IsNullOrEmpty(Content.Frag))
            {
                fragShader = Engine.AssetLoader.Get<TextAsset>(Content.Frag);
                ownFrag = true;

                if (fragShader == null) Engine.Log.Warning($"Couldn't find shader file {Content.Frag}. Using default.", MessageSource.AssetLoader);
            }

            if (fragShader == null)
            {
                fragShader = Engine.AssetLoader.Get<TextAsset>("Shaders/DefaultFrag.frag");
                ownFrag = false;
            }

            Engine.Log.Info($"Creating shader - v:{vertShader.Name}, f:{fragShader.Name}", MessageSource.AssetLoader);

            // Create the shader, or at least try to.
            PerfProfiler.ProfilerEventStart("Compilation", "Loading");
            GLThread.ExecuteGLThread(() => { Shader = ShaderFactory.CreateShader(vertShader.Content, fragShader.Content); });
            PerfProfiler.ProfilerEventEnd("Compilation", "Loading");

            // Free text assets as they are no longer needed.
            if (ownVert) Engine.AssetLoader.Destroy(vertShader.Name);
            if (ownFrag) Engine.AssetLoader.Destroy(fragShader.Name);

            // Check if compilation was successful.
            if (Shader != null && Shader.Valid) return;

            Engine.Log.Warning($"Shader {Name} creation failed. Falling back.", MessageSource.AssetLoader);
            IsFallback = true;

            // If there is no fallback, fallback to default.
            if (string.IsNullOrEmpty(Content.Fallback))
            {
                Engine.Log.Warning("No fallback specified, falling back to default.", MessageSource.AssetLoader);
                Shader = ShaderFactory.DefaultProgram;
                FallbackName = "Default";
                return;
            }

            var fallBackShader = Engine.AssetLoader.Get<ShaderAsset>(Content.Fallback);
            // If not found, fallback to default.
            if (fallBackShader == null)
            {
                Engine.Log.Warning($"Fallback {Content.Fallback} not found. Falling back to default.", MessageSource.AssetLoader);
                Shader = ShaderFactory.DefaultProgram;
                FallbackName = "Default";
                return;
            }

            Engine.Log.Warning($"Shader {Name} fell back to {Content.Fallback}.", MessageSource.AssetLoader);
            FallbackName = Content.Fallback;
            Shader = fallBackShader.Shader;
        }

        protected override void DisposeInternal()
        {
            if (!IsFallback) Shader.Dispose();
        }
    }
}