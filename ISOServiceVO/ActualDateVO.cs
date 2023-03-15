using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISOServiceVO
{
    [DataContract]
    public class ActualDateVO
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int MPDID { get; set; }
        [DataMember]
        public System.DateTime Date { get; set; }
        [DataMember]
        public int NameOfWorkID { get; set; }  

    }
}
