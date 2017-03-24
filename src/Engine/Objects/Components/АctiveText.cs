﻿using Microsoft.Xna.Framework;
using SoulEngine.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoulEngine.Events;
using Microsoft.Xna.Framework.Graphics;
using SoulEngine.Enums;
using SoulEngine.Objects.Components.Helpers;

namespace SoulEngine.Objects.Components
{
    //////////////////////////////////////////////////////////////////////////////
    // SoulEngine - A game engine based on the MonoGame Framework.              //
    // Public Repository: https://github.com/Cryru/SoulEngine                   //
    //////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Location, Size, and Rotation.
    /// </summary>
    public class ActiveText : Component
    {
        #region "Declarations"
        //Main variables.
        #region "Primary"
        /// <summary>
        /// 
        /// </summary>
        public string Text = "";
        /// <summary>
        /// 
        /// </summary>
        public SpriteFont Font;
        /// <summary>
        /// 
        /// </summary>
        public TextStyle Style;
        /// <summary>
        /// The default text color.
        /// </summary>
        public Color Color = Color.White;
        /// <summary>
        /// Scale the transform component (if any) according to the text's size.
        /// </summary>
        public bool AutoSizeWidth = false;
        public bool AutoSizeHeight = false;
        /// <summary>
        /// The width of the text.
        /// </summary>
        public float Width
        {
            get
            {
                if (attachedObject.HasComponent<Transform>() && !AutoSizeWidth)
                {
                    return attachedObject.Component<Transform>().Width;
                }
                else
                {
                    return width;
                }
            }
        }
        /// <summary>
        /// The height of the text.
        /// </summary>
        public float Height
        {
            get
            {
                if (attachedObject.HasComponent<Transform>() && !AutoSizeHeight)
                {
                    return attachedObject.Component<Transform>().Height;
                }
                else
                {
                    return height;
                }
            }
        }
        #endregion
        //Private variables.
        #region "Private"
        private float width;
        private float height;
        #endregion
        #region "Processed Text Data"
        /// <summary>
        /// The text composed to a texture.
        /// </summary>
        public Texture2D Texture
        {
            get
            {
                return texture as Texture2D;
            }
        }
        private RenderTarget2D texture;
        #endregion
        #endregion

        #region "Initialization"
        /// <summary>
        /// 
        /// </summary>
        public ActiveText()
        {
            Text = "";
            Font = AssetManager.DefaultFont;
            Style = TextStyle.Left;
        }
        /// <summary>
        /// 
        /// </summary>
        public ActiveText(string Text)
        {
            this.Text = Text;
            Font = AssetManager.DefaultFont;
            Style = TextStyle.Left;
        }
        /// <summary>
        /// 
        /// </summary>
        public ActiveText(string Text, SpriteFont Font)
        {
            this.Text = Text;
            this.Font = Font;
            Style = TextStyle.Left;
        }
        /// <summary>
        /// 
        /// </summary>
        public ActiveText(string Text, SpriteFont Font, TextStyle Style)
        {
            this.Text = Text;
            this.Font = Font;
            this.Style = Style;
        }
        #endregion

