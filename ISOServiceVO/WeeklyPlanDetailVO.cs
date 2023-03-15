using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISOServiceVO
{
     [DataContract]
    public class WeeklyPlanDetailVO
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int WOPID { get; set; }
        [DataMember]
        public int NameOfWorkID { get; set; }
        [DataMember]
        public System.DateTime PlanFromDate { get; set; }
        [DataMember]
        public System.DateTime PlanToDate { get; set; }
        [DataMember]
        public System.DateTime ActualFromDate { get; set; }
        [DataMember]
        public System.DateTime ActualToDate { get; set; }
        [DataMember]
        public string P1 { get; set; }
        [DataMember]
        public string P2 { get; set; }
        [DataMember]
        public string P3 { get; set; }
        [DataMember]
        public string P4 { get; set; }
        [DataMember]
        public string P5 { get; set; }
        [DataMember]
        public string P6 { get; set; }
        [DataMember]
        public string P7 { get; set; }
        [DataMember]
        public string A1 { get; set; }
        [DataMember]
        public string A2 { get; set; }
        [DataMember]
        public string A3 { get; set; }
        [DataMember]
        public string A4 { get; set; }
        [DataMember]
        public string A5 { get; set; }
        [DataMember]
        public string A6 { get; set; }
        [DataMember]
        public string A7 { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public int ModifiedBy { get; set; }
        [DataMember]
        public System.DateTime ModifiedDate { get; set; }

        [DataMember]
        public string NameOfWork { get; set; }
        [DataMember] 
        public WeeklyPlanVO WeeklyPlan { get; set; }
    }
}
