using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISOServiceVO
{
     [DataContract]
    public class PersonVO
    {
        [DataMember]
        public int PersonID { get; set; }
        [DataMember]
        public string PersonName { get; set; }
        [DataMember]
        public int PersonTypeID { get; set; }
        [DataMember]
        public bool Active { get; set; }
        [DataMember]
        public int ModifiedBy { get; set; }
        [DataMember]
        public System.DateTime ModifiedDate { get; set; }

        [DataMember]
        public string PersonType{ get; set; }
    }
}
