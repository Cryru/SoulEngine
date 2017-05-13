﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoulEngine.Events;

namespace SoulEngine.Objects.Components
{
    public class Box : DrawComponent
    {
        #region "Declarations"
        #region "Styles"
        /// <summary>
        /// Box textures.
        /// </summary>
        public Texture2D TopLeft;
        public Texture2D HorizontalTop;
        public Texture2D TopRight;
        public Texture2D VerticalRight;
        public Texture2D BottomRight;
        public Texture2D HorizontalBottom;
        public Texture2D BottomLeft;
        public Texture2D VerticalLeft;
        public Texture2D Fill;
        #endregion
        #region "Objects"
        /// <summary>
        /// The parent of the component but as a UIObject.
        /// </summary>
        private UIObject Parent
        {
            get
            {
                return (UIObject)attachedObject;
            }
        }
        /// <summary>
        /// Attached children objects.
        /// </summary>
        private List<GameObject> Children;
        #endregion
        #endregion

        public override void Initialize()
        {
            //Check if object we are attaching to is on the UI layer.
            if (Parent.Layer != Enums.ObjectLayer.UI) throw new Exception("Cannot attach UI component to an object not on the UI layer!");

            //Default styles.
            TopLeft = AssetManager.BlankTexture;
            HorizontalTop = AssetManager.BlankTexture;
            TopRight = AssetManager.BlankTexture;
            VerticalRight = AssetManager.BlankTexture;
            BottomRight = AssetManager.BlankTexture;
            HorizontalBottom = AssetManager.BlankTexture;
            BottomLeft = AssetManager.BlankTexture;
            VerticalLeft = AssetManager.BlankTexture;
            Fill = AssetManager.BlankTexture;

            //Create children array.
            Children = new List<GameObject>();
        }

        /// <summary>
        /// Assign an object to be a child of the box.
        /// </summary>
        /// <param name="Object">The object to take in.</param>
        public void AssignObject(GameObject Object)
        {
            Children.Add(Object);
        }

        public override void Update()
        {
            for (int i = 0; i < Children.Count; i++)
            {
                Children[i].Drawing = Parent.Drawing;
            }
        }

        #region "Event Handlers"
        public override void Draw()
        {
            //Draw top horizontal line.
            for (int i = TopLeft.Width; i <= Parent.Width - HorizontalTop.Width; i+= HorizontalTop.Width)
            {
                DrawTexture(HorizontalTop, new Vector2(i, 0));
            }

            //Draw left vertical line.
            for (int i = TopLeft.Height; i <= Parent.Height - VerticalLeft.Height; i += VerticalLeft.Height)
            {
                DrawTexture(VerticalLeft, new Vector2(0, i));
            }

            //Draw right vertical line.
            for (int i = TopRight.Height; i <= Parent.Height - VerticalRight.Height; i += VerticalRight.Height)
            {
                DrawTexture(VerticalRight, new Vector2(Parent.Width - VerticalRight.Width, i));
            }

            //Draw bottom horizontal line.
            for (int i = BottomLeft.Width; i <= Parent.Width - HorizontalBottom.Width; i += HorizontalBottom.Width)
            {
                DrawTexture(HorizontalBottom, new Vector2(i, Parent.Height - HorizontalBottom.Height));
            }

            //Draw top left corner.
            DrawTexture(TopLeft, new Vector2(0, 0));

            //Draw top right corner.
            DrawTexture(TopRight, new Vector2(Parent.Width - TopRight.Width, 0));

            //Draw bottom left.
            DrawTexture(BottomLeft, new Vector2(0, Parent.Height - BottomLeft.Height));

            //Draw bottom right.
            DrawTexture(BottomRight, new Vector2(Parent.Width - BottomRight.Width, Parent.Height - BottomRight.Height));

            //Draw fill.
            Rectangle FillBounds = new Rectangle();

            FillBounds.X = Parent.X + VerticalLeft.Width;
            FillBounds.Y = Parent.Y + HorizontalTop.Height;
            FillBounds.Width = Parent.Width - VerticalLeft.Width - VerticalRight.Width;
            FillBounds.Height = Parent.Height - HorizontalBottom.Height - HorizontalTop.Height;

            Draw(FillBounds.Width, FillBounds.Height, FillBounds.X, FillBounds.Y, Fill);

        }
        private void DrawTexture(Texture2D Texture, Vector2 Position)
        {
            Position.X += Parent.X;
            Position.Y += Parent.Y;

            Draw(Texture.Width, Texture.Height, (int) Position.X, (int) Position.Y, Texture);
        }
        #endregion
    }
}
