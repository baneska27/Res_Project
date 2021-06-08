using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Res_Project;
using Res_Project.Resources;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace DumpingBufferServerTest
{
    [TestFixture]
    public class MessageTest
    {
        
        [Test]
        [TestCase("06/07/2021",CodeType.CODE_ANALOG,1,350)]
        [TestCase("2021/06/07",CodeType.CODE_DIGITAL,13,1000)]
        [TestCase("2021/06/07", CodeType.CODE_CUSTOM, 153, 5000)]
        [TestCase("2021/06/07", CodeType.CODE_LIMITSET, 1013, 45000)]
        [TestCase("2021/06/07", CodeType.CODE_SINGLENODE, 25000, 55000)]
        [TestCase("2021/06/07", CodeType.CODE_MULTIPLENODE, 50000, 105000)]
        [TestCase("2021/06/07", CodeType.CODE_CONSUMER, 105000, 240000)]
        [TestCase("2021/06/07", CodeType.CODE_SOURCE, 165000, 360000)]
        [TestCase("2021/06/07", CodeType.CODE_MOTION, 5703010, 480000)]
        [TestCase("2021/06/07", CodeType.CODE_SENSOR, 21474836, 1100101)]

        public void MessageConstructorDobriParametri(DateTime dateTime, CodeType code, int geoId, int consumption)
        {
            Message m = new Message(dateTime, code, geoId, consumption);
            Assert.AreEqual(m.DateTime,dateTime);
            Assert.AreEqual(m.DateTime,dateTime);
            Assert.AreEqual(m.Consumption,consumption);
            Assert.AreEqual(m.GeoId,geoId);
        }

        [Test]

        [TestCase("2021/06/07", CodeType.CODE_SENSOR, 2147483647, 2147483647)] // Granicna vrednost 32bitnog Inta

        public void MessageConstructorGranicniParametri(DateTime dateTime, CodeType code, int geoId, int consumption)
        {
            Message m = new Message(dateTime, code, geoId, consumption);
            Assert.AreEqual(m.DateTime, dateTime);
            Assert.AreEqual(m.DateTime, dateTime);
            Assert.AreEqual(m.Consumption, consumption);
            Assert.AreEqual(m.GeoId, geoId);
            
        }

        [TestCase("2021/06/07", CodeType.CODE_SENSOR, null, 21002)]
        [TestCase("2021/06/07", CodeType.CODE_SENSOR, 100, null)]

        [ExpectedException(typeof(ArgumentNullException))]
        public void MessageConstructorNevalidniParametri(DateTime dateTime, CodeType code, int geoId, int consumption)
        {
            Message m = new Message(dateTime, code, geoId, consumption);
 
        }

        



    }
}
