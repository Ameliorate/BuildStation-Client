using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buildstation_Client2.Class
{
    static class Variables
    {
        // This class contains public varibles ment to be used in many places.

        /// <summary>
        /// The map. Mostly is used by other objects to see what is under them and to interface with those objects. X and Y are self explanatory, Z is the height of the objects in a pile of objects. 0 is normally the floor or space.
        /// </summary>
        public static string[, ,] Map = new string[16, 16, 64]; 
        // If there are 64 objects on the floor, preferably the tile should be impassible.
        

        /// <summary>
        /// Every single possible reasonable charactor on your keyboard. Could include lowercases for almost twice as many, but thats getting unreasonable. Also too much efort to type.
        /// </summary>
        static public char[] AllPossibleCharactors = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        
        public static Dictionary<string, dynamic> PhysicalObjects = new Dictionary<string, dynamic>();      // A dictionary of objects. Every single object in the game. Probably not optimal, but I cant find another way.

        
        static private int XLength;
        static private int YLength;
        static private int ZLength;
        static private string CerrentTileName;
        static private int XPos;
        static private int YPos;
        static private int ZPos;
        static private bool IsTileNotAtPos;

        /// <summary>
        /// Checks if there is any tile existing in that plane.
        /// </summary>
        /// <param name="ZPlane">The Z coordanite of the plane you want to check.</param>
        /// <returns>Returns a bool, true if it finds a tile, false if not.</returns>
        static public bool IsAnythingInZPlane(int ZPlane)       
        {
            XLength = Map.GetLength(0);         // Gets the length of each plane. Will be used later.
            YLength = Map.GetLength(1);
            ZLength = Map.GetLength(2);

            while (true)
            {
                CerrentTileName = Map[XPos, YPos, ZPlane];      // Gets the thing at the cerrent pos.
                IsTileNotAtPos = string.IsNullOrEmpty(CerrentTileName);        // Sees if it is null or empty.

                if (IsTileNotAtPos == false)            // If it is not, return true since there is something at that spot.
                {
                    return true;
                }
                else
                {
                    XPos++;
                    if (XPos <= XLength)        // If it is at the end of the map, move on to the next Y row.
                    {
                        XPos = 0;
                        YPos++;
                        if (YPos == YLength)    // If it is at the very end, return false because there is nothing in that ZPlane.
                        {
                            XPos = 0;
                            YPos = 0;
                            return false;
                        }
                    }
                }
            }
        }   // Method ends here.

        /// <summary>
        /// Checks if there is any tile existing in that plane.
        /// </summary>
        /// <param name="XPlane">The X coordanite of the plane you want to check.</param>
        /// <returns>Returns a bool, true if it finds a tile, false if not.</returns>
        static public bool IsAnythingInXPlane(int XPlane)       
        {
            XLength = Map.GetLength(0);         // Gets the length of each plane. Will be used later.
            YLength = Map.GetLength(1);
            ZLength = Map.GetLength(2);

            while (true)
            {
                CerrentTileName = Map[XPlane, YPos, ZPos];      // Gets the thing at the cerrent pos.
                IsTileNotAtPos = string.IsNullOrEmpty(CerrentTileName);        // Sees if it is null or empty.

                if (IsTileNotAtPos == false)            // If it is not, return true since there is something at that spot.
                {
                    return true;
                }
                else
                {
                    ZPos++;
                    if (ZPos <= ZLength)        // If it is at the end of the map, move on to the next Z row.
                    {
                        ZPos = 0;
                        YPos++;
                        if (YPos == YLength)    // If it is at the very end, return false because there is nothing in that XPlane.
                        {
                            ZPos = 0;
                            YPos = 0;
                            return false;
                        }
                    }
                }
            }
        }   // Method ends here.

        /// <summary>
        /// Checks if there is any tile existing in that plane
        /// </summary>
        /// <param name="YPlane">The Y coordanite of the plane you want to check.</param>
        /// <returns>Returns a bool, true if it finds a tile, false if not.</returns>
        static public bool IsAnythingInYPlane(int YPlane)       
        {
            XLength = Map.GetLength(0);         // Gets the length of each plane. Will be used later.
            YLength = Map.GetLength(1);
            ZLength = Map.GetLength(2);

            while (true)
            {
                CerrentTileName = Map[XPos, YPlane, ZPos];      // Gets the thing at the cerrent pos.
                IsTileNotAtPos = string.IsNullOrEmpty(CerrentTileName);        // Sees if it is null or empty.

                if (IsTileNotAtPos == false)            // If it is not, return true since there is something at that spot.
                {
                    return true;
                }
                else
                {
                    XPos++;
                    if (XPos <= XLength)        // If it is at the end of the map, move on to the next X row.
                    {
                        XPos = 0;
                        ZPos++;
                        if (ZPos == ZLength)    // If it is at the very end, return false because there is nothing in that YPlane.
                        {
                            XPos = 0;
                            ZPos = 0;
                            return false;
                        }
                    }
                }
            }
        }   // Method ends here.

    }
}
