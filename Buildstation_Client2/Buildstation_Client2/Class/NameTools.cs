using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buildstation_Client2.Class
{
    class NameTools
    {
        private string ObjectType; 
        private string[] NameStorage; // Contains the finished names. Probably can be used for something. I think a part in how the rendering will work, but I keep forgeting. Too much information to hold.
        int[] FirstUnusedChar; // Contains the numerical value of the first unused Charactor. Each spot in the array is another charactor used in combonation.
         // The names of objects are stored like WallA, FloorBC, or SpaceDSAGFGHDT.
        private string CerrentName;
        private int CerrentNameNumber;  //How many names have been generated basically.
        Random Random = new Random();
        public NameTools(string ObjectType)
        {
            ObjectType = this.ObjectType;
        }



        public string GetAtPosition(int Position)   // Return the value of the array at a given spot.
        {
            return NameStorage[Position];
        }

        public int GetLength()
        {
            return NameStorage.Length;
        }

        public string GenerateName(string ObjectType)
        {
            CerrentName = ObjectType + Random.Next(10000000); // This method doesnt have any methiods of avoiding name collision, but to much work for such a small chance.
            NameStorage[CerrentNameNumber] = CerrentName;
            CerrentNameNumber++;
            return CerrentName; // Yes, I know that doesnt actually do what I explained earlier, but at this point, I've been working on this for quite a while and I cant find a good solution.
        }
    }
}
