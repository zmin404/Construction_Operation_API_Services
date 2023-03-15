using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISOServiceVO
{
     [DataContract]
    public class WeekPlanDetailVO
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
        public Nullable<System.DateTime> ActualFromDate { get; set; }
        [DataMember]
        public Nullable<System.DateTime> ActualToDate { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public int ModifiedBy { get; set; }
        [DataMember]
        public System.DateTime ModifiedDate { get; set; }

        [DataMember]
        public string NameOfWork { get; set; }
    }
}
