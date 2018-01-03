﻿// SoulEngine - https://github.com/Cryru/SoulEngine

#region Using

using System;
using Breath.Graphics;
using OpenTK;
using Soul.Engine;
using Soul.Engine.Enums;
using Soul.Engine.Modules;
using Soul.Engine.Objects;
using Functions = Soul.Engine.Functions;

#endregion

namespace Examples.Basic
{
    public class ShapeTest : Scene
    {
        public static void Main(string[] args)
        {
            // Start the engine.
            Core.Start(new ShapeTest(), "shapeTest");
        }

        public override void Initialize()
        {
            // Shapes.

            GameObject circle = new GameObject();
            circle.AddChild("circle", new BasicShape());
            circle.GetChild<BasicShape>("circle").Type = ShapeType.Circle;
            circle.Position = new Vector2(50, 50);
            circle.Size = new Vector2(50, 50);

            AddChild("circle", circle);

            //GameObject line = new GameObject();
            //line.AddChild("line", new BasicShape());
            //line.GetChild<BasicShape>("line").Type = ShapeType.Line;
            //line.Position = new Vector2(150, 50);
            //line.Size = new Vector2(200, 50);

            //AddChild("line", line);

            //GameObject rect = new GameObject();
            //rect.AddChild("rect", new BasicShape());
            //rect.GetChild<BasicShape>("rect").Type = ShapeType.Rectangle;
            //rect.Position = new Vector2(250, 50);
            //rect.Size = new Vector2(50, 50);

            //AddChild("rect", rect);

            //GameObject tri = new GameObject();
            //tri.AddChild("tri", new BasicShape());
            //tri.GetChild<BasicShape>("tri").Type = ShapeType.Triangle;
            //tri.Position = new Vector2(350, 50);
            //tri.Size = new Vector2(50, 50);

            //AddChild("tri", tri);

            //GameObject poly = new GameObject();
            //poly.AddChild("poly", new BasicShape());
            //poly.GetChild<BasicShape>("poly").Type = ShapeType.Polygon;
            //Vector2[] vert =
            //{
            //    new Vector2(9, -9), new Vector2(15, 7), new Vector2(2, 16), new Vector2(-6, 19), new Vector2(-19, 5),
            //    new Vector2(-20, -4), new Vector2(-11, -14), new Vector2(-4, -15), new Vector2(4, -15)
            //};
            //poly.GetChild<BasicShape>().PolygonVertices = vert;
            //poly.Position = new Vector2(450, 50);

            //AddChild("poly", poly);

            //// Spinning shapes.

            //GameObject spinCircle = new GameObject();
            //spinCircle.Position = new Vector2(50, 150);
            //spinCircle.Size = new Vector2(50, 50);
            //spinCircle.AddChild("spinCircle", new BasicShape(ShapeType.Circle));

            //AddChild("spinCircle", spinCircle);

            //GameObject spinLine = new GameObject();
            //spinLine.Position = new Vector2(150, 150);
            //spinLine.Size = new Vector2(200, 150);
            //spinLine.AddChild("spinLine", new BasicShape(ShapeType.Line));

            //AddChild("spinLine", spinLine);

            //GameObject spinRect = new GameObject();
            //spinRect.Position = new Vector2(250, 150);
            //spinRect.Size = new Vector2(50, 50);
            //spinRect.AddChild("spinRect", new BasicShape(ShapeType.Rectangle));

            //AddChild("spinRect", spinRect);

            //GameObject spinTri = new GameObject();
            //spinTri.Position = new Vector2(350, 150);
            //spinTri.Size = new Vector2(50, 50);
            //spinTri.AddChild("spinTri", new BasicShape(ShapeType.Triangle));

            //AddChild("spinTri", spinTri);

            //GameObject spinPoly = new GameObject();
            //spinPoly.Position = new Vector2(450, 150);
            //spinPoly.AddChild("spinPoly", new BasicShape(ShapeType.Polygon, vert));

            //AddChild("spinPoly", spinPoly);

            //// Spin the spinning objects with a script.
            //ScriptEngine.Expose("spinCircle", spinCircle);
            //ScriptEngine.Expose("spinLine", spinLine);
            //ScriptEngine.Expose("spinRect", spinRect);
            //ScriptEngine.Expose("spinTri", spinTri);
            //ScriptEngine.Expose("spinPoly", spinPoly);
            //ScriptEngine.RunScript("register(function() {" +
            //                       " spinCircle.Rotation += 0.1; " +
            //                       " spinLine.Rotation += 0.1; " +
            //                       " spinRect.Rotation += 0.1; " +
            //                       " spinTri.Rotation += 0.1; " +
            //                       " spinPoly.Rotation += 0.1; " +
            //                       "});");

            //// Color changing shapes

            //GameObject colorCircle = new GameObject();
            //colorCircle.AddChild("colorCircle", new BasicShape());
            //colorCircle.GetChild<BasicShape>("colorCircle").Type = ShapeType.Circle;
            //colorCircle.GetChild<BasicShape>("colorCircle").Color =
            //    new Color(Functions.GenerateRandomNumber(0, 255), Functions.GenerateRandomNumber(0, 255),
            //        Functions.GenerateRandomNumber(0, 255));
            //colorCircle.Position = new Vector2(50, 350);
            //colorCircle.Size = new Vector2(50, 50);

            //AddChild("colorCircle", colorCircle);

            //GameObject colorLine = new GameObject();
            //colorLine.AddChild("colorLine", new BasicShape());
            //colorLine.GetChild<BasicShape>("colorLine").Type = ShapeType.Line;
            //colorLine.GetChild<BasicShape>("colorLine").Color =
            //    new Color(Functions.GenerateRandomNumber(0, 255), Functions.GenerateRandomNumber(0, 255),
            //        Functions.GenerateRandomNumber(0, 255));
            //colorLine.Position = new Vector2(150, 350);
            //colorLine.Size = new Vector2(200, 350);

            //AddChild("colorLine", colorLine);

            //GameObject colorRect = new GameObject();
            //colorRect.AddChild("colorRect", new BasicShape());
            //colorRect.GetChild<BasicShape>("colorRect").Type = ShapeType.Rectangle;
            //colorRect.GetChild<BasicShape>("colorRect").Color =
            //    new Color(Functions.GenerateRandomNumber(0, 255), Functions.GenerateRandomNumber(0, 255),
            //        Functions.GenerateRandomNumber(0, 255));
            //colorRect.Position = new Vector2(250, 350);
            //colorRect.Size = new Vector2(50, 50);

            //AddChild("colorRect", colorRect);

            //GameObject colorTri = new GameObject();
            //colorTri.AddChild("colorTri", new BasicShape());
            //colorTri.GetChild<BasicShape>("colorTri").Type = ShapeType.Triangle;
            //colorTri.GetChild<BasicShape>("colorTri").Color =
            //    new Color(Functions.GenerateRandomNumber(0, 255), Functions.GenerateRandomNumber(0, 255),
            //        Functions.GenerateRandomNumber(0, 255));
            //colorTri.Position = new Vector2(350, 350);
            //colorTri.Size = new Vector2(50, 50);

            //AddChild("colorTri", colorTri);

            //GameObject colorPoly = new GameObject();
            //colorPoly.AddChild("colorPoly", new BasicShape());
            //colorPoly.GetChild<BasicShape>("colorPoly").Type = ShapeType.Polygon;
            //colorPoly.GetChild<BasicShape>("colorPoly").Color =
            //    new Color(Functions.GenerateRandomNumber(0, 255), Functions.GenerateRandomNumber(0, 255),
            //        Functions.GenerateRandomNumber(0, 255));
            //colorPoly.GetChild<BasicShape>().PolygonVertices = vert;
            //colorPoly.Position = new Vector2(450, 350);

            //AddChild("colorPoly", colorPoly);

            //// Textured Shapes.

            //GameObject texturedCircle = new GameObject();
            //texturedCircle.AddChild("circle", new BasicShape());
            //texturedCircle.GetChild<BasicShape>("circle").Type = ShapeType.Circle;
            //texturedCircle.GetChild<BasicShape>().AddChild("texture", new Texture("imageTest.png"));
            //texturedCircle.Position = new Vector2(50, 450);
            //texturedCircle.Size = new Vector2(50, 50);

            //AddChild("texturedCircle", texturedCircle);

            //GameObject texturedLine = new GameObject();
            //texturedLine.AddChild("line", new BasicShape());
            //texturedLine.GetChild<BasicShape>("line").Type = ShapeType.Line;
            //texturedLine.GetChild<BasicShape>().AddChild("texture", new Texture("imageTest.png"));
            //texturedLine.Position = new Vector2(150, 450);
            //texturedLine.Size = new Vector2(200, 450);

            //AddChild("texturedLine", texturedLine);

            //GameObject texturedRect = new GameObject();
            //texturedRect.AddChild("rect", new BasicShape());
            //texturedRect.GetChild<BasicShape>("rect").Type = ShapeType.Rectangle;
            //texturedRect.GetChild<BasicShape>().AddChild("texture", new Texture("imageTest.png"));
            //texturedRect.Position = new Vector2(250, 450);
            //texturedRect.Size = new Vector2(50, 50);

            //AddChild("texturedRect", texturedRect);

            //GameObject texturedTriangle = new GameObject();
            //texturedTriangle.AddChild("tri", new BasicShape());
            //texturedTriangle.GetChild<BasicShape>("tri").Type = ShapeType.Triangle;
            //texturedTriangle.GetChild<BasicShape>().AddChild("texture", new Texture("imageTest.png"));
            //texturedTriangle.Position = new Vector2(350, 450);
            //texturedTriangle.Size = new Vector2(50, 50);

            //AddChild("texturedTriangle", texturedTriangle);

            //GameObject texturedPoly = new GameObject();
            //texturedPoly.AddChild("poly", new BasicShape());
            //texturedPoly.GetChild<BasicShape>("poly").Type = ShapeType.Polygon;
            //texturedPoly.GetChild<BasicShape>().PolygonVertices = vert;
            //texturedPoly.GetChild<BasicShape>().AddChild("texture", new Texture("imageTest.png"));
            //texturedPoly.GetChild<BasicShape>().GetChild<Texture>().Animate(new Vector2(50, 50), 200);
            //texturedPoly.Position = new Vector2(450, 450);

            //AddChild("texturedPoly", texturedPoly);

            //// Change the shape colors with a script.
            //ScriptEngine.Expose("colorCircle", colorCircle);
            //ScriptEngine.Expose("colorLine", colorLine);
            //ScriptEngine.Expose("colorRect", colorRect);
            //ScriptEngine.Expose("colorTri", colorTri);
            //ScriptEngine.Expose("colorPoly", colorPoly);
            //ScriptEngine.Expose("ChangeColor", (Action<GameObject>) ChangeColor);
            //ScriptEngine.RunScript("register(function() {" +
            //                       " ChangeColor(colorCircle); " +
            //                       " ChangeColor(colorLine); " +
            //                       " ChangeColor(colorRect); " +
            //                       " ChangeColor(colorTri); " +
            //                       " ChangeColor(colorPoly); " +
            //                       "});");
        }

        public override void Update()
        {
        }

        public override void Draw()
        {

        }

        private void ChangeColor(GameObject obj)
        {
            obj.GetChild<BasicShape>().Color = new Color(obj.GetChild<BasicShape>().Color.R + 1,
                obj.GetChild<BasicShape>().Color.G + 1, obj.GetChild<BasicShape>().Color.B + 1);
        }
    }
}