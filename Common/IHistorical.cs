
using Res_Project.ToHistorical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [ServiceContract]
    public interface IHistorical
    {
        [OperationContract]
        void WriteToHistory(string message);

        
        [OperationContract]
        void WriteDeltaToHistory(DeltaCD delta);
    }
}
