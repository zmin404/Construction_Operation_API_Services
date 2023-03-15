using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISOServiceVO
{
     [DataContract]
    public class MonthlyPlanDetailByStringValueVO 
    {
        [DataMember]
        public string MOPID { get; set; }
        [DataMember]
        public string NameOfWorkID { get; set; }
        [DataMember]
        public string a { get; set; }
        [DataMember]
        public string b { get; set; }
        [DataMember]
        public string c { get; set; }
        [DataMember]
        public string d { get; set; }
        [DataMember]
        public string e { get; set; }
        [DataMember]
        public string f { get; set; }
        [DataMember]
        public string PreviousOverallWorkdone { get; set; }
        [DataMember]
        public string OverallWorkdone { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }
        [DataMember]
        public string ModifiedDate { get; set; }
        [DataMember]
        public List<string> PlanDateByStringValue { get; set; }
        [DataMember]
        public List<string> ActualDateByStringValue { get; set; }

    }
}
