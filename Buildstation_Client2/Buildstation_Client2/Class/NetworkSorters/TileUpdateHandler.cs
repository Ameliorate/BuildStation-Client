using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buildstation_Client2.Class.NetworkSorters
{
    class TileUpdateHandler : NetworkSorter
    {
        public TileUpdateHandler()
        {
            NetworkThread.RegisterSorter("UpdateTile", this);
        }

        public override void NewTrafic(string Data)
        {       // Data comes in as [TileName],[UpdateData]
            DataSplit = Data.Split(',');

            Variables.PhysicalObjects[DataSplit[0]].NetUpdate(DataSplit[1]);
        }
    }
}
