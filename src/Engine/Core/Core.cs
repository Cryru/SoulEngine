using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using SoulEngine.Objects;
using SoulEngine.Objects.Components;
using SoulEngine.Enums;
using SoulEngine.Events;
using SoulEngine.Debugging;
using SoulEngine.Scripting;

namespace SoulEngine
{
    //////////////////////////////////////////////////////////////////////////////
    // SoulEngine - A game engine based on the MonoGame Framework.              //
    // Public Repository: https://github.com/Cryru/SoulEngine                   //
    //////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// The game instance for use by the engine.
    /// </summary>
    public class Core : Game
    {
        #region "Declarations"
        /// <summary>
        /// The time in milliseconds it took for the last frame to render.
        /// </summary>
        public float frameTime = 0;
        #region "Systems"
        /// <summary>
        /// The currently loaded scene.
        /// </summary>
        public Scene Scene;
        /// <summary>
        /// A scene waiting to be loaded.
        /// </summary>
        private Scene sceneLoadQueue;
        #endregion
        #region "Error Checkers"
        /// <summary>
        /// Used to check whether composing is done properly.
        /// </summary>
        public bool __composeAllowed = false;
        /// <summary>
        /// Used to prevent scenes being loaded outside of the queue system.
        /// </summary>
        public bool __sceneSetupAllowed = false;
        #endregion
        #endregion

        #region "Events"
        /// <summary>
        /// Triggered when a tick update cycle begins.
        /// </summary>
        public event EventHandler<SoulUpdateEventArgs> OnUpdate;
        /// <summary>
        /// Triggered when a tick update cycle ends.
        /// </summary>
        public event EventHandler<SoulUpdateEventArgs> OnUpdateEnd;
        /// <summary>
        /// Triggered at the start of a new frame.
        /// </summary>
        public event EventHandler<SoulUpdateEventArgs> OnDraw;
        /// <summary>
        /// Triggered at the end of a new frame.
        /// </summary>
        public event EventHandler<SoulUpdateEventArgs> OnDrawEnd;
        #endregion

        #region "Initialization"
        /// <summary>
        /// The initializer.
        /// </summary>
        public Core()
        {
            //Setup the graphics device.
            Context.GraphicsManager = new GraphicsDeviceManager(this);

            //Setup the Content root folder for the master scene. The root for this folder is the exe.
            Content.RootDirectory = "Content";

            //Connect the C# native events to the SE trigger system.
            Window.TextInput += Window_TextInput;
            Window.ClientSizeChanged += Window_SizeChanged;
        }

        /// <summary>
        /// Setups the spritebatch and starts the start sequence.
        /// </summary>
        protected override void LoadContent()
        {
            //Apply settings.
            IsMouseVisible = Settings.RenderMouse;
            IsFixedTimeStep = Settings.FPS > 0 ? true : false; //Check whether to cap FPS based on the fps target.
            TargetElapsedTime = Settings.FPS > 0 ? TimeSpan.FromSeconds(1.0f / Settings.FPS) : TimeSpan.FromSeconds(1);
            Context.GraphicsManager.SynchronizeWithVerticalRetrace = Settings.vSync;

            //Apply hardcoded settings.
            Window.AllowAltF4 = true;
            Window.Title = Settings.WName;

            //Setup the brush for drawing.
            Context.ink = new SpriteBatch(GraphicsDevice);

            //Load global resources.
            AssetManager.LoadGlobal();

            //Setup the window manager.
            WindowManager.Initialize();

            //Check if we are enforcing asset integrity, and check it.
            if (Settings.EnforceAssetIntegrity == true && AssetManager.AssertAssets() == false)
            {
                throw new Exception("The assets meta file is missing, or file tampering detected.");
            }

            //Setup the scripting engine.
            ScriptEngine.SetupScripting();

            //Setup networking if we have to.
            if (Settings.Networking) Networking.Setup();

            //Load the primary scene.
            LoadScene(new ScenePrim());

            //Load the debugging scene.
            if (Settings.Debug) DebugScene.Setup();

            //Measure boot time.
            Starter.bootPerformance.Stop();
            Logger.Add("Engine loaded in: " + Starter.bootPerformance.ElapsedMilliseconds + "ms");

            //Signify that we don't expect any more system event listeners.
            ESystem.AddSystemListeners = false;
        }
        #endregion

