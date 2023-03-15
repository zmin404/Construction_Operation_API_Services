using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISOServiceVO
{
    [DataContract]
    public class MasterSchedulePDFVO
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int SiteID { get; set; }
        [DataMember]
        public string MasterSchedulePDF { get; set; }

        [DataMember]
        public byte[] PDF { get; set; }
        [DataMember]
        public string SiteName { get; set; }
    }
}
