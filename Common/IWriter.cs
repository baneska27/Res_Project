using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{






    [ServiceContract]
    
    public interface IWriter
    {
        [OperationContract]
        void WriteToDumpingBuffer(string message);
        [OperationContract]
        void ManualWriteToDumpingBuffer(string message);
    }
}
