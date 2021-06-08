using NUnit.Framework;
using Res_Project;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Res_Project.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Res_Project.ToHistorical;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Moq;

namespace DumpingBufferServerTest
{
    [TestFixture]
    public class MessageServisTest
    {
        private MessageServis ms;
        private Message a;
        private DeltaCD deltaForTest;
        private Message mm;
        [SetUp]
        public void SetUP()
        {
            Mock<Message> m = new Mock<Message>();
            Mock<MessageServis> ms1 = new Mock<MessageServis>();
            ms = ms1.Object;
            m.Object.Code = CodeType.CODE_DIGITAL;
            a = m.Object;
            Mock<DeltaCD> dMock = new Mock<DeltaCD>();
            deltaForTest = dMock.Object;
            mm = new Message(new DateTime(1942, 2, 2), CodeType.CODE_DIGITAL, 12, 350);
            

        }






        [Test]
        [TestCase("1/7/2021+0+12+350")]
        public void StringToMessageAnalogConverterCorrectCreatingMessage(string message)
        {
           

            a = ms.StringToMessageConvert(message);

            Assert.AreEqual(a.Code,CodeType.CODE_ANALOG);
            Assert.AreEqual(a.Consumption,350);
            Assert.AreEqual(a.GeoId,12);

        }
    
        
        [Test]
        [TestCase("1/7/2021+1+12+350")]
        public void StringToMessageDigitalConverterCorrectCreatingMessage(string message)
        {

            a = ms.StringToMessageConvert(message);

            Assert.AreEqual(a.Code, CodeType.CODE_DIGITAL);
            Assert.AreEqual(a.Consumption, 350);
            Assert.AreEqual(a.GeoId, 12);

        }
        [Test]
        [TestCase("1/7/2021+2+12+350")]
        public void StringToMessageCustomConverterCorrectCreatingMessage(string message)
        {

            a = ms.StringToMessageConvert(message);

            Assert.AreEqual(a.Code, CodeType.CODE_CUSTOM);
            Assert.AreEqual(a.Consumption, 350);
            Assert.AreEqual(a.GeoId, 12);

        }
        [Test]
        [TestCase("1/7/2021+3+12+350")]
        public void StringToMessageLimitsetConverterCorrectCreatingMessage(string message)
        {
           
            a = ms.StringToMessageConvert(message);

            Assert.AreEqual(a.Code, CodeType.CODE_LIMITSET);
            Assert.AreEqual(a.Consumption, 350);
            Assert.AreEqual(a.GeoId, 12);

        }
        [Test]
        [TestCase("1/7/2021+4+12+350")]
        public void StringToMessageSingleNodeConverterCorrectCreatingMessage(string message)
        {
           
            a = ms.StringToMessageConvert(message);

            Assert.AreEqual(a.Code, CodeType.CODE_SINGLENODE);
            Assert.AreEqual(a.Consumption, 350);
            Assert.AreEqual(a.GeoId, 12);

        }
        [Test]
        [TestCase("1/7/2021+5+12+350")]
        public void StringToMessageMultipleConverterCorrectCreatingMessage(string message)
        {
            
            a = ms.StringToMessageConvert(message);

            Assert.AreEqual(a.Code, CodeType.CODE_MULTIPLENODE);
            Assert.AreEqual(a.Consumption, 350);
            Assert.AreEqual(a.GeoId, 12);

        }
        [Test]
        [TestCase("1/7/2021+6+12+350")]
        public void StringToMessageConsumerConverterCorrectCreatingMessage(string message)
        {
            
            a = ms.StringToMessageConvert(message);

            Assert.AreEqual(a.Code, CodeType.CODE_CONSUMER);
            Assert.AreEqual(a.Consumption, 350);
            Assert.AreEqual(a.GeoId, 12);

        }
        [Test]
        [TestCase("1/7/2021+7+12+350")]
        public void StringToMessageSourceConverterCorrectCreatingMessage(string message)
        {
           
            a = ms.StringToMessageConvert(message);

            Assert.AreEqual(a.Code, CodeType.CODE_SOURCE);
            Assert.AreEqual(a.Consumption, 350);
            Assert.AreEqual(a.GeoId, 12);
        }
        [Test]
        [TestCase("1/7/2021+8+12+350")]
        public void StringToMessageMotionConverterCorrectCreatingMessage(string message)
        {
           
            a = ms.StringToMessageConvert(message);

            Assert.AreEqual(a.Code, CodeType.CODE_MOTION);
            Assert.AreEqual(a.Consumption, 350);
            Assert.AreEqual(a.GeoId, 12);

        }
        [Test]
        [TestCase("1/7/2021+9+12+350")]
        public void StringToMessageSensorConverterCorrectCreatingMessage(string message)
        {
            
            a = ms.StringToMessageConvert(message);

            Assert.AreEqual(a.Code, CodeType.CODE_SENSOR);
            Assert.AreEqual(a.Consumption, 350);
            Assert.AreEqual(a.GeoId, 12);

        }


     
        [Test]
        
        public void VracanjeDelte()
        {
            
            deltaForTest = ms.VratiDeltu();
            Assert.AreEqual(deltaForTest, ms.VratiDeltu());
        }
        

        [Test]
        
        public void NotReadyForSendingDelta()
        {
;
            
            Assert.AreEqual(false,ms.IsReadyToSendDelta());


        }
        

        [Test]
        
        public void ReadyToSendDelta()
        {
            
            deltaForTest = ms.VratiDeltu();
            deltaForTest.AnalogDigitalReady = true;
            deltaForTest.ConsumerSourceReady = true;
            deltaForTest.CustomLimitsetReady = true;
            deltaForTest.MotionSensorReady = true;
            deltaForTest.SingleMultipleReady = true;
            Assert.AreEqual(true,ms.IsReadyToSendDelta());
        }
       


        [Test]
        
        public void IsItReallyIncremented()
        {
            int idPre = ms.vratiDumpingID();
            //ms.AddMessageToCDAndIncrement(new Message(DateTime.Today, CodeType.CODE_ANALOG,12,350));
            ms.AddMessageToCDAndIncrement(a);
            int idPosle = ms.vratiDumpingID();
            Assert.AreEqual(idPre + 1, idPosle);

        }

        [Test]
        public void NotDigitalTest()
        {
            
            ms.MessageToDeltaCD(a);


            Assert.AreNotEqual(a.Code,deltaForTest.CollectionDescription_ANALOG_DIGITAL.DumpingPropertyCollection.TypeCode1);
            Assert.AreNotEqual(a.Consumption, deltaForTest.CollectionDescription_ANALOG_DIGITAL.DumpingPropertyCollection.Value1);
        }

        [Test]
        public void MessageToDeltaCDTestDigital()
        {
            ms.MessageToDeltaCD(a);
            deltaForTest = ms.VratiDeltu();

            a.Code = CodeType.CODE_DIGITAL;
            Assert.AreEqual(a.Code,
                deltaForTest.CollectionDescription_ANALOG_DIGITAL.DumpingPropertyCollection.TypeCode2);
            Assert.AreNotEqual(a.Consumption, deltaForTest.CollectionDescription_ANALOG_DIGITAL.DumpingPropertyCollection.Value1);
        }

        [TearDown]
        public void TearDown()
        {
            ms = null;
            a = null;
            deltaForTest = null;
            
        }
        

    }
}
