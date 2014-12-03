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

namespace Buildstation_Client2
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


        int XSetting = 0;
        int YSetting = 0;
        string CerrentName;
        Buildstation_Client2.Class.NameTools SpaceName = new Buildstation_Client2.Class.NameTools("Space");
        public static Dictionary<string, dynamic> PhysicalObjects = new Dictionary<string, dynamic>();      // A dictionary of objects. Every single object in the game. Probably not optimal, but I cant find another way.
        private bool FinishedGenerating = false;
        private bool Generating;

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

            PhysicalObjects.Add("Foo", new Buildstation_Client2.Class.Objects.Space("Foo", 0, 0));


            while (Generating)  // Yes, I know this doesn't fallow my object spawning class, but I cant figure out how to to make a class into a type.
            {   // Basically this creates a space tile at every coordnite.
                CerrentName = SpaceName.GenerateName();
                PhysicalObjects.Add(CerrentName, new Buildstation_Client2.Class.Objects.Space(CerrentName, XSetting, YSetting));
                PhysicalObjects[CerrentName].Initalise();
                XSetting++;
                if (XSetting == 15)
                {
                    YSetting++;
                    XSetting = 0;
                    if (YSetting == 15)
                    {
                        XSetting = 0;
                        YSetting = 0;
                        Generating = false;
                    }
                }
            }

            FinishedGenerating = true;

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

        private bool Rendering;
        private int XRendering = 0;
        private int YRendering = 0;
        private int ZRendering = 0;
        private int XRenderingPixel;
        private int YRenderingPixel;
        private string RenderingObjectName;
        private Texture2D RenderingObjectBuffer;
        private string RenderingObjectState;

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            if (FinishedGenerating)
            {
                while (Rendering)
                {
                    RenderingObjectName = Buildstation_Client2.Class.Variables.Map[XRendering, YRendering, ZRendering];     // Gets what object it is drawing using the object map.
                    RenderingObjectState = PhysicalObjects[RenderingObjectName].GetSprite();      // Gets the sprite of that object.
                    XRenderingPixel = XRendering * 48;      // Gets what pixel to draw the tile at.
                    YRenderingPixel = YRendering * 48;      // Same here.

                    spriteBatch.Draw(RenderingObjectBuffer, new Rectangle(XRenderingPixel, YRenderingPixel, 48, 48), Color.White);      // Draws the tile at the intended place.
                    ZRendering++;       // Goes on the the next tile on the Z plane.
                    if (Buildstation_Client2.Class.Variables.Map[XRendering, YRendering, ZRendering] == string.Empty)       // If there is no tile there, move on to the next one.
                    {
                        ZRendering = 0;
                        XRendering++;       // Moves on to the next tile on the X plane.

                        if (Buildstation_Client2.Class.Variables.Map[XRendering, YRendering, ZRendering] == string.Empty)       // If ther is no tile, move on.
                        {
                            YRendering++;       // Next tile on the Y plane.
                            XRendering = 0;
                            if (Buildstation_Client2.Class.Variables.Map[XRendering, YRendering, ZRendering] == string.Empty)       // No tile? Move on. Or not, Your actually done.
                            {
                                YRendering = 0;
                                XRendering = 0;     // Not sure if these are nesasary, but wouldnt make a differance anyway.
                                ZRendering = 0;
                                Rendering = false;      // Stops the rendering loop, since it is finished.
                            }
                        }
                    }
                }
            }

            spriteBatch.End();
            Rendering = true;

            base.Draw(gameTime);
        }
    }
}
