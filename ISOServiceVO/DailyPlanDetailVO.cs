using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISOServiceVO
{
     [DataContract]
    public class DailyPlanDetailVO
    {
         [DataMember]
         public int ID { get; set; }
          [DataMember]
         public int DPID { get; set; }
          [DataMember]
         public int NameOfWorkID { get; set; }
          [DataMember]
         public int LabourTypeID { get; set; }
          [DataMember]
         public string Location { get; set; }
          [DataMember]
         public int SkillLabour { get; set; }
          [DataMember]
         public Nullable<int> MaleLabour { get; set; }
          [DataMember]
         public Nullable<int> FemaleLabour { get; set; }
          [DataMember]
         public Nullable<int> AssignNo { get; set; }
          [DataMember]
         public Nullable<decimal> AssignLength { get; set; }
          [DataMember]
         public Nullable<decimal> AssignBase { get; set; }
          [DataMember]
         public Nullable<decimal> AssignHeight { get; set; }
          [DataMember]
         public Nullable<int> WDNo { get; set; }
          [DataMember]
         public Nullable<decimal> WDLength { get; set; }
          [DataMember]
         public Nullable<decimal> WDBase { get; set; }
          [DataMember]
         public Nullable<decimal> WDHeight { get; set; }
          [DataMember]
         public Nullable<decimal> WDDe { get; set; }
         [DataMember]
          public string DailyType { get; set; }
          [DataMember]
         public string Remark { get; set; }
          [DataMember]
         public int ModifiedBy { get; set; }
          [DataMember]
         public System.DateTime ModifiedDate { get; set; }

          [DataMember]
          public string NameOfWork { get; set; }
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
    }
}
