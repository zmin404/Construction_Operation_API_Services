using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISOServiceVO
{
     [DataContract]
    public class WeeklyPlanVO
    {
        [DataMember]
        public int WOPID { get; set; }
        [DataMember]
        public int SiteID { get; set; }
        [DataMember]
        public System.DateTime Date { get; set; }
        [DataMember]
        public string Week { get; set; }
        [DataMember]
        public System.DateTime Month { get; set; }
        [DataMember]
        public int PreparedBy { get; set; }
        [DataMember]
        public bool CompletePrepare { get; set; }
        [DataMember]
        public Nullable<int> CheckedBy { get; set; }
        [DataMember]
        public Nullable<bool> CompleteCheck { get; set; }
        [DataMember]
        public Nullable<int> ApproveBy { get; set; }
        [DataMember]
        public Nullable<bool> DeleteStatus { get; set; }
        [DataMember]
        public int ModifiedBy { get; set; }
        [DataMember]
        public System.DateTime ModifiedDate { get; set; }

        [DataMember]
        public string SiteName { get; set; }
        [DataMember]
        public string PreparedByName { get; set; }
        [DataMember]
        public string CheckedByName { get; set; }
        [DataMember]
        public string ApprovedByName { get; set; }
        [DataMember]
        public string SiteCode { get; set; }
        [DataMember]
        public List<WeeklyPlanDetailVO> WeeklyPlanDetailList { get; set; }
    }
}
