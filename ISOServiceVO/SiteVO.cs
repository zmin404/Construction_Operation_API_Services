using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISOServiceVO
{
     [DataContract]
    public class SiteVO
    {
        [DataMember]
        public int SiteID { get; set; }
        [DataMember]
        public string SiteCode { get; set; }
        [DataMember]
        public string SiteName { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public bool IsComplete { get; set; }
        [DataMember]
        public bool Active { get; set; }
        [DataMember]
        public int ModifiedBy { get; set; }
        [DataMember]
        public System.DateTime ModifiedDate { get; set; }

        [DataMember]
        public List<PersonAndSiteVO> PersonAndSitelist { get; set; }
    }
}
