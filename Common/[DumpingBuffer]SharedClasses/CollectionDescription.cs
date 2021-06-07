using Res_Project.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res_Project._Resource_DumpingBuffer
{
    public class CollectionDescription
    {
        int id=0;
        DataSet dataSet;
        DumpingPropertyCollection dumpingPropertyCollection = new DumpingPropertyCollection();
        
        public CollectionDescription(CodeType typeCode1, CodeType typeCode2)
        {
            Id++;
            DataSet = new DataSet(typeCode1);
            DumpingPropertyCollection = new DumpingPropertyCollection();
        }
        public CollectionDescription()
        {
            //DataSet = new DataSet();
            DumpingPropertyCollection = new DumpingPropertyCollection();
        }

        public int Id { get => id; set => id = value; }
        public DataSet DataSet { get => dataSet; set => dataSet = value; }
        public DumpingPropertyCollection DumpingPropertyCollection { get => dumpingPropertyCollection; set => dumpingPropertyCollection = value; }
    }



}
