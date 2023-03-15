using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISOServiceVO
{
     [DataContract]
    public  class OperationOrderRegVO
    {
        [DataMember]
        public int OORID { get; set; }
        [DataMember]
        public string OrderNo { get; set; }
        [DataMember]
        public System.DateTime OrderDate { get; set; }
        [DataMember]
        public int SiteID { get; set; }
        [DataMember]
        public int BuildingTypeId { get; set; }
        [DataMember]
        public int SiteEngineerID { get; set; }
        [DataMember]
        public int SeniorInchargeID { get; set; }
        [DataMember]
        public int StoreKeeperID { get; set; }
        [DataMember]
        public System.DateTime StartingDate { get; set; }
        [DataMember]
        public string Remark { get; set; }
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
         public string CustomerName { get; set; }

         [DataMember]
         public List<MasterSchedulePDFVO> MasterSchedulePDFList { get; set; }
         [DataMember]
         public List<ContractPDFVO> ContractPDFList { get; set; }  
    
    }
}