        //Main functions.
        #region "Functions"
        public override void Compose()
        {
            //Start composing on the render target.
            Context.ink.StartRenderTarget(ref texture, (int)Width, (int)Height);

            //Drawing offsets.
            float offsetX = 0;
            float offsetY = 0;

            //The space left on the current line.
            float spaceOnLine = Width - offsetX;

            //The character data that is modified by effects.
            CharData current = new CharData(Color);

            //The tags in effect.
            List<Tag> tagStack = new List<Tag>();

            //Read through the text.
            for (int i = 0; i < Text.Length; i++)
            {
                //Get the current and previous character.
                string curChar = Text[i].ToString();

                //Check if opening a tag.
                if (curChar == "<")
                {
                    //Read the tag info.
                    string tagInfo;
                    i = ReadTag(i, out tagInfo);
                    //Process the collected tag.
                    ProcessTagStack(tagStack, tagInfo);
                    continue;
                }

                //Apply effects.
                current.Color = Color;
                for (int e = 0; e < tagStack.Count; e++)
                {
                    tagStack[e].Effect(current);
                }

                //Define a trigger for forcing a new line.
                bool newLine = false;

                //If the current character is space and it isn't the last character...
                if(curChar == " " && i != Text.Length - 1)
                {
                    //Get the text between this space and the next.
                    string textBetweenCurrentCharAndNextSpace = "";
                    int locationOfNextSpace = Text.IndexOf(' ', i + 1);
                    if(locationOfNextSpace != -1)
                        textBetweenCurrentCharAndNextSpace = Text.Substring(i + 1, locationOfNextSpace - i - 1);

                    //Check if there is no space on the line for the next word, in which case force a new line.
                    if (spaceOnLine - stringWidth(textBetweenCurrentCharAndNextSpace) < 0)
                    {
                        newLine = true;
                    }
                }

                //If the character is not a space and there is not enough space on the next line or it's a new line character, set offsets to new line.
                if ((curChar != " " && spaceOnLine - stringWidth(curChar) <= 0) || curChar == "\n")
                {
                    offsetX = 0;
                    offsetY += Font.MeasureString(" ").Y;
                }

                
                //Render character.
                Context.ink.DrawString(Font, curChar, new Vector2(offsetX, offsetY), current.Color);

                //Update the offset.
                if(newLine)
                {
                    offsetX = 0;
                    offsetY += Font.MeasureString(" ").Y;
                }
                else
                {
                    offsetX += Font.MeasureString(curChar).X;
                }

                //Update the space on line variable.
                spaceOnLine = Width - offsetX;
            }

            //Stop composing.
            Context.ink.EndRenderTarget();
        }

        /// <summary>
        /// Read the tag.
        /// </summary>
        /// <param name="Position">The position of the tag opening character.</param>
        /// <param name="TagInformation">The collected tag's information.</param>
        /// <returns>The position of the tag closing character</returns>
        private int ReadTag(int Position, out string TagInformation)
        {
            TagInformation = "";

            //Read through the text from the position of the opening character.
            for (int i = Position + 1; i < Text.Length; i++)
            {
                //If the character is the closing tag return the position to continue reading after it. 
                //It's incremented by one by the 'continue' statement.
                if (Text[i] == '>') return i;

                //Add the character to the tag's information.
                TagInformation += Text[i];
            }

            //If a closing character is not found then everything up to the text's ending is considered part of the tag.
            return Text.Length - 1;
        }

        /// <summary>
        /// Updates the tag stack with new tag information.
        /// </summary>
        /// <param name="TagStack">The collected tags,</param>
        /// <param name="TagInformation">The tag information to process. Shouldn't include the opening and closing characters.</param>
        private void ProcessTagStack(List<Tag> TagStack, string TagInformation)
        {
            //Check if the tag information collected contains data in addition to the identifier and separate them if so.
            string identifier = TagInformation.Contains("=") ? TagInformation.Split('=')[0] : TagInformation;
            string data = TagInformation.Contains("=") ? TagInformation.Split('=')[1] : "";

            //Check if ending tag, if yes remove the last tag.
            if(identifier == "/")
            { 
                if(TagStack.Count > 0) TagStack.RemoveAt(TagStack.Count - 1);
            }
            else
                 TagStack.Add(TagFactory.Build(identifier, data));        
        }
        #endregion

        #region "Internal Functions"
        /// <summary>
        /// Returns the width of a string.
        /// </summary>
        /// <param name="line">The string to measure.</param>
        /// <returns>The width of the input string.</returns>
        private float stringWidth(string text)
        {
            return Font.MeasureString(text).X;
        }
        #endregion

        //Other
        #region "Component Interface"
        public override void Draw() { }
        public override void Update() { }
        #endregion
    }
}
