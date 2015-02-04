using System;
using System.Collections.Generic;
using System.Linq;


namespace Buildstation_Client2.Class.Objects
{
    class Space : Turf
    {
        private int SpriteNumber;
        private int NumberOfSprites = 16;

        /// <summary>
        /// A space tile.
        /// </summary>
        /// <param name="_ObjectName">The name the object will refer to itself to on the game map. Use NameTools to generate a name that will avoid collisions.</param>
        /// <param name="X">The X Pos of the object you want to create.</param>
        /// <param name="Y">The Y Pos of the object you want to create.</param>
        public Space(string _ObjectName, string X, string Y) 
        {
            Position.XPos = Convert.ToInt32(X);
            Position.YPos = Convert.ToInt32(Y);
            
            ObjectName = _ObjectName;   
        }
        

        /// <summary>
        /// A space tile.
        /// </summary>
        /// <param name="_ObjectName">The name the object will refer to itself to on the game map. Use NameTools to generate a name that will avoid collisions.</param>
        /// <param name="X">The X Pos of the object you want to create.</param>
        /// <param name="Y">The Y Pos of the object you want to create.</param>
        /// <param name="Z">The Z Pos of the object you want to create</param>
        public Space(string _ObjectName, string X, string Y, string Z)
        {
            Position.XPos = Convert.ToInt32(X);
            Position.YPos = Convert.ToInt32(Y);
            Position.ZPos = Convert.ToUInt32(Z);
            
            ObjectName = _ObjectName;
        }


        private int Seed;
        private int ZeroToThree;

        /// <summary>
        /// Initalsies the tile, always run this, or this tile wont exist.
        /// </summary>
        public void Initalise()
        {
            LeakPercent = 100;        // It is space, so it leaks 100% of the air there.
            Seed = ObjectName.GetHashCode(); // This will get a random seed that isn't dependant on the system time as much since it is dependant on 1 centeral RNG (Right now. This will change.)
            Random Random = new Random(Seed);
            SpriteNumber = Random.Next(NumberOfSprites);  // Choses what icon is used for this tile.
            SpriteState = "Space" + SpriteNumber.ToString();                      // Sets the sprite to that icon.
            ContentLoader.AddTexture("Space" + SpriteNumber, "Objects/Turf/Space/" + SpriteNumber);
            ZeroToThree = Random.Next(4);
            RotationInRadians = ZeroToThree * (float)1.57079633; // Creates 4 varations of each sprite by rotating them, reducing common patterns.
            

            OtherProperties.Remove("footheight");
            OtherProperties.Add("lackofobject");        // lackofobject means that the object in question is more of the lack of an object than an object itself.


            InitaliseTurf();  // Does things relating to turfs. Like makes you able to walk on them and see through them.
        }

        /// <summary>
        /// Gets the data nesasary to sync to clients upon initalisation.
        /// </summary>
        /// <returns>Returns the data in Colin ':' seperated value form.</returns>
        public override string GetData()
        {
            return SpriteNumber.ToString() + "," + RotationInRadians.ToString();        // In this case the rotation and spritenumber are sent to the client.
        }

        private string[] Data; 

        /// <summary>
        /// Allows you to sync certan values batween client and server.
        /// </summary>
        /// <param name="DataInCSV">The data, in Colin ':' seperated value format.</param>
        public override void GiveData(string DataInCSV)
        {
            Data = DataInCSV.Split(',');    // Splits the data into an array, for easy interaction.

            SpriteNumber = Convert.ToInt32(Data[0]);
            RotationInRadians = Convert.ToInt32(Data[1]);
        }
    }
}


