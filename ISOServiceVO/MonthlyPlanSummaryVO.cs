using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISOServiceVO
{
    [DataContract]
    public class MonthlyPlanSummaryVO
    {
        [DataMember]
        public int MOPDID { get; set; }  
        [DataMember]
        public System.DateTime FortheMonth { get; set; }
        [DataMember]
        public System.DateTime Date { get; set; }
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
        public decimal a { get; set; }
        [DataMember]
        public decimal b { get; set; }
        [DataMember]
        public Nullable<decimal> c { get; set; }
        [DataMember]
        public Nullable<decimal> d { get; set; }
        [DataMember]
        public Nullable<decimal> e { get; set; }
        [DataMember]
        public Nullable<decimal> f { get; set; }
        [DataMember]
        public Nullable<decimal> PreviousOverallWorkdone { get; set; }
        [DataMember]
        public Nullable<decimal> OverallWorkdone { get; set; }

        [DataMember]
        public string NameOfWork { get; set; }
        //[DataMember]
        //public List<PlanDateVO> PlanDateList { get; set; }
        //[DataMember]
        //public List<ActualDateVO> ActualDateList { get; set; }

        [DataMember]
        public MPlanDateVO MPlanDateVO { get; set; }
        [DataMember]
        public MActualDateVO MActualDateVO { get; set; }          
    }
}
