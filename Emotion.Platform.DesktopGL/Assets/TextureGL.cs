﻿#region Using

using System.IO;
using System.Numerics;
using Adfectus.Common;
using Adfectus.Graphics;
using FreeImageAPI;

#endregion

namespace Emotion.Platform.DesktopGL.Assets
{
    /// <inheritdoc />
    public class TextureGL : Texture
    {
        /// <summary>
        /// The texture matrix used to convert UVs.
        /// </summary>
        public Matrix4x4 TextureMatrix { get; protected set; }

        /// <summary>
        /// The OpenGL pointer of the texture.
        /// </summary>
        public uint Pointer;

        /// <inheritdoc />
        public TextureGL()
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Wrap an already created texture in a TextureGL object.
        /// </summary>
        /// <param name="pointer">Pointer to the created OpenGL texture.</param>
        /// <param name="size">The size of the texture.</param>
        /// <param name="name">The name of the texture.</param>
        public TextureGL(uint pointer, Vector2 size, string name = null)
        {
            Pointer = pointer;
            Size = size;
            TextureMatrix = Matrix4x4.CreateOrthographicOffCenter(0, Size.X * 2, Size.Y * 2, 0, 0, 1);
            Name = name ?? $"OpenGL Texture - {Pointer}";
            Created = true;
        }

        /// <inheritdoc />
        /// <summary>
        /// Wrap an already created texture in a TextureGL object.
        /// </summary>
        /// <param name="pointer">Pointer to the created OpenGL texture.</param>
        /// <param name="size">The size of the texture.</param>
        /// <param name="matrix">The texture matrix.</param>
        /// <param name="name">The name of the texture.</param>
        public TextureGL(uint pointer, Vector2 size, Matrix4x4 matrix, string name = null)
        {
            Pointer = pointer;
            Size = size;
            TextureMatrix = matrix;
            Name = name ?? $"OpenGL Texture - {Pointer}";
            Created = true;
        }

        protected override void CreateInternal(byte[] data)
        {
            // Create a GL pointer to the new texture.
            Pointer = Engine.GraphicsManager.CreateTexture();

            FIBITMAP freeImageBitmap;

            // Put the bytes into a stream.
            using (MemoryStream stream = new MemoryStream(data))
            {
                // Get the image format and load the image as a FreeImageBitmap.
                FREE_IMAGE_FORMAT fileType = FreeImage.GetFileTypeFromStream(stream);
                freeImageBitmap = FreeImage.ConvertTo32Bits(FreeImage.LoadFromStream(stream, ref fileType));

                // Assign size.
                Size = new Vector2(FreeImage.GetWidth(freeImageBitmap), FreeImage.GetHeight(freeImageBitmap));
            }

            FIBITMAP preRotation = freeImageBitmap;
            freeImageBitmap = FreeImage.Rotate(preRotation, 180);
            FreeImage.Unload(preRotation);

            TextureMatrix = Matrix4x4.CreateOrthographicOffCenter(0, Size.X * 2, Size.Y * 2, 0, 0, 1) * Matrix4x4.CreateScale(-1, -1, 1);

            // Even though all of the calls in the graphics manager call for execution on the GL Thread, wrapping them together like this ensures they'll be called within one loop.
            GLThread.ExecuteGLThread(() =>
            {
                Engine.GraphicsManager.BindTexture(Pointer);
                Engine.GraphicsManager.SetTextureMask(0x0000ff00, 0x00ff0000, 0xff000000, 0x000000ff);
                Engine.GraphicsManager.UploadToTexture(FreeImage.GetBits(freeImageBitmap), Size, TextureInternalFormat.Rgba8,
                    Engine.Flags.RenderFlags.TextureLoadStandard ? TexturePixelFormat.Rgba : TexturePixelFormat.Bgra);
            });

            // Cleanup FreeImage object.
            FreeImage.Unload(freeImageBitmap);
        }

        protected override void DisposeInternal()
        {
            Engine.GraphicsManager.DeleteTexture(Pointer);
        }
    }
}