using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buildstation_Client2.Class
{
    class ObjectTools        // Intended to contain tools relating to using physical objects.
    {
        private int[] Coordnates2d;
        private int[] Coordnates3d;

        public object SpawnObject(string ObjectName, Type ObjectType, int XPos, int YPos)  // Spawns an object at the given coordanites.
        {
            Coordnates2d[1] = XPos;
            Coordnates2d[2] = YPos;
            return Activator.CreateInstance(ObjectType, Coordnates2d);
        }

        public object SpawnObject(string ObjectName, Type ObjectType, int XPos, int YPos, int ZPos)  // Spawns an object at the given coordanites. Replaces the object if there is already something in that spot.
        {
            Coordnates3d[1] = XPos;
            Coordnates3d[2] = YPos;
            Coordnates3d[3] = ZPos;
            return Activator.CreateInstance(ObjectType, Coordnates3d);
        }
        


    }
}
