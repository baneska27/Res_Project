using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common._Historical_SharedClasses;
using Moq;
using NUnit.Framework;

namespace CommonTest
{
    [TestFixture]
    public class LDTest
    {
        private List<Description> a = new List<Description>();
        [SetUp]
        public void Setup()
        {
            Mock<List<Description>> mock = new Mock<List<Description>>();
            a = mock.Object;
        }
        [Test]
        
        public void TestConstructorValid()
        {
            LD ld = new LD(a);

            Assert.AreEqual(ld.ListDescription,a);
        }

        [TearDown]
        public void TearDown()
        {
            a = null;
        }
    }
}
