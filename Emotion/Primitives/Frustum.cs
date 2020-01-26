#region Using

using System.Numerics;

#endregion

namespace Emotion.Primitives
{
    public class Plane
    {
        public Vector3 Abc;

        public float D;

        public Plane(Vector3 p, Vector3 p1, Vector3 p2)
        {
            Vector3 v1 = p1 - p;
            Vector3 v2 = p2 - p;

            Abc = Vector3.Normalize(Vector3.Cross(v1, v2));

            D = -Vector3.Dot(p, Abc);
        }

        public float Distance(Vector3 point)
        {
            return Abc.X * point.X + Abc.Y * point.Y + Abc.Z * point.Z + D;
        }
    }

    public class Frustum
    {
        /// <summary>
        /// The four vertices of the near plane.
        /// </summary>
        public Vector3[] Near = new Vector3[4];

        /// <summary>
        /// The four vertices of the far plane.
        /// </summary>
        public Vector3[] Far = new Vector3[4];

        /// <summary>
        /// The center of the frustum.
        /// </summary>
        public Vector3 Center = Vector3.Zero;

        /// <summary>
        /// The planes of the frustum in this order:
        /// Left, right, bottom, top, near, far.
        /// </summary>
        public Plane[] Planes = new Plane[6];

        public bool Intersects(Vector3 point)
        {
            for (var i = 0; i < 6; i++)
            {
                if (Planes[i].Distance(point) > 0) return false;
            }

            return true;
        }

        public bool Intersects(Transform transform)
        {
            var transformSize3D = new Vector3(transform.Size, transform.Z);

            for (var p = 0; p < 6; p++)
            {
                if (Planes[p].Distance(transform.Position) < 0)
                    continue;
                if (Planes[p].Distance(transformSize3D) < 0)
                    continue;
                return false;
            }

            return true;
        }
    }
}