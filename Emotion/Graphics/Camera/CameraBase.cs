#region Using

using System.Numerics;
using Emotion.Common;
using Emotion.Primitives;
using Emotion.Utility;

#endregion

namespace Emotion.Graphics.Camera
{
    /// <summary>
    /// The basis for a camera object. Intended to be used for 2D environments and optimized for pixel art.
    /// Will automatically scale based on the "IntScale" property of the Renderer.
    /// </summary>
    public abstract class CameraBase : Positional
    {
        #region Properties

        /// <summary>
        /// How zoomed the camera is.
        /// Negative values will cause position inversion.
        /// </summary>
        public float Zoom
        {
            get => _zoom;
            set
            {
                _zoom = value;
                RecreateMatrix();
            }
        }

        protected float _zoom;

        /// <summary>
        /// The camera rotation in radians.
        /// </summary>
        public Vector3 Rotation
        {
            get => _rotation;
            set
            {
                _rotation = value;
                RecreateMatrix();
            }
        }

        /// <summary>
        /// The camera rotation in angles.
        /// Internally the rotation is stored in radians so setting this with a value from its getter will cause loss of data.
        /// </summary>
        public Vector3 RotationAngle
        {
            get => new Vector3(Maths.RadiansToDegrees(_rotation.X), Maths.RadiansToDegrees(_rotation.Y), Maths.RadiansToDegrees(_rotation.Z));
            set
            {
                _rotation.X = Maths.DegreesToRadians(value.X);
                _rotation.Y = Maths.DegreesToRadians(value.Y);
                _rotation.Z = Maths.DegreesToRadians(value.Z);
                RecreateMatrix();
            }
        }

        protected Vector3 _rotation;

        #endregion

        #region Calculated

        /// <summary>
        /// The camera's matrix.
        /// </summary>
        public Matrix4x4 ViewMatrix { get; protected set; } = Matrix4x4.Identity;

        /// <summary>
        /// The camera's matrix without scaling applied.
        /// </summary>
        public Matrix4x4 ViewMatrixUnscaled { get; protected set; } = Matrix4x4.Identity;

        #endregion

        /// <summary>
        /// Create a new camera basis.
        /// </summary>
        /// <param name="position">The position of the camera.</param>
        /// <param name="zoom">The camera's zoom.</param>
        protected CameraBase(Vector3 position, float zoom = 1f)
        {
            Position = position;
            Zoom = zoom;

            RecreateMatrix();

            OnMove += (s, e) => { RecreateMatrix(); };
        }

        /// <summary>
        /// Update the camera. The current camera is updated each tick.
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// Recreates the view matrix of the camera and updates it for the renderer.
        /// </summary>
        public abstract void RecreateMatrix();

