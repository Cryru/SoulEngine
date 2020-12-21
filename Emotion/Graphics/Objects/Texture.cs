﻿#region Using

using System;
using System.Numerics;
using Emotion.Common;
using Emotion.Common.Serialization;
using Emotion.Common.Threading;
using Emotion.Standard.Logging;
using OpenGL;

#endregion

namespace Emotion.Graphics.Objects
{
    /// <summary>
    /// An uploaded texture.
    /// </summary>
    [DontSerialize]
    public class Texture : IDisposable
    {
        /// <summary>
        /// The bound textures.
        /// </summary>
        public static uint[] Bound = new uint[Engine.Renderer.TextureArrayLimit];

        /// <summary>
        /// The OpenGL pointer to this Texture.
        /// </summary>
        public uint Pointer { get; protected set; }

        /// <summary>
        /// The size of the texture in pixels.
        /// </summary>
        public virtual Vector2 Size { get; protected set; }

        /// <summary>
        /// Whether the image was uploaded upside down. Upside down in this case means not-upside down
        /// due to the way images are stored.
        /// </summary>
        public bool FlipY = false;

        /// <summary>
        /// Whether to apply linear interpolation to the texture. Off by default.
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

        /// <summary>
        /// Whether to tile the texture if sampled outside its bounds. On by default.
        /// </summary>
        public bool Tile
        {
            get => _tile;
            set
            {
                _tile = value;

                if (Engine.Renderer.Dsa)
                {
                    Gl.TextureParameter(Pointer, TextureParameterName.TextureWrapS, _tile ? Gl.REPEAT : Gl.CLAMP_TO_EDGE);
                    Gl.TextureParameter(Pointer, TextureParameterName.TextureWrapT, _tile ? Gl.REPEAT : Gl.CLAMP_TO_EDGE);
                }
                else
                {
                    EnsureBound(Pointer);
                    Gl.TexParameter(TextureTarget.Texture2d, TextureParameterName.TextureWrapS, _tile ? Gl.REPEAT : Gl.CLAMP_TO_EDGE);
                    Gl.TexParameter(TextureTarget.Texture2d, TextureParameterName.TextureWrapT, _tile ? Gl.REPEAT : Gl.CLAMP_TO_EDGE);
                }
            }
        }

        /// <summary>
        /// The format in which the texture is stored internally - this is the format shader should expect to work with.
        /// </summary>
        public InternalFormat InternalFormat { get; protected set; }

        /// <summary>
        /// The source format in which the texture's pixels were uploaded.
        /// </summary>
        public PixelFormat PixelFormat { get; protected set; }

        /// <summary>
        /// The source pixel type of the texture's pixels.
        /// </summary>
        public PixelType PixelType { get; protected set; } = PixelType.UnsignedByte;

        private bool _tile = true;
        private bool _smooth;

        /// <summary>
        /// Create a new uninitialized texture.
        /// </summary>
        public Texture()
        {
            Pointer = Gl.GenTexture();
        }

        /// <summary>
        /// Create a new empty texture.
        /// </summary>
        /// <param name="size">The size of the texture.</param>
        /// <param name="smooth">Whether to apply linear interpolation to the surface's texture.</param>
        /// <param name="internalFormat">The internal format of the texture.</param>
        /// <param name="pixelFormat">The pixel format of the texture.</param>
        /// <param name="pixelType">The data type of individual pixel components.</param>
        public Texture(Vector2 size, bool? smooth = null, InternalFormat internalFormat = InternalFormat.Rgba,
            PixelFormat pixelFormat = PixelFormat.Bgra, PixelType pixelType = PixelType.UnsignedByte) : this()
        {
            _smooth = smooth ?? Engine.Configuration.TextureDefaultSmooth;
            Upload(size, null, internalFormat, pixelFormat, pixelType);
        }

