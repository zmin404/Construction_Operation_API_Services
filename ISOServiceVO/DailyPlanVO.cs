using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISOServiceVO
{
    [DataContract]
    public class DailyPlanVO
    {
        [DataMember]
        public int DPID { get; set; }
        [DataMember]
        public int SiteID { get; set; }
        [DataMember]
        public int SubContractorID { get; set; }
        [DataMember]
        public System.DateTime Date { get; set; }
        [DataMember]
        public int WeatherID { get; set; }
        [DataMember]
        public int PreparedBy { get; set; }
        [DataMember]
        public Nullable<bool> CompletePrepare { get; set; }
        [DataMember]
        public Nullable<int> ReceivedBy { get; set; }
        [DataMember]
        public Nullable<bool> CompleteReceive { get; set; }
        [DataMember]
        public Nullable<int> CheckedBy { get; set; }
        [DataMember]
        public Nullable<bool> CompleteCheck { get; set; }
        [DataMember]
        public Nullable<int> ApprovedBy { get; set; }
        [DataMember]
        public Nullable<bool> DeleteStatus { get; set; }
        [DataMember]
        public int ModifiedBy { get; set; }
        [DataMember]
        public System.DateTime ModifiedDate { get; set; }

        [DataMember]
        public string SiteName { get; set; }
        [DataMember]
        public string SiteCode { get; set; }
        [DataMember]
        public string SubContractorName { get; set; }
        [DataMember]
        public string Weather { get; set; }
        [DataMember]
        public string PreparedByName { get; set; }
        [DataMember]
        public string ReceivedByName { get; set; }
        [DataMember]
        public string CheckedByName { get; set; }
        [DataMember]
        public string ApprovedByName { get; set; }
        [DataMember]
        public List<DailyPlanDetailVO> DailyPlanDetailList { get; set; }
    }
}
