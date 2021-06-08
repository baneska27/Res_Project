using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common._Historical_SharedClasses;
using Res_Project._Resource_DumpingBuffer;
using Res_Project.Resources;
using Moq;

namespace CommonTest
{
    [TestFixture]

    public class DescriptionTest
    {
        private List<HistoricalProperty> properties;
        [SetUp]
        public void SetUP()
        {
            Mock<List<HistoricalProperty>> hp = new Mock<List<HistoricalProperty>>();

            properties = hp.Object;
           
        }

        [Test]
        [TestCase(35,CodeType.CODE_ANALOG)]
        [TestCase(35, CodeType.CODE_CUSTOM)]
        [TestCase(35, CodeType.CODE_CONSUMER)]
        [TestCase(35, CodeType.CODE_LIMITSET)]
        [TestCase(35, CodeType.CODE_MOTION)]
        [TestCase(35, CodeType.CODE_MULTIPLENODE)]
        [TestCase(35, CodeType.CODE_SENSOR)]
        [TestCase(35, CodeType.CODE_SINGLENODE)]
        [TestCase(35, CodeType.CODE_SOURCE)]
        [TestCase(35, CodeType.CODE_DIGITAL)]

        public void DescriptionValidConstructorTest(int ids, CodeType codeType)
        {
            DataSet ds = new DataSet(codeType);
            Description a = new Description(ids, properties, ds);

            Assert.AreEqual(a.DataSet,ds);
            Assert.AreEqual(a.Id,ids);
            Assert.AreEqual(a.ListHistorical,properties);
        }

        [TearDown]
        public void TearDown()
        {
            properties = null;
            
            
        }
    }
}
