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
    
    public partial class tbl_NameOfWork
    {
        public tbl_NameOfWork()
        {
            this.tbl_MonthlyPlanDetail = new HashSet<tbl_MonthlyPlanDetail>();
            this.tbl_WeeklyPlanDetail = new HashSet<tbl_WeeklyPlanDetail>();
            this.tbl_DailyPlanDetail = new HashSet<tbl_DailyPlanDetail>();
        }
    
        public int ID { get; set; }
        public int OPTypeID { get; set; }
        public string NameofWork { get; set; }
        public bool Active { get; set; }
        public int ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    
        public virtual ICollection<tbl_MonthlyPlanDetail> tbl_MonthlyPlanDetail { get; set; }
        public virtual tbl_OPType tbl_OPType { get; set; }
        public virtual tbl_User tbl_User { get; set; }
        public virtual ICollection<tbl_WeeklyPlanDetail> tbl_WeeklyPlanDetail { get; set; }
        public virtual ICollection<tbl_DailyPlanDetail> tbl_DailyPlanDetail { get; set; }
    }
}
