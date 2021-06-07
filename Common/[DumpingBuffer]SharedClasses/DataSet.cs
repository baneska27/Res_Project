using Res_Project.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Res_Project._Resource_DumpingBuffer
{
    public enum EnumberOfDataSet
    {
        CODEANALOG_CODEDIGTIAL=1,
        CODECUSTOM_CODELIMITSET=2,
        CODESINGLENODE_CODEMULTIPLENODE=3,
        CODECONSUMER_CODESOURCE = 4,
        CODEMOTION_CODESENSOR=5
    }

    [DataContract]

    public class DataSet
    {
        [DataMember]
        EnumberOfDataSet num;

        public EnumberOfDataSet Num { get => num; set => num = value; }

        public DataSet(CodeType typeCode1)
        {
            
            if(typeCode1.Equals(CodeType.CODE_ANALOG) || typeCode1.Equals(CodeType.CODE_DIGITAL))
            {
                this.Num = EnumberOfDataSet.CODEANALOG_CODEDIGTIAL;
            }

            if(typeCode1.Equals(CodeType.CODE_CUSTOM) || typeCode1.Equals(CodeType.CODE_LIMITSET))
            {
                this.Num = EnumberOfDataSet.CODECUSTOM_CODELIMITSET;
            }
            if (typeCode1.Equals(CodeType.CODE_SINGLENODE) || typeCode1.Equals(CodeType.CODE_MULTIPLENODE))
            {
                this.Num = EnumberOfDataSet.CODESINGLENODE_CODEMULTIPLENODE;
            }
            if (typeCode1.Equals(CodeType.CODE_CONSUMER) || typeCode1.Equals(CodeType.CODE_SOURCE))
            {
                this.Num = EnumberOfDataSet.CODECONSUMER_CODESOURCE;
            }
            if (typeCode1.Equals(CodeType.CODE_MOTION) || typeCode1.Equals(CodeType.CODE_SENSOR))
            {
                this.Num = EnumberOfDataSet.CODEMOTION_CODESENSOR;
            }

        }
 
       
    }
}
