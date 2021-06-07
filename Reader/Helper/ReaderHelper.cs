using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader.Helper
{
    public class ReaderHelper
    {
        public void IspisiPoDataSetu(int izborIspisa2)
        {
            string path = "";
            switch (izborIspisa2)
            {
                case 1:
                    path = "../../../Historical/Baza/CodeAnalogCodeDigitalTable.txt";
                    break;
                case 2:
                    path = "../../../Historical/Baza/CodeCustomCodeLimitsetTable.txt";
                    break;
                case 3:
                    path = "../../../Historical/Baza/CodeSinglenodeCodeMultiplenodeTable.txt";
                    break;
                case 4:
                    path = "../../../Historical/Baza/CodeConsumerCodeSourceTable.txt";
                    break;
                case 5:
                    path = "../../../Historical/Baza/CodeMotionCodeSensorTable.txt";
                    break;
            }
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            string type = "";
            string value = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] data = line.Split(';');
                if (data.Length == 3)
                {
                    Console.WriteLine(data[0] + " " + data[1] + " " + data[2]);

                }

            }
            sr.Close();

        }

        public void IspisPoCode(int izborIspisa2)
        {
            string path = "";
            switch (izborIspisa2)
            {
                case 1:
                    path = "../../../Historical/Baza/CodeAnalogCodeDigitalTable.txt";
                    break;
                case 2:
                    path = "../../../Historical/Baza/CodeAnalogCodeDigitalTable.txt";
                    break;
                case 3:
                    path = "../../../Historical/Baza/CodeCustomCodeLimitsetTable.txt";
                    break;
                case 4:
                    path = "../../../Historical/Baza/CodeCustomCodeLimitsetTable.txt";
                    break;
                case 5:
                    path = "../../../Historical/Baza/CodeSinglenodeCodeMultiplenodeTable.txt";
                    break;
                case 6:
                    path = "../../../Historical/Baza/CodeSinglenodeCodeMultiplenodeTable.txt";
                    break;
                case 7:
                    path = "../../../Historical/Baza/CodeConsumerCodeSourceTable.txt";
                    break;
                case 8:
                    path = "../../../Historical/Baza/CodeConsumerCodeSourceTable.txt";
                    break;
                case 9:
                    path = "../../../Historical/Baza/CodeMotionCodeSensorTable.txt";
                    break;
                case 10:
                    path = "../../../Historical/Baza/CodeMotionCodeSensorTable.txt";
                    break;


            }
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            string type = "";
            string value = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] data = line.Split(';');
                if (data.Length == 3)
                {
                    if (izborIspisa2 == 1)
                    {
                        if (data[0].Equals("CODE_ANALOG"))
                        {
                            Console.WriteLine(data[0] + " " + data[1] + " " + data[2]);

                        }
                    }
                    else if (izborIspisa2 == 2)
                    {
                        if (data[0].Equals("CODE_DIGITAL"))
                        {
                            Console.WriteLine(data[0] + " " + data[1] + " " + data[2]);
                        }
                    }
                    else if (izborIspisa2 == 3)
                    {
                        if (data[0].Equals("CODE_CUSTOM"))
                        {
                            Console.WriteLine(data[0] + " " + data[1] + " " + data[2]);
                        }
                    }
                    else if (izborIspisa2 == 4)
                    {
                        if (data[0].Equals("CODE_LIMITSET"))
                        {
                            Console.WriteLine(data[0] + " " + data[1] + " " + data[2]);
                        }
                    }
                    else if (izborIspisa2 == 5)
                    {
                        if (data[0].Equals("CODE_SINGLENODE"))
                        {
                            Console.WriteLine(data[0] + " " + data[1] + " " + data[2]);
                        }
                    }
                    else if (izborIspisa2 == 6)
                    {
                        if (data[0].Equals("CODE_MULTIPLENODE"))
                        {
                            Console.WriteLine(data[0] + " " + data[1] + " " + data[2]);
                        }
                    }
                    else if (izborIspisa2 == 7)
                    {
                        if (data[0].Equals("CODE_CONSUMER"))
                        {
                            Console.WriteLine(data[0] + " " + data[1] + " " + data[2]);
                        }
                    }
                    else if (izborIspisa2 == 8)
                    {
                        if (data[0].Equals("CODE_SOURCE"))
                        {
                            Console.WriteLine(data[0] + " " + data[1] + " " + data[2]);
                        }
                    }
                    else if (izborIspisa2 == 9)
                    {
                        if (data[0].Equals("CODE_MOTION"))
                        {
                            Console.WriteLine(data[0] + " " + data[1] + " " + data[2]);
                        }
                    }
                    else if (izborIspisa2 == 10)
                    {
                        if (data[0].Equals("CODE_SENSOR"))
                        {
                            Console.WriteLine(data[0] + " " + data[1] + " " + data[2]);
                        }
                    }

                }

            }
            sr.Close();

        }

        public void IspisPoDatumu(DateTime from, DateTime to)
        {
            string path1 = "../../../Historical/Baza/CodeAnalogCodeDigitalTable.txt";
            string path2 = "../../../Historical/Baza/CodeCustomCodeLimitsetTable.txt";
            string path3 = "../../../Historical/Baza/CodeSinglenodeCodeMultiplenodeTable.txt";
            string path4 = "../../../Historical/Baza/CodeConsumerCodeSourceTable.txt";
            string path5 = "../../../Historical/Baza/CodeMotionCodeSensorTable.txt";

            FileStream stream = new FileStream(path1, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            string type = "";
            string value = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] data = line.Split(';');
                if (data.Length == 3)
                {
                    DateTime dateInFile = DateTime.Parse(data[2]);
                    if (dateInFile.CompareTo(from)>0 && dateInFile.CompareTo(to)<0)
                    {
                        Console.WriteLine(data[0] + " " + data[1] + " " + data[2]);

                    }





                }
            }
            sr.Close();

            stream = new FileStream(path2, FileMode.Open);
            sr = new StreamReader(stream);
            line = "";
            type = "";
            value = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] data = line.Split(';');
                if (data.Length == 3)
                {
                    DateTime dateInFile = DateTime.Parse(data[2]);
                    if (dateInFile.CompareTo(from) > 0 && dateInFile.CompareTo(to) < 0)
                    {
                        Console.WriteLine(data[0] + " " + data[1] + " " + data[2]);

                    }





                }
            }
            sr.Close();
            stream = new FileStream(path3, FileMode.Open);
            sr = new StreamReader(stream);
            line = "";
            type = "";
            value = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] data = line.Split(';');
                if (data.Length == 3)
                {
                    DateTime dateInFile = DateTime.Parse(data[2]);
                    if (dateInFile.CompareTo(from) > 0 && dateInFile.CompareTo(to) < 0)
                    {
                        Console.WriteLine(data[0] + " " + data[1] + " " + data[2]);

                    }





                }
            }
            sr.Close();
            stream = new FileStream(path4, FileMode.Open);
            sr = new StreamReader(stream);
            line = "";
            type = "";
            value = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] data = line.Split(';');
                if (data.Length == 3)
                {
                    DateTime dateInFile = DateTime.Parse(data[2]);
                    if (dateInFile.CompareTo(from) > 0 && dateInFile.CompareTo(to) < 0)
                    {
                        Console.WriteLine(data[0] + " " + data[1] + " " + data[2]);

                    }





                }
            }
            sr.Close();
            stream = new FileStream(path5, FileMode.Open);
            sr = new StreamReader(stream);
            line = "";
            type = "";
            value = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] data = line.Split(';');
                if (data.Length == 3)
                {
                    DateTime dateInFile = DateTime.Parse(data[2]);
                    int vrednost = dateInFile.CompareTo(from);
                    if (dateInFile.CompareTo(from) > 0 && dateInFile.CompareTo(to) < 0)
                    {
                        Console.WriteLine(data[0] + " " + data[1] + " " + data[2]);

                    }





                }
            }
            sr.Close();
        }
    }
}
