using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Template
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //KOmentar

        //spelare
        Texture2D cube;
        Rectangle cubePos;

        //Fiende
        Texture2D block1;
        Rectangle block1Pos;
        //bakgrund
        Texture2D background;

        //Camera
        Camera camera;          

        public static int Height;
        public static int Width;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            cubePos = new Rectangle(new Point(0, 0), new Point(180, 135));
            cubePos.Y = graphics.PreferredBackBufferHeight - cubePos.Height;
            cubePos.X = graphics.PreferredBackBufferWidth / 2 - cubePos.Width / 2;
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
            cube = Content.Load<Texture2D>("cubeplayer");
            background = Content.Load<Texture2D>("dash");
            block1 = Content.Load<Texture2D>("block1");

            camera = new Camera(GraphicsDevice.Viewport); 

            // TODO: use this.Content to load your game content here 
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.W) && cubePos.X < graphics.PreferredBackBufferWidth - cubePos.Width)
                cubePos.X += 10;
            camera.Position = cubePos.Center.ToVector2();
            camera.UpdateCamera(GraphicsDevice.Viewport);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred,null,null,null,null,null,camera.Transform);

            
            spriteBatch.Draw(cube, cubePos, Color.White);
            spriteBatch.Draw(block1, blocket1Pos, Color.White);

            spriteBatch.End();

            // TODO: Add your drawing code here.

            base.Draw(gameTime);
        }
    }
}
