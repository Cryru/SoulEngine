#region Using

using System.Numerics;
using Emotion.Common;
using Emotion.Primitives;
using Emotion.Utility;

#endregion

namespace Emotion.Graphics.Camera
{
    /// <summary>
    /// Intended to be used for 2D environments and optimized for pixel art.
    /// Will automatically scale based on the "IntScale" property of the Renderer.
    /// </summary>
    public class PixelArtCamera : CameraBase
    {
        /// <summary>
        /// Create a new pixel art camera.
        /// </summary>
        /// <param name="position">The position of the camera.</param>
        /// <param name="zoom">The camera's zoom.</param>
        public PixelArtCamera(Vector3 position, float zoom = 1f) : base(position, zoom)
        {
        }

        /// <inheritdoc />
        public override void RecreateMatrix()
        {
            var iX = (int)X;
            var iY = (int)Y;

            Vector2 targetSize = Engine.Configuration.RenderSize;
            Vector2 currentSize = Engine.Renderer.DrawBuffer.Size;

            // Transform the position from the center position to the offset position.
            Vector3 posOffset = new Vector3(iX, iY, 0) - new Vector3(targetSize, 0) / 2;

            // Get the scale relative to the zoom.
            float scale = Engine.Renderer.IntScale * Zoom;

            // Find the camera margin and scale from the center.
            // As the current size expands more of the world will come into view until the integer scale changes at which point everything will be resized.
            // This allows for pixel art to scale integerly in FullScale mode.
            Vector2 margin = (currentSize - targetSize) / 2;
            Vector3 pos = posOffset - new Vector3((int) margin.X, (int) margin.Y, 0);

            // scale, rotation, translate
            Matrix4x4 scaleMat = Matrix4x4.CreateScale(new Vector3(scale, scale, 1), new Vector3(iX, iY, 0));
            Matrix4x4 rotateMat;
            // No rotation case.
            if (_rotation.X == 0 && _rotation.Y == 0 && _rotation.Z == 0)
            {
                rotateMat = Matrix4x4.Identity;
            }
            else
            {
                // Mix rotation angles into one.
                (float xyAngle, Vector3 xyAxis) = Maths.CombineAxisAngle(Rotation.X, new Vector3(1, 0, 0), Rotation.Y, new Vector3(0, 1, 0));
                (float angle, Vector3 axis) = Maths.CombineAxisAngle(xyAngle, xyAxis, Rotation.Z, new Vector3(0, 0, 1));
                rotateMat = Matrix4x4.CreateFromAxisAngle(axis, angle);
            }

            ViewMatrixUnscaled = rotateMat * Matrix4x4.CreateLookAt(pos, pos + new Vector3(0, 0, -1), new Vector3(0.0f, 1.0f, 0.0f));
            ViewMatrix = scaleMat * ViewMatrixUnscaled;
        }

        /// <inheritdoc />
        public override void Update()
        {
        }
    }
}