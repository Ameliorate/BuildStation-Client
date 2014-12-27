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
using Buildstation_Client2.Class.Objects;

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


        private int XSetting = 0;
        private int YSetting = 0;
        private string CerrentName;
        private bool Generating = true;
        public bool FinishedGenerating;     // If any object creates a thread, it can depend on this to tell it when it is okay to start.

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

            Buildstation_Client2.Class.ContentPasser.GiveContent(Content);      // Alows classes outside of this to do graphics related tasks.
            
            

            while (Generating)  
            {   // Basically this creates a space tile at every coordnite.
                CerrentName = Buildstation_Client2.Class.NameTools.GenerateName("Space");
               Class.ObjectTools.SpawnObject(XSetting.ToString(), YSetting.ToString(), CerrentName, "Space");
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

            Class.ObjectTools.SpawnObject("1", "1", "Bar", "ObjectTemplate");
            Class.ObjectTools.SpawnObject("7", "5", "Foo", "ObjectTemplate");
            FinishedGenerating = true;

            Console.WriteLine("[Info] Finished Initalising!");
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
            // Not much updating actually goes on here, because most of it will be handled in a server.
            base.Update(gameTime);
        }

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
        private float RotationInRad;
        
        
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();    // Starts the spritebatch rendering.

            if (FinishedGenerating)
            {
                while (true)
                {
                    RenderingObjectName = Buildstation_Client2.Class.Variables.Map[XRendering, YRendering, ZRendering];     // Gets what object it is drawing using the object map.

                    RenderingObjectState = Class.Variables.PhysicalObjects[RenderingObjectName].GetSpriteState();      // Gets the spritestate of that object.
                    RenderingObjectBuffer = Buildstation_Client2.Class.ContentLoader.GetTexture(RenderingObjectState);

                    RotationInRad = Class.Variables.PhysicalObjects[RenderingObjectName].GetRotation();

                    XRenderingPixel = XRendering * 48 + 24;      // Gets what pixel to draw the tile at.
                    YRenderingPixel = YRendering * 48 + 24;      // Same here.

                    spriteBatch.Draw(RenderingObjectBuffer, new Rectangle(XRenderingPixel, YRenderingPixel, 48, 48), new Rectangle(0, 0, 48, 48), Color.White, RotationInRad, new Vector2(RenderingObjectBuffer.Width / 2, RenderingObjectBuffer.Height / 2), SpriteEffects.None, 1);        // Draws the time at the intended place, now with rotation!


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
                                break;      // Stops the rendering loop, since it is finished.
                                
                            }

                        }

                    }
                 
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
            
        }
    }
}
