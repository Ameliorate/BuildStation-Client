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


namespace Buildstation_Client2.Class
{
    abstract class PhysicalObject
    {
        /*
         * This is anything that exists, and contains information about possitioning, movement, and anything else that would exist in the world. 
         */


        // Where the object is and what are its properties. Affects things when they are simulated.
        protected bool IsPassable; // If you can walk through or on it. For example a floor can be walked on, but you couldnt walk on a wall.
        protected bool IsTransparent; // Can you see through or over it? You can see through a window or a PDA on ther floor, but fou cant see through a wall.
        protected bool IsDragable; // Can you drag it around or push it?
        protected string[] OtherProperties; // Any other properties of the object. Such as a table would be flat, waist height, and hard. This makes certan actions be able to depend on what an object is like instead of whitelisting certan objects.
        protected int XPos; // The X possition on a grid. 0 starts at the top left courner. This is normally set automatically.
        protected int YPos; // The Y possition on a grid.
        protected int ZPos;
        protected string ObjectName; // The name of the object. An example would be SpaceX, FloorAB, or WallHFDHYRFDGTRHTG.
        protected bool DoesMove; // Does it move? Affects preformance.
        protected string ObjectType; // What is the type of the object? EX: Space, Wall, Floor.

        // What the object looks like. Affects things durring rendertime.
        static public Texture2D Sprite; // The cerrent apearance of the thing. You'll have to assighn an existing texture2d to this.
        protected int SpriteSizeX = 48; // How large your sprite is on the X plane. Normally 48 pixels.
        protected int SpriteSizeY = 48;
        protected int RotationInDegrees = 0; // How much should it be rotated? Normally 0.




        // Varibles used for the map updating code.
        private int OldXPos;  
        private int OldYPos;
        private int OldZPos;
        private bool RanBefore = false; 



        





        // Actually starting logic.

        protected void InitaliseBace()        // Preforms the nesasary actions to create the object.
        {
            Thread thread = new Thread(MapUpdateThread);
            thread.Start();
        }


        public bool GetPassableStatus()
        {
            return IsPassable;
        }

        public bool GetDragableStatus()
        {
            return IsDragable;
        }

        public bool GetTransparentStatus()
        {
            return IsTransparent;
        }

        public Texture2D GetSprite()
        {
            return Sprite;
        }



        private void MapUpdateThread()
        {
            while (true) 
            {
                while (ObjectName != String.Empty)
                {
                    Variables.Map[XPos, YPos, ZPos] = ObjectName; // Sets the possition of the object to the intended coordanites.

                    if (RanBefore == true && XPos != OldXPos && YPos != OldYPos && ZPos != OldZPos)  // Deletes the old reference to the object on the map since it just moved.
                    {
                        Variables.Map[OldXPos, OldYPos, OldZPos] = String.Empty;
                    }

                    RanBefore = true;
                }
            }
        }
        





    }
}
