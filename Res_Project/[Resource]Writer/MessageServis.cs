using Common;
using Res_Project._Resource_DumpingBuffer;
using Res_Project.ToHistorical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res_Project.Resources
{
    
    public class MessageServis : IWriter
    {
        static DeltaCD deltaForSend = new DeltaCD(); public static DeltaCD DeltaForSend { get => deltaForSend; set => deltaForSend = value; }

        static Dictionary<Message, int> collectionDescription = new Dictionary<Message, int>();
        static int dumpingId = 0;


        public void MessageToDeltaCD(Message m)
        {
            if(m.Code==CodeType.CODE_ANALOG)
            {
                deltaForSend.CollectionDescription_ANALOG_DIGITAL.DataSet = new DataSet(CodeType.CODE_ANALOG);
                deltaForSend.CollectionDescription_ANALOG_DIGITAL.DumpingPropertyCollection.TypeCode1 = CodeType.CODE_ANALOG;
                deltaForSend.CollectionDescription_ANALOG_DIGITAL.DumpingPropertyCollection.Id1 = m.GeoId;
                deltaForSend.CollectionDescription_ANALOG_DIGITAL.DumpingPropertyCollection.Value1 = m.Consumption;
                deltaForSend.CollectionDescription_ANALOG_DIGITAL.Id = dumpingId;
                if (deltaForSend.CollectionDescription_ANALOG_DIGITAL.DumpingPropertyCollection.Value1 != -1 && deltaForSend.CollectionDescription_ANALOG_DIGITAL.DumpingPropertyCollection.Value2 != -1)
                {
                    deltaForSend.AnalogDigitalReady = true;
                }
            }
            else if(m.Code==CodeType.CODE_DIGITAL)
            {
                deltaForSend.CollectionDescription_ANALOG_DIGITAL.DataSet = new DataSet(CodeType.CODE_DIGITAL);
                deltaForSend.CollectionDescription_ANALOG_DIGITAL.DumpingPropertyCollection.TypeCode2 = CodeType.CODE_DIGITAL;
                deltaForSend.CollectionDescription_ANALOG_DIGITAL.DumpingPropertyCollection.Id2 = m.GeoId;
                deltaForSend.CollectionDescription_ANALOG_DIGITAL.DumpingPropertyCollection.Value2 = m.Consumption;
                deltaForSend.CollectionDescription_ANALOG_DIGITAL.Id = dumpingId;
                if(deltaForSend.CollectionDescription_ANALOG_DIGITAL.DumpingPropertyCollection.Value1!=-1 && deltaForSend.CollectionDescription_ANALOG_DIGITAL.DumpingPropertyCollection.Value2 != -1)
                {
                    deltaForSend.AnalogDigitalReady = true;
                }
            }
            else if(m.Code==CodeType.CODE_CUSTOM)
            {
                deltaForSend.CollectionDescription_CUSTOM_LIMITSET.DataSet = new DataSet(CodeType.CODE_CUSTOM);
                deltaForSend.CollectionDescription_CUSTOM_LIMITSET.DumpingPropertyCollection.Id1 = m.GeoId;
                deltaForSend.CollectionDescription_CUSTOM_LIMITSET.DumpingPropertyCollection.TypeCode1 = CodeType.CODE_CUSTOM;
                deltaForSend.CollectionDescription_CUSTOM_LIMITSET.DumpingPropertyCollection.Value1 = m.Consumption;
                deltaForSend.CollectionDescription_CUSTOM_LIMITSET.Id = dumpingId;
                if(deltaForSend.CollectionDescription_CUSTOM_LIMITSET.DumpingPropertyCollection.Value1!=-1 && deltaForSend.CollectionDescription_CUSTOM_LIMITSET.DumpingPropertyCollection.Value2!=-1)
                {
                    deltaForSend.CustomLimitsetReady = true;
                }

            }
            else if (m.Code == CodeType.CODE_LIMITSET)
            {
                deltaForSend.CollectionDescription_CUSTOM_LIMITSET.DataSet = new DataSet(CodeType.CODE_LIMITSET);
                deltaForSend.CollectionDescription_CUSTOM_LIMITSET.DumpingPropertyCollection.Id2 = m.GeoId;
                deltaForSend.CollectionDescription_CUSTOM_LIMITSET.DumpingPropertyCollection.TypeCode2 = CodeType.CODE_LIMITSET;
                deltaForSend.CollectionDescription_CUSTOM_LIMITSET.DumpingPropertyCollection.Value2 = m.Consumption;
                deltaForSend.CollectionDescription_CUSTOM_LIMITSET.Id = dumpingId;
                if (deltaForSend.CollectionDescription_CUSTOM_LIMITSET.DumpingPropertyCollection.Value1 != -1 && deltaForSend.CollectionDescription_CUSTOM_LIMITSET.DumpingPropertyCollection.Value2 != -1)
                {
                    deltaForSend.CustomLimitsetReady = true;
                }

            }
            else if (m.Code == CodeType.CODE_SINGLENODE)
            {
                deltaForSend.CollectionDescription_SINGLE_MULTIPLE.DataSet = new DataSet(CodeType.CODE_SINGLENODE);
                deltaForSend.CollectionDescription_SINGLE_MULTIPLE.DumpingPropertyCollection.Id1 = m.GeoId;
                deltaForSend.CollectionDescription_SINGLE_MULTIPLE.DumpingPropertyCollection.TypeCode1 = CodeType.CODE_SINGLENODE;
                deltaForSend.CollectionDescription_SINGLE_MULTIPLE.DumpingPropertyCollection.Value1 = m.Consumption;
                deltaForSend.CollectionDescription_SINGLE_MULTIPLE.Id = dumpingId;
                if (deltaForSend.CollectionDescription_SINGLE_MULTIPLE.DumpingPropertyCollection.Value1 != -1 && deltaForSend.CollectionDescription_SINGLE_MULTIPLE.DumpingPropertyCollection.Value2 != -1)
                {
                    deltaForSend.SingleMultipleReady = true;
                }

            }
            else if (m.Code == CodeType.CODE_MULTIPLENODE)
            {
                deltaForSend.CollectionDescription_SINGLE_MULTIPLE.DataSet = new DataSet(CodeType.CODE_MULTIPLENODE);
                deltaForSend.CollectionDescription_SINGLE_MULTIPLE.DumpingPropertyCollection.Id2 = m.GeoId;
                deltaForSend.CollectionDescription_SINGLE_MULTIPLE.DumpingPropertyCollection.TypeCode2 = CodeType.CODE_MULTIPLENODE;
                deltaForSend.CollectionDescription_SINGLE_MULTIPLE.DumpingPropertyCollection.Value2 = m.Consumption;
                deltaForSend.CollectionDescription_SINGLE_MULTIPLE.Id = dumpingId;
                if (deltaForSend.CollectionDescription_SINGLE_MULTIPLE.DumpingPropertyCollection.Value1 != -1 && deltaForSend.CollectionDescription_SINGLE_MULTIPLE.DumpingPropertyCollection.Value2 != -1)
                {
                    deltaForSend.SingleMultipleReady = true;
                }

            }



            else if (m.Code == CodeType.CODE_CONSUMER)
            {
                deltaForSend.CollectionDescription_CONSUMER_SOURCE.DataSet = new DataSet(CodeType.CODE_CONSUMER);
                deltaForSend.CollectionDescription_CONSUMER_SOURCE.DumpingPropertyCollection.Id1 = m.GeoId;
                deltaForSend.CollectionDescription_CONSUMER_SOURCE.DumpingPropertyCollection.TypeCode1 = CodeType.CODE_CONSUMER;
                deltaForSend.CollectionDescription_CONSUMER_SOURCE.DumpingPropertyCollection.Value1 = m.Consumption;
                deltaForSend.CollectionDescription_CONSUMER_SOURCE.Id = dumpingId;
                if (deltaForSend.CollectionDescription_CONSUMER_SOURCE.DumpingPropertyCollection.Value1 != -1 && deltaForSend.CollectionDescription_CONSUMER_SOURCE.DumpingPropertyCollection.Value2 != -1)
                {
                    deltaForSend.ConsumerSourceReady = true;
                }

            }
            else if (m.Code == CodeType.CODE_SOURCE)
            {
                deltaForSend.CollectionDescription_CONSUMER_SOURCE.DataSet = new DataSet(CodeType.CODE_SOURCE);
                deltaForSend.CollectionDescription_CONSUMER_SOURCE.DumpingPropertyCollection.Id2 = m.GeoId;
                deltaForSend.CollectionDescription_CONSUMER_SOURCE.DumpingPropertyCollection.TypeCode2 = CodeType.CODE_SOURCE;
                deltaForSend.CollectionDescription_CONSUMER_SOURCE.DumpingPropertyCollection.Value2 = m.Consumption;
                deltaForSend.CollectionDescription_CONSUMER_SOURCE.Id = dumpingId;
                if (deltaForSend.CollectionDescription_CONSUMER_SOURCE.DumpingPropertyCollection.Value1 != -1 && deltaForSend.CollectionDescription_CONSUMER_SOURCE.DumpingPropertyCollection.Value2 != -1)
                {
                    deltaForSend.ConsumerSourceReady = true;
                }

            }

            else if (m.Code == CodeType.CODE_MOTION)
            {
                deltaForSend.CollectionDescription_MOTION_SENSOR.DataSet = new DataSet(CodeType.CODE_MOTION);
                deltaForSend.CollectionDescription_MOTION_SENSOR.DumpingPropertyCollection.Id1 = m.GeoId;
                deltaForSend.CollectionDescription_MOTION_SENSOR.DumpingPropertyCollection.TypeCode1 = CodeType.CODE_MOTION;
                deltaForSend.CollectionDescription_MOTION_SENSOR.DumpingPropertyCollection.Value1 = m.Consumption;
                deltaForSend.CollectionDescription_MOTION_SENSOR.Id = dumpingId;
                if (deltaForSend.CollectionDescription_MOTION_SENSOR.DumpingPropertyCollection.Value1 != -1 && deltaForSend.CollectionDescription_MOTION_SENSOR.DumpingPropertyCollection.Value2 != -1)
                {
                    deltaForSend.MotionSensorReady = true;
                }

            }
            else if (m.Code == CodeType.CODE_SENSOR)
            {
                deltaForSend.CollectionDescription_MOTION_SENSOR.DataSet = new DataSet(CodeType.CODE_SENSOR);
                deltaForSend.CollectionDescription_MOTION_SENSOR.DumpingPropertyCollection.Id2 = m.GeoId;
                deltaForSend.CollectionDescription_MOTION_SENSOR.DumpingPropertyCollection.TypeCode2 = CodeType.CODE_SENSOR;
                deltaForSend.CollectionDescription_MOTION_SENSOR.DumpingPropertyCollection.Value2 = m.Consumption;
                deltaForSend.CollectionDescription_MOTION_SENSOR.Id = dumpingId;
                if (deltaForSend.CollectionDescription_MOTION_SENSOR.DumpingPropertyCollection.Value1 != -1 && deltaForSend.CollectionDescription_MOTION_SENSOR.DumpingPropertyCollection.Value2 != -1)
                {
                    deltaForSend.MotionSensorReady = true;
                }

            }









        }

        public int vratiDumpingID()
        {
            return dumpingId;
        }
        
        public DeltaCD VratiDeltu()
        {
            return deltaForSend;
        }
            
        public Message StringToMessageConvert(string message)
        {
            if (message == null)
            {
                throw new ArgumentNullException();
            }

            if (message == string.Empty)
            {
                throw new ArgumentException();
            }
            string[] podaci = message.Split('+');

            if (podaci.Length < 3)
            {
                throw new ArgumentException();
            }
            Message a = new Message();
            try
            {
                a.DateTime = DateTime.Parse(podaci[0]);
                a.Code = (CodeType) Int32.Parse(podaci[1]);
                a.GeoId = Int32.Parse(podaci[2]);
                a.Consumption = Int32.Parse(podaci[3]);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new OverflowException();
            }


            return a;
        }

        public void DeltaSent()
        {
            deltaForSend = new DeltaCD();
            deltaForSend.AnalogDigitalReady = false;
            deltaForSend.ConsumerSourceReady = false;
            deltaForSend.CustomLimitsetReady = false;
            deltaForSend.MotionSensorReady = false;
            deltaForSend.SingleMultipleReady = false;
        }

        public void AddMessageToCDAndIncrement(Message m)
        {
            collectionDescription.Add(m, dumpingId);
            dumpingId++;
        }

        public bool IsReadyToSendDelta()
        {
            if(deltaForSend.AnalogDigitalReady==true && deltaForSend.ConsumerSourceReady == true && deltaForSend.CustomLimitsetReady==true && deltaForSend.MotionSensorReady==true && deltaForSend.SingleMultipleReady==true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void ManualWriteToDumpingBuffer(string message)
        {

            Message a = StringToMessageConvert(message);
            AddMessageToCDAndIncrement(a);
            MessageToDeltaCD(a);
       

            Console.WriteLine("[ManualWriteToDumpingBuffer]\n RECIEVED MESSAGE: DATE TIME : {0}\n CODE: {1}\n GEO ID: {2}\n CONSUMPTION: {3}\n", a.DateTime.ToString(),a.Code,a.GeoId,a.Consumption);

        }

        public void WriteToDumpingBuffer(string message)
        {
        }
    }
}
