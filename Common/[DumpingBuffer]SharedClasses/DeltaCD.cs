using Res_Project._Resource_DumpingBuffer;
using Res_Project.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Res_Project.ToHistorical
{
    [DataContract]
    public class DeltaCD
    {

        CollectionDescription collectionDescription_ANALOG_DIGITAL = new CollectionDescription();
        CollectionDescription collectionDescription_CUSTOM_LIMITSET = new CollectionDescription(CodeType.CODE_CUSTOM, CodeType.CODE_LIMITSET);
        CollectionDescription collectionDescription_SINGLE_MULTIPLE = new CollectionDescription(CodeType.CODE_SINGLENODE, CodeType.CODE_MULTIPLENODE);
        CollectionDescription collectionDescription_CONSUMER_SOURCE = new CollectionDescription(CodeType.CODE_CONSUMER, CodeType.CODE_SOURCE);
        CollectionDescription collectionDescription_MOTION_SENSOR = new CollectionDescription(CodeType.CODE_MOTION, CodeType.CODE_SENSOR);

        private bool analogDigitalReady;
        private bool customLimitsetReady;
        private bool singleMultipleReady;
        private bool consumerSourceReady;
        private bool motionSensorReady;


        [DataMember]
        public CollectionDescription CollectionDescription_ANALOG_DIGITAL { get => collectionDescription_ANALOG_DIGITAL; set => collectionDescription_ANALOG_DIGITAL = value; }
        [DataMember]
        public CollectionDescription CollectionDescription_CUSTOM_LIMITSET { get => collectionDescription_CUSTOM_LIMITSET; set => collectionDescription_CUSTOM_LIMITSET = value; }
        [DataMember]
        public CollectionDescription CollectionDescription_SINGLE_MULTIPLE { get => collectionDescription_SINGLE_MULTIPLE; set => collectionDescription_SINGLE_MULTIPLE = value; }
        [DataMember]
        public CollectionDescription CollectionDescription_CONSUMER_SOURCE { get => collectionDescription_CONSUMER_SOURCE; set => collectionDescription_CONSUMER_SOURCE = value; }
        [DataMember]
        public CollectionDescription CollectionDescription_MOTION_SENSOR { get => collectionDescription_MOTION_SENSOR; set => collectionDescription_MOTION_SENSOR = value; }
        public bool AnalogDigitalReady { get => analogDigitalReady; set => analogDigitalReady = value; }
        public bool CustomLimitsetReady { get => customLimitsetReady; set => customLimitsetReady = value; }
        public bool SingleMultipleReady { get => singleMultipleReady; set => singleMultipleReady = value; }
        public bool ConsumerSourceReady { get => consumerSourceReady; set => consumerSourceReady = value; }
        public bool MotionSensorReady { get => motionSensorReady; set => motionSensorReady = value; }


        public DeltaCD()
        {
            AnalogDigitalReady = false;
            CustomLimitsetReady = false;
            SingleMultipleReady = false;
            ConsumerSourceReady = false;
            MotionSensorReady = false;
            CollectionDescription CollectionDescription_ANALOG_DIGITAL = new CollectionDescription();
            CollectionDescription CollectionDescription_CUSTOM_LIMITSET = new CollectionDescription(CodeType.CODE_CUSTOM, CodeType.CODE_LIMITSET);
            CollectionDescription CollectionDescription_SINGLE_MULTIPLE = new CollectionDescription(CodeType.CODE_SINGLENODE, CodeType.CODE_MULTIPLENODE);
            CollectionDescription CollectionDescription_CONSUMER_SOURCE = new CollectionDescription(CodeType.CODE_CONSUMER, CodeType.CODE_SOURCE);
            CollectionDescription CollectionDescription_MOTION_SENSOR = new CollectionDescription(CodeType.CODE_MOTION, CodeType.CODE_SENSOR);
        }

    }
}
