﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoulEngine.Objects.Components.Helpers
{
    //////////////////////////////////////////////////////////////////////////////
    // SoulEngine - A game engine based on the MonoGame Framework.              //
    // Public Repository: https://github.com/Cryru/SoulEngine                   //
    //////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Render data about a single character.
    /// </summary>
    public class CharData
    {
        public Color Color;
        public string Content;
        public SpriteFont Font;

        public List<Tag> Tags = new List<Tag>();

        public CharData(string Content, Color Color, SpriteFont Font)
        {
            this.Content = Content;
            this.Color = Color;
            this.Font = Font;
        }
    }
}
