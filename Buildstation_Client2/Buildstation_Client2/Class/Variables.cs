using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buildstation_Client2.Class
{
    static class Variables
    {
        // This class contains public varibles ment to be used in many places.

        public static string[, ,] Map = new string[15, 15, 64]; // The map. Mostly is used by other objects to see what is under them and to interface with those objects. X and Y are self explanatory, Z is the height of the objects in a pile of objects. 0 is normally the floor.
        // If there are 64 objects on the floor, preferably the tile should be impassible.
        


        static public char[] AllPossibleCharactors = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        // Every single possible reasonable charactor on your keyboard. Could include lowercases for almost twice as many, but thats getting unreasonable. Also too much efort to type.


         

    }
}
