using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISOServiceVO
{
     [DataContract]
    public class NameOfWorkVO
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int OPTypeID { get; set; }
        [DataMember]
        public string NameofWork { get; set; }
        [DataMember]
        public bool Active { get; set; }
        [DataMember]
        public int ModifiedBy { get; set; }
        [DataMember]
        public System.DateTime ModifiedDate { get; set; }

        [DataMember]
        public string OPTypeName { get; set; } 
    }
}
