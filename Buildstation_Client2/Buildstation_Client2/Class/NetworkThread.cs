using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Sockets;

namespace Buildstation_Client2.Class
{
    static class NetworkThread
    {
        /// <summary>
        /// Sorts data incoming from the server and acts apon it.
        /// </summary>
        public static void NetworkSortThread()
        {
            // Setting up everything needed for Sending and reciving data.
            TcpClient Client = new TcpClient(Variables.ServerIP, Variables.ServerPort);
            StreamReader ServerGet = new StreamReader(Client.GetStream());
            StreamWriter ServerSend = new StreamWriter(Client.GetStream());
            string Data;
            string[] DataSeperated;
            try
            {
                ServerSend.WriteLine("Info;Connected");  // Tells the server it's connected, and to send it to the info NetworkSorter. It works in the format [Thread];[Data]. If there is more than 1 peace of data, it can be seperated by commas.
                ServerSend.Flush();

                while (true)
                {
                    Data = ServerGet.ReadLine();
                    DataSeperated = Data.Split(';');

                    if (Data == "Sorter;Disconnect")    // Perhaps not nesasary, but I'm doing it anyway.
                    {
                        Client.Close();
                        break;
                    }

                    Console.WriteLine("Recived packet of sorter " + DataSeperated[0] + " And data " + DataSeperated[1]);

                    NetworkSorters[DataSeperated[0]].NewTrafic(DataSeperated[1]);      // Tells the NetworkSorter that it has new network trafic and gives it the data related to it.
                }
            }
            catch (Exception)
            {
                Game1.ExitGame();
            }
        }

        private static Dictionary<string, dynamic> NetworkSorters = new Dictionary<string, dynamic>();

        /// <summary>
        /// Allows you to recive network trafic.
        /// </summary>
        /// <param name="SorterName">The name trafic will refer to you as.</param>
        /// <param name="NetworkSorter">The reference to you. The best way to do this is to use the keyword "this" by itself.</param>
        public static void RegisterSorter(string SorterName, dynamic NetworkSorter)
        {
            NetworkSorters.Add(SorterName, NetworkSorter);
        }

        /// <summary>
        /// Send a packet to the server.
        /// </summary>
        /// <param name="NetworkSorter">The sorter the data will go to.</param>
        /// <param name="Data">The data sent to the server. Normally comma seperated values with no spaces.</param>
        public static void SendMessage(string NetworkSorter, string Data)
        {
            // Setting up everything needed for Sending and reciving data.
            TcpClient Client = new TcpClient(Variables.ServerIP, Variables.ServerPort);
            StreamWriter ServerSend = new StreamWriter(Client.GetStream());

            ServerSend.WriteLine(NetworkSorter + ";" + Data);
            ServerSend.Flush();
        }

    }




}

