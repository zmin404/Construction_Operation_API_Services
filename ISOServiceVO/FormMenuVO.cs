using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISOServiceVO
{
    [DataContract]
    public class FormMenuVO
    {
        [DataMember]
        public int FormID { get; set; }
        [DataMember]
        public string FormDescription { get; set; }
        [DataMember]
        public string FormName { get; set; }
        [DataMember]
        public int ParentFormID { get; set; }
        [DataMember]
        public string GroupName { get; set; }
        [DataMember]
        public bool Active { get; set; }
    }
}
