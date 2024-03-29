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
    
    public partial class tbl_MonthlyPlan
    {
        public tbl_MonthlyPlan()
        {
            this.tbl_MonthlyPlanDetail = new HashSet<tbl_MonthlyPlanDetail>();
        }
    
        public int MOPID { get; set; }
        public int SiteID { get; set; }
        public Nullable<System.DateTime> FortheMonth { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public int PreparedBy { get; set; }
        public Nullable<bool> CompletePrepare { get; set; }
        public int CheckedBy { get; set; }
        public Nullable<bool> CompleteChecked { get; set; }
        public int ApproveBy { get; set; }
        public Nullable<bool> CompleteApproved { get; set; }
        public Nullable<bool> DeleteStatus { get; set; }
        public int ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        public virtual tbl_Site tbl_Site { get; set; }
        public virtual tbl_User tbl_User { get; set; }
        public virtual tbl_User tbl_User1 { get; set; }
        public virtual tbl_User tbl_User2 { get; set; }
        public virtual tbl_User tbl_User3 { get; set; }
        public virtual ICollection<tbl_MonthlyPlanDetail> tbl_MonthlyPlanDetail { get; set; }
        public virtual tbl_Person tbl_Person { get; set; }
        public virtual tbl_Person tbl_Person1 { get; set; }
        public virtual tbl_Person tbl_Person2 { get; set; }
    }
}
