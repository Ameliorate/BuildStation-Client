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


namespace Buildstation_Client2.Class.Objects
{
    class Space : Turf
    {
        private int IconNumber;
        private int NumberOfIcons = 16;

        /// <summary>
        /// A space tile.
        /// </summary>
        /// <param name="_ObjectName">The name the object will refer to itself to on the game map. Use NameTools to generate a name that will avoid collisions.</param>
        /// <param name="X">The X Pos of the object you want to create.</param>
        /// <param name="Y">The Y Pos of the object you want to create.</param>
        /// <param name="Content">The contentmanager. It should be "this.Content" if your creating this in the main game file, if not than youll need to take "ContentManager Content" as a parameter.</param>
        public Space(string _ObjectName, int X, int Y, ContentManager Content)  // You must replace the "ObjectTemplate" part with the name of your class.
        {
            XPos = X;
            YPos = Y;
            ObjectName = _ObjectName;
            GraphicsDevice = Content;   
        }
        

        /// <summary>
        /// A space tile.
        /// </summary>
        /// <param name="_ObjectName">The name the object will refer to itself to on the game map. Use NameTools to generate a name that will avoid collisions.</param>
        /// <param name="X">The X Pos of the object you want to create.</param>
        /// <param name="Y">The Y Pos of the object you want to create.</param>
        /// <param name="Z">The Z Pos of the object you want to create</param>
        /// <param name="Content">The contentmanager. It should be "this.Content" if your creating this in the main game file, if not than youll need to take "ContentManager Content" as a parameter.</param>
        public Space(string _ObjectName, int X, int Y, int Z, ContentManager Content) // Same here.
        {
            XPos = X;
            YPos = Y;
            ZPos = Z;
            ObjectName = _ObjectName;
            GraphicsDevice = Content;
        }

        /// <summary>
        /// Initalsies the tile, always run this, or this tile wont exist.
        /// </summary>
        public void Initalise()
        {


            DoesMove = false;
            Random Random = new Random();
            IconNumber = Random.Next(NumberOfIcons);  // Choses what icon is used for this tile.
            SetSpriteRandom();                      // Sets the sprite to that icon.
            RotationInDegrees = Random.Next(3) * 90; // Creates 4 varations of each sprite by rotating them, reducing common patterns.
            
            InitaliseTurf();  // Does things relating to turfs. Like makes you able to walk on them and see through them.
        }

        /// <summary>
        /// Sets the space tile to a new, random sprite.
        /// </summary>
        private void SetSpriteRandom()
        {
            // WARNING: Possibly ugly code ahead. Don't say I didn't warn you.
            if (IconNumber == 0)                                 
            {
                SpriteState = "Space0";
            }

            if (IconNumber == 1)
            {
                SpriteState = "Space1";
            }

            if (IconNumber == 2)
            {
                SpriteState = "Space2";
            }

            if (IconNumber == 3)
            {
                SpriteState = "Space3";
            }

            if (IconNumber == 4)
            {
                SpriteState = "Space4";
            }

            if (IconNumber == 5)
            {
                SpriteState = "Space5";
            }

            if (IconNumber == 6)
            {
                SpriteState = "Space6";
            }

            if (IconNumber == 7)
            {
                SpriteState = "Space7";
            }

            if (IconNumber == 8)
            {
                SpriteState = "Space8";
            }

            if (IconNumber == 9)
            {
                SpriteState = "Space9";
            }

            if (IconNumber == 10)
            {
                SpriteState = "Space10";
            }

            if (IconNumber == 11)
            {
                SpriteState = "Space11";
            }

            if (IconNumber == 12)
            {
                SpriteState = "Space12";
            }

            if (IconNumber == 13)
            {
                SpriteState = "Space13";
            }

            if (IconNumber == 14)
            {
                SpriteState = "Space14";
            }

            if (IconNumber == 15)
            {
                SpriteState = "Space15";
            }
        }
    }
}


