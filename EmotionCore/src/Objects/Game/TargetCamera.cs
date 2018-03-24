﻿// Emotion - https://github.com/Cryru/Emotion

#region Using

using System;
using Emotion.Engine;
using Emotion.Objects.Bases;
using Emotion.Primitives;

#endregion

namespace Emotion.Objects.Game
{
    /// <summary>
    /// A camera which follows the target closely.
    /// </summary>
    public sealed class TargetCamera : Camera
    {
        /// <summary>
        /// The speed at which the camera should move. From 0 to 1, 0 being an immovable camera, and 1 being always at the target.
        /// </summary>
        public float Speed = 0.1f;

        public TargetCamera(Rectangle bounds) : base(bounds)
        {
           
        }

        public void Update(float frameTime)
        {
            // Check if no target.
            if (Target == null) return;

            // Smooth.
            float lx = GameMath.Lerp(Bounds.Center.X, Target.Bounds.X, GameMath.Clamp(Speed * frameTime, 0, 1));
            float ly = GameMath.Lerp(Bounds.Center.Y, Target.Bounds.Y, GameMath.Clamp(Speed * frameTime, 0, 1));

            Bounds.Center = new Vector2(lx, ly);
        }
    }
}