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
        // In theory you can have the same object in different places at the same time, but any change you make to one object will ablo hapen to the otheer. Could be used to simulate quantum psyics though. "This is a quantum entangled paper. Anything you write on it will also be written on an other quantum entagled paper somewhere else."

        public Dictionary<string, string> ObjectData = new Dictionary<string, string>(); // The dictionary that was refered to, be careful to not let things conflict.
    }
}
