﻿#region Using

using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using Emotion.Common;
using Emotion.Common.Threading;
using Emotion.Graphics;
using Emotion.Graphics.Objects;
using Emotion.IO;
using Emotion.Primitives;

#endregion

namespace Emotion.Game.Effects
{
    public class PaletteAsset : XMLAsset<PaletteDescription>
    {
        public PaletteBaseTexture BaseTexture { get; set; }
        public Dictionary<Palette, Texture> PaletteSwaps = new Dictionary<Palette, Texture>();

        protected override void CreateInternal(byte[] data)
        {
            base.CreateInternal(data);
            if (Content == null) return;

            // Load the base texture.
            BaseTexture = Engine.AssetLoader.Get<PaletteBaseTexture>(Content.BaseAsset);

            Debug.Assert(BaseTexture != null);
            Debug.Assert(BaseTexture.PaletteMap != null);

            // Load all variations.
            var pixels = new byte[BaseTexture.PaletteMap.Length * 4];
            foreach (Palette p in Content.Palettes)
            {
                for (var j = 0; j < pixels.Length; j += 4)
                {
                    byte index = BaseTexture.PaletteMap[j / 4];
                    if (index >= p.Colors.Length) index = 0;

                    Color c = p.Colors[index];
                    pixels[j] = c.B;
                    pixels[j + 1] = c.G;
                    pixels[j + 2] = c.R;
                    pixels[j + 3] = c.A;
                }

                GLThread.ExecuteGLThread(() =>
                {
                    var texture = new Texture(BaseTexture.Texture.Size);
                    texture.Upload(BaseTexture.Texture.Size, pixels);
                    texture.TextureMatrix = BaseTexture.Texture.TextureMatrix;
                    PaletteSwaps.Add(p, texture);
                });
            }

            // Free up the palette map memory.
            BaseTexture.PaletteMap = null;
        }

        /// <summary>
        /// Get the palette texture under a specific name.
        /// </summary>
        /// <param name="paletteName">The name of the palette texture to get.</param>
        /// <returns>A horizontal texture containing the specified palette.</returns>
        public Texture GetTextureForPalette(string paletteName)
        {
            if (string.Equals(paletteName, "default", System.StringComparison.OrdinalIgnoreCase)) return BaseTexture.Texture;

            Palette p = Content.GetPalette(paletteName);
            if (p == null) return null;
            return PaletteSwaps.ContainsKey(p) ? PaletteSwaps[p] : null;
        }

        protected override void DisposeInternal()
        {
            base.DisposeInternal();
            GLThread.ExecuteGLThreadAsync(() =>
            {
                BaseTexture.Dispose();
                foreach (KeyValuePair<Palette, Texture> p in PaletteSwaps)
                {
                    p.Value.Dispose();
                }
            });
        }
    }
}