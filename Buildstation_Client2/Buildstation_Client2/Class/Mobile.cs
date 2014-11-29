using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buildstation_Client2.Class
{
    abstract class Mobile : PhysicalObject
    {
        protected void MoveUp() // Moves the player 1 tile up every time it's called.
        {
            YPos++;
        }

        protected void MoveDown() // 1 tle down.
        {
            YPos--;
        }

        protected void MoveLeft() // 1 tile left.
        {
            XPos--;
        }

        protected void MoveRight() // 1 tile right.
        {
            YPos++;
        }




        

        protected void MoveUp(int Distance) // Any ammount up.
        {
            YPos += Distance;
        }

        protected void MoveDown(int Distance) // Any ammount down.
        {
            YPos -= Distance;
        }

        protected void MoveLeft(int Distance) // Any ammount left.
        {
            XPos -= Distance;
        }

        protected void MoveRight(int Distance) // Any ammount right.
        {
            XPos += Distance;
        }


    }
}
