using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISOServiceVO
{
    [DataContract]
    public class LabourTypeVO
    {
        [DataMember]
        public int LabourTypeID { get; set; }
        [DataMember]
        public string LabourType { get; set; }
        [DataMember]
        public bool Active { get; set; }
        [DataMember]
        public int ModifiedBy { get; set; }
        [DataMember]
        public System.DateTime ModifiedDate { get; set; }
    }
}
