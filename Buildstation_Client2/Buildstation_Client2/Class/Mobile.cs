using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buildstation_Client2.Class
{
    abstract class Mobile : PhysicalObject
    {

        /// <summary>
        /// Moves up 1 tile every time it is called.
        /// </summary>
        protected void MoveUp() // Moves the player 1 tile up every time it's called.
        {
            YPos++;
        }

        /// <summary>
        /// Moves down 1 tile every time it is called.
        /// </summary>
        protected void MoveDown() // 1 tle down.
        {
            YPos--;
        }

        /// <summary>
        /// Moves left 1 tile every time it is called.
        /// </summary>
        protected void MoveLeft() // 1 tile left.
        {
            XPos--;
        }

        /// <summary>
        /// Moves right 1 tile every time it is called.
        /// </summary>
        protected void MoveRight() // 1 tile right.
        {
            YPos++;
        }




        
        /// <summary>
        /// Moves any distance up.
        /// </summary>
        /// <param name="Distance">How far you want to move.</param>
        protected void MoveUp(int Distance) // Any ammount up.
        {
            YPos += Distance;
        }

        /// <summary>
        /// Moves any distance down.
        /// </summary>
        /// <param name="Distance">How far you want to move.</param>
        protected void MoveDown(int Distance) // Any ammount down.
        {
            YPos -= Distance;
        }

        /// <summary>
        /// Moves any distance left.
        /// </summary>
        /// <param name="Distance">How far you want to move.</param>
        protected void MoveLeft(int Distance) // Any ammount left.
        {
            XPos -= Distance;
        }

        /// <summary>
        /// Moves any distance right.
        /// </summary>
        /// <param name="Distance">How far you want to move.</param>
        protected void MoveRight(int Distance) // Any ammount right.
        {
            XPos += Distance;
        }


    }
}
