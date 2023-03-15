using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISOServiceVO
{
     [DataContract]
    public class AddMonthlyPlanVO
    {
        [DataMember]
        public int MOPID { get; set; }
        [DataMember]
        public int SiteID { get; set; }
         [DataMember]
        public string FortheMonth { get; set; }
         [DataMember]
         public string Date { get; set; }
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
         public string ModifiedDate { get; set; }

    }
}
