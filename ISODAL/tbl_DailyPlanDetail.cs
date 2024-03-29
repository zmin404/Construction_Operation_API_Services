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
    
    public partial class tbl_DailyPlanDetail
    {
        public int ID { get; set; }
        public int DPID { get; set; }
        public int NameOfWorkID { get; set; }
        public int LabourTypeID { get; set; }
        public string Location { get; set; }
        public int SkillLabour { get; set; }
        public Nullable<int> MaleLabour { get; set; }
        public Nullable<int> FemaleLabour { get; set; }
        public Nullable<int> AssignNo { get; set; }
        public Nullable<decimal> AssignLength { get; set; }
        public Nullable<decimal> AssignBase { get; set; }
        public Nullable<decimal> AssignHeight { get; set; }
        public Nullable<int> WDNo { get; set; }
        public Nullable<decimal> WDLength { get; set; }
        public Nullable<decimal> WDBase { get; set; }
        public Nullable<decimal> WDHeight { get; set; }
        public Nullable<decimal> WDDe { get; set; }
        public string DailyType { get; set; }
        public string Remark { get; set; }
        public int ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    
        public virtual tbl_DailyPlan tbl_DailyPlan { get; set; }
        public virtual tbl_LabourType tbl_LabourType { get; set; }
        public virtual tbl_NameOfWork tbl_NameOfWork { get; set; }
        public virtual tbl_User tbl_User { get; set; }
    }
}
