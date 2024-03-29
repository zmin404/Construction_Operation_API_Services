//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ISODAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_OperationOrder
    {
        public int OOID { get; set; }
        public int OORID { get; set; }
        public System.DateTime OODate { get; set; }
        public int BuildingTypeID { get; set; }
        public string Duration { get; set; }
        public int SiteID { get; set; }
        public int SiteEngineerID { get; set; }
        public int SeniorInchargeID { get; set; }
        public int StoreKeeperID { get; set; }
        public string DetailInstruction { get; set; }
        public Nullable<bool> CompletePrepare { get; set; }
        public Nullable<int> ApprovedBy { get; set; }
        public Nullable<bool> CompleteApprove { get; set; }
        public int ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    
        public virtual tbl_BuildingType tbl_BuildingType { get; set; }
        public virtual tbl_OperationOrderReg tbl_OperationOrderReg { get; set; }
        public virtual tbl_Person tbl_Person { get; set; }
        public virtual tbl_Person tbl_Person1 { get; set; }
        public virtual tbl_Person tbl_Person2 { get; set; }
        public virtual tbl_Site tbl_Site { get; set; }
        public virtual tbl_User tbl_User { get; set; }
        public virtual tbl_User tbl_User1 { get; set; }
    }
}
