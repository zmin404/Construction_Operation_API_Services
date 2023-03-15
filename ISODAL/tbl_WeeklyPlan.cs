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
    
    public partial class tbl_WeeklyPlan
    {
        public tbl_WeeklyPlan()
        {
            this.tbl_WeeklyPlanDetail = new HashSet<tbl_WeeklyPlanDetail>();
        }
    
        public int WOPID { get; set; }
        public int SiteID { get; set; }
        public System.DateTime Date { get; set; }
        public string Week { get; set; }
        public System.DateTime Month { get; set; }
        public int PreparedBy { get; set; }
        public bool CompletePrepare { get; set; }
        public Nullable<int> CheckedBy { get; set; }
        public Nullable<bool> CompleteCheck { get; set; }
        public Nullable<int> ApproveBy { get; set; }
        public Nullable<bool> DeleteStatus { get; set; }
        public int ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    
        public virtual tbl_Site tbl_Site { get; set; }
        public virtual tbl_User tbl_User { get; set; }
        public virtual tbl_User tbl_User1 { get; set; }
        public virtual tbl_User tbl_User2 { get; set; }
        public virtual tbl_User tbl_User3 { get; set; }
        public virtual ICollection<tbl_WeeklyPlanDetail> tbl_WeeklyPlanDetail { get; set; }
    }
}