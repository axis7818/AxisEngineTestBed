using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using AxisEngine;
using AxisEngine.AxisDebug;
using TestBed.Worlds.FirstTest;
using TestBed.Worlds.SplashScreen;
using System;
using TestBed.Content;

namespace TestGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private WorldManager _worldManager;
        
        private bool paused = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            Window.Position = new Point(100, 100);

            Content.RootDirectory = "Content";
            ContentLoader.Content = Content;
        }

        protected override void OnActivated(object sender, EventArgs args)
        {
            paused = false;
        }

        protected override void OnDeactivated(object sender, EventArgs args)
        {
            paused = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            BodySpriteAnimTestWorld testWorld = new BodySpriteAnimTestWorld(graphics, GraphicsDevice);
            SplashScreen splashScreen = new SplashScreen(graphics, GraphicsDevice);

            _worldManager = new WorldManager(splashScreen);
            _worldManager.AddWorld(testWorld);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (paused)
                return;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed && !Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

#if DEBUG
            Grid.Visible = Keyboard.GetState().IsKeyDown(Keys.NumPad0);
#endif
            _worldManager.CurrentWorld.Update(gameTime);

            base.Update(gameTime);  
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (paused)
                return;

            GraphicsDevice.Clear(_worldManager.CurrentWorld.BackgroundColor);

            _worldManager.CurrentWorld.Draw(gameTime);

#if DEBUG
            Grid.Draw(GraphicsDevice);
            _worldManager.CurrentWorld.DrawWireFrames = true;
#endif

            base.Draw(gameTime);
        }
    }
}