using Common;
using Res_Project.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Res_Project
{
    [DataContract]

    public class Message 
    {

        DateTime dateTime;
        CodeType code;        
        int geoId;
        int consumption;
        [DataMember]
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        [DataMember]
        public CodeType Code { get => code; set => code = value; }
        [DataMember]

        public int GeoId { get => geoId; set => geoId = value; }
        [DataMember]

        public int Consumption { get => consumption; set => consumption = value; }

        public Message() { }

        public Message(DateTime dateTime,CodeType code,int geoId,int consumption)
        {
            if (geoId == null)
            {
                throw new ArgumentNullException();
            }

            if (consumption == null)
            {
                throw new ArgumentNullException();
            }
            this.dateTime = dateTime;
            this.code = code;
            this.geoId = geoId;
            this.consumption = consumption;
        }
    }
}