        #region "Loops"
        /// <summary>
        /// Is executed every tick.
        /// </summary>
        protected override void Update(GameTime gameTime)
        {
            //If the game is not focused, don't update.
            if (IsActive == false) return;

            //Check if a scene is waiting to be loaded and if so load it.
            if (sceneLoadQueue != null) SceneLoad();

            //Trigger tick start event.
            OnUpdate?.Invoke(this, new SoulUpdateEventArgs(gameTime));

            //Update input module.
            Input.UpdateInput();

            //Update the sound engine.
            SoundEngine.Update();

            //Update the current scene.
            Scene.UpdateHook();

            //Trigger tick end event.
            OnUpdateEnd?.Invoke(this, new SoulUpdateEventArgs(gameTime));

            //Update input module.
            Input.UpdateInput_End();
        }
        /// <summary>
        /// Is executed every frame.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            //If the game is not focused, don't update.
            if (IsActive == false) return;

            //Record frametime.
            frameTime = (float) gameTime.ElapsedGameTime.TotalMilliseconds;

            //Start drawing frame by first clearing the screen, first the behind and then the front.
            Context.Graphics.Clear(Color.Black);

            //Allow composing.
            __composeAllowed = true;

            //Trigger frame start event.
            OnDraw?.Invoke(this, new SoulUpdateEventArgs(gameTime));

            //Compose textures on the current scene. We draw the render targets before anything else because it renders over other things otherwise.
            Scene.Compose();

            //Stop allowing composig. This is to prevent the 'black screen bug'.
            __composeAllowed = false;

            Context.ink.Start(DrawChannel.Screen);
            Context.ink.Draw(AssetManager.BlankTexture, new Rectangle(0, 0, Settings.Width, Settings.Height), Settings.FillColor);
            Context.ink.End();

            //Draw the current scene.
            Scene.DrawHook();

            //Trigger frame end event.
            OnDrawEnd?.Invoke(this, new SoulUpdateEventArgs(gameTime));
        }
        #endregion

        #region "Scene System"
        /// <summary>
        /// Loads the provided scene at the next frame.
        /// </summary>
        /// <param name="Scene">The scene to load.</param>
        public void LoadScene(Scene Scene)
        {
            sceneLoadQueue = Scene;
        }
        private void SceneLoad()
        {
            //Dispose of the current scene if any.
            if (Scene != null) Scene.Dispose();

            //Trasfer the scene from the queue.
            Scene = sceneLoadQueue;
            sceneLoadQueue = null;

            //Allow scene loading.
            __sceneSetupAllowed = true;

            //Initiate inner setup.
            Scene.SetupScene();

            //Disallow scene loading.
            __sceneSetupAllowed = false;

            //Log the scene being loaded.
            Logger.Add("Scene loaded: " + Context.Core.Scene.ToString().Replace("SoulEngine.", ""));
        }
        #endregion

        #region "Triggers for Internal Events"
        /// <summary>
        /// Is triggered when text input is detected to the game.
        /// This returns the character as input, for instance capital letters etc. 
        /// and doesn't capture non text characters.
        /// </summary>
        private void Window_TextInput(object sender, TextInputEventArgs e)
        {
            ESystem.Add(new Event(EType.INPUT_TEXT, this, e.Character.ToString()));
        }
        /// <summary>
        /// Triggered when the size of the window changes. If Settings.ResizableWindow is true
        /// this can be quite useful. Has a system event hooked to it that regenerates the window.
        /// </summary>
        private void Window_SizeChanged(object sender, EventArgs e)
        {
            ESystem.Add(new Event(EType.WINDOW_SIZECHANGED, this, null));
        }
        #endregion
    }
}

