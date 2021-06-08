using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common._Historical_SharedClasses
{
    public class LD
    {
        private List<Description> listDescription;

        public List<Description> ListDescription { get => listDescription; set => listDescription = value; }

        public LD()
        {
            ListDescription = new List<Description>();
        }

        public LD(List<Description> descriptions)
        {
            ListDescription = descriptions;
        }
    }
}
