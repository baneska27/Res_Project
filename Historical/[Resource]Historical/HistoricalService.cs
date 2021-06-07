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

            if(first_time)
            {
                UpisiUBazuAnalog();
                UpisiUBazuDigital();
            }
            else
            {
                
            }

        }

        private void UpisiUBazuAnalog()
        {
            string path = "../../Baza/CodeAnalogCodeDigitalTable.txt";
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                for(int i=0;i<ld.ListDescription.Count;i++)
                {
                    if(ld.ListDescription[i].DataSet.Num == EnumberOfDataSet.CODEANALOG_CODEDIGTIAL)
                    {
                        for(int j=0;j<2;j++)
                        {
                            if (ld.ListDescription[i].ListHistorical[j].CodeType== Res_Project.Resources.CodeType.CODE_ANALOG)
                            {
                                sw.WriteLine(ld.ListDescription[i].ListHistorical[j].CodeType.ToString() +";" + ld.ListDescription[i].ListHistorical[j].Value.ToString());
                                
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
                                sw.WriteLine(ld.ListDescription[i].ListHistorical[j].CodeType.ToString() + ";" + ld.ListDescription[i].ListHistorical[j].Value.ToString());

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

        public bool DeadBandCheck()
        {
            throw new NotImplementedException();
        }


    }
}
