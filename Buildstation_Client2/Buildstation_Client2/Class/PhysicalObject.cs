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
        public bool IsPassable; // If you can walk through or on it. For example a floor can be walked on, but you couldnt walk on a wall.
        public bool IsTransparent; // Can you see through or over it? You can see through a window or a PDA on ther floor, but fou cant see through a wall.
        public bool IsDragable; // Can you drag it around or push it?
        public List<string> OtherProperties = new List<string>(); // Any other properties of the object. Such as a table would be flat, waist height, and hard. This makes certan actions be able to depend on what an object is like instead of whitelisting certan objects.
        public Class.Coordinate Position = new Coordinate(0, 0, 0, "default");
        public string ObjectName; // The name of the object. An example would be SpaceX, FloorAB, or WallHFDHYRFDGTRHTG.
        public string ObjectType; // The type of the object. Basically is what it is called. EX: Space, Wall, Computer

        // What the object looks like. Affects things durring rendertime.
        public Spritestate SpriteState;

        // Varibles used for the map updating code.
        private Coordinate OldPosition = new Coordinate();









        // Actually starting logic.

        /// <summary>
        /// The nessasary stuff to create an object, always run this last, unless you are inheriting from something that adds it's own initalise method, then use that.
        /// </summary>
        protected void InitaliseBace()        // Preforms the nesasary actions to create the object.
        {
            Variables.Map[Position] = ObjectName;   // Adds the object to the map array.
            OldPosition.XPos = Position.XPos;
            OldPosition.YPos = Position.YPos;
            OldPosition.ZPos = Position.ZPos;
        }



        // Start networking methods.
        // If you want to do anything with networking in a class, you would overwride these.

        /// <summary>
        /// Gets the data nesasary to sync to clients upon initalisation.
        /// </summary>
        /// <returns>Returns the data in CSV form.</returns>
        public virtual string GetData()
        {
            return "";      // There is no data that would be sent to clients upon initatisation.
        }

        /// <summary>
        /// Gets the update data to be sent to clients.
        /// </summary>
        /// <returns>Returns the data in colin ':' seperated value form.</returns>
        public virtual string GetUpdateData()
        {
            return "";      // There is no data that will ever be sent to the client after initalisation.
        }

        /// <summary>
        /// Allows you to sync certan values batween client and server.
        /// </summary>
        /// <param name="DataInCSV">The data, in Colin ':' seperated value format.</param>
        public virtual void GiveData(string DataInCSV)
        {
            // Does nothing here, because there is no data that will be given.
        }

        public virtual void ClientUpdate(string DataInCSV)
        {
            // Do nothing, since there is no need to update.
        }

        public virtual string Update()
        {
            return "";
        }
    }
}
