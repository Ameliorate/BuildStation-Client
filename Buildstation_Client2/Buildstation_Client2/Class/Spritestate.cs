using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buildstation_Client2.Class
{
    struct Spritestate
    {
        public Spritestate (string Sprite, float Rotation, int SizeX, int SizeY)
        {
            this.Sprite = Sprite;
            this.Rotation = Rotation;
            this.SizeX = SizeX;
            this.SizeY = SizeY;
        }

        public string Sprite;
        public float Rotation;
        public int SizeX;
        public int SizeY;
    }
}
