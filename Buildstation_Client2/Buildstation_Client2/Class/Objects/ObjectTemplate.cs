using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buildstation_Client2.Class.Objects
{
    class ObjectTemplate : PhysicalObject
    {
        // This is all the code you need to create an object in the game. In this case, I'm defineing a rudementry wall.

        // This next part will allow you to set the internal doccumentation. You should probably only modify the part inbatween the <summary> and </summary> parts. 
        /// <summary>
        /// A basic example for an object. You probably shouldn't use this.
        /// </summary>
        /// <param name="_ObjectName">The name the object will refer to itself to on the game map. Use NameTools to generate a name that will avoid collisions.</param>
        /// <param name="X">The X Pos of the object you want to create.</param>
        /// <param name="Y">The Y Pos of the object you want to create.</param>
        public ObjectTemplate(string _ObjectName, string X, string Y)  // You must replace the "ObjectTemplate" part with the name of your class.
        {
            XPos = Convert.ToInt32(X);
            YPos = Convert.ToInt32(Y);
            ObjectName = _ObjectName; 
        }

        
        /// <summary>
        /// A basic example for an object. You probably shouldn't use this.
        /// </summary>
        /// <param name="_ObjectName">The name the object will refer to itself to on the game map. Use NameTools to generate a name that will avoid collisions.</param>
        /// <param name="X">The X Pos of the object you want to create.</param>
        /// <param name="Y">The Y Pos of the object you want to create.</param>
        /// <param name="Z">The Z Pos of the object you want to create</param>
        public ObjectTemplate(string _ObjectName, string X, string Y, string Z) // Same here.
        {
            XPos = Convert.ToInt32(X);
            YPos = Convert.ToInt32(Y);
            ZPos = Convert.ToInt32(Z);
            ObjectName = _ObjectName;
        }

        /// <summary>
        /// Allows you to initalise the object, you should always run this right after creating that object, or else it wont exist.
        /// </summary>
        public void Initalise()
        {
            IsPassable = false; // Can you walk over it?
            IsDragable = false; // Can you drag it or push it around?
            IsTransparent = false; // Can you see through it.
            SpriteSizeX = 48;  // Sets the size of the sprite to 48*48. By default if is that size, so you don't really need to set these. It is best to have it a multiple of 48, but anything is fine.
            SpriteSizeY = 48;
            ObjectType = "ObjectTemplate"; // The type of the object. Basically what it would normally be called.

            ContentLoader.AddTexture("Wall", "Objects/Wall");       // Accosates the wall spritestate with the wall texture.

            SpriteState = "Wall"; // Sets the sprite to the wall sprite we set earlier.



            InitaliseBace();    // InitaliseBase does a few things relating to rendering and updating position for you. Make sure this is last, as it does vairous things related to stuff you did earlier.
        }


        /* Also, in ObjectTools.cs, you have to add these lines, replacing ObjectTemplate  with the name of your tile.
         
           
           // Begin new object
            if (ObjectType == "ObjectTemplate")
            {
                if (ZPos == "No")
                {
                    return new Objects.ObjectTemplate(ObjectName, XPos, YPos);
                }
                else
                {
                    return new Objects.ObjectTemplate(ObjectName, XPos, YPos, ZPos);
                }
            }
            // End new object
         
         
         */

    }
}
