﻿#region Using

using System.Numerics;
using Emotion.Graphics;
using Emotion.Primitives;
using Emotion.UI;
using Emotion.Utility;

#endregion

namespace Emotion.Tools.Windows.UIEdit
{
    public class DebugUIController : UIController
    {
        public int DebugGridSize = 20;

        public DebugUIController()
        {
            Color = new Color(32, 32, 32);
        }

        protected override bool RenderInternal(RenderComposer c, ref Color windowColor)
        {
            if (!base.RenderInternal(c, ref windowColor)) return false;
            var scaledGridSize = (int) Maths.RoundClosest(DebugGridSize * GetScale());
            for (var y = 0; y < Size.Y; y += scaledGridSize)
            {
                for (var x = 0; x < Size.X; x += scaledGridSize)
                {
                    c.RenderOutline(new Rectangle(x, y, scaledGridSize, scaledGridSize), Color.White * 0.2f);
                }
            }

            Vector2 posVec2 = Position.ToVec2();
            c.RenderLine(posVec2 + new Vector2(Size.X / 2, 0), posVec2 + new Vector2(Size.X / 2, Size.Y), Color.White * 0.8f);
            c.RenderLine(posVec2 + new Vector2(0, Size.Y / 2), posVec2 + new Vector2(Size.X, Size.Y / 2), Color.White * 0.8f);
            return true;
        }
    }
}