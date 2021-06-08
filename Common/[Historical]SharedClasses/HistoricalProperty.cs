using Res_Project.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common._Historical_SharedClasses
{
    public class HistoricalProperty
    {
        CodeType codeType;
        int value;

        public CodeType CodeType { get => codeType; set => codeType = value; }
        public int Value { get => value; set => this.value = value; }

        public HistoricalProperty(CodeType codeType,int value)
        {
            this.codeType = codeType;
            if (value == null)
            {
                throw new ArgumentNullException();
            }
            this.value = value;
        }
    }
}
