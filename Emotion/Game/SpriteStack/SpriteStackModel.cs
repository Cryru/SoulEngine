﻿#region Using

using System;
using System.Numerics;
using Emotion.Graphics;
using Emotion.Graphics.Batches;
using Emotion.Graphics.Data;
using Emotion.Primitives;
using Emotion.Utility;

#endregion

namespace Emotion.Game.SpriteStack
{
    public class SpriteStackModel : Transform, IRenderable
    {
        public float Depth
        {
            get => _depth;
            set
            {
                if (value == _depth) return;
                _depth = value;
                Resized();
            }
        }

        private float _depth = 1;

        public float Scale
        {
            get
            {
                if (_width == _height && _height == _depth) return _width;
                return 0;
            }
            set
            {
                _width = value;
                _height = value;
                _depth = value;
                Resized();
            }
        }

        public Vector3 Rotation
        {
            get => _rotationRad;
            set
            {
                if (_rotationRad == value) return;
                _rotationRad = value;
                Rotated();
            }
        }

        public Vector3 RotationDeg
        {
            get => new Vector3(Maths.RadiansToDegrees(_rotationRad.X), Maths.RadiansToDegrees(_rotationRad.Y), Maths.RadiansToDegrees(_rotationRad.Z));
            set
            {
                _rotationRad = new Vector3(Maths.DegreesToRadians(value.X), Maths.DegreesToRadians(value.Y), Maths.DegreesToRadians(value.Z));
                Rotated();
            }
        }

        private Vector3 _rotationRad;

        public event EventHandler OnRotate;

        protected override void Resized()
        {
            _scaleMatrix = Matrix4x4.CreateScale(_width, _height, _depth);
            base.Resized();
        }

        protected override void Moved()
        {
            _translationMatrix = Matrix4x4.CreateTranslation(_x, _y, _z);
            base.Moved();
        }

        protected virtual void Rotated()
        {
            _rotationMatrix = Matrix4x4.CreateFromYawPitchRoll(_rotationRad.Y, _rotationRad.X, _rotationRad.Z);
            OnRotate?.Invoke(this, EventArgs.Empty);
        }

        private Matrix4x4 _rotationMatrix;
        private Matrix4x4 _scaleMatrix;
        private Matrix4x4 _translationMatrix;

        public SpriteStackFrame[] Frames;
        public int FrameWidth;
        public int FrameHeight;

        public SpriteStackModel(SpriteStackFrame[] frames, int frameWidth, int frameHeight)
        {
            Frames = frames;
            FrameWidth = frameWidth;
            FrameHeight = frameHeight;

            _width = 1;
            _height = 1;
            Resized();
            Moved();
        }

        public void Render(RenderComposer c)
        {
            c.PushModelMatrix(_rotationMatrix * _scaleMatrix * _translationMatrix);

            for (var i = 0; i < Frames.Length; i++)
            {
                SpriteStackFrame frame = Frames[i];
                Span<VertexData> vertData = frame.Vertices;
                Span<VertexData> vertices = c.RenderStream.GetStreamMemory((uint) vertData.Length, BatchMode.SequentialTriangles);
                vertData.CopyTo(vertices);
            }

            c.PopModelMatrix();
        }
    }
}