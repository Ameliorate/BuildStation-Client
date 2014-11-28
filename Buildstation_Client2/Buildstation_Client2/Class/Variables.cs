using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buildstation_Client2.Class
{
    static class Variables
    {
        // This class contains public varibles ment to be used in many places.

        public static string[, ,] Map = new string[15, 15, 64]; // The map. The contents of the string indacate what object, and is used to refer to a dictionary below witch contains data about the object. Formated [x] [y] [z] where z is how high in the stack or pile of objects the thing is. Preferably having 64 objects on one tile sould have the tile act as if it had an inpassible object on it. After all, it would be a very large pile of stuff.

        // TODO: Figure out a better way to store data about an object than a dictionary. If it is even needed that is.
    }
}
