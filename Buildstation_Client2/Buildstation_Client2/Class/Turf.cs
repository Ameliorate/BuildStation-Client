using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buildstation_Client2.Class
{
    abstract class Turf : PhysicalObject
    {
        protected void InitaliseTurf()
        {
            IsDragable = false;  // Sets all the properties tipical of a floor.
            IsPassable = true;
            IsTransparent = true;

            InitaliseBace();   // Initalises the bace class.

            // TODO: Set up nesasary code to simulate an atmosphere.
        }




    }
}
