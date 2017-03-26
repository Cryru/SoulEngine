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
        /// The opacity of the text.
        /// </summary>
        public float Opacity = 1f;
        #region "Bounds"
        /// <summary>
        /// Whether to lock the width to the Transform component's width.
        /// </summary>
        public bool LockWidth = true;
        /// <summary>
        /// The width of the text, based on the transform component's width if locked, and the screen size if not.
        /// </summary>
        public float Width
        {
            get
            {
                if (attachedObject.HasComponent<Transform>() && LockWidth)
                {
                    return attachedObject.Component<Transform>().Width;
                }
                else
                {
                    if (texture != null) { return texture.Width; } else return Settings.Width;
                }
            }
        }
        /// <summary>
        /// The height of the text.
        /// </summary>
        public int Height = 0;
        #endregion
        #endregion
        //Private variables.
        #region "Private"
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
            DrawPriority = 1;
        }
        /// <summary>
        /// 
        /// </summary>
        public ActiveText(string Text)
        {
            this.Text = Text;
            Font = AssetManager.DefaultFont;
            Style = TextStyle.Left;
            DrawPriority = 1;
        }
        /// <summary>
        /// 
        /// </summary>
        public ActiveText(string Text, SpriteFont Font)
        {
            this.Text = Text;
            this.Font = Font;
            Style = TextStyle.Left;
            DrawPriority = 1;
        }
        /// <summary>
        /// 
        /// </summary>
        public ActiveText(string Text, SpriteFont Font, TextStyle Style)
        {
            this.Text = Text;
            this.Font = Font;
            this.Style = Style;
            DrawPriority = 1;
        }
        #endregion

        //Main functions.
        #region "Functions"
        /// <summary>
        /// Composes the text texture.
        /// </summary>
        public override void Compose()
        {
            //Start composing on the render target.
            Context.ink.StartRenderTarget(ref texture, (int)Width, (int)Height);

            //Drawing offsets.
            float offsetX = 0;
            float offsetY = 0;

            //The space left on the current line.
            float spaceOnLine = Width - offsetX;

            //The current line.
            List<CharData> currentLine = new List<CharData>();

            //The tags in effect.
            List<Tag> tagStack = new List<Tag>();

            //Read through the text.
            for (int i = 0; i < Text.Length; i++)
            {
                //Get the current character.
                CharData current = new CharData(Text[i].ToString(), Color, offsetX, offsetY, Font);

                //Check if opening a tag.
                if (current.Content == "<")
                {
                    //Read the tag info.
                    string tagInfo;
                    i = ReadTag(i, out tagInfo);
                    //Process the collected tag.
                    ProcessTagStack(tagStack, tagInfo);
                    continue;
                }

                //Apply effects.
                for (int e = 0; e < tagStack.Count; e++)
                {
                    tagStack[e].Effect(current);
                }

                //Define a trigger for forcing a new line.
                bool newLine = false;

                //If the current character is space and it isn't the last character...
                if (current.Content == " " && i != Text.Length - 1)
                {
                    //Get the text between this space and the next.
                    string textBetweenCurrentCharAndNextSpace = "";
                    int locationOfNextSpace = Text.IndexOf(' ', i + 1);
                    if (locationOfNextSpace != -1)
                        textBetweenCurrentCharAndNextSpace = Text.Substring(i + 1, locationOfNextSpace - i - 1);
                    else
                        textBetweenCurrentCharAndNextSpace = Text.Substring(i + 1);

                    //Check if manual new line symbol is present between this and the next space.
                    if(textBetweenCurrentCharAndNextSpace.IndexOf('\n') != -1)
                    {
                        textBetweenCurrentCharAndNextSpace = textBetweenCurrentCharAndNextSpace.Substring(0, textBetweenCurrentCharAndNextSpace.IndexOf('\n'));
                    }


                    //Check if there is no space on the line for the next word, in which case force a new line.
                    if (spaceOnLine - stringWidth(" " + textBetweenCurrentCharAndNextSpace) < 0)
                    {
                        newLine = true;
                    }
                }

                //If the character is not a space and there is not enough space on the next line or it's a new line character, set offsets to new line.
                if ((current.Content != " " && spaceOnLine - stringWidth(current.Content) <= 0))
                {
                    //NEW LINE
                    offsetX = 0;
                    RenderLine(currentLine, offsetY, spaceOnLine);
                    currentLine.Clear();
                    offsetY += Font.MeasureString(" ").Y;
                }
                else if (current.Content == "\n")
                {
                    //NEW LINE
                    offsetX = 0;
                    RenderLine(currentLine, offsetY, spaceOnLine, true);
                    currentLine.Clear();
                    offsetY += Font.MeasureString(" ").Y;
                }

                //Add the character to the current line.
                currentLine.Add(current);

                //Update the offset.
                if (newLine)
                {
                    //NEW LINE
                    offsetX = 0;
                    RenderLine(currentLine, offsetY, spaceOnLine);
                    currentLine.Clear();
                    offsetY += Font.MeasureString(" ").Y;
                }
                else
                {
                    offsetX += Font.MeasureString(current.Content).X;
                }

                //Update the space on line variable.
                spaceOnLine = Width - offsetX;
            }

            //Check if any characters are left to be rendered.
            if (currentLine.Count > 0)
            {
                RenderLine(currentLine, offsetY, spaceOnLine);
            }

            //Stop composing.
            Context.ink.EndRenderTarget();


            //Set bounds cache.
            Height = (int) (offsetY + Font.MeasureString(" ").Y);
        }
        /// <summary>
        /// Draws the text texture that was composed based on cached data.
        /// </summary>
        public override void Draw()
        {
            //Check if empty texture, sometimes it happens.
            if (Texture == null) return;

            //Get some drawing properties.
            int X = attachedObject.GetProperty("X", 0);
            int Y = attachedObject.GetProperty("Y", 0);
            SpriteEffects MirrorEffects = attachedObject.GetProperty("MirrorEffects", SpriteEffects.None);
            int Width = attachedObject.GetProperty("Width", Texture.Width);
            int Height = attachedObject.GetProperty("Height", Texture.Height);
            float Rotation = attachedObject.GetProperty("Rotation", 0f);

            Rectangle DrawBounds = new Rectangle(X, Y, Width, Height);

            //Correct bounds to center origin.
            DrawBounds = new Rectangle(new Point((DrawBounds.X + DrawBounds.Width / 2),
                (DrawBounds.Y + DrawBounds.Height / 2)),
                new Point(DrawBounds.Width, DrawBounds.Height));

            //Draw the object through XNA's SpriteBatch.
            Context.ink.Draw(Texture,
                DrawBounds,
                null,
                Color * Opacity,
                Rotation,
                new Vector2((float)Texture.Width / 2, (float)Texture.Height / 2),
                MirrorEffects,
                1.0f);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Update()
        {

        }
        #endregion

        #region "Internal Functions"
        /// <summary>
        /// Returns the width of a string.
        /// </summary>
        /// <param name="line">The string to measure.</param>
        /// <returns>The width of the input string.</returns>
        private int stringWidth(string text)
        {
            return (int) Math.Ceiling(Font.MeasureString(text).X);
        }
        /// <summary>
        /// Render the provided character data as a line.
        /// </summary>
        /// <param name="currentLine">The current line as a list of character data.</param>
        /// <param name="offsetY">The vertical offset of the line.</param>
        private void RenderLine(List<CharData> currentLine, float offsetY, float spaceOnLine, bool manualNewLine = false)
        {
            float offsetX = 0;
            float wordSpacing = 0.1f;

            string lineAsString = "";

            for (int i = 0; i < currentLine.Count; i++)
            {
                lineAsString += currentLine[i].Content;
            }

            //Calculate style offsets.
            switch (Style)
            {
                case TextStyle.Right:
                    offsetX = spaceOnLine;
                    break;
                case TextStyle.Center:
                    offsetX = spaceOnLine / 2;
                    break;
                case TextStyle.Justified:
                    //If manually going to a new line then don't apply justification.
                    if(!manualNewLine)
                    {
                        float lineWidth = Width - spaceOnLine;
                        float a = lineAsString.Count(x => x == ' ');
                        float b = wordSpacing * a;
                        if (b != 0)
                        {
                            while (lineWidth + b < Width && wordSpacing < 5)
                            {
                                wordSpacing += 0.1f;
                                b = wordSpacing * a;
                            }
                        }
                    }
                    break;
                default:
                    offsetX = 0;
                    break;
            }

            //Render the line.
            for (int i = 0; i < currentLine.Count; i++)
            {
                Context.ink.DrawString(Font, currentLine[i].Content, new Vector2(offsetX, offsetY), currentLine[i].Color);
                offsetX += Font.MeasureString(currentLine[i].Content).X;
                //Add word spacing if going to the next word.
                if (currentLine[i].Content == " ") offsetX += wordSpacing;
            }
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
            if (identifier == "/")
            {
                if (TagStack.Count > 0) TagStack.RemoveAt(TagStack.Count - 1);
            }
            else
                TagStack.Add(TagFactory.Build(identifier, data));
        }
        #endregion
    }
}
