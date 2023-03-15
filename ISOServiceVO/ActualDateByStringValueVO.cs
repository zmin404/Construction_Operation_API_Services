using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISOServiceVO
{
    [DataContract]
    public class ActualDateByStringValueVO
    {
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string MPDID { get; set; }
        [DataMember]
        public string Date { get; set; }
        

    }
}
