using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Writer.Helper;

namespace WriterClientTest
{
    [TestFixture]
    public class WriterHelperTest
    {

        private WriterHelper writerHelper;
        [SetUp]
        public void SetUP()
        {
            Mock<WriterHelper> wrHelp = new Mock<WriterHelper>();
            writerHelper = wrHelp.Object;
        }

        [TearDown]
        public void TearDown()
        {
            writerHelper = null;
        }

        
        }
    }

