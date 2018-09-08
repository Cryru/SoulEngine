﻿// Emotion - https://github.com/Cryru/Emotion

#region Using

using Emotion.Graphics;
using Emotion.Primitives;
using Soul;

#endregion

namespace Emotion.Game.UI
{
    public class ScrollInput : Control
    {
        #region Properties

        /// <summary>
        /// The color of the bar.
        /// </summary>
        public Color BarColor = Color.Black;

        /// <summary>
        /// The scroll input's selector.
        /// </summary>
        public ScrollInputSelector Selector;

        /// <summary>
        /// The current value of the input.
        /// </summary>
        public int Value { get; set; }

        #endregion

        public ScrollInput(Rectangle bounds, float priority) : base(bounds, priority)
        {
            Selector = new ScrollInputSelector(this, new Rectangle(), Z + 1);
        }

        public override void Init()
        {
            Controller.Add(Selector);
        }

        public override void Draw(Renderer renderer)
        {
            // Sync active states.
            Selector.Active = Active;

            // Clamp value.
            Value = (int) MathHelper.Clamp(Value, 0, 100);

            // Draw bar.
            renderer.Render(Position, new Vector2(Width, Height), BarColor);

            // Calculate selector.
            Rectangle selectorBounds = new Rectangle
            {
                Width = Bounds.Width / 100 * 6,
                Height = (int) (Bounds.Height + Bounds.Height * 0.1 * 2),
                Center = Bounds.Center
            };
            selectorBounds.X = Bounds.X + Bounds.Width / 100 * Value - selectorBounds.Width / 2;
            Selector.Bounds = selectorBounds;
        }

        public override void Destroy()
        {
            Controller.Remove(Selector);
            base.Destroy();
        }
    }
}