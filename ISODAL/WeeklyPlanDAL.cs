using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ISOServiceVO;
using System.Data.Objects;

namespace ISODAL
{
    public static class WeeklyPlanDAL
    {
        public static List<WeeklyPlanVO> GetAllWeeklyPlan()
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                return context.tbl_WeeklyPlan.ToList().ToWeeklyPlanVOList();
            }
        }

        public static void AddWeeklyPlan(WeeklyPlanVO WeeklyPlanVO)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (ISOFormatEntities context = new ISOFormatEntities())
                {
                    tbl_WeeklyPlan temp = WeeklyPlanVO.ToWeeklyPlanTbl();
                    WeeklyPlanVO.WOPID = temp.WOPID;
                    context.tbl_WeeklyPlan.Add(temp);
                    context.SaveChanges();

                    foreach (WeeklyPlanDetailVO detail in WeeklyPlanVO.WeeklyPlanDetailList)
                    {
                        detail.WOPID = temp.WOPID;
                        context.tbl_WeeklyPlanDetail.Add(detail.ToWeeklyPlanDetailTbl());
                    }
                    context.SaveChanges();
                    scope.Complete();
                }
            }
        }

        public static void EditWeeklyPlan(WeeklyPlanVO WeeklyPlanVO)
        {
            using (TransactionScope scope = new TransactionScope())
            {

                using (ISOFormatEntities context = new ISOFormatEntities())
                {
                    tbl_WeeklyPlan temp = WeeklyPlanVO.ToWeeklyPlanTbl();
                    context.tbl_WeeklyPlan.Attach(temp);
                    context.Entry(temp).State = System.Data.EntityState.Modified;
                    context.SaveChanges();

                    List<tbl_WeeklyPlanDetail> oldDetail = context.tbl_WeeklyPlanDetail.Where(x => x.WOPID == temp.WOPID).ToList();
                    foreach (tbl_WeeklyPlanDetail detail in oldDetail)
                    {
                        context.tbl_WeeklyPlanDetail.Attach(detail);
                        context.Entry(detail).State = System.Data.EntityState.Deleted;
                    }
                    context.SaveChanges();
                    foreach (WeeklyPlanDetailVO detail in WeeklyPlanVO.WeeklyPlanDetailList)
                    {
                        detail.WOPID = temp.WOPID;
                        context.tbl_WeeklyPlanDetail.Add(detail.ToWeeklyPlanDetailTbl());
                    }
                    context.SaveChanges();
                    scope.Complete();
                }
            }
        }

        public static void DeleteWeeklyPlan(WeeklyPlanVO WeeklyPlanVO)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (ISOFormatEntities context = new ISOFormatEntities())
                {
                    tbl_WeeklyPlan temp = WeeklyPlanVO.ToWeeklyPlanTbl();
                    temp.ModifiedBy = temp.ModifiedBy;
                    temp.ModifiedDate = DateTime.Now;
                    temp.DeleteStatus = true;
                    context.tbl_WeeklyPlan.Attach(temp);
                    context.Entry(temp).State = System.Data.EntityState.Modified;
                    context.SaveChanges();

                    scope.Complete();
                }
            }
        }

        public static List<WeeklyPlanDetailVO> GetWeeklyPlanByFilter(DateTime date, int siteID)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                DateTime startDate, endDate;
                startDate = date;
                endDate = startDate.AddDays(7).AddSeconds(-1);

                //IQueryable<tbl_WeeklyPlanDetail> query = context.tbl_WeeklyPlanDetail.Where(x => EntityFunctions.TruncateTime(x.tbl_WeeklyPlan.Date) >= startDate && EntityFunctions.TruncateTime(x.tbl_WeeklyPlan.Date) < endDate && x.tbl_WeeklyPlan.DeleteStatus == false);
                IQueryable<tbl_WeeklyPlanDetail> query = context.tbl_WeeklyPlanDetail.Where(x => EntityFunctions.TruncateTime(x.tbl_WeeklyPlan.Date) >= startDate.Date && EntityFunctions.TruncateTime(x.tbl_WeeklyPlan.Date) < endDate.Date && x.tbl_WeeklyPlan.DeleteStatus == false);
                if (siteID != 0)
                {
                    query = query.Where(x => x.tbl_WeeklyPlan.SiteID == siteID);
                }
                if (query != null)
                {
                    var temp = from s in query select s.WOPID;
                    List<int> IDList = temp.ToList();
                    var list = context.tbl_WeeklyPlanDetail.Where(x => IDList.Contains(x.WOPID)).Select(x => new WeeklyPlanDetailVO
                    {
                        PlanFromDate = x.PlanFromDate,
                        PlanToDate = x.PlanToDate,
                        ActualFromDate = x.ActualFromDate,
                        ActualToDate = x.ActualToDate,
                        NameOfWork = x.tbl_NameOfWork.NameofWork,
                        P1 = x.P1,
                        P2 = x.P2,
                        P3 = x.P3,
                        P4 = x.P4,
                        P5 = x.P5,
                        P6 = x.P6,
                        P7 = x.P7,
                        A1 = x.A1,
                        A2 = x.A2,
                        A3 = x.A3,
                        A4 = x.A4,
                        A5 = x.A5,
                        A6 = x.A6,
                        A7 = x.A7,
                        Remark = x.Remark,
                        WeeklyPlan = new WeeklyPlanVO() 
                                                {      
                                                    Date = x.tbl_WeeklyPlan.Date,
                                                    Week = x.tbl_WeeklyPlan.Week,
                                                    Month = x.tbl_WeeklyPlan.Month,
                                                   SiteName = x.tbl_WeeklyPlan.tbl_Site.SiteName,
                                                   SiteCode = x.tbl_WeeklyPlan.tbl_Site.SiteCode,
                                                   PreparedByName = x.tbl_WeeklyPlan.tbl_User1.tbl_Person1.PersonName,
                                                    CheckedByName = x.tbl_WeeklyPlan.tbl_User2.tbl_Person1.PersonName,
                                                    ApprovedByName = x.tbl_WeeklyPlan.tbl_User3.tbl_Person1.PersonName,
                                                },
                    }).ToList();
                    //list = list.Wh
                    return list;
                }
                return null;
            }
        }

        #region Translate Monthly Plan

        public static WeeklyPlanVO ToWeeklyPlanVO(this tbl_WeeklyPlan that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new WeeklyPlanVO()
                {
                    WOPID = that.WOPID,
                    SiteID = that.SiteID,
                    ApproveBy = that.ApproveBy,
                    CheckedBy = that.CheckedBy,
                    PreparedBy = that.PreparedBy,
                    Date = that.Date,
                    CompletePrepare = that.CompletePrepare,
                    DeleteStatus = that.DeleteStatus,
                    ModifiedBy = that.ModifiedBy,
                    ModifiedDate = that.ModifiedDate,
                    Month = that.Month,
                    Week = that.Week,
                    CompleteCheck = that.CompleteCheck,

                    SiteCode = that.tbl_Site.SiteCode,
                    SiteName = that.tbl_Site.SiteName,
                    PreparedByName = that.tbl_User1.LoginName,
                    CheckedByName = that.tbl_User2.LoginName,
                    ApprovedByName = that.tbl_User3.LoginName,
                    WeeklyPlanDetailList = that.tbl_WeeklyPlanDetail.ToList().ToWeeklyPlanDetailVOList(),
                };
            }
        }

        public static List<WeeklyPlanVO> ToWeeklyPlanVOList(this List<tbl_WeeklyPlan> list)
        {
            if (list == null || list.Count() == 0)
            {
                return null;
            }
            else
            {
                List<WeeklyPlanVO> result = new List<WeeklyPlanVO>();

                foreach (tbl_WeeklyPlan WeeklyPlan in list)
                {
                    result.Add(WeeklyPlan.ToWeeklyPlanVO());
                }
                return result;
            }
        }

        public static tbl_WeeklyPlan ToWeeklyPlanTbl(this WeeklyPlanVO that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new tbl_WeeklyPlan()
                {
                    WOPID = that.WOPID,
                    SiteID = that.SiteID,
                    ApproveBy = that.ApproveBy,
                    CheckedBy = that.CheckedBy,
                    PreparedBy = that.PreparedBy,
                    Date = that.Date,
                    CompletePrepare = that.CompletePrepare,
                    DeleteStatus = that.DeleteStatus,
                    ModifiedBy = that.ModifiedBy,
                    ModifiedDate = that.ModifiedDate,
                    Month = that.Month,
                    Week = that.Week,
                    CompleteCheck = that.CompleteCheck,
                };
            }
        }

        #endregion

        #region Monthly Plan Detail

        public static WeeklyPlanDetailVO ToWeeklyPlanDetailVO(this tbl_WeeklyPlanDetail that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new WeeklyPlanDetailVO()
                {
                    ID = that.ID,
                    WOPID = that.WOPID,
                    PlanFromDate = that.PlanFromDate,
                    PlanToDate = that.PlanToDate,
                    ActualFromDate = that.ActualFromDate,
                    ActualToDate = that.ActualToDate,
                    NameOfWorkID = that.NameOfWorkID,
                    ModifiedBy = that.ModifiedBy,
                    ModifiedDate = that.ModifiedDate,
                    Remark = that.Remark,
                    P1 = that.P1,
                    P2 = that.P2,
                    P3 = that.P3,
                    P4 = that.P4,
                    P5 = that.P5,
                    P6 = that.P6,
                    P7 = that.P7,
                    A1 = that.A1,
                    A2 = that.A2,
                    A3 = that.A3,
                    A4 = that.A4,
                    A5 = that.A5,
                    A6 = that.A6,
                    A7 = that.A7,

                    NameOfWork = that.tbl_NameOfWork.NameofWork,
                };
            }
        }

        public static List<WeeklyPlanDetailVO> ToWeeklyPlanDetailVOList(this List<tbl_WeeklyPlanDetail> list)
        {
            if (list == null || list.Count() == 0)
            {
                return null;
            }
            else
            {
                List<WeeklyPlanDetailVO> result = new List<WeeklyPlanDetailVO>();

                foreach (tbl_WeeklyPlanDetail WeeklyPlanDetail in list)
                {
                    result.Add(WeeklyPlanDetail.ToWeeklyPlanDetailVO());
                }
                return result;
            }
        }

        public static tbl_WeeklyPlanDetail ToWeeklyPlanDetailTbl(this WeeklyPlanDetailVO that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new tbl_WeeklyPlanDetail()
                {
                    ID = that.ID,
                    WOPID = that.WOPID,
                    PlanFromDate = that.PlanFromDate,
                    PlanToDate = that.PlanToDate,
                    ActualFromDate = that.ActualFromDate,
                    ActualToDate = that.ActualToDate,
                    NameOfWorkID = that.NameOfWorkID,
                    ModifiedBy = that.ModifiedBy,
                    ModifiedDate = that.ModifiedDate,
                    Remark = that.Remark,
                    P1 = that.P1,
                    P2 = that.P2,
                    P3 = that.P3,
                    P4 = that.P4,
                    P5 = that.P5,
                    P6 = that.P6,
                    P7 = that.P7,
                    A1 = that.A1,
                    A2 = that.A2,
                    A3 = that.A3,
                    A4 = that.A4,
                    A5 = that.A5,
                    A6 = that.A6,
                    A7 = that.A7,
                };
            }
        }

        #endregion
    }
}
