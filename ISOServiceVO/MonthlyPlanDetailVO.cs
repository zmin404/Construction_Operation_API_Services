using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISOServiceVO
{
     [DataContract]
    public class MonthlyPlanDetailVO
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int MOPID { get; set; }
        [DataMember]
        public int NameOfWorkID { get; set; }
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
        public int ModifiedBy { get; set; }
        [DataMember]
        public System.DateTime ModifiedDate { get; set; }

        [DataMember]
        public string NameOfWork { get; set; }
        [DataMember]
        public List<ActualDateVO> ActualDateList { get; set; }
        [DataMember]
        public List<PlanDateVO> PlanDateList { get; set; }
    }
}