        /// <summary>
        /// Create a texture from data.
        /// </summary>
        /// <param name="size">The size of the texture.</param>
        /// <param name="data">The data to upload.</param>
        /// <param name="smooth">Whether to apply linear interpolation to the surface's texture.</param>
        /// <param name="internalFormat">The internal format of the texture.</param>
        /// <param name="pixelFormat">The pixel format of the texture.</param>
        public Texture(Vector2 size, byte[] data, bool? smooth = false, InternalFormat internalFormat = InternalFormat.Rgba,
            PixelFormat pixelFormat = PixelFormat.Bgra) : this()
        {
            _smooth = smooth ?? Engine.Configuration.TextureDefaultSmooth;
            Upload(size, data, internalFormat, pixelFormat);
        }

        /// <summary>
        /// Uploads data to the texture. If no data is specified the texture is just resized.
        /// This will reset the texture matrix.
        /// </summary>
        /// <param name="size">The width and height of the texture data.</param>
        /// <param name="data">The data to upload.</param>
        /// <param name="internalFormat">The internal format of the texture. If null the format which was last used is taken.</param>
        /// <param name="pixelFormat">The pixel format of the texture. If null the format which was last used is taken.</param>
        /// <param name="pixelType">The data type of individual pixel components.</param>
        public virtual void Upload(Vector2 size, byte[] data, InternalFormat? internalFormat = null, PixelFormat? pixelFormat = null, PixelType? pixelType = null)
        {
            Size = size;

            if (internalFormat == null)
                internalFormat = InternalFormat;
            else
                InternalFormat = (InternalFormat) internalFormat;
            if (pixelFormat == null)
                pixelFormat = PixelFormat;
            else
                PixelFormat = (PixelFormat) pixelFormat;
            if (pixelType == null)
                pixelType = PixelType;
            else
                PixelType = (PixelType) pixelType;

            if (Gl.CurrentVersion.GLES)
            {
                // ES doesn't support BGRA so convert it to RGBA on the CPU
                var stride = 0;
                switch (pixelFormat)
                {
                    case PixelFormat.Bgra:
                        pixelFormat = PixelFormat.Rgba;
                        stride = 4;
                        break;
                    case PixelFormat.Bgr:
                        pixelFormat = PixelFormat.Rgb;
                        stride = 3;
                        break;
                }

                if (stride != 0 && data != null)
                    for (var i = 0; i < data.Length; i += stride)
                    {
                        byte r = data[i + 2];
                        byte b = data[i];
                        data[i + 2] = b;
                        data[i] = r;
                    }
            }

            EnsureBound(Pointer);
            if (data == null)
                Gl.TexImage2D(TextureTarget.Texture2d, 0, (InternalFormat) internalFormat, (int) Size.X, (int) Size.Y, 0, (PixelFormat) pixelFormat,
                    (PixelType) pixelType, IntPtr.Zero);
            else
                Gl.TexImage2D(TextureTarget.Texture2d, 0, (InternalFormat) internalFormat, (int) Size.X, (int) Size.Y, 0, (PixelFormat) pixelFormat,
                    (PixelType) pixelType, data);

            Smooth = _smooth;
            Tile = _tile;
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
                if (!Engine.Configuration.GlDebugMode) return;

                Gl.ActiveTexture(TextureUnit.Texture0 + (int) slot);
                Gl.GetInteger(GetPName.TextureBinding2d, out int actualBound);
                if (actualBound != pointer) Engine.Log.Error($"Assumed texture bound to slot {slot} was {pointer} but it was {actualBound}.", MessageSource.GL);
                return;
            }

            Gl.ActiveTexture(TextureUnit.Texture0 + (int) slot);
            Gl.BindTexture(TextureTarget.Texture2d, pointer);
            Bound[slot] = pointer;
        }

        /// <summary>
        /// Destroy the texture freeing up memory.
        /// The graphics object's destruction is async.
        /// </summary>
        public virtual void Dispose()
        {
            uint ptr = Pointer;
            Pointer = 0;

            if (Engine.Host == null) return;

            for (var i = 0; i < Bound.Length; i++)
            {
                if (Bound[i] == ptr) Bound[i] = 0;
            }

            if (ptr != 0)
                GLThread.ExecuteGLThreadAsync(() => { Gl.DeleteTextures(ptr); });
        }

        public static Texture EmptyWhiteTexture;

        public static void InitializeEmptyTexture()
        {
            EmptyWhiteTexture = new Texture(new Vector2(1, 1), new byte[] {255, 255, 255, 255});
        }
    }
}