using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buildstation_Client2.Class
{
    /// <summary>
    /// Holds 3 values corasponding to a point in space.
    /// </summary>
    struct Coordinate
    {
        public int XPos;
        public int YPos;
        public int ZPos;

        public Coordinate(int XPos, int YPos, int ZPos)
        {
            this.XPos = XPos;
            this.YPos = YPos;
            this.ZPos = ZPos;
        }

        public static bool operator ==(Coordinate c1, Coordinate c2)
        {
            if (c1.XPos == c2.XPos && c1.YPos == c2.YPos && c1.ZPos == c2.ZPos)
                return true;
            else
                return false;
        }

        public static bool operator !=(Coordinate c1, Coordinate c2)
        {
            if (c1.XPos != c2.XPos && c1.YPos != c2.YPos && c1.ZPos != c2.ZPos)
                return false;
            else
                return true;
        }
    }
}
