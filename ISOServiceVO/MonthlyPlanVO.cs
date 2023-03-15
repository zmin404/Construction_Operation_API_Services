using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISOServiceVO
{
     [DataContract]
    public class MonthlyPlanVO
    {
        [DataMember]
        public int MOPID { get; set; }
        [DataMember]
        public int SiteID { get; set; }
         [DataMember]
        public DateTime? FortheMonth { get; set; }
         [DataMember]
         public DateTime? Date { get; set; }
         [DataMember]
        public int PreparedBy { get; set; }
         [DataMember]
        public Nullable<bool> CompletePrepare { get; set; }
         [DataMember]
        public int CheckedBy { get; set; }
         [DataMember]
        public Nullable<bool> CompleteChecked { get; set; }
         [DataMember]
        public int ApproveBy { get; set; }
         [DataMember]
         public Nullable<bool> CompleteApproved { get; set; }
         [DataMember]
        public Nullable<bool> DeleteStatus { get; set; }
         [DataMember]
        public int ModifiedBy { get; set; }
         [DataMember]
         public DateTime? ModifiedDate { get; set; }

         [DataMember]
         public string SiteName { get; set; }
         [DataMember]
         public string SiteCode { get; set; }
         [DataMember]
         public string PreparedByName { get; set; }
         [DataMember]
         public string CheckedByName { get; set; }
         [DataMember]
         public string ApprovedByName { get; set; }
         [DataMember]
         public List<MonthlyPlanDetailVO> MonthlyPlanDetailList { get; set; }
         [DataMember]
         public List<ActualDateVO> ActualDateList { get; set; }
         [DataMember]
         public List<PlanDateVO> PlanDateList { get; set; }
    }
}
