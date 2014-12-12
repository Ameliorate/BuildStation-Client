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
using System.Threading;

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
        private bool Generating = true;

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.IsMouseVisible = true;     // Makes the mouse visable when your hovering over the game.

            graphics.PreferredBackBufferWidth = 720;        // Sets window size to 720*720. This allows for 15 tiles on a screen if each tile is 48*48.
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();

            // PhysicalObjects.Add("Foo", new Buildstation_Client2.Class.Objects.Space("Foo", 0, 0));


            while (Generating)  // Yes, I know this doesn't fallow my object spawning class, but I cant figure out how to to make a class into a type.
            {   // Basically this creates a space tile at every coordnite.
                CerrentName = SpaceName.GenerateName();
                // Console.WriteLine("Generated space tile at X: " + XSetting.ToString() + " Y: " + YSetting.ToString());   // Debug info about initalising.
                PhysicalObjects.Add(CerrentName, new Buildstation_Client2.Class.Objects.Space(CerrentName, XSetting, YSetting, this.Content));
                // Console.WriteLine("Creating " + CerrentName + "!");
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

            // Console.WriteLine(Content.ServiceProvider + ", " + Content.RootDirectory);

            Console.WriteLine("[Info] Finished Initalising");
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
            

            RenderingObjectBuffer = Content.Load<Texture2D>("Objects/Turf/Space/0");
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


        string IsAt000;


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
            
            // IsAt000 = Buildstation_Client2.Class.Variables.Map[0, 0, 0];
            // Console.WriteLine(IsAt000 + " Is at 0,0,0!");


            


            base.Update(gameTime);
        }
        Random Random = new Random();
        private bool Rendering;
        private int XRendering;
        private int YRendering;
        private int ZRendering;
        private int XRenderingPixel;
        private int YRenderingPixel;
        private string RenderingObjectName;
        private Texture2D RenderingObjectBuffer;
        private string RenderingObjectState;
        private bool IsCerrentTileEmpty;
        private bool IsCerrentZLevelEmpty;
        
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            // Renderer; Does not work.

            spriteBatch.Begin();    // Starts the spritebatch rendering.

            if (FinishedGenerating)
            {
                while (Rendering)
                {

                    RenderingObjectName = Buildstation_Client2.Class.Variables.Map[XRendering, YRendering, ZRendering];     // Gets what object it is drawing using the object map.
                    
                    RenderingObjectState = PhysicalObjects[RenderingObjectName].GetSpriteState();      // Gets the spritestate of that object.
                    
                    RenderingObjectBuffer = Buildstation_Client2.Class.ContentLoader.GetTexture(RenderingObjectState);

                    

                    XRenderingPixel = XRendering * 48;      // Gets what pixel to draw the tile at.
                    YRenderingPixel = YRendering * 48;      // Same here.

                    spriteBatch.Draw(RenderingObjectBuffer, new Rectangle(XRenderingPixel, YRenderingPixel, 48, 48), Color.White);      // Draws the tile at the intended place.

                    ZRendering++;       // Goes on the the next tile on the Z plane.

                    IsCerrentTileEmpty = string.IsNullOrEmpty(Buildstation_Client2.Class.Variables.Map[XRendering, YRendering, ZRendering]);    // Checks if the tile is empty.
                    IsCerrentZLevelEmpty = Buildstation_Client2.Class.Variables.IsAnythingInZPlane(ZRendering);     // Checks if there is anything in the cerrent plane.

                    
                    if (IsCerrentTileEmpty == true) // If there is no tile there, move onto the next tile in the array.
                    {

                        ZRendering = 0;
                        XRendering++;       // Moves on to the next tile on the X plane.
                        IsCerrentTileEmpty = string.IsNullOrEmpty(Buildstation_Client2.Class.Variables.Map[XRendering, YRendering, ZRendering]);       // Is the tile empty now?

                        if (IsCerrentTileEmpty == true)       // If there is no tile, move on.
                        {
                            YRendering++;       // Next tile on the Y plane.
                            XRendering = 0;

                            IsCerrentTileEmpty = string.IsNullOrEmpty(Buildstation_Client2.Class.Variables.Map[XRendering, YRendering, ZRendering]);    // How about now?

                            if (IsCerrentTileEmpty == true)       // No tile? Move on. Or not, Your actually done.
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
            // Thread.Sleep(10000);
            base.Draw(gameTime);
            
        }
    }
}
