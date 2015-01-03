using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buildstation_Client2.Class
{
    abstract class NetworkSorter
    {
        public NetworkSorter()
        {
            NetworkThread.RegisterSorter("Foo", this);
        }

        protected string[] DataSplit;
        public virtual void NewTrafic(string Data)
        {
            throw new NotImplementedException();
        }
    }
}
