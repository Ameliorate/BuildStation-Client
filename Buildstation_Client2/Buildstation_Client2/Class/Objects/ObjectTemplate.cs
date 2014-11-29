using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buildstation_Client2.Class.Objects
{
    class ObjectTemplate : PhysicalObject
    {
        // This is all the code you need to create an object in the game. In this case, I'm defineing a rudementry wall.

        public ObjectTemplate(int X, int Y)   // You'd need to have the name of the class in place of the "ObjectTemplate" part.
        {   // Basically, these allow you to create the object with preset coordanates.
            XPos = X;
            YPos = Y;
        }

        public ObjectTemplate(int X, int Y, int Z) // Same here.
        {   // This is the same, but also allows you to set the height of the object in a pile of stuff. Do note, that with this, it will replace the object there is there is already something there.
            XPos = X;
            YPos = Y;
            ZPos = Z;
        }

        public void Initalise()
        {
            InitaliseBace();    // InitaliseBase does a few things relating to rendering and updating position for you.
            IsPassable = false; // Can you walk over it?
            IsDragable = false; // Can you drag it or push it around?
            IsTransparent = false; // Can you see through it.
            SpriteSizeX = 48;  // Sets the size of the sprite to 48*48. By default if is that size, so you don't really need to set these. It is best to have it a multiple of 48, but anything is fine.
            SpriteSizeY = 48;


            Sprite = Buildstation_Client.Game1.Wall; // Sets the sprite to the content of the wall texture2d. You'd need to add that in the main game class somewhere under the LoadContent method. An example of what I added is below.
            
            /*
             * Wall = Content.Load<Texture2D>("Objects/Wall");
             */
            
            // Also, Just above the LoadContent method, I added this:

            /*
             * static public Texture2D Wall;
             */
        }
    }
}
