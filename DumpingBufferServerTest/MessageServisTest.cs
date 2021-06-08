using NUnit.Framework;
using Res_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Res_Project.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Res_Project.ToHistorical;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace DumpingBufferServerTest
{
    [TestFixture]
    public class MessageServisTest
    {
        [Test]
        [TestCase("1/7/2021+0+12+350")]
        public void StringToMessageAnalogConverterCorrectCreatingMessage(string message)
        {
            MessageServis ms = new MessageServis();
            Message a;
            a = ms.StringToMessageConvert(message);

            Assert.AreEqual(a.Code,CodeType.CODE_ANALOG);
            Assert.AreEqual(a.Consumption,350);
            Assert.AreEqual(a.GeoId,12);

        }
        [Test]
        [TestCase("1/7/2021+1+12+350")]
        public void StringToMessageDigitalConverterCorrectCreatingMessage(string message)
        {
            MessageServis ms = new MessageServis();
            Message a;
            a = ms.StringToMessageConvert(message);

            Assert.AreEqual(a.Code, CodeType.CODE_DIGITAL);
            Assert.AreEqual(a.Consumption, 350);
            Assert.AreEqual(a.GeoId, 12);

        }
        [Test]
        [TestCase("1/7/2021+2+12+350")]
        public void StringToMessageCustomConverterCorrectCreatingMessage(string message)
        {
            MessageServis ms = new MessageServis();
            Message a;
            a = ms.StringToMessageConvert(message);

            Assert.AreEqual(a.Code, CodeType.CODE_CUSTOM);
            Assert.AreEqual(a.Consumption, 350);
            Assert.AreEqual(a.GeoId, 12);

        }
        [Test]
        [TestCase("1/7/2021+3+12+350")]
        public void StringToMessageLimitsetConverterCorrectCreatingMessage(string message)
        {
            MessageServis ms = new MessageServis();
            Message a;
            a = ms.StringToMessageConvert(message);

            Assert.AreEqual(a.Code, CodeType.CODE_LIMITSET);
            Assert.AreEqual(a.Consumption, 350);
            Assert.AreEqual(a.GeoId, 12);

        }
        [Test]
        [TestCase("1/7/2021+4+12+350")]
        public void StringToMessageSingleNodeConverterCorrectCreatingMessage(string message)
        {
            MessageServis ms = new MessageServis();
            Message a;
            a = ms.StringToMessageConvert(message);

            Assert.AreEqual(a.Code, CodeType.CODE_SINGLENODE);
            Assert.AreEqual(a.Consumption, 350);
            Assert.AreEqual(a.GeoId, 12);

        }
        [Test]
        [TestCase("1/7/2021+5+12+350")]
        public void StringToMessageMultipleConverterCorrectCreatingMessage(string message)
        {
            MessageServis ms = new MessageServis();
            Message a;
            a = ms.StringToMessageConvert(message);

            Assert.AreEqual(a.Code, CodeType.CODE_MULTIPLENODE);
            Assert.AreEqual(a.Consumption, 350);
            Assert.AreEqual(a.GeoId, 12);

        }
        [Test]
        [TestCase("1/7/2021+6+12+350")]
        public void StringToMessageConsumerConverterCorrectCreatingMessage(string message)
        {
            MessageServis ms = new MessageServis();
            Message a;
            a = ms.StringToMessageConvert(message);

            Assert.AreEqual(a.Code, CodeType.CODE_CONSUMER);
            Assert.AreEqual(a.Consumption, 350);
            Assert.AreEqual(a.GeoId, 12);

        }
        [Test]
        [TestCase("1/7/2021+7+12+350")]
        public void StringToMessageSourceConverterCorrectCreatingMessage(string message)
        {
            MessageServis ms = new MessageServis();
            Message a;
            a = ms.StringToMessageConvert(message);

            Assert.AreEqual(a.Code, CodeType.CODE_SOURCE);
            Assert.AreEqual(a.Consumption, 350);
            Assert.AreEqual(a.GeoId, 12);
        }
        [Test]
        [TestCase("1/7/2021+8+12+350")]
        public void StringToMessageMotionConverterCorrectCreatingMessage(string message)
        {
            MessageServis ms = new MessageServis();
            Message a;
            a = ms.StringToMessageConvert(message);

            Assert.AreEqual(a.Code, CodeType.CODE_MOTION);
            Assert.AreEqual(a.Consumption, 350);
            Assert.AreEqual(a.GeoId, 12);

        }
        [Test]
        [TestCase("1/7/2021+9+12+350")]
        public void StringToMessageSensorConverterCorrectCreatingMessage(string message)
        {
            MessageServis ms = new MessageServis();
            Message a;
            a = ms.StringToMessageConvert(message);

            Assert.AreEqual(a.Code, CodeType.CODE_SENSOR);
            Assert.AreEqual(a.Consumption, 350);
            Assert.AreEqual(a.GeoId, 12);

        }


     
        [Test]
        public void vracanjeDelte()
        {
            MessageServis ms = new MessageServis();
            DeltaCD deltaForTest = ms.VratiDeltu();
            Assert.AreEqual(deltaForTest, ms.VratiDeltu());
        }

        [Test]
        public void IsItReallyIncremented(Message m)
        {
            m.Code = CodeType.CODE_ANALOG;
            m.Consumption = 350;
            m.GeoId = 12;
            m.DateTime = DateTime.Today;

            MessageServis ms = new MessageServis();
            ms.AddMessageToCDAndIncrement(m);

            


        }
    }
}
