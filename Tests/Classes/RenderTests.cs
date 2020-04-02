﻿#region Using

using System.Numerics;
using Emotion.Common;
using Emotion.Game.Text;
using Emotion.Game.Tiled;
using Emotion.Graphics;
using Emotion.Graphics.Batches;
using Emotion.Graphics.Objects;
using Emotion.IO;
using Emotion.Primitives;
using Emotion.Test;
using Tests.Results;

#endregion

namespace Tests.Classes
{
    /// <summary>
    /// Tests concerning the rendering and not the composer itself.
    /// </summary>
    [Test]
    public class RenderTests
    {
        /// <summary>
        /// Tests the basic text drawing functionality of the composer.
        /// </summary>
        [Test]
        public void RenderText()
        {
            var asset = Engine.AssetLoader.Get<FontAsset>("Fonts/1980XX.ttf");

            Runner.ExecuteAsLoop(_ =>
            {
                RenderComposer composer = Engine.Renderer.StartFrame();
                composer.RenderString(new Vector3(10, 10, 0), Color.Red, "The quick brown fox jumps over the lazy dog.\n123456789!@#$%^&*(0", asset.GetAtlas(20));
                Engine.Renderer.EndFrame();
                Runner.VerifyScreenshot(ResultDb.ComposerRenderText);
            }).WaitOne();
        }

        /// <summary>
        /// Tests the rendering of RichText. This also tests batch caching.
        /// </summary>
        [Test]
        public void RenderRichText()
        {
            var asset = Engine.AssetLoader.Get<FontAsset>("Fonts/1980XX.ttf");
            var testRich = new RichText(new Vector3(20, 20, 0), new Vector2(100, 100), asset.GetAtlas(20));
            testRich.SetText("The quick brown fox jumps over the <color=255-0-0>lazy</> dog.\n123456789!@#$%^&*(0");

            Runner.ExecuteAsLoop(_ =>
            {
                RenderComposer composer = Engine.Renderer.StartFrame();
                composer.Render(testRich);
                Engine.Renderer.EndFrame();
                Runner.VerifyScreenshot(ResultDb.RenderRichText);
            }).WaitOne();
        }

