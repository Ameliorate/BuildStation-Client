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


namespace Buildstation_Client2.Class
{
    class PhysicalObject
    {
        /*
         * This is anything that exists, and contains information about possitioning, movement, and anything else that would exist in the world.
         */


        // Where the object is and what are its properties.
        protected bool IsPassable; // If you can walk through or on it. For example a floor can be walked on, but you couldnt walk on a wall.
        protected bool IsTransparent; // Can you see through or over it? You can see through a window or a PDA on ther floor, but fou cant see through a wall.
        protected bool IsDragable; // Can you drag it around or push it?
        protected string[] OtherProperties; // Any other properties of the object. Such as a table would be flat, waist height, and hard. This makes certan actions be able to depend on what an object is like instead of whitelisting certan objects.
        protected int XPos; // The X possition on a grid. 0 starts at the top left courner. This is normally set automatically.
        protected int YPos; // The Y possition on a grid.
        protected int ZPos;
        protected string ObjectName; // The name of the object. An example would be SpaceX, FloorAB, or WallHFDHYRFDGTRHTG.


        // What the object looks like.
        protected Texture2D Sprite; // The cerrent apearance of the thing.
        protected int SpriteSizeX = 48; // How large your sprite is on the X plane. Normally 48 pixels.
        protected int SpriteSizeY = 48; // How large your sprite is on the Y plane. Normally 48 pixels.

        

        // Actually starting logic.
        //Map[XPos, YPos, ZPos] = ObjectName; // Is supposed to set the location of the object to the apropiate place on the map. But it seems to hate me.



        





    }
}
