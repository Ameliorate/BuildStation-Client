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
        private int ZSetting = 0;
        private string CerrentName;
        private string IPPort;
        private string[] ServerIPPortSplit;

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


            // Prepares the networkhandlers. This may end up quite long.
            Class.NetworkSorters.FinishedHandler FinishedHandler = new Class.NetworkSorters.FinishedHandler();
            Class.NetworkSorters.TilePlacmentHandler TilePlacementHandler = new Class.NetworkSorters.TilePlacmentHandler();
            Class.NetworkSorters.TileUpdateHandler TileUpdateHandler = new Class.NetworkSorters.TileUpdateHandler();

            Console.Write("Please enter a IP and port of a server to connect to in the form if [IP]:[Port]: ");
            IPPort = Console.ReadLine();

            if (IPPort == "")
                IPPort = "127.0.0.1:25565";

            ServerIPPortSplit = IPPort.Split(':');

            Class.Variables.ServerIP = ServerIPPortSplit[0];
            Class.Variables.ServerPort = Convert.ToInt32(ServerIPPortSplit[1]);

            Thread NetWorkThread = new Thread(Class.NetworkThread.NetworkSortThread);

            Class.NetworkThread.SendMessage("GetAll", "0,0");       // Tels the server that it wants a 15*15 chunk of the map placed begining at 0,0.

            FinishedHandler.WaitUntill("GetAll");

            base.Initialize();
            Console.WriteLine("[Info] Finished Initalising!");
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

        public static bool ExitGameBool = false;

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

            if (ExitGameBool == true)
                this.Exit();

            // Not much updating actually goes on here, because most of it will be handled in a server.
            base.Update(gameTime);
        }


        
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            Texture2D drawing;
            dynamic tile;
            float rotation;

            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();    // Starts the spritebatch rendering.

            for (int x = Class.Variables.RenderCentre.XPos; x < Class.Variables.RenderCentre.XPos + 15; x++)
                for (int y = Class.Variables.RenderCentre.YPos; y < Class.Variables.RenderCentre.YPos + 15; y++)
                    while (true)    // Too bad I can't make this a for loop too.
                    {
                        int z = 0;
                        if (Class.Variables.isEmpty(new Class.Coordinate(x, y, z, Class.Variables.RenderCentre.Level)) && z == 0)
                        {
                            Class.NetworkThread.SendMessage("GetTile", x.ToString() + "," + y.ToString() + "," + z.ToString());
                        }
                        // Do stuff here
                        tile = Class.Variables.getTile(new Class.Coordinate(x, y, z, Class.Variables.RenderCentre.Level));
                        drawing = Class.ContentLoader.GetTexture(tile.SpriteState);
                        rotation = tile.RotationInRadians;

                        spriteBatch.Draw(drawing, new Rectangle(x * 48 + 24, y * 48 + 24, 48, 48), new Rectangle(0, 0, 48, 48), Color.White, rotation, new Vector2(drawing.Width / 2, drawing.Height / 2), SpriteEffects.None, 1);  // I used to understand this, now I just copy paste and fix the errors.

                        // Stop doing stuff here.
                        z++;
                        if (Class.Variables.isEmpty(new Class.Coordinate(x, y, z, Class.Variables.RenderCentre.Level)))
                            break;
                    }

            spriteBatch.End();

            base.Draw(gameTime);
            
        }

        public static void ExitGame()
        {
            Game1.ExitGameBool = true;
        }

    }
}
