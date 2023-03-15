using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISOServiceVO
{
     [DataContract]
    public class OperationOrderVO
    {
        [DataMember]
        public int OOID { get; set; }
        [DataMember]
        public int OORID { get; set; }
        [DataMember]
        public System.DateTime OODate { get; set; }
        [DataMember]
        public int BuildingTypeID { get; set; }
        [DataMember]
        public string Duration { get; set; }
        [DataMember]
        public int SiteID { get; set; }
        [DataMember]
        public int SiteEngineerID { get; set; }
        [DataMember]
        public int SeniorInchargeID { get; set; }
        [DataMember]
        public int StoreKeeperID { get; set; }
        [DataMember]
        public string DetailInstruction { get; set; }
        [DataMember]
        public Nullable<bool> CompletePrepare { get; set; }
        [DataMember]
        public Nullable<int> ApprovedBy { get; set; }
        [DataMember]
        public Nullable<bool> CompleteApprove { get; set; }
         [DataMember]
        public int ModifiedBy { get; set; }
         [DataMember]
        public System.DateTime ModifiedDate { get; set; }

        [DataMember]
        public string BuildingType { get; set; }
        [DataMember]
        public string Site { get; set; }
        [DataMember]
        public string SiteEngineer { get; set; }
        [DataMember]
        public string SeniorIncharge { get; set; }
        [DataMember]
        public string StoreKeeper { get; set; }
        [DataMember]
        public string OrderNo { get; set; }
        [DataMember]
        public string ApprovedByName { get; set; } 
    }
}
