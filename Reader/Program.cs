using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reader
{
    class Program
    {
        static void ConnectToHistorical()
        {
            string address = "net.tcp://localhost:4003/IReader";
            NetTcpBinding binding = new NetTcpBinding();

            ChannelFactory<IReader> channel = new ChannelFactory<IReader>(binding, address);

            IReader proxy = channel.CreateChannel();

            Console.WriteLine("[READER] as a [CLIENT] - Successfully connected on Historical component\n");

            binding.SendTimeout = new TimeSpan(1, 0, 0);

            string message = "";
        }

        static void Main(string[] args)
        {

            Thread t1 = new Thread(new ThreadStart(ConnectToHistorical));
            t1.Start();
            for (; ; );
        }
    }
}
