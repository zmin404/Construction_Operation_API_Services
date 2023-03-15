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
    
    public partial class tbl_OperationOrderReg
    {
        public tbl_OperationOrderReg()
        {
            this.tbl_OperationOrder = new HashSet<tbl_OperationOrder>();
        }
    
        public int OORID { get; set; }
        public string OrderNo { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int SiteID { get; set; }
        public int BuildingTypeId { get; set; }
        public int SiteEngineerID { get; set; }
        public int SeniorInchargeID { get; set; }
        public int StoreKeeperID { get; set; }
        public System.DateTime StartingDate { get; set; }
        public string Remark { get; set; }
        public int ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    
        public virtual tbl_BuildingType tbl_BuildingType { get; set; }
        public virtual ICollection<tbl_OperationOrder> tbl_OperationOrder { get; set; }
        public virtual tbl_Person tbl_Person { get; set; }
        public virtual tbl_Person tbl_Person1 { get; set; }
        public virtual tbl_Person tbl_Person2 { get; set; }
        public virtual tbl_Site tbl_Site { get; set; }
        public virtual tbl_User tbl_User { get; set; }
    }
}