        Frustum _frustum;
        public void RecalculateFrustum()
        {
            //Frustum returnFrustum;

            //// Calculate the near and far plane points
            //float nearHeight = 2 * tan(fov / 2) * fnear;
            //float nearWidth = nearHeight * aspect;
            //float farHeight = 2 * tan(fov / 2) * ffar;
            //float farWidth = farHeight * aspect;

            //// And their centers
            //vector3 nearCenter = position + (look * fnear);
            //vector3 farCenter = position + (look * ffar);

            //_frustum.center = position + (look * (ffar / 2.0f));

            //// And the actual coordinates
            //returnFrustum.fnear[Frustum::COORD_BOTTOMLEFT] = nearCenter - (up * (nearHeight / 2.0f)) - (right * (nearWidth / 2.0f));
            //returnFrustum.fnear[Frustum::COORD_BOTTOMRIGHT] = nearCenter - (up * (nearHeight / 2.0f)) + (right * (nearWidth / 2.0f));
            //returnFrustum.fnear[Frustum::COORD_TOPLEFT] = nearCenter + (up * (nearHeight / 2.0f)) - (right * (nearWidth / 2.0f));
            //returnFrustum.fnear[Frustum::COORD_TOPRIGHT] = nearCenter + (up * (nearHeight / 2.0f)) + (right * (nearWidth / 2.0f));

            //returnFrustum.ffar[Frustum::COORD_BOTTOMLEFT] = farCenter - (up * (farHeight / 2.0f)) - (right * (farWidth / 2.0f));
            //returnFrustum.ffar[Frustum::COORD_BOTTOMRIGHT] = farCenter - (up * (farHeight / 2.0f)) + (right * (farWidth / 2.0f));
            //returnFrustum.ffar[Frustum::COORD_TOPLEFT] = farCenter + (up * (farHeight / 2.0f)) - (right * (farWidth / 2.0f));
            //returnFrustum.ffar[Frustum::COORD_TOPRIGHT] = farCenter + (up * (farHeight / 2.0f)) + (right * (farWidth / 2.0f));

            //// Then create our frustum planes
            //returnFrustum.planes[Frustum::PLANE_NEAR].CreateFromPoints(m_viewFrustum.fnear[Frustum::COORD_BOTTOMLEFT], m_viewFrustum.fnear[Frustum::COORD_BOTTOMRIGHT], m_viewFrustum.fnear[Frustum::COORD_TOPLEFT]);
            //returnFrustum.planes[Frustum::PLANE_FAR].CreateFromPoints(m_viewFrustum.ffar[Frustum::COORD_TOPLEFT], m_viewFrustum.ffar[Frustum::COORD_TOPRIGHT], m_viewFrustum.ffar[Frustum::COORD_BOTTOMLEFT]);
            //returnFrustum.planes[Frustum::PLANE_LEFT].CreateFromPoints(m_viewFrustum.fnear[Frustum::COORD_BOTTOMLEFT], m_viewFrustum.fnear[Frustum::COORD_TOPLEFT], m_viewFrustum.ffar[Frustum::COORD_BOTTOMLEFT]);
            //returnFrustum.planes[Frustum::PLANE_RIGHT].CreateFromPoints(m_viewFrustum.ffar[Frustum::COORD_TOPRIGHT], m_viewFrustum.fnear[Frustum::COORD_TOPRIGHT], m_viewFrustum.ffar[Frustum::COORD_BOTTOMRIGHT]);
            //returnFrustum.planes[Frustum::PLANE_TOP].CreateFromPoints(m_viewFrustum.ffar[Frustum::COORD_TOPLEFT], m_viewFrustum.fnear[Frustum::COORD_TOPLEFT], m_viewFrustum.ffar[Frustum::COORD_TOPRIGHT]);
            //returnFrustum.planes[Frustum::PLANE_BOTTOM].CreateFromPoints(m_viewFrustum.fnear[Frustum::COORD_BOTTOMLEFT], m_viewFrustum.ffar[Frustum::COORD_BOTTOMLEFT], m_viewFrustum.fnear[Frustum::COORD_BOTTOMRIGHT]);
        }

        /// <summary>
        /// Transforms a point through the viewMatrix converting it from screen space to world space.
        /// </summary>
        /// <param name="position">The point to transform.</param>
        /// <returns>The provided point in the world.</returns>
        public virtual Vector2 ScreenToWorld(Vector2 position)
        {
            return Vector2.Transform(position, ViewMatrix.Inverted());
        }

        /// <summary>
        /// Transforms a point through the viewMatrix converting it from world space to screen space.
        /// </summary>
        /// <param name="position">The point to transform.</param>
        /// <returns>The provided point on the screen.</returns>
        public virtual Vector2 WorldToScreen(Vector2 position)
        {
            return Vector2.Transform(position, ViewMatrix);
        }

        /// <summary>
        /// Return a Rectangle which bounds the visible section of the game world.
        /// </summary>
        /// <returns>Rectangle bounding the visible section of the world.</returns>
        public Rectangle GetWorldBoundingRect()
        {
            return new Rectangle(
                Engine.Renderer.Camera.ScreenToWorld(Vector2.Zero),
                Engine.Renderer.Camera.ScreenToWorld(Engine.Renderer.DrawBuffer.Size) * 2
            );
        }
    }
}