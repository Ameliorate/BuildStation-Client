using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Buildstation_Client
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

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
            // TODO: Add your initialization logic here

            graphics.PreferredBackBufferWidth = 720;        // Sets window size to 720*720. This allows for 15 tiles on a screen if each tile is 48*48.
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();




            base.Initialize();
        }



        static public Texture2D Space0;      // Creating all the varibles for the space tiles.
        static public Texture2D Space1;      // Perhaps I could make these all a dictionary?
        static public Texture2D Space2;
        static public Texture2D Space3;
        static public Texture2D Space4;
        static public Texture2D Space5;
        static public Texture2D Space6;
        static public Texture2D Space7;
        static public Texture2D Space8;
        static public Texture2D Space9;
        static public Texture2D Space10;
        static public Texture2D Space11;
        static public Texture2D Space12;
        static public Texture2D Space13;
        static public Texture2D Space14;
        static public Texture2D Space15;

        static public Texture2D Wall;



        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Space0 = Content.Load<Texture2D>("Objects/Turf/Space/0");             // Loading all the space tiles
            Space1 = Content.Load<Texture2D>("Objects/Turf/Space/1");
            Space2 = Content.Load<Texture2D>("Objects/Turf/Space/2");
            Space3 = Content.Load<Texture2D>("Objects/Turf/Space/3");
            Space4 = Content.Load<Texture2D>("Objects/Turf/Space/4");
            Space5 = Content.Load<Texture2D>("Objects/Turf/Space/5");
            Space6 = Content.Load<Texture2D>("Objects/Turf/Space/6");
            Space7 = Content.Load<Texture2D>("Objects/Turf/Space/7");
            Space8 = Content.Load<Texture2D>("Objects/Turf/Space/8");
            Space9 = Content.Load<Texture2D>("Objects/Turf/Space/9");
            Space10 = Content.Load<Texture2D>("Objects/Turf/Space/10");
            Space11 = Content.Load<Texture2D>("Objects/Turf/Space/11");
            Space12 = Content.Load<Texture2D>("Objects/Turf/Space/12");
            Space13 = Content.Load<Texture2D>("Objects/Turf/Space/13");
            Space14 = Content.Load<Texture2D>("Objects/Turf/Space/14");
            Space15 = Content.Load<Texture2D>("Objects/Turf/Space/15");

            Wall = Content.Load<Texture2D>("Objects/Wall");


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            



            base.Draw(gameTime);
        }
    }
}
