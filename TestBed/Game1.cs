using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using AxisEngine.Debug;
using TestGame.Worlds.FirstTest;
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
        private BodySpriteAnimTestWorld testWorld;
        private bool paused = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            Window.Position = new Point(550, 100);

#if DEBUG
            Log.ShowWindow();
#endif

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
            testWorld = new BodySpriteAnimTestWorld(graphics, GraphicsDevice, Content);

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

            Grid.Visible = Keyboard.GetState().IsKeyDown(Keys.NumPad0);

            testWorld.Update(gameTime);

            base.Update(gameTime);  
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(testWorld.BackgroundColor);

#if DEBUG
            Grid.Draw(GraphicsDevice);
#endif

            testWorld.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}