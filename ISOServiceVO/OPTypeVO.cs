using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISOServiceVO
{
     [DataContract]
    public  class OPTypeVO
    {
        [DataMember]
        public int OPTypeID { get; set; }
        [DataMember]
        public string OperationPlan { get; set; }
        [DataMember]
        public bool Active { get; set; }
        [DataMember]
        public int ModifiedBy { get; set; }
        [DataMember]
        public System.DateTime ModifiedDate { get; set; }
    }
}
