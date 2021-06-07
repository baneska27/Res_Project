using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ServiceModel;
using Common;
using Res_Project;
using Res_Project.Resources;
using Res_Project.ToHistorical;


namespace DumpingBuffer
{
    public class Program 
    {

        public static DeltaCD deltaCD = new DeltaCD();
        public static bool canSendToHistory;
        public static MessageServis ms = new MessageServis();


        static void BeServerToWriter()
        {
            

            using (ServiceHost host = new ServiceHost(typeof(MessageServis)))
            {
                host.AddServiceEndpoint(typeof(IWriter),
                    new NetTcpBinding()
                    {
                        ReceiveTimeout = new TimeSpan(1, 0, 0)
                    },
                    new Uri("net.tcp://localhost:4000/IWriter"));
                host.Open();
                Console.WriteLine("[DumpingBuffer] as a [Server] - Successfully waiting on Writer component\n");

           

                
                for (; ; )
                {
                    
                }

            }
        }

        static void BeClientToHistorical()
        {
          
            
            

            //semaphoreHistorical 
            string address = "net.tcp://localhost:5002/IHistorical";
            NetTcpBinding binding = new NetTcpBinding();

            ChannelFactory<IHistorical> channel = new ChannelFactory<IHistorical>(binding, address);

            IHistorical proxy = channel.CreateChannel();

            Console.WriteLine("[DumpingBuffer] as a [CLIENT] - Successfully connected on Historical component\n");

            binding.SendTimeout = new TimeSpan(1, 0, 0);

            


          while (true)
            {
                deltaCD = ms.VratiDeltu();
                canSendToHistory = ms.IsReadyToSendDelta();
                Thread.Sleep(2000);
                if (canSendToHistory)
                {
                    /* proxy.WriteToHistory(deltaCD.CollectionDescription_ANALOG_DIGITAL.DumpingPropertyCollection.Value1.ToString());*/
                    proxy.WriteDeltaToHistory(deltaCD);
                    
                    ms.DeltaSent();
                   
                    
                }
               

            }





        }

        static void Main(string[] args)
        {
            
            Thread t1 = new Thread(BeServerToWriter);
            Thread t2 = new Thread(BeClientToHistorical);
            t1.Start();
            t2.Start();


        }
    }
}
