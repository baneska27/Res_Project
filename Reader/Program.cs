using Common;
using Reader.Helper;
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
        static ReaderHelper readerHelper = new ReaderHelper();
        static void ConnectToHistorical()
        {
            string address = "net.tcp://localhost:4003/IReader";
            NetTcpBinding binding = new NetTcpBinding();

            ChannelFactory<IReader> channel = new ChannelFactory<IReader>(binding, address);

            IReader proxy = channel.CreateChannel();

            Console.WriteLine("[READER] as a [CLIENT] - Successfully connected on Historical component\n");

            binding.SendTimeout = new TimeSpan(1, 0, 0);

            int izborIspisa = 0;
            int izborIspisa2 = 0;
            string message = "";
            while(true)
            {
                do
                {
                    Console.WriteLine("1. Ispis po DataSetu\n");
                    Console.WriteLine("2. Ispis po Code-u\n");
                    Console.WriteLine("3. Ispis po datumu\n");
                    izborIspisa = Int32.Parse(Console.ReadLine());
                } while (izborIspisa > 4);
                
                if(izborIspisa==1)
                {
                    do
                    {
                        Console.WriteLine("Izaberite DataSet\n");
                        Console.WriteLine("1. Dataset 1 (CodeAnalog+CodeDigital)\n");
                        Console.WriteLine("2. Dataset 2 (CodeCustom+CodeLimitset)\n");
                        Console.WriteLine("3. Dataset 3 (CodeSingleNode+CodeMultipleNode\n");
                        Console.WriteLine("4. Dataset 4 (CodeConsumer+CodeSource)\n");
                        Console.WriteLine("5. Dataset 5 (CodeMotion+CodeSensor)\n");
                        izborIspisa2 = Int32.Parse(Console.ReadLine());

                    } while (izborIspisa2 > 6  || izborIspisa2 < 0);

                    readerHelper.IspisiPoDataSetu(izborIspisa2);
                }
                else if(izborIspisa==2)
                {
                    do
                    {
                        Console.WriteLine("Izaberite Code\n");
                        Console.WriteLine("1. Code Analog\n");
                        Console.WriteLine("2. Code Digital\n");
                        Console.WriteLine("3. Code Custom\n");
                        Console.WriteLine("4. Code Limitset\n");
                        Console.WriteLine("5. Code Singlenode\n");
                        Console.WriteLine("6. Code Multiplenode\n");
                        Console.WriteLine("7. Code Consumer\n");
                        Console.WriteLine("8. Code Source\n");
                        Console.WriteLine("9. Code Motion\n");
                        Console.WriteLine("10. Code Sensor\n");
                        izborIspisa2 = Int32.Parse(Console.ReadLine());

                    } while (izborIspisa2 > 10 || izborIspisa2<0);

                    readerHelper.IspisPoCode(izborIspisa2);
                }
                else if(izborIspisa==3)
                {
                    DateTime from;
                    DateTime to;
                    Console.WriteLine("Unos datuma OD - DO\n");
                    Console.WriteLine("[OD] Unesite datum u formatu DD/MM/YYYY: ");
                    from = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("[DO] Unesite datum u formatu DD/MM/YYYY: ");
                    to = DateTime.Parse(Console.ReadLine());

                    readerHelper.IspisPoDatumu(from, to);
                }
            }
        }

        static void Main(string[] args)
        {

            Thread t1 = new Thread(new ThreadStart(ConnectToHistorical));
            t1.Start();
            
        }
    }
}
