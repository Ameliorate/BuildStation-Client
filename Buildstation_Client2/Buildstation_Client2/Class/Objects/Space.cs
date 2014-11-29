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


        public Space(int X, int Y) 
        {
            XPos = X;
            YPos = Y;
        }

        public Space(int X, int Y, int Z)
        {
            XPos = X;
            YPos = Y;
            ZPos = Z;
        }

        public void Initalise()
        {
            InitaliseTurf();  // Does things relating to turfs. Like makes you able to walk on them and see through them.

            Random Random = new Random();
            IconNumber = Random.Next(NumberOfIcons);
            SetName("Space");    // Does nothing yet, but will probably work later when I figure out setname.
            SetSpriteRandom();
            RotationInDegrees = Random.Next(3) * 90; // Creates 4 varations of each sprite by rotating them, reducing common patterns.

        }


        private void SetSpriteRandom()
        {
            // WARNING: Possibly ugly code ahead. Don't say I didn't warn you.
            if (IconNumber == 0)                                 // Basically, it sets the icon to a random icon of 16 posibilities.
            {
                Sprite = Buildstation_Client.Game1.Space0;
            }

            if (IconNumber == 1)
            {
                Sprite = Buildstation_Client.Game1.Space1;
            }

            if (IconNumber == 2)
            {
                Sprite = Buildstation_Client.Game1.Space2;
            }

            if (IconNumber == 3)
            {
                Sprite = Buildstation_Client.Game1.Space3;
            }

            if (IconNumber == 4)
            {
                Sprite = Buildstation_Client.Game1.Space4;
            }

            if (IconNumber == 5)
            {
                Sprite = Buildstation_Client.Game1.Space5;
            }

            if (IconNumber == 6)
            {
                Sprite = Buildstation_Client.Game1.Space6;
            }

            if (IconNumber == 7)
            {
                Sprite = Buildstation_Client.Game1.Space7;
            }

            if (IconNumber == 8)
            {
                Sprite = Buildstation_Client.Game1.Space8;
            }

            if (IconNumber == 9)
            {
                Sprite = Buildstation_Client.Game1.Space9;
            }

            if (IconNumber == 10)
            {
                Sprite = Buildstation_Client.Game1.Space10;
            }

            if (IconNumber == 11)
            {
                Sprite = Buildstation_Client.Game1.Space11;
            }

            if (IconNumber == 12)
            {
                Sprite = Buildstation_Client.Game1.Space12;
            }

            if (IconNumber == 13)
            {
                Sprite = Buildstation_Client.Game1.Space13;
            }

            if (IconNumber == 14)
            {
                Sprite = Buildstation_Client.Game1.Space14;
            }

            if (IconNumber == 15)
            {
                Sprite = Buildstation_Client.Game1.Space15;
            }
        }
    }
}


