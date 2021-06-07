using Common;
using Historical._Resource_Historical;
using Historical._Resource_Reader;
using Res_Project._Resource_DumpingBuffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Historical
{
    class Program
    {
        static void BeServerToDumping()
        {
           
            using (ServiceHost host = new ServiceHost(typeof(HistoricalService)))
            {
                host.AddServiceEndpoint(typeof(IHistorical),
                    new NetTcpBinding()
                    {
                        ReceiveTimeout = new TimeSpan(1, 0, 0)
                    },
                    new Uri("net.tcp://localhost:5002/IHistorical"));
                host.Open();
                Console.WriteLine("[Historical] as a [Server] - Successfully waiting on DumpingBuffer component\n");

                Console.ReadLine();



            }
        }

        static void BeServerToReader()
        {
            using (ServiceHost host = new ServiceHost(typeof(ReaderService)))
            {
                host.AddServiceEndpoint(typeof(IReader),
                    new NetTcpBinding()
                    {
                        ReceiveTimeout = new TimeSpan(1, 0, 0)
                    },
                    new Uri("net.tcp://localhost:4003/IReader"));
                host.Open();
                Console.WriteLine("[Historical] as a [Server] - Successfully waiting on Reader component\n");

                Console.ReadLine();





            }
        }

        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(BeServerToDumping));
            Thread t2 = new Thread(new ThreadStart(BeServerToReader));

            t2.Start();
            t1.Start();
            for (; ; );
        }
    }
}
