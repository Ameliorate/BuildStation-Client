using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buildstation_Client2.Class.Objects
{
    class ObjectTemplate : PhysicalObject
    {
        // This is all the code you need to create an object in the game. In this case, I'm defineing a rudementry wall.

        public ObjectTemplate(string ObjectName, int X, int Y)  // You must replace the "ObjectTemplate" part with the name of your class.
        {
            XPos = X;
            YPos = Y;
            ObjectName = this.ObjectName;
        }

        public ObjectTemplate(string ObjectName, int X, int Y, int Z) // Same here.
        {
            XPos = X;
            YPos = Y;
            ZPos = Z;
            ObjectName = this.ObjectName;
        }

        public void Initalise()
        {
            InitaliseBace();    // InitaliseBase does a few things relating to rendering and updating position for you.
            IsPassable = false; // Can you walk over it?
            IsDragable = false; // Can you drag it or push it around?
            IsTransparent = false; // Can you see through it.
            SpriteSizeX = 48;  // Sets the size of the sprite to 48*48. By default if is that size, so you don't really need to set these. It is best to have it a multiple of 48, but anything is fine.
            SpriteSizeY = 48;
            ObjectType = "ObjectTemplate"; // The type of the object. Basically what it would normally be called.


            Sprite = Buildstation_Client2.Game1.Wall; // Sets the sprite to the content of the wall texture2d. You'd need to add that in the main game class somewhere under the LoadContent method. An example of what I added is below.
            
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
