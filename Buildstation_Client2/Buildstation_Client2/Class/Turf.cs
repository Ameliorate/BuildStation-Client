using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buildstation_Client2.Class
{
    class Turf : PhysicalObject
    {

        protected void InitaliseTurf()
        {
            InitaliseBace();   // Initalises the bace class.
            IsDragable = false;  // Sets all the properties tipical of a floor.
            IsPassable = true;
            IsTransparent = true;

            // TODO: Set up nesasary code to simulate an atmosphere.
        }




    }
}