        /// <summary>
        /// Tests the ordering of items drawn by the composer by drawing at different Z coordinates and how the result overlaps.
        /// </summary>
        [Test]
        public void RenderDepthTest()
        {
            var asset = Engine.AssetLoader.Get<TextureAsset>("Images/logoAlpha.png");
            var fontAsset = Engine.AssetLoader.Get<FontAsset>("Fonts/1980XX.ttf");
            const int maxY = 5 * 49;

            Runner.ExecuteAsLoop(_ =>
            {
                RenderComposer composer = Engine.Renderer.StartFrame();

                // Set a background so invalid alpha can be seen
                composer.RenderSprite(new Vector3(0, 0, -1), Engine.Renderer.CurrentTarget.Size, Color.CornflowerBlue);

                for (var i = 0; i < 50; i++)
                {
                    composer.RenderSprite(new Vector3(5 * i, 5 * i, i), new Vector2(100, 100), Color.White, asset.Texture);
                }

                for (var i = 0; i < 50; i++)
                {
                    composer.RenderSprite(new Vector3(5 * i, maxY - 5 * i, i), new Vector2(100, 100), Color.White, asset.Texture);
                }

                composer.RenderSprite(new Vector3(Engine.Renderer.CurrentTarget.Size.X, 0, 0), new Vector2(100, 100), Color.White, asset.Texture);
                composer.RenderSprite(new Vector3(Engine.Renderer.CurrentTarget.Size.X - 50, 0, 1), new Vector2(100, 100), Color.White, asset.Texture);
                composer.RenderSprite(new Vector3(Engine.Renderer.CurrentTarget.Size.X - 100, 0, 0), new Vector2(100, 100), Color.White, asset.Texture);
                composer.RenderSprite(new Vector3(Engine.Renderer.CurrentTarget.Size.X - 150, 0, 1), new Vector2(100, 100), Color.White, asset.Texture);
                composer.RenderSprite(new Vector3(Engine.Renderer.CurrentTarget.Size.X - 200, 0, 0), new Vector2(100, 100), Color.White, asset.Texture);
                composer.RenderSprite(new Vector3(Engine.Renderer.CurrentTarget.Size.X - 250, 0, 1), new Vector2(100, 100), Color.White, asset.Texture);
                composer.RenderSprite(new Vector3(Engine.Renderer.CurrentTarget.Size.X - 300, 0, 0), new Vector2(100, 100), Color.White, asset.Texture);

                composer.RenderSprite(new Vector3(Engine.Renderer.CurrentTarget.Size.X, 100, 1), new Vector2(100, 100), Color.White, asset.Texture);
                composer.RenderSprite(new Vector3(Engine.Renderer.CurrentTarget.Size.X - 50, 100, 0), new Vector2(100, 100), Color.White, asset.Texture);
                composer.RenderSprite(new Vector3(Engine.Renderer.CurrentTarget.Size.X - 100, 100, 1), new Vector2(100, 100), Color.White, asset.Texture);
                composer.RenderSprite(new Vector3(Engine.Renderer.CurrentTarget.Size.X - 150, 100, 0), new Vector2(100, 100), Color.White, asset.Texture);
                composer.RenderSprite(new Vector3(Engine.Renderer.CurrentTarget.Size.X - 200, 100, 1), new Vector2(100, 100), Color.White, asset.Texture);
                composer.RenderSprite(new Vector3(Engine.Renderer.CurrentTarget.Size.X - 250, 100, 0), new Vector2(100, 100), Color.White, asset.Texture);
                composer.RenderSprite(new Vector3(Engine.Renderer.CurrentTarget.Size.X - 300, 100, 1), new Vector2(100, 100), Color.White, asset.Texture);

                composer.RenderString(new Vector3(Engine.Renderer.CurrentTarget.Size.X / 2 - 100, 0, 1), Color.Red, "This is test text", fontAsset.GetAtlas(20));
                composer.RenderString(new Vector3(Engine.Renderer.CurrentTarget.Size.X / 2 - 100, 10, 2), Color.Green, "This is test text", fontAsset.GetAtlas(20));
                composer.RenderString(new Vector3(Engine.Renderer.CurrentTarget.Size.X / 2 - 100, 20, 1), Color.Blue, "This is test text", fontAsset.GetAtlas(20));
                composer.RenderSprite(new Vector3(Engine.Renderer.CurrentTarget.Size.X / 2 - 100, 0, 0), new Vector2(200, 100), Color.Black);

                Engine.Renderer.EndFrame();
                Runner.VerifyScreenshot(ResultDb.ComposerRender);
            }).WaitOne();
        }

