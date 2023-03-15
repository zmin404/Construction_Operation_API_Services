using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISOServiceVO
{
     [DataContract]
    public class PersonAndSiteVO
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int SiteID { get; set; }
        [DataMember]
        public int PersonID { get; set; }
        [DataMember]
        public int ResponsibilityTypeID { get; set; }
        [DataMember]
        public bool Finished { get; set; }
        [DataMember]
        public int ModifiedBy { get; set; }
        [DataMember]
        public System.DateTime ModifiedDate { get; set; }

        [DataMember]
        public string SiteName {get;set;}
        [DataMember]
        public string PersonName {get;set;}
        [DataMember]
        public string ResponsibilityType { get; set; }
    }
}
