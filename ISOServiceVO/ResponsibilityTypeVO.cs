using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISOServiceVO
{
     [DataContract]
    public class ResponsibilityTypeVO
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Type { get; set; }
    }
}
