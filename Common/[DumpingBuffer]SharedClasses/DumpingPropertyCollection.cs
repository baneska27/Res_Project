using Res_Project.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res_Project._Resource_DumpingBuffer
{
    public class DumpingPropertyCollection
    {
        int id1;
        int id2;
        CodeType typeCode1;
        CodeType typeCode2;
        int value1;
        int value2;

        public CodeType TypeCode1 { get => typeCode1; set => typeCode1 = value; }
        public CodeType TypeCode2 { get => typeCode2; set => typeCode2 = value; }
        public int Value1 { get => value1; set => value1 = value; }
        public int Value2 { get => value2; set => value2 = value; }
        public int Id1 { get => id1; set => id1 = value; }
        public int Id2 { get => id2; set => id2 = value; }

        public DumpingPropertyCollection(CodeType typeCode1, CodeType typeCode2,int value1,int value2,int id1,int id2)
        {
            this.typeCode1 = typeCode1;
            this.typeCode1 = typeCode1;
            this.Value1 = value1;
            this.Value2 = value2;
            this.id1 = id1;
            this.id2 = id2;

        }

        public DumpingPropertyCollection()
        {
            value1 = -1;
            value2 = -1;
        }

    }
}
