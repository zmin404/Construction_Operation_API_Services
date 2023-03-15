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
    
    public partial class tbl_User
    {
        public tbl_User()
        {
            this.tbl_BuildingType = new HashSet<tbl_BuildingType>();
            this.tbl_LabourType = new HashSet<tbl_LabourType>();
            this.tbl_MonthlyPlanDetail = new HashSet<tbl_MonthlyPlanDetail>();
            this.tbl_NameOfWork = new HashSet<tbl_NameOfWork>();
            this.tbl_OperationOrder = new HashSet<tbl_OperationOrder>();
            this.tbl_OperationOrder1 = new HashSet<tbl_OperationOrder>();
            this.tbl_OperationOrderReg = new HashSet<tbl_OperationOrderReg>();
            this.tbl_OPType = new HashSet<tbl_OPType>();
            this.tbl_Person = new HashSet<tbl_Person>();
            this.tbl_PersonAndSite = new HashSet<tbl_PersonAndSite>();
            this.tbl_PersonType = new HashSet<tbl_PersonType>();
            this.tbl_Site = new HashSet<tbl_Site>();
            this.tbl_User1 = new HashSet<tbl_User>();
            this.tbl_WeeklyPlan = new HashSet<tbl_WeeklyPlan>();
            this.tbl_WeeklyPlan1 = new HashSet<tbl_WeeklyPlan>();
            this.tbl_WeeklyPlan2 = new HashSet<tbl_WeeklyPlan>();
            this.tbl_WeeklyPlan3 = new HashSet<tbl_WeeklyPlan>();
            this.tbl_MonthlyPlan = new HashSet<tbl_MonthlyPlan>();
            this.tbl_MonthlyPlan1 = new HashSet<tbl_MonthlyPlan>();
            this.tbl_MonthlyPlan2 = new HashSet<tbl_MonthlyPlan>();
            this.tbl_MonthlyPlan3 = new HashSet<tbl_MonthlyPlan>();
            this.tbl_WeeklyPlanDetail = new HashSet<tbl_WeeklyPlanDetail>();
            this.tbl_DailyPlan = new HashSet<tbl_DailyPlan>();
            this.tbl_DailyPlan1 = new HashSet<tbl_DailyPlan>();
            this.tbl_DailyPlan2 = new HashSet<tbl_DailyPlan>();
            this.tbl_DailyPlan3 = new HashSet<tbl_DailyPlan>();
            this.tbl_DailyPlan4 = new HashSet<tbl_DailyPlan>();
            this.tbl_DailyPlanDetail = new HashSet<tbl_DailyPlanDetail>();
        }
    
        public int ID { get; set; }
        public int UserRoleID { get; set; }
        public Nullable<int> PersonID { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public byte[] Image { get; set; }
        public bool IsActive { get; set; }
        public int LastModifiedBy { get; set; }
        public System.DateTime LastModifiedOn { get; set; }
    
        public virtual ICollection<tbl_BuildingType> tbl_BuildingType { get; set; }
        public virtual ICollection<tbl_LabourType> tbl_LabourType { get; set; }
        public virtual ICollection<tbl_MonthlyPlanDetail> tbl_MonthlyPlanDetail { get; set; }
        public virtual ICollection<tbl_NameOfWork> tbl_NameOfWork { get; set; }
        public virtual ICollection<tbl_OperationOrder> tbl_OperationOrder { get; set; }
        public virtual ICollection<tbl_OperationOrder> tbl_OperationOrder1 { get; set; }
        public virtual ICollection<tbl_OperationOrderReg> tbl_OperationOrderReg { get; set; }
        public virtual ICollection<tbl_OPType> tbl_OPType { get; set; }
        public virtual ICollection<tbl_Person> tbl_Person { get; set; }
        public virtual tbl_Person tbl_Person1 { get; set; }
        public virtual ICollection<tbl_PersonAndSite> tbl_PersonAndSite { get; set; }
        public virtual ICollection<tbl_PersonType> tbl_PersonType { get; set; }
        public virtual ICollection<tbl_Site> tbl_Site { get; set; }
        public virtual ICollection<tbl_User> tbl_User1 { get; set; }
        public virtual tbl_User tbl_User2 { get; set; }
        public virtual tbl_UserRole tbl_UserRole { get; set; }
        public virtual ICollection<tbl_WeeklyPlan> tbl_WeeklyPlan { get; set; }
        public virtual ICollection<tbl_WeeklyPlan> tbl_WeeklyPlan1 { get; set; }
        public virtual ICollection<tbl_WeeklyPlan> tbl_WeeklyPlan2 { get; set; }
        public virtual ICollection<tbl_WeeklyPlan> tbl_WeeklyPlan3 { get; set; }
        public virtual ICollection<tbl_MonthlyPlan> tbl_MonthlyPlan { get; set; }
        public virtual ICollection<tbl_MonthlyPlan> tbl_MonthlyPlan1 { get; set; }
        public virtual ICollection<tbl_MonthlyPlan> tbl_MonthlyPlan2 { get; set; }
        public virtual ICollection<tbl_MonthlyPlan> tbl_MonthlyPlan3 { get; set; }
        public virtual ICollection<tbl_WeeklyPlanDetail> tbl_WeeklyPlanDetail { get; set; }
        public virtual ICollection<tbl_DailyPlan> tbl_DailyPlan { get; set; }
        public virtual ICollection<tbl_DailyPlan> tbl_DailyPlan1 { get; set; }
        public virtual ICollection<tbl_DailyPlan> tbl_DailyPlan2 { get; set; }
        public virtual ICollection<tbl_DailyPlan> tbl_DailyPlan3 { get; set; }
        public virtual ICollection<tbl_DailyPlan> tbl_DailyPlan4 { get; set; }
        public virtual ICollection<tbl_DailyPlanDetail> tbl_DailyPlanDetail { get; set; }
    }
}