        /// <summary>
        /// Tests the ordering of items drawn by the composer by drawing at different Z coordinates and how the result overlaps.
        /// </summary>
        [Test]
        public void RenderSortedDepthTest()
        {
            var asset = Engine.AssetLoader.Get<TextureAsset>("Images/logoAlpha.png");
            var fontAsset = Engine.AssetLoader.Get<FontAsset>("Fonts/1980XX.ttf");
            const int maxY = 5 * 49;

            Runner.ExecuteAsLoop(_ =>
            {
                RenderComposer composer = Engine.Renderer.StartFrame();

                // Set a background so invalid alpha can be seen
                composer.RenderSprite(new Vector3(0, 0, -1), Engine.Renderer.CurrentTarget.Size, Color.CornflowerBlue);

                composer.SetSpriteBatch(new SortedSpriteBatch());

                for (var i = 0; i < 50; i++)
                {
                    composer.RenderSprite(new Vector3(5 * i, 5 * i, i), new Vector2(100, 100), Color.White, asset.Texture);
                }

                for (var i = 0; i < 50; i++)
                {
                    composer.RenderSprite(new Vector3(5 * i, maxY - 5 * i, i), new Vector2(100, 100), Color.White, asset.Texture);
                }

                composer.RenderSprite(new Vector3(Engine.Renderer.CurrentTarget.Size.X, 0, 0), new Vector2(100, 100), Color.White, asset.Texture);
                composer.RenderSprite(new Vector3(Engine.Renderer.CurrentTarget.Size.X - 50, 0, 1), new Vector2(100, 100), Color.White, asset.Texture);
                composer.RenderSprite(new Vector3(Engine.Renderer.CurrentTarget.Size.X - 100, 0, 0), new Vector2(100, 100), Color.White, asset.Texture);
                composer.RenderSprite(new Vector3(Engine.Renderer.CurrentTarget.Size.X - 150, 0, 1), new Vector2(100, 100), Color.White, asset.Texture);
                composer.RenderSprite(new Vector3(Engine.Renderer.CurrentTarget.Size.X - 200, 0, 0), new Vector2(100, 100), Color.White, asset.Texture);
                composer.RenderSprite(new Vector3(Engine.Renderer.CurrentTarget.Size.X - 250, 0, 1), new Vector2(100, 100), Color.White, asset.Texture);
                composer.RenderSprite(new Vector3(Engine.Renderer.CurrentTarget.Size.X - 300, 0, 0), new Vector2(100, 100), Color.White, asset.Texture);

                composer.RenderSprite(new Vector3(Engine.Renderer.CurrentTarget.Size.X, 100, 1), new Vector2(100, 100), Color.White, asset.Texture);
                composer.RenderSprite(new Vector3(Engine.Renderer.CurrentTarget.Size.X - 50, 100, 0), new Vector2(100, 100), Color.White, asset.Texture);
                composer.RenderSprite(new Vector3(Engine.Renderer.CurrentTarget.Size.X - 100, 100, 1), new Vector2(100, 100), Color.White, asset.Texture);
                composer.RenderSprite(new Vector3(Engine.Renderer.CurrentTarget.Size.X - 150, 100, 0), new Vector2(100, 100), Color.White, asset.Texture);
                composer.RenderSprite(new Vector3(Engine.Renderer.CurrentTarget.Size.X - 200, 100, 1), new Vector2(100, 100), Color.White, asset.Texture);
                composer.RenderSprite(new Vector3(Engine.Renderer.CurrentTarget.Size.X - 250, 100, 0), new Vector2(100, 100), Color.White, asset.Texture);
                composer.RenderSprite(new Vector3(Engine.Renderer.CurrentTarget.Size.X - 300, 100, 1), new Vector2(100, 100), Color.White, asset.Texture);

                composer.RenderString(new Vector3(Engine.Renderer.CurrentTarget.Size.X / 2 - 100, 0, 1), Color.Red, "This is test text", fontAsset.GetAtlas(20));
                composer.RenderString(new Vector3(Engine.Renderer.CurrentTarget.Size.X / 2 - 100, 10, 2), Color.Green, "This is test text", fontAsset.GetAtlas(20));
                composer.RenderString(new Vector3(Engine.Renderer.CurrentTarget.Size.X / 2 - 100, 20, 1), Color.Blue, "This is test text", fontAsset.GetAtlas(20));
                composer.RenderSprite(new Vector3(Engine.Renderer.CurrentTarget.Size.X / 2 - 100, 0, 0), new Vector2(200, 100), Color.Black);

                composer.SetDefaultSpriteBatch();

                Engine.Renderer.EndFrame();
                Runner.VerifyScreenshot(ResultDb.ComposerRenderSorted);
            }).WaitOne();
        }

        [Test]
        public void TilemapTest()
        {
            var tileMap = new TileMap(Vector3.Zero, Vector2.Zero, "Tilemap/DeepForest.tmx", "Tilemap/");

            Runner.ExecuteAsLoop(_ =>
            {
                RenderComposer composer = Engine.Renderer.StartFrame();

                composer.Render(tileMap);

                Engine.Renderer.EndFrame();
                Runner.VerifyScreenshot(ResultDb.TilemapRender);
            }).WaitOne();

            tileMap.Reset("", "");
        }

