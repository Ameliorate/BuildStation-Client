using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buildstation_Client2.Class
{
    static class NameTools
    {
        private static int[] FirstUnusedChar; // Contains the numerical value of the first unused Charactor. Each spot in the array is another charactor used in combonation.
         // The names of objects are stored like Wall_A, Floor_BC, or Space_DSAGFGHDT.
        private static string CerrentName;
        private static int CerrentNameNumber;  //How many names have been generated basically.
        private static Random Random = new Random();



        
        /// <summary>
        /// Generates names for objects to use
        /// </summary>
        /// <param name="ObjectType">The type of object you are making. EX: Space or Wall.</param>
        /// <returns>Returns a name for the object in the form of [Type]_[UOID]</returns>
        public static string GenerateName(string ObjectType)
        {
            CerrentName = ObjectType + "_" + Random.Next(int.MaxValue); // This method doesnt have any methiods of avoiding name collision, but to much work for such a small chance.
            CerrentNameNumber++;
            return CerrentName; // Yes, I know that doesnt actually do what I explained earlier, but at this point, I've been working on this for quite a while and I cant find a good solution.
        }
    }
}
