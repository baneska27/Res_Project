using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Writer.Helper;

namespace Writer
{
    class Program
    {
           static void ConnectToDumpingBuffer()
           {
                
                string address = "net.tcp://localhost:4000/IWriter";
                NetTcpBinding binding = new NetTcpBinding();

                ChannelFactory<IWriter> channel = new ChannelFactory<IWriter>(binding, address);

                IWriter proxy = channel.CreateChannel();

                Console.WriteLine("[Writer] as a [CLIENT] - Successfully connected on DumpingBuffer component\n");

                binding.SendTimeout = new TimeSpan(1, 0, 0);

                string message = "";

                WriterHelper a = new WriterHelper();


                do
                {
                    //proxy.WriteToDumpingBuffer(message);

                    while (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        message = a.UnosZaDumping();
                        proxy.ManualWriteToDumpingBuffer(message);
                    }

                    Thread.Sleep(2000);

                } while (true);



           }

        static void Main(string[] args)
        {

            Thread t1 = new Thread(new ThreadStart(ConnectToDumpingBuffer));
            t1.Start();

            for (; ; );
            




            
  
        }
    }
}