        /// <summary>
        /// Tests reading the FrameBuffer's depth texture, and using it to copy the depth over to the draw buffer.
        /// </summary>
        [Test]
        public void TestDepthFromOtherFrameBuffer()
        {
            Runner.ExecuteAsLoop(_ =>
            {
                FrameBuffer testBuffer = new FrameBuffer(Engine.Renderer.DrawBuffer.Size).WithColor().WithDepth(true);
                var shader = Engine.AssetLoader.Get<ShaderAsset>("Shaders/DepthTest.xml");

                RenderComposer composer = Engine.Renderer.StartFrame();
                composer.RenderTo(testBuffer);
                composer.ClearFrameBuffer();
                composer.RenderSprite(new Vector3(0, 0, 10), new Vector2(100, 100), Color.Green);
                composer.RenderTo(null);

                composer.SetUseViewMatrix(false);
                composer.SetShader(shader.Shader);
                Texture.EnsureBound(testBuffer.DepthTexture.Pointer, 1);
                composer.RenderSprite(new Vector3(0, 0, 0), testBuffer.Texture.Size, Color.White, testBuffer.Texture);
                composer.SetShader();
                composer.SetUseViewMatrix(true);

                composer.RenderSprite(new Vector3(20, 20, 15), new Vector2(100, 100), Color.Blue);
                composer.RenderSprite(new Vector3(10, 10, 0), new Vector2(100, 100), Color.Red);

                Engine.Renderer.EndFrame();
                Runner.VerifyScreenshot(ResultDb.TestDepthFromOtherFrameBuffer);

                testBuffer.Dispose();
            }).WaitOne();
        }

        /// <summary>
        /// Tests whether the UVs are mapped properly and flipping functionality.
        /// </summary>
        [Test]
        public void TestUVMapping()
        {
            var asset = Engine.AssetLoader.Get<TextureAsset>("Images/logoAsymmetric.png");

            Runner.ExecuteAsLoop(_ =>
            {
                RenderComposer composer = Engine.Renderer.StartFrame();

                composer.RenderSprite(new Vector3(10, 10, 0), new Vector2(100, 100), Color.White, asset.Texture, null, true);
                composer.RenderSprite(new Vector3(100, 10, 0), new Vector2(100, 100), Color.White, asset.Texture, null, false, true);
                composer.RenderSprite(new Vector3(200, 10, 0), new Vector2(100, 100), Color.White, asset.Texture, null, true, true);

                composer.InvalidateStateBatches();
                asset.Texture.Tile = false;

                composer.RenderSprite(new Vector3(10, 100, 0), new Vector2(100, 100), Color.White, asset.Texture, null, true);
                composer.RenderSprite(new Vector3(100, 100, 0), new Vector2(100, 100), Color.White, asset.Texture, null, false, true);
                composer.RenderSprite(new Vector3(200, 100, 0), new Vector2(100, 100), Color.White, asset.Texture, null, true, true);

                composer.RenderSprite(new Vector3(10, 200, 0), new Vector2(100, 100), Color.White, asset.Texture, new Rectangle(0, 0, 50, 50), true);
                composer.RenderSprite(new Vector3(100, 200, 0), new Vector2(100, 100), Color.White, asset.Texture, new Rectangle(0, 0, 50, 50), false, true);
                composer.RenderSprite(new Vector3(200, 200, 0), new Vector2(100, 100), Color.White, asset.Texture, new Rectangle(0, 0, 50, 50), true, true);

                composer.InvalidateStateBatches();
                asset.Texture.Tile = true;
                Engine.Renderer.EndFrame();
                Runner.VerifyScreenshot(ResultDb.TestUVMapping);
            }).WaitOne();
        }
    }
}