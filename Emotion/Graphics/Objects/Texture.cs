﻿#region Using

using System;
using System.Numerics;
using Emotion.Common;
using Emotion.Common.Threading;
using Emotion.Standard.Logging;
using OpenGL;

#endregion

namespace Emotion.Graphics.Objects
{
    /// <summary>
    /// An uploaded texture.
    /// </summary>
    public sealed class Texture : IDisposable
    {
        /// <summary>
        /// The bound textures.
        /// </summary>
        public static uint[] Bound = new uint[10];

        /// <summary>
        /// The OpenGL pointer to this Texture.
        /// </summary>
        public uint Pointer { get; private set; }

        /// <summary>
        /// The size of the texture in pixels.
        /// </summary>
        public Vector2 Size { get; private set; }

        /// <summary>
        /// The matrix to multiply UVs by.
        /// </summary>
        public Matrix4x4 TextureMatrix { get; set; }

        /// <summary>
        /// Whether to apply linear interpolation to the texture.
        /// </summary>
        public bool Smooth
        {
            get => _smooth;
            set
            {
                _smooth = value;

                if (Engine.Renderer.Dsa)
                {
                    Gl.TextureParameter(Pointer, TextureParameterName.TextureMinFilter, _smooth ? Gl.LINEAR : Gl.NEAREST);
                    Gl.TextureParameter(Pointer, TextureParameterName.TextureMagFilter, _smooth ? Gl.LINEAR : Gl.NEAREST);
                }
                else
                {
                    EnsureBound(Pointer);
                    Gl.TexParameter(TextureTarget.Texture2d, TextureParameterName.TextureMinFilter, _smooth ? Gl.LINEAR : Gl.NEAREST);
                    Gl.TexParameter(TextureTarget.Texture2d, TextureParameterName.TextureMagFilter, _smooth ? Gl.LINEAR : Gl.NEAREST);
                }
            }
        }

        private bool _smooth;
        private InternalFormat _internalFormat;
        private PixelFormat _pixelFormat;

        /// <summary>
        /// Create a new empty texture.
        /// </summary>
        /// <param name="size">The size of the texture.</param>
        /// <param name="smooth">Whether to apply linear interpolation to the surface's texture.</param>
        /// <param name="internalFormat">The internal format of the texture.</param>
        /// <param name="pixelFormat">The pixel format of the texture.</param>
        public Texture(Vector2 size, bool smooth = false, InternalFormat internalFormat = InternalFormat.Rgba,
            PixelFormat pixelFormat = PixelFormat.Rgba)
        {
            Pointer = Gl.GenTexture();

            Upload(size, null, internalFormat, pixelFormat);

            Smooth = smooth;
        }

        /// <summary>
        /// Create a texture from data.
        /// </summary>
        /// <param name="size">The size of the texture.</param>
        /// <param name="data">The data to upload.</param>
        /// <param name="smooth">Whether to apply linear interpolation to the surface's texture.</param>
        /// <param name="internalFormat">The internal format of the texture.</param>
        /// <param name="pixelFormat">The pixel format of the texture.</param>
        public Texture(Vector2 size, byte[] data, bool smooth = false, InternalFormat internalFormat = InternalFormat.Rgba,
            PixelFormat pixelFormat = PixelFormat.Rgba)
        {
            Pointer = Gl.GenTexture();

            Upload(size, data, internalFormat, pixelFormat);

            Smooth = smooth;
        }

        /// <summary>
        /// Uploads data to the texture. If no data is specified the texture is just resized.
        /// This will reset the texture matrix.
        /// </summary>
        /// <param name="size">The width and height of the texture data.</param>
        /// <param name="data">The data to upload.</param>
        /// <param name="internalFormat">The internal format of the texture. If null the format which was last used is taken.</param>
        /// <param name="pixelFormat">The pixel format of the texture. If null the format which was last used is taken.</param>
        public void Upload(Vector2 size, byte[] data, InternalFormat? internalFormat = null, PixelFormat? pixelFormat = null)
        {
            Size = size;

            if (internalFormat == null)
                internalFormat = _internalFormat;
            else
                _internalFormat = (InternalFormat) internalFormat;
            if (pixelFormat == null)
                pixelFormat = _pixelFormat;
            else
                _pixelFormat = (PixelFormat) pixelFormat;


            EnsureBound(Pointer);
            if (data == null)
                Gl.TexImage2D(TextureTarget.Texture2d, 0, (InternalFormat) internalFormat, (int) Size.X, (int) Size.Y, 0, (PixelFormat) pixelFormat,
                    PixelType.UnsignedByte, IntPtr.Zero);
            else
                Gl.TexImage2D(TextureTarget.Texture2d, 0, (InternalFormat) internalFormat, (int) Size.X, (int) Size.Y, 0, (PixelFormat) pixelFormat,
                    PixelType.UnsignedByte, data);

            Gl.GenerateMipmap(TextureTarget.Texture2d);
            TextureMatrix = Matrix4x4.CreateOrthographicOffCenter(0, Size.X * 2, Size.Y * 2, 0, 0, 1);
        }

        /// <summary>
        /// Ensures the provided pointer is the currently bound texture in the provided slot.
        /// </summary>
        /// <param name="pointer">The pointer to ensure is bound.</param>
        /// <param name="slot">Ensure the texture is bound in this slot.</param>
        public static void EnsureBound(uint pointer, uint slot = 0)
        {
            // Check if it is already bound.
            if (Bound[slot] == pointer && pointer != 0)
            {
                // If in debug mode, verify this with OpenGL.
                if (!Engine.Configuration.DebugMode) return;

                Gl.ActiveTexture(TextureUnit.Texture0 + (int) slot);
                Gl.GetInteger(GetPName.TextureBinding2d, out uint actualBound);
                if (actualBound != pointer) Engine.Log.Error($"Assumed texture bound to slot {slot} was {pointer} but it was {actualBound}.", MessageSource.GL);
                return;
            }

            Gl.ActiveTexture(TextureUnit.Texture0 + (int) slot);
            Gl.BindTexture(TextureTarget.Texture2d, pointer);
            Bound[slot] = pointer;
        }

        #region Cleanup

        public void Dispose()
        {
            uint ptr = Pointer;
            Pointer = 0;

            if (Engine.Host == null) return;

            for (var i = 0; i < Bound.Length; i++)
            {
                if (Bound[i] == ptr) Bound[i] = 0;
            }

            GLThread.ExecuteGLThreadAsync(() => { Gl.DeleteTextures(ptr); });
        }

        #endregion
    }
}