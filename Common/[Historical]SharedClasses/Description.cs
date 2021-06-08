using Res_Project._Resource_DumpingBuffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common._Historical_SharedClasses
{
    public class Description
    {
        private int id;
        private List<HistoricalProperty> listHistorical;
        private DataSet dataSet;

        public int Id { get => id; set => id = value; }
        public List<HistoricalProperty> ListHistorical { get => listHistorical; set => listHistorical = value; }
        public DataSet DataSet { get => dataSet; set => dataSet = value; }

        public Description(int id,List<HistoricalProperty> historicalProperties,DataSet dataSet)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            this.id = id;
            ListHistorical = historicalProperties;
            this.dataSet = dataSet;
        }
    }
}
