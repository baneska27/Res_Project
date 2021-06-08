using NUnit.Framework;
using Res_Project.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common._Historical_SharedClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace CommonTest
{
    [TestFixture]
    public class HistoricalPropertyTest
    {

        [Test]
        [TestCase(CodeType.CODE_DIGITAL, 27110)]
        [TestCase(CodeType.CODE_ANALOG, 27101)]
        [TestCase(CodeType.CODE_CONSUMER, 273210)]
        [TestCase(CodeType.CODE_CUSTOM, 10)]
        [TestCase(CodeType.CODE_LIMITSET, 5)]
        [TestCase(CodeType.CODE_MOTION, 4)]
        [TestCase(CodeType.CODE_MULTIPLENODE, 99)]
        [TestCase(CodeType.CODE_SENSOR, 82)]
        [TestCase(CodeType.CODE_SINGLENODE, 15)]
        [TestCase(CodeType.CODE_SOURCE, 1)]

        public void HistoricalConstructorDobriParametri(CodeType codeType, int value)
        {
            HistoricalProperty hp = new HistoricalProperty(codeType, value);
            Assert.AreEqual(hp.CodeType,codeType);
            Assert.AreEqual(hp.Value,value);
        }

        [Test]
        [TestCase(CodeType.CODE_DIGITAL, 2147483647)]
        public void GranicniParametri(CodeType typeCode, int value)
        {
            HistoricalProperty hp = new HistoricalProperty(typeCode, value);

            Assert.AreEqual(hp.CodeType,typeCode);
            Assert.AreEqual(hp.Value,value);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        [TestCase(CodeType.CODE_DIGITAL, null)]

        public void NevalidniParametri(CodeType typeCode, int value)
        {
            HistoricalProperty hp = new HistoricalProperty(typeCode, value);
        }

    }
}
