using System;
using System.Collections.Generic;
using System.Linq;
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
        protected List<string> OtherProperties = new List<string>(); // Any other properties of the object. Such as a table would be flat, waist height, and hard. This makes certan actions be able to depend on what an object is like instead of whitelisting certan objects.
        protected int XPos; // The X possition on a grid. 0 starts at the top left courner. This is normally set automatically.
        protected int YPos; // The Y possition on a grid.
        protected int ZPos;
        protected string ObjectName; // The name of the object. An example would be SpaceX, FloorAB, or WallHFDHYRFDGTRHTG.
        protected string ObjectType; // The type of the object. Basically is what it is called. EX: Space, Wall, Computer
        protected bool DoesMove; // Does it move? Affects preformance.

        // What the object looks like. Affects things durring rendertime.
        static public string SpriteState; // The cerrent apearance of the thing. You'll have to assighn an existing texture2d to this.
        protected int SpriteSizeX = 48; // How large your sprite is on the X plane. Normally 48 pixels.
        protected int SpriteSizeY = 48;
        protected float RotationInRadians = 0; // How much should it be rotated? Normally 0.



        // Varibles used for the map updating code.
        private int OldXPos;  
        private int OldYPos;
        private int OldZPos;
        private bool RanBefore = false; 



        





        // Actually starting logic.

        /// <summary>
        /// The nessasary stuff to create an object, always run this last, unless you are inheriting from something that adds it's own initalise method, then use that.
        /// </summary>
        protected void InitaliseBace()        // Preforms the nesasary actions to create the object.
        {
            

            if (DoesMove == true)   // Vairous optimatasation things making objects faster (Probably, it does get rid of a whole thread)
            {
                Thread thread = new Thread(MapUpdateThread);
                thread.Start();
            }
            else
            {
                Variables.Map[XPos, YPos, ZPos] = ObjectName;   // Adds the object to the map array.
            }
        }

        /// <summary>
        /// Gets weather it can be passed or not.
        /// </summary>
        /// <returns>True if it can be passed, false if not.</returns>
        public bool GetPassableStatus()
        {
            return IsPassable;
        }

        /// <summary>
        /// If it can be dragged.
        /// </summary>
        /// <returns>True if dragable, false if not.</returns>
        public bool GetDragableStatus()
        {
            return IsDragable;
        }

        /// <summary>
        /// Gets if it is transparent or not.
        /// </summary>
        /// <returns>True if transparent, false if not.</returns>
        public bool GetTransparentStatus()
        {
            return IsTransparent;
        }

        /// <summary>
        /// Gets it's spritestate.
        /// </summary>
        /// <returns>Returns the spritestate of the object.</returns>
        public virtual string GetSpriteState()
        {
            return SpriteState;
        }

        /// <summary>
        /// Gets the rotation of the object
        /// </summary>
        /// <returns>Returns the rotation in Radians.</returns>
        public float GetRotation()
        {
            return RotationInRadians;
        }

        

        /// <summary>
        /// Map update thread, inefficent, resource hog, and needs to be redone in favor of a better way. More than 6 or so slows the program to very few lines per second. Less than 1.
        /// </summary>
        private void MapUpdateThread()
        {
            Console.WriteLine("[WARNING] Created a Map Update Thread, these are slow and resource hogs! Dont use these!");
            while (true) 
            {
                while (ObjectName != String.Empty)
                {
                    Variables.Map[XPos, YPos, ZPos] = ObjectName; // Sets the possition of the object to the intended coordanites.

                    if (RanBefore == true)  // Deletes the old reference to the object on the map since it just moved.
                    {
                        if (XPos != OldXPos || YPos != OldYPos || ZPos != OldZPos)
                        {
                            Variables.Map[OldXPos, OldYPos, OldZPos] = String.Empty;
                        }
                    }

                    RanBefore = true;

                    if (RanBefore == true && DoesMove == false)  // If it has updated it's possition once before than it breaks out of the loop and stops the thread.
                    {
                        break;
                    }

                    Thread.Sleep(500);
                }

                
            }
        }
        





    }
}
