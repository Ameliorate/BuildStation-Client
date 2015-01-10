using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Buildstation_Client2.Class.NetworkSorters
{
    class FinishedHandler : NetworkSorter
    {
        public FinishedHandler()
        {
            NetworkThread.RegisterSorter("Finished", this);
        }

        private Dictionary<string, bool> Finished = new Dictionary<string, bool>();

        public override void NewTrafic(string Data)
        {
            try
            {
                Finished.Add(Data, true);
            }
            catch (ArgumentException)
            {
                Finished[Data] = true;
            }
        }

        public void WaitUntill(string Condition)
        {
            try
            {
                Finished.Add(Condition, false);
            }
            catch (ArgumentException) {}

            while (Finished[Condition] == false)
                Thread.Sleep(100);      // This never ends for some reason.
            

            Finished.Remove(Condition);
        }
    }
}
