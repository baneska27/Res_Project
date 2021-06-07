using Common;
using Common._Historical_SharedClasses;
using Res_Project._Resource_DumpingBuffer;
using Res_Project.ToHistorical;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Historical._Resource_Historical
{
    public class HistoricalService : IHistorical
    {
        static LD ld = new LD();
        static bool first_time = true;
        public void WriteDeltaToHistory(DeltaCD delta)
        {
            Console.WriteLine(delta.CollectionDescription_ANALOG_DIGITAL.Id + delta.CollectionDescription_ANALOG_DIGITAL.DataSet.ToString() + delta.CollectionDescription_ANALOG_DIGITAL.DumpingPropertyCollection.Value1);
            List<HistoricalProperty> historicals = new List<HistoricalProperty>();
            //analog
            HistoricalProperty historicalProperty = new HistoricalProperty(delta.CollectionDescription_ANALOG_DIGITAL.DumpingPropertyCollection.TypeCode1, delta.CollectionDescription_ANALOG_DIGITAL.DumpingPropertyCollection.Value1);
            //digital
            HistoricalProperty historicalProperty1 = new HistoricalProperty(delta.CollectionDescription_ANALOG_DIGITAL.DumpingPropertyCollection.TypeCode2, delta.CollectionDescription_ANALOG_DIGITAL.DumpingPropertyCollection.Value2);

            historicals.Add(historicalProperty);
            historicals.Add(historicalProperty1);

            ld.ListDescription.Add(new Description(delta.CollectionDescription_ANALOG_DIGITAL.Id, historicals, delta.CollectionDescription_ANALOG_DIGITAL.DataSet));

            historicals = new List<HistoricalProperty>();

            //CONSUMER --- SOURCE  
            historicalProperty = new HistoricalProperty(delta.CollectionDescription_CONSUMER_SOURCE.DumpingPropertyCollection.TypeCode1, delta.CollectionDescription_CONSUMER_SOURCE.DumpingPropertyCollection.Value1);
            historicalProperty1 = new HistoricalProperty(delta.CollectionDescription_CONSUMER_SOURCE.DumpingPropertyCollection.TypeCode2, delta.CollectionDescription_CONSUMER_SOURCE.DumpingPropertyCollection.Value2);

            historicals.Add(historicalProperty);
            historicals.Add(historicalProperty1);

            ld.ListDescription.Add(new Description(delta.CollectionDescription_CONSUMER_SOURCE.Id, historicals, delta.CollectionDescription_CONSUMER_SOURCE.DataSet));

            historicals = new List<HistoricalProperty>();

            //CUSTOM - LIMITSET

            historicalProperty = new HistoricalProperty(delta.CollectionDescription_CUSTOM_LIMITSET.DumpingPropertyCollection.TypeCode1, delta.CollectionDescription_CUSTOM_LIMITSET.DumpingPropertyCollection.Value1);
            historicalProperty1 = new HistoricalProperty(delta.CollectionDescription_CUSTOM_LIMITSET.DumpingPropertyCollection.TypeCode2, delta.CollectionDescription_CUSTOM_LIMITSET.DumpingPropertyCollection.Value2);
            historicals.Add(historicalProperty);
            historicals.Add(historicalProperty1);

            ld.ListDescription.Add(new Description(delta.CollectionDescription_CUSTOM_LIMITSET.Id, historicals, delta.CollectionDescription_CUSTOM_LIMITSET.DataSet));
            historicals = new List<HistoricalProperty>();


            // MOTION - SENSOR 
            historicalProperty = new HistoricalProperty(delta.CollectionDescription_MOTION_SENSOR.DumpingPropertyCollection.TypeCode1, delta.CollectionDescription_MOTION_SENSOR.DumpingPropertyCollection.Value1);
            historicalProperty1 = new HistoricalProperty(delta.CollectionDescription_MOTION_SENSOR.DumpingPropertyCollection.TypeCode2, delta.CollectionDescription_MOTION_SENSOR.DumpingPropertyCollection.Value2);

            historicals.Add(historicalProperty);
            historicals.Add(historicalProperty1);

            ld.ListDescription.Add(new Description(delta.CollectionDescription_MOTION_SENSOR.Id, historicals, delta.CollectionDescription_MOTION_SENSOR.DataSet));
            historicals = new List<HistoricalProperty>();



            // SINGLE - MULTIPLE

            historicalProperty = new HistoricalProperty(delta.CollectionDescription_SINGLE_MULTIPLE.DumpingPropertyCollection.TypeCode1, delta.CollectionDescription_SINGLE_MULTIPLE.DumpingPropertyCollection.Value1);
            historicalProperty1 = new HistoricalProperty(delta.CollectionDescription_SINGLE_MULTIPLE.DumpingPropertyCollection.TypeCode2, delta.CollectionDescription_SINGLE_MULTIPLE.DumpingPropertyCollection.Value2);

            historicals.Add(historicalProperty);
            historicals.Add(historicalProperty1);

            ld.ListDescription.Add(new Description(delta.CollectionDescription_SINGLE_MULTIPLE.Id, historicals, delta.CollectionDescription_SINGLE_MULTIPLE.DataSet));
            historicals = new List<HistoricalProperty>();

            if (DeadBandCheckAnalog())
            {
                UpisiUBazuAnalog();
            }
                
                UpisiUBazuDigital();
            
            if(DeadBandCheckConsumer())
            {
                UpisiUBazuConsumer();
            }

            if(DeadBandCheckSource())
            {
                UpisiUBazuSource();

            }
            if(DeadBandCheckCustom())
            {
                UpisiUBazuCustom();

            }
            if(DeadBandCheckLimitset())
            {
                UpisiUBazuLimitset();

            }
            if(DeadBandCheckMotion())
            {
                UpisiUBazuMotion();

            }

            if(DeadBandCheckSensor())
            {
                UpisiUBazuSensor();

            }
            if(DeadBandCheckSinglenode())
            {
                UpisiUBazuSinglenode();

            }
            if(DeadBandCheckMultiplenode())
            {
                UpisiUBazuMultiplenode();

            }




        }

        private void UpisiUBazuAnalog()
        {
            string path = "../../Baza/CodeAnalogCodeDigitalTable.txt";
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                for (int i = 0; i < ld.ListDescription.Count; i++)
                {
                    if (ld.ListDescription[i].DataSet.Num == EnumberOfDataSet.CODEANALOG_CODEDIGTIAL)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            if (ld.ListDescription[i].ListHistorical[j].CodeType == Res_Project.Resources.CodeType.CODE_ANALOG)
                            {
                                
                             
                                    sw.WriteLine(ld.ListDescription[i].ListHistorical[j].CodeType.ToString() + ";" + ld.ListDescription[i].ListHistorical[j].Value.ToString() + ";" + DateTime.Now.ToString());

                                

                            }
                        }

                    }
                }
            }

        }

        private void UpisiUBazuDigital()
        {
            string path = "../../Baza/CodeAnalogCodeDigitalTable.txt";
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                for (int i = 0; i < ld.ListDescription.Count; i++)
                {
                    if (ld.ListDescription[i].DataSet.Num == EnumberOfDataSet.CODEANALOG_CODEDIGTIAL)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            if (ld.ListDescription[i].ListHistorical[j].CodeType == Res_Project.Resources.CodeType.CODE_DIGITAL)
                            {
                                sw.WriteLine(ld.ListDescription[i].ListHistorical[j].CodeType.ToString() + ";" + ld.ListDescription[i].ListHistorical[j].Value.ToString() + ";" + DateTime.Now.ToString());

                            }
                        }

                    }
                }
            }

        }

        private void UpisiUBazuConsumer()
        {
            string path = "../../Baza/CodeConsumerCodeSourceTable.txt";
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                for (int i = 0; i < ld.ListDescription.Count; i++)
                {
                    if (ld.ListDescription[i].DataSet.Num == EnumberOfDataSet.CODECONSUMER_CODESOURCE)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            if (ld.ListDescription[i].ListHistorical[j].CodeType == Res_Project.Resources.CodeType.CODE_CONSUMER)
                            {
                                sw.WriteLine(ld.ListDescription[i].ListHistorical[j].CodeType.ToString() + ";" + ld.ListDescription[i].ListHistorical[j].Value.ToString() + ";" + DateTime.Now.ToString());

                            }
                        }

                    }
                }
            }

        }

        private void UpisiUBazuSource()
        {
            string path = "../../Baza/CodeConsumerCodeSourceTable.txt";
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                for (int i = 0; i < ld.ListDescription.Count; i++)
                {
                    if (ld.ListDescription[i].DataSet.Num == EnumberOfDataSet.CODECONSUMER_CODESOURCE)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            if (ld.ListDescription[i].ListHistorical[j].CodeType == Res_Project.Resources.CodeType.CODE_SOURCE)
                            {
                                sw.WriteLine(ld.ListDescription[i].ListHistorical[j].CodeType.ToString() + ";" + ld.ListDescription[i].ListHistorical[j].Value.ToString() + ";" + DateTime.Now.ToString());

                            }
                        }

                    }
                }
            }

        }

        private void UpisiUBazuCustom()
        {
            string path = "../../Baza/CodeCustomCodeLimitsetTable.txt";
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                for (int i = 0; i < ld.ListDescription.Count; i++)
                {
                    if (ld.ListDescription[i].DataSet.Num == EnumberOfDataSet.CODECUSTOM_CODELIMITSET)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            if (ld.ListDescription[i].ListHistorical[j].CodeType == Res_Project.Resources.CodeType.CODE_CUSTOM)
                            {
                                sw.WriteLine(ld.ListDescription[i].ListHistorical[j].CodeType.ToString() + ";" + ld.ListDescription[i].ListHistorical[j].Value.ToString() + ";" + DateTime.Now.ToString());

                            }
                        }

                    }
                }
            }

        }

        private void UpisiUBazuLimitset()
        {
            string path = "../../Baza/CodeCustomCodeLimitsetTable.txt";
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                for (int i = 0; i < ld.ListDescription.Count; i++)
                {
                    if (ld.ListDescription[i].DataSet.Num == EnumberOfDataSet.CODECUSTOM_CODELIMITSET)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            if (ld.ListDescription[i].ListHistorical[j].CodeType == Res_Project.Resources.CodeType.CODE_LIMITSET)
                            {
                                sw.WriteLine(ld.ListDescription[i].ListHistorical[j].CodeType.ToString() + ";" + ld.ListDescription[i].ListHistorical[j].Value.ToString() + ";" + DateTime.Now.ToString());

                            }
                        }

                    }
                }
            }

        }


        private void UpisiUBazuMotion()
        {
            string path = "../../Baza/CodeMotionCodeSensorTable.txt";
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                for (int i = 0; i < ld.ListDescription.Count; i++)
                {
                    if (ld.ListDescription[i].DataSet.Num == EnumberOfDataSet.CODEMOTION_CODESENSOR)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            if (ld.ListDescription[i].ListHistorical[j].CodeType == Res_Project.Resources.CodeType.CODE_MOTION)
                            {
                                sw.WriteLine(ld.ListDescription[i].ListHistorical[j].CodeType.ToString() + ";" + ld.ListDescription[i].ListHistorical[j].Value.ToString() + ";" + DateTime.Now.ToString());

                            }
                        }

                    }
                }
            }

        }

        private void UpisiUBazuSensor()
        {
            string path = "../../Baza/CodeMotionCodeSensorTable.txt";
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                for (int i = 0; i < ld.ListDescription.Count; i++)
                {
                    if (ld.ListDescription[i].DataSet.Num == EnumberOfDataSet.CODEMOTION_CODESENSOR)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            if (ld.ListDescription[i].ListHistorical[j].CodeType == Res_Project.Resources.CodeType.CODE_SENSOR)
                            {
                                sw.WriteLine(ld.ListDescription[i].ListHistorical[j].CodeType.ToString() + ";" + ld.ListDescription[i].ListHistorical[j].Value.ToString() + ";" + DateTime.Now.ToString());

                            }
                        }

                    }
                }
            }

        }

        private void UpisiUBazuSinglenode()
        {
            string path = "../../Baza/CodeSinglenodeCodeMultiplenodeTable.txt";
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                for (int i = 0; i < ld.ListDescription.Count; i++)
                {
                    if (ld.ListDescription[i].DataSet.Num == EnumberOfDataSet.CODESINGLENODE_CODEMULTIPLENODE)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            if (ld.ListDescription[i].ListHistorical[j].CodeType == Res_Project.Resources.CodeType.CODE_SINGLENODE)
                            {
                                sw.WriteLine(ld.ListDescription[i].ListHistorical[j].CodeType.ToString() + ";" + ld.ListDescription[i].ListHistorical[j].Value.ToString() + ";" + DateTime.Now.ToString());

                            }
                        }

                    }
                }
            }

        }

        private void UpisiUBazuMultiplenode()
        {
            string path = "../../Baza/CodeSinglenodeCodeMultiplenodeTable.txt";
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                for (int i = 0; i < ld.ListDescription.Count; i++)
                {
                    if (ld.ListDescription[i].DataSet.Num == EnumberOfDataSet.CODESINGLENODE_CODEMULTIPLENODE)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            if (ld.ListDescription[i].ListHistorical[j].CodeType == Res_Project.Resources.CodeType.CODE_MULTIPLENODE)
                            {
                                sw.WriteLine(ld.ListDescription[i].ListHistorical[j].CodeType.ToString() + ";" + ld.ListDescription[i].ListHistorical[j].Value.ToString() + ";" + DateTime.Now.ToString());

                            }
                        }

                    }
                }
            }

        }



        public void WriteToHistory(string deltaCD)
        {
            Console.WriteLine(deltaCD);
        }

        public bool DeadBandCheckAnalog()
        {
            string path = "../../Baza/CodeAnalogCodeDigitalTable.txt";
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            string type = "";
            string value = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] data = line.Split(';');
                type = data[0];
                if (type.Equals("CODE_ANALOG"))
                {

                    value = data[1];
                }

                if (line == null)
                {
                    break;
                }
            }

            sr.Close();

            float vrednostP = -1;
            for (int i = 0; i < ld.ListDescription.Count; i++)
            {
                if (ld.ListDescription[i].DataSet.Num == EnumberOfDataSet.CODEANALOG_CODEDIGTIAL)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (ld.ListDescription[i].ListHistorical[j].CodeType == Res_Project.Resources.CodeType.CODE_ANALOG)
                        {


                            vrednostP =(float) ld.ListDescription[i].ListHistorical[j].Value;



                        }
                    }

                }
            }




            float vrednost = (float)int.Parse(value);




            float granicaDonja = vrednost - ((vrednost / 100) * 2);
            float granicaGornja = vrednost + ((vrednost / 100) * 2);










            if (vrednostP < granicaDonja || vrednostP > granicaGornja)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeadBandCheckConsumer()
        {
            string path = "../../Baza/CodeConsumerCodeSourceTable.txt";
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            string type = "";
            string value = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] data = line.Split(';');
                type = data[0];
                if (type.Equals("CODE_CONSUMER"))
                {

                    value = data[1];
                }

                if (line == null)
                {
                    break;
                }
            }

            sr.Close();

            float vrednostP = -1;
            for (int i = 0; i < ld.ListDescription.Count; i++)
            {
                if (ld.ListDescription[i].DataSet.Num == EnumberOfDataSet.CODECONSUMER_CODESOURCE)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (ld.ListDescription[i].ListHistorical[j].CodeType == Res_Project.Resources.CodeType.CODE_CONSUMER)
                        {


                            vrednostP = (float)ld.ListDescription[i].ListHistorical[j].Value;



                        }
                    }

                }
            }




            float vrednost = (float)int.Parse(value);




            float granicaDonja = vrednost - ((vrednost / 100) * 2);
            float granicaGornja = vrednost + ((vrednost / 100) * 2);










            if (vrednostP < granicaDonja || vrednostP > granicaGornja)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeadBandCheckSource()
        {
            string path = "../../Baza/CodeConsumerCodeSourceTable.txt";
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            string type = "";
            string value = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] data = line.Split(';');
                type = data[0];
                if (type.Equals("CODE_SOURCE"))
                {

                    value = data[1];
                }

                if (line == null)
                {
                    break;
                }
            }

            sr.Close();

            float vrednostP = -1;
            for (int i = 0; i < ld.ListDescription.Count; i++)
            {
                if (ld.ListDescription[i].DataSet.Num == EnumberOfDataSet.CODECONSUMER_CODESOURCE)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (ld.ListDescription[i].ListHistorical[j].CodeType == Res_Project.Resources.CodeType.CODE_SOURCE)
                        {


                            vrednostP = (float)ld.ListDescription[i].ListHistorical[j].Value;



                        }
                    }

                }
            }




            float vrednost = (float)int.Parse(value);




            float granicaDonja = vrednost - ((vrednost / 100) * 2);
            float granicaGornja = vrednost + ((vrednost / 100) * 2);










            if (vrednostP < granicaDonja || vrednostP > granicaGornja)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeadBandCheckCustom()
        {
            string path = "../../Baza/CodeCustomCodeLimitsetTable.txt";
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            string type = "";
            string value = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] data = line.Split(';');
                type = data[0];
                if (type.Equals("CODE_CUSTOM"))
                {

                    value = data[1];
                }

                if (line == null)
                {
                    break;
                }
            }

            sr.Close();

            float vrednostP = -1;
            for (int i = 0; i < ld.ListDescription.Count; i++)
            {
                if (ld.ListDescription[i].DataSet.Num == EnumberOfDataSet.CODECUSTOM_CODELIMITSET)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (ld.ListDescription[i].ListHistorical[j].CodeType == Res_Project.Resources.CodeType.CODE_CUSTOM)
                        {


                            vrednostP = (float)ld.ListDescription[i].ListHistorical[j].Value;



                        }
                    }

                }
            }




            float vrednost = (float)int.Parse(value);




            float granicaDonja = vrednost - ((vrednost / 100) * 2);
            float granicaGornja = vrednost + ((vrednost / 100) * 2);










            if (vrednostP < granicaDonja || vrednostP > granicaGornja)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeadBandCheckLimitset()
        {
            string path = "../../Baza/CodeCustomCodeLimitsetTable.txt";
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            string type = "";
            string value = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] data = line.Split(';');
                type = data[0];
                if (type.Equals("CODE_LIMITSET"))
                {

                    value = data[1];
                }

                if (line == null)
                {
                    break;
                }
            }

            sr.Close();

            float vrednostP = -1;
            for (int i = 0; i < ld.ListDescription.Count; i++)
            {
                if (ld.ListDescription[i].DataSet.Num == EnumberOfDataSet.CODECUSTOM_CODELIMITSET)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (ld.ListDescription[i].ListHistorical[j].CodeType == Res_Project.Resources.CodeType.CODE_LIMITSET)
                        {


                            vrednostP = (float)ld.ListDescription[i].ListHistorical[j].Value;



                        }
                    }

                }
            }




            float vrednost = (float)int.Parse(value);




            float granicaDonja = vrednost - ((vrednost / 100) * 2);
            float granicaGornja = vrednost + ((vrednost / 100) * 2);










            if (vrednostP < granicaDonja || vrednostP > granicaGornja)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeadBandCheckMotion()
        {
            string path = "../../Baza/CodeMotionCodeSensorTable.txt";
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            string type = "";
            string value = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] data = line.Split(';');
                type = data[0];
                if (type.Equals("CODE_MOTION"))
                {

                    value = data[1];
                }

                if (line == null)
                {
                    break;
                }
            }

            sr.Close();

            float vrednostP = -1;
            for (int i = 0; i < ld.ListDescription.Count; i++)
            {
                if (ld.ListDescription[i].DataSet.Num == EnumberOfDataSet.CODEMOTION_CODESENSOR)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (ld.ListDescription[i].ListHistorical[j].CodeType == Res_Project.Resources.CodeType.CODE_MOTION)
                        {


                            vrednostP = (float)ld.ListDescription[i].ListHistorical[j].Value;



                        }
                    }

                }
            }




            float vrednost = (float)int.Parse(value);




            float granicaDonja = vrednost - ((vrednost / 100) * 2);
            float granicaGornja = vrednost + ((vrednost / 100) * 2);










            if (vrednostP < granicaDonja || vrednostP > granicaGornja)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeadBandCheckSensor()
        {
            string path = "../../Baza/CodeMotionCodeSensorTable.txt";
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            string type = "";
            string value = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] data = line.Split(';');
                type = data[0];
                if (type.Equals("CODE_SENSOR"))
                {

                    value = data[1];
                }

                if (line == null)
                {
                    break;
                }
            }

            sr.Close();

            float vrednostP = -1;
            for (int i = 0; i < ld.ListDescription.Count; i++)
            {
                if (ld.ListDescription[i].DataSet.Num == EnumberOfDataSet.CODEMOTION_CODESENSOR)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (ld.ListDescription[i].ListHistorical[j].CodeType == Res_Project.Resources.CodeType.CODE_SENSOR)
                        {


                            vrednostP = (float)ld.ListDescription[i].ListHistorical[j].Value;



                        }
                    }

                }
            }




            float vrednost = (float)int.Parse(value);




            float granicaDonja = vrednost - ((vrednost / 100) * 2);
            float granicaGornja = vrednost + ((vrednost / 100) * 2);










            if (vrednostP < granicaDonja || vrednostP > granicaGornja)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeadBandCheckSinglenode()
        {
            string path = "../../Baza/CodeSinglenodeCodeMultiplenodeTable.txt";
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            string type = "";
            string value = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] data = line.Split(';');
                type = data[0];
                if (type.Equals("CODE_SINGLENODE"))
                {

                    value = data[1];
                }

                if (line == null)
                {
                    break;
                }
            }

            sr.Close();

            float vrednostP = -1;
            for (int i = 0; i < ld.ListDescription.Count; i++)
            {
                if (ld.ListDescription[i].DataSet.Num == EnumberOfDataSet.CODESINGLENODE_CODEMULTIPLENODE)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (ld.ListDescription[i].ListHistorical[j].CodeType == Res_Project.Resources.CodeType.CODE_SINGLENODE)
                        {


                            vrednostP = (float)ld.ListDescription[i].ListHistorical[j].Value;



                        }
                    }

                }
            }




            float vrednost = (float)int.Parse(value);




            float granicaDonja = vrednost - ((vrednost / 100) * 2);
            float granicaGornja = vrednost + ((vrednost / 100) * 2);










            if (vrednostP < granicaDonja || vrednostP > granicaGornja)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeadBandCheckMultiplenode()
        {
            string path = "../../Baza/CodeSinglenodeCodeMultiplenodeTable.txt";
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            string type = "";
            string value = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] data = line.Split(';');
                type = data[0];
                if (type.Equals("CODE_MULTIPLENODE"))
                {

                    value = data[1];
                }

                if (line == null)
                {
                    break;
                }
            }

            sr.Close();

            float vrednostP = -1;
            for (int i = 0; i < ld.ListDescription.Count; i++)
            {
                if (ld.ListDescription[i].DataSet.Num == EnumberOfDataSet.CODESINGLENODE_CODEMULTIPLENODE)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (ld.ListDescription[i].ListHistorical[j].CodeType == Res_Project.Resources.CodeType.CODE_MULTIPLENODE)
                        {


                            vrednostP = (float)ld.ListDescription[i].ListHistorical[j].Value;



                        }
                    }

                }
            }




            float vrednost = (float)int.Parse(value);




            float granicaDonja = vrednost - ((vrednost / 100) * 2);
            float granicaGornja = vrednost + ((vrednost / 100) * 2);










            if (vrednostP < granicaDonja || vrednostP > granicaGornja)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}
