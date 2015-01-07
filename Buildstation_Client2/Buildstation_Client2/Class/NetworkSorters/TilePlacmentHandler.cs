using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buildstation_Client2.Class.NetworkSorters
{
    class TilePlacmentHandler : NetworkSorter
    {
        public TilePlacmentHandler()
        {
            NetworkThread.RegisterSorter("PlaceTile", this);
        }

        public override void NewTrafic(string Data)
        {       // Data will be [TileType],[TileName],[XPos],[YPos],[ZPos],[InitData]
            DataSplit = Data.Split(',');

            ObjectTools.SpawnObject(DataSplit[2], DataSplit[3], DataSplit[4], DataSplit[1], DataSplit[0]); // Basically, it creates a new tile in that place.
            Variables.PhysicalObjects[DataSplit[1]].GiveData(DataSplit[5]);     // Gives the tile in that spot the data it is intended to have at the molment.
        }
    }
}
