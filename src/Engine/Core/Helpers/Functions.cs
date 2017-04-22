﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SoulEngine.Events;
using SoulEngine.Enums;
using System;
using System.Linq;
using System.Globalization;
using System.IO;
using SoulEngine.Objects;

namespace SoulEngine
{
    //////////////////////////////////////////////////////////////////////////////
    // SoulEngine - A game engine based on the MonoGame Framework.              //
    // Public Repository: https://github.com/Cryru/SoulEngine                   //
    //////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Engine functions.
    /// </summary>
    static class Functions
    {
        #region "Screen Functions"
        /// <summary>
        /// Returns the size of the primary physical screen.
        /// </summary>
        public static Vector2 GetScreenSize()
        {
            return new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);
        }

        /// <summary>
        /// Returns the number that corresponds to the provided number scaled by the current resolution.
        /// </summary>
        /// <param name="NumToScale">The number to scale.</param>
        /// <param name="DefaultSize">The smaller side of the default resolution.</param>
        /// <returns></returns>
        public static int ManualRatio(int NumToScale, int DefaultSize)
        {
            int smallerNum = Math.Min(Settings.Width, Settings.Height);

            return (NumToScale * smallerNum) / DefaultSize;
        }
        #endregion

        #region "Extensions"
        /// <summary>
        /// Starts drawing on the specified channel. 
        /// </summary>
        /// <param name="ink">The spritebatch to use.</param>
        /// <param name="DrawChannel">The channel to render on.</param>
        /// <param name="Parallax">Parallax factor for the World channel.</param>
        public static void Start(this SpriteBatch ink, DrawChannel DrawChannel = DrawChannel.Terminus, Vector2? Parallax = null)
        {
            //Define a render matrix to determine later, by default it's null.
            Matrix? transformationMatrix = null;

            //Determine which channel we are rendering on, and get its matrix.
            switch (DrawChannel)
            {
                case DrawChannel.Screen:
                    transformationMatrix = Context.Screen.View;
                    break;
                case DrawChannel.World: //If on the world channel then check for parallax.
                    if (Parallax != null)
                        transformationMatrix = Context.Camera.ViewParallax(Parallax.Value);
                    else
                        transformationMatrix = Context.Camera.View;
                    break;
            }

            //Start drawing.
            if (Settings.AntiAlias)
                ink.Begin(SpriteSortMode.Deferred, null, null, null, RasterizerState.CullNone, null, transformationMatrix);
            else
                ink.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, RasterizerState.CullNone, null, transformationMatrix);
        }

        /// <summary>
        /// Start drawing on the provided render target.
        /// </summary>
        /// <param name="ink">The spritebatch to use.</param>
        /// <param name="Target">The render target to render on.</param>
        /// <param name="Width">The desired width of the render target.</param>
        /// <param name="Height">The desired height of the render target.</param>
        /// <param name="Force">Whether to force the target to be redefined.</param>
        public static void StartRenderTarget(this SpriteBatch ink, ref RenderTarget2D Target, int Width = 0, int Height = 0, bool Force = false)
        {
            if (!Context.Core.__composeAllowed) throw new Exception("Cannot compose outside of the frame start sequence.");

            //Redefine target if needed.
            if ((Width != 0 && Height != 0) || Force) DefineTarget(ref Target, Width, Height);

            //Set the current rendertarget to the drawer.
            Context.Graphics.SetRenderTarget(Target);

            //Clear the rendertarget.
            Context.Graphics.Clear(Color.Transparent);

            //Start drawing.
            ink.Start();
        }

        /// <summary>
        /// Stop drawing and return the render target. 
        /// </summary>
        /// <param name="ink">The spritebatch to use.</param>
        public static void EndRenderTarget(this SpriteBatch ink)
        {
            //Start drawing.
            ink.End();

            //Return to the default render target.
            Context.Graphics.SetRenderTarget(null);

            //Return the viewport holder.
            Context.Screen.Update();
        }

        /// <summary>
        /// Returns a portion of an array.
        /// </summary>
        /// <param name="data">The array.</param>
        /// <param name="index">The starting location, included.</param>
        /// <param name="length">The length of the range, if -1 then until the length is until the end array.</param>
        public static T[] SubArray<T>(this T[] data, int index, int length = -1)
        {
            if (length == -1) length = data.Length - index;

            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        /// <summary>
        /// Creates a color from a string.
        /// </summary>
        /// <param name="color">The color object.</param>
        /// <param name="String">The string to parse.</param>
        /// <param name="Separator"></param>
        /// <returns></returns>
        public static Color fromString(this Color color, string String, char Separator = '-')
        {
            try
            {
                if (String.Contains("#"))
                {
                    String = String.Replace("#", "");
                    byte r = byte.Parse(String.Substring(0, 2), NumberStyles.HexNumber);
                    byte g = byte.Parse(String.Substring(2, 2), NumberStyles.HexNumber);
                    byte b = byte.Parse(String.Substring(4, 2), NumberStyles.HexNumber);
                    return new Color(r, g, b);
                }
                else
                {
                    int[] args = String.Split(Separator).Select(x => int.Parse(x)).ToArray();
                    return color = new Color(args[0], args[1], args[2]);
                }
            }
            catch (Exception)
            {
                Debugging.Logger.Add("Invalid color argument: " + String);
                return color = new Color(0, 0, 0, 0);
            }
        }

        /// <summary>
        /// Creates a rectangle from two vectors.
        /// </summary>
        /// <param name="Location">The coordinate location of the rectangle.</param>
        /// <param name="Size">The size of the rectangle.</param>
        public static Rectangle fromVectors(this Rectangle Rectangle, Vector2 Location, Vector2 Size)
        {
            return new Rectangle(Location.ToPoint(), Size.ToPoint());
        }

        /// <summary>
        /// Returns whether the Vector2 is within the Rectangle. 
        /// </summary>
        /// <param name="Point">The point to check for intersection.</param>
        public static bool Intersects(this Rectangle Rectangle, Vector2 Point)
        {
            return Rectangle.Intersects(new Rectangle().fromVectors(Point, new Vector2(1, 1)));
        }
        #endregion

        #region "Ink Primitives Drawing"
        /// <summary>
        /// Draws a hollow rectangle.
        /// </summary>
        /// <param name="Rectangle">The rectangle to draw.</param>
        /// <param name="Width">The width of the outline.</param>
        /// <param name="Color">The color of the outline.</param>
        static public void DrawRectangle(this SpriteBatch ink, Rectangle Rectangle, int Width = 1, Color Color = new Color())
        {
            if (Color == new Color()) Color = Color.White;

            //Draw the sides as lines.
            Context.ink.DrawLine(new Vector2(Rectangle.X, Rectangle.Y), new Vector2(Rectangle.Width, Rectangle.Y), Width, Color);
            Context.ink.DrawLine(new Vector2(Rectangle.Width, Rectangle.Y), new Vector2(Rectangle.Width, Rectangle.Height), Width, Color);
            Context.ink.DrawLine(new Vector2(Rectangle.Width, Rectangle.Height), new Vector2(Rectangle.X, Rectangle.Height), Width, Color);
            Context.ink.DrawLine(new Vector2(Rectangle.X, Rectangle.Height), new Vector2(Rectangle.X, Rectangle.Y), Width, Color);
        }

        /// <summary>
        /// Draws a hollow circle.
        /// </summary>
        /// <param name="Center">The center of the circle.</param>
        /// <param name="Radius">The radius of the circle.</param>
        /// <param name="Width">The width of the outline.</param>
        /// <param name="Color">The color of the outline.</param>
        /// <param name="Detail">How smooth the circle should be.</param>
        public static void DrawCircle(this SpriteBatch ink, Vector2 Center, float Radius, int Width = 1, Color Color = new Color(), int Detail = 64)
        {
            if (Color == new Color()) Color = Color.White;

            //Build a circle polygon based on the requested detail and draw it as a polygon.
            Vector2[] vertex = new Vector2[Detail];

            double increment = Math.PI * 2.0 / Detail;
            double theta = 0.0;

            for (int i = 0; i < Detail; i++)
            {
                vertex[i] = Center + Radius * new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta));
                theta += increment;
            }

            Context.ink.DrawPolygon(vertex, Width, Color);
        }

        /// <summary>
        /// Draws a hollow polygon shape.
        /// </summary>
        /// <param name="Vertex">The vertex of the polygon.</param>
        /// <param name="Width">The width of the outline.</param>
        /// <param name="Color">The color of the outline.</param>
        public static void DrawPolygon(this SpriteBatch ink, Vector2[] Vertex, int Width = 1, Color Color = new Color())
        {
            if (Vertex.Length > 0)
            {
                for (int i = 0; i < Vertex.Length - 1; i++)
                {
                    Context.ink.DrawLine(Vertex[i], Vertex[i + 1], Width, Color);
                }
                Context.ink.DrawLine(Vertex[Vertex.Length - 1], Vertex[0], Width, Color);
            }
        }

        /// <summary>
        /// Draws a line between two points.
        /// </summary>
        /// <param name="Start"></param>
        /// <param name="End"></param>
        /// <param name="Width"></param>
        /// <param name="Color"></param>
        public static void DrawLine(this SpriteBatch ink, Vector2 Start, Vector2 End, int Width = 1, Color Color = new Color())
        {
            if (Color == new Color()) Color = Color.White;

            //To draw a line we stretch and rotate a texture.
            Vector2 edge = End - Start;
            float angle = (float)Math.Atan2(edge.Y, edge.X);
            float length = Vector2.Distance(Start, End);

            Context.ink.Draw(AssetManager.BlankTexture, Start, null, Color, angle, Vector2.Zero, new Vector2(length, Width), SpriteEffects.None, 0f);
        }
        #endregion

        #region "Others"
        /// <summary>
        /// Defines or redefines the provided render target to it's specified dimensions.
        /// </summary>
        /// <param name="Target">The render target to define or redefine.</param>
        /// <param name="Width">The desired width of the target.</param>
        /// <param name="Height">The desired height of the target.</param>
        public static void DefineTarget(ref RenderTarget2D Target, int Width = 0, int Height = 0)
        {
            //Check if the render target is the same size as the draw area, because if it's not we need to redefine it.
            if (!(Target == null ||
                Width != Target.Bounds.Size.X ||
                Height != Target.Bounds.Size.Y)) return;

            //Destroy previous render target safely, if any.
            if (Target != null) Target.Dispose();

            //Generate a new rendertarget with the specified size. (Through the optimization engine.)
            Target = new RenderTarget2D(Context.Graphics, Width, Height);
        }

        /// <summary>
        /// Generates a stream from a string.
        /// </summary>
        /// <param name="String">The string to convert to a stream.</param>
        /// <returns></returns>
        public static Stream StreamFromString(string String)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(String);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        /// <summary>
        /// The generator to be used for generating randomness.
        /// </summary>
        private static Random generator = new Random();

        /// <summary>
        /// Returns a randomly (tm) generated number within specified constraints.
        /// </summary>
        /// <param name="Min">The lowest number that can be generated.</param>
        /// <param name="Max">The highest number that can be generated.</param>
        /// <returns></returns>
        public static int generateRandomNumber(int Min = 0, int Max = 100)
        {
            return generator.Next(Min, Max + 1); //We add one because by Random.Next does not include max.
        }
        #endregion

        #region "Wrappers"
        /// <summary>
        /// Executes the requested action after a set interval of time.
        /// </summary>
        /// <param name="Time">The time to wait before executing the action.</param>
        /// <param name="Action">The action to execute.</param>
        public static void queueAction(int Time, Action Action)
        {
            Ticker temp = new Ticker(Time, 1, true);
            temp.OnDone += new QueuedAction(Action).EventWrapper;
        }
        #endregion
    }

    /// <summary>
    /// Wrapper for the queueAction function.
    /// </summary>
    class QueuedAction
    {
        Action Action;

        public QueuedAction(Action Action)
        {
            this.Action = Action;
        }

        public void EventWrapper(object sender, EventArgs e)
        {
            Action?.Invoke();
        }
    }
}