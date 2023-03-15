using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISOServiceVO;
using System.Transactions;
using System.Data.Objects;

namespace ISODAL
{
    public static class MonthlyPlanDAL
    {
        public static List<MonthlyPlanVO> GetAllMonthlyPlan()
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                return context.tbl_MonthlyPlan.ToList().ToMonthlyPlanVOList();
            }
        }

        public static void AddMonthlyPlan(AddMonthlyPlanVO addMonthlyPlanVO)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                tbl_MonthlyPlan temp = addMonthlyPlanVO.ToAddMonthlyPlanTbl();
                context.tbl_MonthlyPlan.Add(temp);
                context.SaveChanges();
            }
        }

        public static void SaveMonthlyPlan(MonthlyPlanVO MonthlyPlanVO)  
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (ISOFormatEntities context = new ISOFormatEntities())
                {
                    tbl_MonthlyPlan temp = MonthlyPlanVO.ToMonthlyPlanTbl();
                    MonthlyPlanVO.MOPID = temp.MOPID;
                    context.tbl_MonthlyPlan.Add(temp);
                    context.SaveChanges();

                    foreach (MonthlyPlanDetailVO detail in MonthlyPlanVO.MonthlyPlanDetailList)
                    {
                        detail.MOPID = temp.MOPID;
                        context.tbl_MonthlyPlanDetail.Add(detail.ToMonthlyPlanDetailTbl());
                        context.SaveChanges();

                        foreach(ActualDateVO actualDate in MonthlyPlanVO.ActualDateList )
                        {
                          actualDate.MPDID = detail.ID;
                          context.tbl_ActualDate.Add(actualDate.ToActualDateTbl());
                        }
                        context.SaveChanges();
                        foreach (PlanDateVO planDate in MonthlyPlanVO.PlanDateList) 
                        {
                            planDate.MPDID = detail.ID;
                            context.tbl_PlanDate.Add(planDate.ToPlanDateTbl());
                        }
                        context.SaveChanges();
                    }
                    scope.Complete();
                }
            }
        }

        public static void EditMonthlyPlan(MonthlyPlanVO MonthlyPlanVO)
        {
            using (TransactionScope scope = new TransactionScope())
            {

                using (ISOFormatEntities context = new ISOFormatEntities())
                {
                    tbl_MonthlyPlan temp = MonthlyPlanVO.ToMonthlyPlanTbl();
                    context.tbl_MonthlyPlan.Attach(temp);
                    context.Entry(temp).State = System.Data.EntityState.Modified;
                    context.SaveChanges();

                    List<tbl_MonthlyPlanDetail> oldDetail = context.tbl_MonthlyPlanDetail.Where(x => x.MOPID == temp.MOPID).ToList();
                    foreach(tbl_MonthlyPlanDetail detail in oldDetail)
                    {
                        context.tbl_MonthlyPlanDetail.Attach(detail);
                        context.Entry(detail).State = System.Data.EntityState.Deleted;
                    }
                    context.SaveChanges();
                    foreach (MonthlyPlanDetailVO detail in MonthlyPlanVO.MonthlyPlanDetailList)
                    {
                        detail.MOPID = temp.MOPID;
                        context.tbl_MonthlyPlanDetail.Add(detail.ToMonthlyPlanDetailTbl());
                    }
                    context.SaveChanges();
                    scope.Complete();
                }
            }
        }

        public static void DeleteMonthlyPlan(MonthlyPlanVO MonthlyPlanVO)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (ISOFormatEntities context = new ISOFormatEntities())
                {
                    tbl_MonthlyPlan temp = MonthlyPlanVO.ToMonthlyPlanTbl();
                    temp.ModifiedBy = temp.ModifiedBy;
                    temp.ModifiedDate = DateTime.Now;
                    temp.DeleteStatus = true;
                    context.tbl_MonthlyPlan.Attach(temp);
                    context.Entry(temp).State = System.Data.EntityState.Modified;
                    context.SaveChanges();

                    //List<tbl_MonthlyPlanDetail> oldDetail = context.tbl_MonthlyPlanDetail.Where(x => x.MOPID == temp.MOPID).ToList();
                    //foreach(tbl_MonthlyPlanDetail detail in oldDetail)
                    //{
                    //    detail.ModifiedDate = DateTime.Now;
                    //    context.tbl_MonthlyPlanDetail.Attach(detail);
                    //    context.Entry(detail).State = System.Data.EntityState.Modified;
                    //}
                    //context.SaveChanges();
                    scope.Complete();
                }
            }
        }

        public static List<MonthlyPlanSummaryVO> GetMonthlyPlanByFilter(DateTime date, int siteID)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                //context.Configuration.ProxyCreationEnabled = false;
                DateTime startDate, endDate;
                startDate = new DateTime(date.Year, date.Month, 1);
                endDate = startDate.AddMonths(1).AddSeconds(-1);

                IQueryable<tbl_MonthlyPlanDetail> query = context.tbl_MonthlyPlanDetail.Where(x => EntityFunctions.TruncateTime(x.tbl_MonthlyPlan.FortheMonth) >= startDate && EntityFunctions.TruncateTime(x.tbl_MonthlyPlan.FortheMonth) <= endDate && x.tbl_MonthlyPlan.DeleteStatus == false);
                if (siteID != 0)
                {
                    query = query.Where(x => x.tbl_MonthlyPlan.tbl_Site.SiteID == siteID);
                }
                if (query != null && query.Count() > 0)
                {
                    var temp = from s in query select s;
                    //List<int> IDList = temp.ToList();
                    //var list = temp.Select(x => x).ToList();

                    //var e = list.ToList();  

                    var list = temp.ToList().Select(x => new MonthlyPlanSummaryVO
                    {
                        MOPDID = x.ID,
                        FortheMonth =(DateTime) x.tbl_MonthlyPlan.FortheMonth,
                        Date = (DateTime)x.tbl_MonthlyPlan.Date,
                        SiteName = x.tbl_MonthlyPlan.tbl_Site.SiteName,
                        SiteCode = x.tbl_MonthlyPlan.tbl_Site.SiteCode,
                        //PreparedByName = x.tbl_MonthlyPlan.tbl_User1.tbl_PersonAndSite1.tbl_Person.PersonName,
                        //CheckedByName = x.tbl_MonthlyPlan.tbl_User2.tbl_PersonAndSite1.tbl_Person.PersonName,
                        //ApprovedByName = x.tbl_MonthlyPlan.tbl_User3.tbl_PersonAndSite1.tbl_Person.PersonName,
                        a = x.a,
                        b = x.b,
                        c = x.c,
                        d = x.d,
                        e = x.e,
                        f = x.f,
                        OverallWorkdone = x.OverallWorkdone,
                        PreviousOverallWorkdone = x.PreviousOverallWorkdone,

                        NameOfWork = x.tbl_NameOfWork.NameofWork,
                        MPlanDateVO = x.tbl_PlanDate.Where(a => a.MPDID == x.ID).ToList().ToMonthlyPlanDateVO(),
                        MActualDateVO = x.tbl_ActualDate.Where(a => a.MPDID == x.ID).ToList().ToMonthlyActualDateVO()

                        #region Date Test
                        //ActualDateList = x.tbl_ActualDate.Where(a => a.MPDID == x.ID).Select(a => new ActualDateVO
                        //{
                        //    ID = a.ID,
                        //    MPDID = a.MPDID,
                        //    Date = a.Date,
                        //    //NameOfWork = a.tbl_MonthlyPlanDetail.tbl_NameOfWork.NameofWork,
                        //}).ToList(),
                        //PlanDateList = x.tbl_PlanDate.Where(a => a.MPDID == x.ID).Select(a => new PlanDateVO
                        //{
                        //    ID = a.ID,
                        //    MPDID = a.MPDID,
                        //    Date = a.Date,
                        //    NameOfWork = a.tbl_MonthlyPlanDetail.tbl_NameOfWork.NameofWork,
                        //}).ToList(),    
                        #endregion

                    }).ToList();


                    return list;
                }
                return null;
            }
        }

        public static List<MonthlyPlanVO> GetAllMonthlyPlanBySiteIDAndPersonRole(int siteID, string personRole)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                List<MonthlyPlanVO> temp = new List<MonthlyPlanVO>();
                if(personRole == "Prepared By")
                {
                   temp = context.tbl_MonthlyPlan.Where(x => x.SiteID == siteID && x.DeleteStatus == false).ToList().ToMonthlyPlanVOList();
                    
                }
                else if(personRole == "Checked By")
                {
                    temp = context.tbl_MonthlyPlan.Where(x => (x.SiteID == siteID && x.CompletePrepare == true && x.DeleteStatus == false && x.CompleteChecked == null) || (x.SiteID == siteID && x.CompletePrepare == true && x.CompleteChecked == true && x.CompleteApproved == true && x.DeleteStatus == false )).ToList().ToMonthlyPlanVOList();
                }
                else if(personRole == "Approved By")
                {
                    temp = context.tbl_MonthlyPlan.Where(x => x.SiteID == siteID && x.CompletePrepare == true && x.CompleteChecked == true && x.DeleteStatus == false).ToList().ToMonthlyPlanVOList();
                    
                }
                return temp;

            }
        }

        public static List<MonthlyPlanVO> GetAllMonthlyPlanByPersonIDAndPersonRole(int personID, string personRole)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                List<MonthlyPlanVO> temp = new List<MonthlyPlanVO>();
                if (personRole == "Checked By")
                {

                    temp = context.tbl_MonthlyPlan.Where(x => x.CompletePrepare == true  && x.CompleteChecked == null && x.PreparedBy != x.CheckedBy && x.DeleteStatus == false && x.CheckedBy == personID).ToList().ToMonthlyPlanVOList();
                }
                else if (personRole == "Approved By")
                {
                    temp = context.tbl_MonthlyPlan.Where(x => (x.CompletePrepare == true && x.CompleteChecked == null && x.CompleteApproved == null && x.DeleteStatus == false && x.CheckedBy == x.ApproveBy && x.ApproveBy == personID) || (x.CompletePrepare == true && x.CompleteChecked == true && x.CompleteApproved == null && x.DeleteStatus == false && x.CheckedBy != x.ApproveBy && x.ApproveBy == personID)).ToList().ToMonthlyPlanVOList();
                }
                return temp;

            }
        }

        public static List<MonthlyPlanDetailVO> GetAllMonthlyPlanDetailsBySiteIDAndForthemonth(int siteID, DateTime month)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                context.Configuration.ProxyCreationEnabled = true;
                var temp = context.tbl_MonthlyPlanDetail.Where(x => x.tbl_MonthlyPlan.SiteID == siteID && EntityFunctions.TruncateTime(x.tbl_MonthlyPlan.FortheMonth) == month.Date && x.tbl_MonthlyPlan.DeleteStatus == false).ToList().ToMonthlyPlanDetailVOList();
                return temp;
            }
        }
  
        public static void DeleteMonthlyPlanBySiteIDAndForTheMonth(int siteID, string forMonth)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                DateTime month = Convert.ToDateTime(forMonth);
                tbl_MonthlyPlan temp = context.tbl_MonthlyPlan.Where(x=>x.SiteID == siteID && EntityFunctions.TruncateTime(x.FortheMonth) == month.Date && x.DeleteStatus == false).FirstOrDefault();
                temp.DeleteStatus = true;
                context.tbl_MonthlyPlan.Attach(temp);
                context.Entry(temp).State = System.Data.EntityState.Modified;
                context.SaveChanges();

                //context.tbl_MonthlyPlan.Where(x => x.SiteID == siteID && EntityFunctions.TruncateTime(x.FortheMonth) == month.Date).ToList().ForEach(x => x.DeleteStatus = true);
                //context.SaveChanges();
            }
        }
        public static void UpdateMonthlyPlanStatusByMOPID(int mopID)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                tbl_MonthlyPlan temp = context.tbl_MonthlyPlan.Where(x => x.MOPID == mopID).FirstOrDefault();
                if(temp.PreparedBy == temp.CheckedBy)
                {
                    temp.CompletePrepare = true;
                    temp.CompleteChecked = true;
                    temp.CompleteApproved = null;
                }
                else
                {
                    temp.CompletePrepare = true;
                    temp.CompleteChecked = null;
                    temp.CompleteApproved = null;
                }
                
                context.tbl_MonthlyPlan.Attach(temp);
                context.Entry(temp).State = System.Data.EntityState.Modified;
                context.SaveChanges();

                //context.tbl_MonthlyPlan.Where(x => x.SiteID == siteID && EntityFunctions.TruncateTime(x.FortheMonth) == month.Date).ToList().ForEach(x => x.DeleteStatus = true);
                //context.SaveChanges();
            }
        }
        public static void UpdateMonthlyPlanStatusByMOPIDAndPersonRoleAndStatus(int mopID, string personRole, string status)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                tbl_MonthlyPlan temp = context.tbl_MonthlyPlan.Where(x => x.MOPID == mopID).FirstOrDefault();
                if (status == "Accept")
                {
                    if(personRole == "Checked By")
                    {
                        temp.CompleteChecked = true;
                    }
                    else if(personRole == "Approved By")
                    {
                        temp.CompleteChecked = true;
                        temp.CompleteApproved = true;
                    }
                }
                else if(status == "Reject")
                {
                    if (personRole == "Checked By")
                    {
                        temp.CompleteChecked = false;
                    }
                    else if (personRole == "Approved By")
                    {
                        temp.CompleteChecked = false;
                        temp.CompleteApproved = false;
                    }
                }

                context.tbl_MonthlyPlan.Attach(temp);
                context.Entry(temp).State = System.Data.EntityState.Modified;
                context.SaveChanges();

                //context.tbl_MonthlyPlan.Where(x => x.SiteID == siteID && EntityFunctions.TruncateTime(x.FortheMonth) == month.Date).ToList().ForEach(x => x.DeleteStatus = true);
                //context.SaveChanges();
            }
        }

        public static List<MonthlyPlanVO> GetAllMonthlyPlanBySiteIDAndForTheMonth(int siteID, string forMonth)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                //DateTime month = Convert.ToDateTime(forMonth);
                //var temp = context.tbl_MonthlyPlan.Where(x => x.SiteID == siteID && EntityFunctions.TruncateTime(x.FortheMonth) == month.Date && x.DeleteStatus == false).ToList().ToMonthlyPlanVOList();
                //return temp;
                int year = Convert.ToDateTime(forMonth).Year;
                int month = Convert.ToDateTime(forMonth).Month;
                var temp = context.tbl_MonthlyPlan.Where(x => x.SiteID == siteID && EntityFunctions.TruncateTime(x.FortheMonth).Value.Year == year && EntityFunctions.TruncateTime(x.FortheMonth).Value.Month == month && x.DeleteStatus == false).ToList().ToMonthlyPlanVOList();
                return temp;
            }
        }
        public static MonthlyPlanVO GetMonthlyPlanBySiteIDAndForTheMonth(int siteID, string forMonth)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                int year = Convert.ToDateTime(forMonth).Year;
                int month = Convert.ToDateTime(forMonth).Month;
                var temp = context.tbl_MonthlyPlan.Where(x => x.SiteID == siteID && EntityFunctions.TruncateTime(x.FortheMonth).Value.Year == year && EntityFunctions.TruncateTime(x.FortheMonth).Value.Month == month && x.DeleteStatus == false).FirstOrDefault().ToMonthlyPlanVO();
                return temp;
            }
        }

        //public static List<MonthlyPlanSummaryVO> GetMonthlyPlanByFilter(DateTime date, int siteID)
        //{
        //    using (ISOFormatEntities context = new ISOFormatEntities())
        //    {
        //        DateTime startDate, endDate;
        //        startDate = new DateTime(date.Year, date.Month, 1);
        //        endDate = startDate.AddMonths(1).AddSeconds(-1);

        //        IQueryable<tbl_MonthlyPlan> query = context.tbl_MonthlyPlan.Where(x => EntityFunctions.TruncateTime(x.FortheMonth) >= startDate && EntityFunctions.TruncateTime(x.FortheMonth) <= endDate && x.DeleteStatus == false);
        //        if (siteID != 0) 
        //        {
        //            query = query.Where(x => x.SiteID == siteID);
        //        }
        //        if (query != null && query.Count() > 0)
        //        {
        //            var temp = from s in query select s.MOPID;
        //            List<int> IDList = temp.ToList();
        //            var list = context.tbl_MonthlyPlanDetail.Where(x => IDList.Contains(x.MOPID)).Select(x => new MonthlyPlanSummaryVO())
        //                              {
        //                FortheMonth = x.tbl_MonthlyPlan.FortheMonth,
        //                Date = x.tbl_MonthlyPlan.Date,
        //                SiteName = x.tbl_MonthlyPlan.tbl_Site.SiteName,
        //                SiteCode = x.tbl_MonthlyPlan.tbl_Site.SiteCode,
        //                PreparedByName = x.tbl_MonthlyPlan.tbl_User1.tbl_PersonAndSite.Select(z => z.tbl_Person.PersonName).FirstOrDefault(),
        //                CheckedByName = x.tbl_MonthlyPlan.tbl_User2.tbl_PersonAndSite.Select(z => z.tbl_Person.PersonName).FirstOrDefault(),
        //                ApprovedByName = x.tbl_MonthlyPlan.tbl_User3.tbl_PersonAndSite.Select(z => z.tbl_Person.PersonName).FirstOrDefault(),
        //                a = x.a,
        //                b = x.b,
        //                c = x.c,
        //                d = x.d,
        //                e = x.e,
        //                f = x.f,
        //                PlanFromDate = x.PlanFromDate,
        //                PlanToDate = x.PlanToDate,
        //                ActualFromDate = x.ActualFromDate,
        //                ActualToDate = x.ActualToDate,
        //                NameOfWork = x.tbl_NameOfWork.NameofWork,
        //            }).ToList();

        //                //.GroupBy(x => new { x.tbl_MonthlyPlan.FortheMonth,x.tbl_MonthlyPlan.Date,x.tbl_MonthlyPlan.tbl_Site.SiteName,x.tbl_MonthlyPlan.tbl_Site.SiteCode,x.a,x.b,x.c,x.d,x.e,x.f,x.PlanFromDate,x.PlanToDate,x.ActualFromDate,x.ActualToDate,x.tbl_NameOfWork.NameofWork })
        //                //.Select(x => new MonthlyPlanSummaryVO
        //            //{
        //            //    FortheMonth = x.Key.FortheMonth,
        //            //    Date = x.Key.Date,
        //            //    SiteName = x.Key.SiteName,
        //            //    SiteCode = x.Key.SiteCode,
        //            //    PreparedByName = context.tbl_PersonAndSite.Where(y=>y.tbl_Person.PersonID == x.p)
        //            //    //CheckedByName = x.tbl_MonthlyPlan.tbl_User2.LoginName,
        //            //     CheckedByName = x.Select(y=>y.tbl_MonthlyPlan.tbl_User2.tbl_PersonAndSite.Select(z=>z.tbl_Person.PersonName).FirstOrDefault()).FirstOrDefault(),
        //            //    //ApprovedByName = x.tbl_MonthlyPlan.tbl_User3.LoginName,
        //            //    a = x.Key.a,
        //            //    b = x.Key.b,
        //            //    c = x.Key.c,
        //            //    d = x.Key.d,
        //            //    e = x.Key.e,
        //            //    f = x.Key.f,
        //            //    PlanFromDate = x.Key.PlanFromDate,
        //            //    PlanToDate = x.Key.PlanToDate,
        //            //    ActualFromDate = x.Key.ActualFromDate,
        //            //    ActualToDate = x.Key.ActualToDate,
        //            //    NameOfWork = x.Key.NameofWork,
        //            //}).ToList();


        //            return list;
        //        }
        //        return null;
        //    }
        //}

        #region Monthly Plan Detail

        public static void AddMonthlyPlanDetail(List<MonthlyPlanDetailByStringValueVO> detailPlanList)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (ISOFormatEntities context = new ISOFormatEntities())
                {
                    foreach(var details1 in detailPlanList)
                    {
                        int mopID = int.Parse(details1.MOPID);
                        List<tbl_MonthlyPlanDetail> tempDetail = new List<tbl_MonthlyPlanDetail>();
                        tempDetail = context.tbl_MonthlyPlanDetail.Where(x => x.MOPID == mopID).ToList();
                        if (tempDetail != null && tempDetail.Count > 0)
                        {
                            foreach (tbl_MonthlyPlanDetail td in tempDetail)
                            {
                                List<tbl_PlanDate> tempPlanDate = new List<tbl_PlanDate>();
                                tempPlanDate = context.tbl_PlanDate.Where(x => x.MPDID == td.ID).ToList();
                                if (tempPlanDate != null || tempPlanDate.Count > 0)
                                {
                                    foreach (tbl_PlanDate tPD in tempPlanDate)
                                    {
                                        context.tbl_PlanDate.Attach(tPD);
                                        context.Entry(tPD).State = System.Data.EntityState.Deleted;
                                    }
                                    context.SaveChanges();
                                }
                                context.tbl_MonthlyPlanDetail.Attach(td);
                                context.Entry(td).State = System.Data.EntityState.Deleted;
                            }
                            context.SaveChanges();
                        }
                    }
                    foreach (var detail in detailPlanList)
                    {
                        tbl_MonthlyPlanDetail temp = detail.ToMonthlyPlanDetailTbl1();
                        context.tbl_MonthlyPlanDetail.Add(temp);

                        context.SaveChanges();

                        List<PlanDateByStringValueVO> detailPlanDateList = new List<PlanDateByStringValueVO>();
                        List<ActualDateByStringValueVO> detailActualDateList = new List<ActualDateByStringValueVO>();
                        foreach (var item in detail.PlanDateByStringValue)
                        {
                            PlanDateByStringValueVO detailPlanDate = new PlanDateByStringValueVO();
                            detailPlanDate.Date = item;
                            detailPlanDate.MPDID = temp.ID.ToString();
                            detailPlanDateList.Add(detailPlanDate);
                        }

                        foreach (var i in detailPlanDateList)
                        {
                            tbl_PlanDate temps = i.ToPlanDateTbl1();
                            context.tbl_PlanDate.Add(temps);
                        }
                        context.SaveChanges();                        
                    }
                    scope.Complete();
                }

            }
            
        }
        public static void UpdateMonthlyPlanDetail(List<MonthlyPlanDetailByStringValueVO> planDetail)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (ISOFormatEntities context = new ISOFormatEntities())
                {
                    foreach(var pd in planDetail)
                    {
                        int mopID = int.Parse(pd.MOPID);
                        int nameOfWorkID = int.Parse(pd.NameOfWorkID);
                        tbl_MonthlyPlanDetail temp = context.tbl_MonthlyPlanDetail.Where(x => x.MOPID == mopID && x.NameOfWorkID == nameOfWorkID).FirstOrDefault();
                        temp.c = Convert.ToDecimal(pd.c);
                        temp.d = Convert.ToDecimal(pd.d);
                        temp.f = Convert.ToDecimal(pd.f);
                        context.tbl_MonthlyPlanDetail.Attach(temp);
                        context.Entry(temp).State = System.Data.EntityState.Modified;
                        context.SaveChanges();

                        List<ActualDateByStringValueVO> detailActualDateList = new List<ActualDateByStringValueVO>();

                        List<tbl_ActualDate> test = new List<tbl_ActualDate>();
                        test = context.tbl_ActualDate.Where(x => x.MPDID == temp.ID).ToList();
                        if (test != null || test.Count > 0)
                        {
                            foreach (tbl_ActualDate item in test)
                            {
                                context.tbl_ActualDate.Attach(item);
                                context.Entry(item).State = System.Data.EntityState.Deleted;
                            }
                            context.SaveChanges();
                        }

                        foreach (var item in pd.ActualDateByStringValue)
                        {
                            ActualDateByStringValueVO detailActualDate = new ActualDateByStringValueVO();
                            detailActualDate.Date = item;
                            detailActualDate.MPDID = temp.ID.ToString();
                            detailActualDateList.Add(detailActualDate);
                        }

                        foreach (var i in detailActualDateList)
                        {
                            tbl_ActualDate temps = i.ToActualDateTbl1();
                            context.tbl_ActualDate.Add(temps);
                        }
                        context.SaveChanges();
  
                    }
                    scope.Complete();

                }
                
            }
            
        }
        public static void AddMonthlyPlanDetail(int mopID)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                tbl_MonthlyPlan temp = context.tbl_MonthlyPlan.Where(x => x.MOPID == mopID).FirstOrDefault();
                temp.CompletePrepare = true;
                context.tbl_MonthlyPlan.Attach(temp);
                context.Entry(temp).State = System.Data.EntityState.Modified;
                context.SaveChanges();

                //context.tbl_MonthlyPlan.Where(x => x.SiteID == siteID && EntityFunctions.TruncateTime(x.FortheMonth) == month.Date).ToList().ForEach(x => x.DeleteStatus = true);
                //context.SaveChanges();
            }
        }
        //public static void AddMonthlyPlanDetailAMMH(List<MonthlyPlanDetailByStringValueVO> detailPlanList)
        //{
        //    using (ISOFormatEntities context = new ISOFormatEntities())
        //    {
        //        foreach (var detail in detailPlanList)
        //        {
        //            tbl_MonthlyPlanDetail temp = detail.ToMonthlyPlanDetailTbl1();
        //            context.tbl_MonthlyPlanDetail.Add(temp);

        //            context.SaveChanges();

        //            List<PlanDateByStringValueVO> detailPlanDateList = new List<PlanDateByStringValueVO>();
        //            PlanDateByStringValueVO detailPlanDate = new PlanDateByStringValueVO();
        //            foreach (var item in detail.PlanDateByStringValue)
        //            {
        //                detailPlanDate.Date = item;
        //                detailPlanDate.MPDID = temp.ID.ToString();
        //                detailPlanDateList.Add(detailPlanDate);
        //            }

        //            foreach (var i in detailPlanDateList)
        //            {
        //                tbl_PlanDate temps = i.ToPlanDateTbl1();
        //                context.tbl_PlanDate.Add(temps);
        //            }
        //            context.SaveChanges();

        //        }

        //    }
        //}

        public static void AddMonthlyPlanDetailByPlanDate(List<PlanDateByStringValueVO> detailPlanDateList)  
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                foreach (var detail in detailPlanDateList)
                {
                    tbl_PlanDate temp = detail.ToPlanDateTbl1();
                    context.tbl_PlanDate.Add(temp);
                }
                context.SaveChanges();
            }
        }

        public static void AddMonthlyPlanDetailByActualDate(List<ActualDateByStringValueVO> detailActualDateList)   
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                foreach (var detail in detailActualDateList)
                {
                    tbl_ActualDate temp = detail.ToActualDateTbl1();
                    context.tbl_ActualDate.Add(temp);
                }
                context.SaveChanges();
            }
        }
        public static List<MonthlyPlanDetailVO> GetAllMonthlyPlanDetailsByMOPIDAndNameOfWorkID(int mopID, int nameOfWorkID)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                context.Configuration.ProxyCreationEnabled = true;
                var temp = context.tbl_MonthlyPlanDetail.Where(x => x.MOPID == mopID && x.NameOfWorkID == nameOfWorkID).ToList().ToMonthlyPlanDetailVOList();
                return temp;
            }
        }
        public static MonthlyPlanDetailVO GetMonthlyPlanDetailsIDByMOPIDAndNameOfWorkID(int mopID, int nameOfWorkID)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                context.Configuration.ProxyCreationEnabled = true;
                var temp = context.tbl_MonthlyPlanDetail.Where(x => x.MOPID == mopID && x.NameOfWorkID == nameOfWorkID).FirstOrDefault().ToMonthlyPlanDetailVO();
                return temp;
            }
        }
        #endregion

        #region Translate Monthly Plan

        public static MonthlyPlanVO ToMonthlyPlanVO(this tbl_MonthlyPlan that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new MonthlyPlanVO()
                {
                    MOPID = that.MOPID,
                    SiteID = that.SiteID,
                    ApproveBy = that.ApproveBy,
                    CheckedBy = that.CheckedBy,
                    PreparedBy = that.PreparedBy,
                    CompleteApproved = that.CompleteApproved,
                    Date = that.Date,
                    CompleteChecked = that.CompleteChecked,
                    CompletePrepare = that.CompletePrepare,
                    FortheMonth = that.FortheMonth,
                    DeleteStatus = that.DeleteStatus,
                    ModifiedBy = that.ModifiedBy,
                    ModifiedDate = that.ModifiedDate,

                    SiteCode = that.tbl_Site.SiteCode,
                    SiteName = that.tbl_Site.SiteName,
                    PreparedByName  = that.tbl_Person.PersonName,
                    CheckedByName = that.tbl_Person1.PersonName,
                    ApprovedByName = that.tbl_Person2.PersonName,
                    MonthlyPlanDetailList = that.tbl_MonthlyPlanDetail.ToList().ToMonthlyPlanDetailVOList(),
                };
            }
        }

        public static List<MonthlyPlanVO> ToMonthlyPlanVOList(this List<tbl_MonthlyPlan> list)
        {
            if (list == null || list.Count() == 0)
            {
                return null;
            }
            else
            {
                List<MonthlyPlanVO> result = new List<MonthlyPlanVO>();

                foreach (tbl_MonthlyPlan MonthlyPlan in list)
                {
                    result.Add(MonthlyPlan.ToMonthlyPlanVO());
                }
                return result;
            }
        }

        public static tbl_MonthlyPlan ToMonthlyPlanTbl(this MonthlyPlanVO that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new tbl_MonthlyPlan()
                {
                    MOPID = that.MOPID,
                    SiteID = that.SiteID,
                    ApproveBy = that.ApproveBy,
                    CheckedBy = that.CheckedBy,
                    PreparedBy = that.PreparedBy,
                    CompleteApproved = that.CompleteApproved,
                    Date =that.Date,
                    CompleteChecked = that.CompleteChecked,
                    CompletePrepare = that.CompletePrepare,
                    FortheMonth = that.FortheMonth,
                    DeleteStatus = that.DeleteStatus,
                    ModifiedBy = that.ModifiedBy,
                    ModifiedDate = that.ModifiedDate,
                };
            }
        }

        public static tbl_MonthlyPlan ToAddMonthlyPlanTbl(this AddMonthlyPlanVO that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new tbl_MonthlyPlan()
                {
                    MOPID = that.MOPID,
                    SiteID = that.SiteID,
                    FortheMonth = DateTime.Parse(that.FortheMonth),
                    Date = DateTime.Parse(that.Date),
                    PreparedBy = that.PreparedBy,
                    CompletePrepare = that.CompletePrepare,
                    CheckedBy = that.CheckedBy,
                    CompleteChecked = that.CompleteChecked,
                    ApproveBy = that.ApproveBy,
                    CompleteApproved = that.CompleteApproved,
                    DeleteStatus = that.DeleteStatus,
                    ModifiedBy = that.ModifiedBy,
                    ModifiedDate = DateTime.Parse(that.ModifiedDate),
                };
            }
        }

        #endregion

        #region Translate Monthly Plan Detail

        public static MonthlyPlanDetailVO ToMonthlyPlanDetailVO(this tbl_MonthlyPlanDetail that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new MonthlyPlanDetailVO()
                {
                   ID = that.ID,
                   MOPID = that.MOPID,
                   a = that.a,
                   b = that.b,
                   c = that.c,
                   d = that.d,
                   e = that.e,
                   f = that.f,
                   NameOfWorkID = that.NameOfWorkID ,
                   ModifiedBy = that.ModifiedBy,
                   ModifiedDate = that.ModifiedDate,
                   NameOfWork = that.tbl_NameOfWork.NameofWork,      
                   PlanDateList = that.tbl_PlanDate.ToList().ToPlanDateVOList(),
                   ActualDateList = that.tbl_ActualDate.ToList().ToActualDateVOList(),
                };
            }
        }

        public static List<MonthlyPlanDetailVO> ToMonthlyPlanDetailVOList(this List<tbl_MonthlyPlanDetail> list)
        {
            if (list == null || list.Count() == 0)
            {
                return null;
            }
            else
            {
                List<MonthlyPlanDetailVO> result = new List<MonthlyPlanDetailVO>();

                foreach (tbl_MonthlyPlanDetail MonthlyPlanDetail in list)
                {
                    result.Add(MonthlyPlanDetail.ToMonthlyPlanDetailVO());
                }
                return result;
            }
        }

        public static tbl_MonthlyPlanDetail ToMonthlyPlanDetailTbl(this MonthlyPlanDetailVO that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new tbl_MonthlyPlanDetail()
                {
                    ID = that.ID,
                    MOPID = that.MOPID,
                    a = that.a,
                    b = that.b,
                    c = that.c,
                    d = that.d,
                    e = that.e,
                    f = that.f,
                    NameOfWorkID = that.NameOfWorkID,
                    PreviousOverallWorkdone = that.PreviousOverallWorkdone,
                    OverallWorkdone = that.OverallWorkdone,
                    ModifiedBy = that.ModifiedBy,
                    ModifiedDate = that.ModifiedDate,
                };
            }
        }

        public static tbl_MonthlyPlanDetail ToMonthlyPlanDetailTbl1(this MonthlyPlanDetailByStringValueVO that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                var i = DateTime.Parse(that.ModifiedDate);
                tbl_MonthlyPlanDetail m = new tbl_MonthlyPlanDetail();
                m.MOPID = Convert.ToInt32(that.MOPID);
                m.a = Convert.ToDecimal(that.a);
                m.b = Convert.ToDecimal(that.b);
                //m.c = (!string.IsNullOrEmpty(that.c)) ? Convert.ToDecimal(that.c) : (decimal?)null;
                m.c = (that.c != "" && that.c != "null") ? Convert.ToDecimal(that.c) : (decimal?)null;
                m.d = (that.d != "" && that.d != "null") ? Convert.ToDecimal(that.d):(decimal?)null;
                m.e = (that.e != "" && that.e != "null") ? Convert.ToDecimal(that.e) : (decimal?)null;
                m.f = (that.f != "" && that.f != "null") ? Convert.ToDecimal(that.f) : (decimal?)null;
                m.NameOfWorkID = Convert.ToInt32(that.NameOfWorkID);
                m.PreviousOverallWorkdone = (that.PreviousOverallWorkdone != "" && that.PreviousOverallWorkdone != "null") ? Convert.ToDecimal(that.PreviousOverallWorkdone) : (decimal?)null;
                m.OverallWorkdone = (that.OverallWorkdone != "" && that.OverallWorkdone != "null") ? Convert.ToDecimal(that.OverallWorkdone) : (decimal?)null;
                m.ModifiedBy = Convert.ToInt32(that.ModifiedBy);
                m.ModifiedDate = DateTime.Parse(that.ModifiedDate);
                return m;
            }
        }

        #endregion

        #region Translate Monthly Plan Date

        public static PlanDateVO ToPlanDateVO(this tbl_PlanDate that) 
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new PlanDateVO()
                {
                    ID = that.ID,
                    MPDID = that.MPDID,
                    Date = that.Date,
                };
            }
        }

        public static List<PlanDateVO> ToPlanDateVOList(this List<tbl_PlanDate> list)
        {
            if (list == null || list.Count() == 0)
            {
                return null;
            }
            else
            {
                List<PlanDateVO> result = new List<PlanDateVO>();

                foreach (tbl_PlanDate PlanDate in list)
                {
                    result.Add(PlanDate.ToPlanDateVO());
                }
                return result;
            }
        }

        public static tbl_PlanDate ToPlanDateTbl(this PlanDateVO that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new tbl_PlanDate()
                {
                    ID = that.ID,
                    MPDID = that.MPDID,
                    Date = that.Date,
                };
            }
        }

        public static tbl_PlanDate ToPlanDateTbl1(this PlanDateByStringValueVO that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new tbl_PlanDate()
                {
                    ID = Convert.ToInt32(that.ID),
                    MPDID = Convert.ToInt32(that.MPDID),
                    Date = Convert.ToDateTime(that.Date),
                };
            }
        }

        #endregion

        #region Translate Monthly Actual Date

        public static ActualDateVO ToActualDateVO(this tbl_ActualDate that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new ActualDateVO()
                {
                    ID = that.ID,
                    MPDID = that.MPDID,
                    Date = that.Date,
                };
            }
        }

        public static List<ActualDateVO> ToActualDateVOList(this List<tbl_ActualDate> list)
        {
            if (list == null || list.Count() == 0)
            {
                return null;
            }
            else
            {
                List<ActualDateVO> result = new List<ActualDateVO>();

                foreach (tbl_ActualDate ActualDate in list)
                {
                    result.Add(ActualDate.ToActualDateVO());
                }
                return result;
            }
        }

        public static tbl_ActualDate ToActualDateTbl(this ActualDateVO that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new tbl_ActualDate()
                {
                    ID = that.ID,
                    MPDID = that.MPDID,
                    Date = that.Date,
                };
            }
        }

        public static tbl_ActualDate ToActualDateTbl1(this ActualDateByStringValueVO that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new tbl_ActualDate()
                {
                    ID = Convert.ToInt32(that.ID),
                    MPDID = Convert.ToInt32(that.MPDID),
                    Date = Convert.ToDateTime(that.Date),
                };
            }
        }

        #endregion

        #region Translate Date Object

        public static MPlanDateVO ToMonthlyPlanDateVO(this List<tbl_PlanDate> list)  
        {
            if (list == null || list.Count() == 0)
            {
                return null;
            }
            else
            {
                MPlanDateVO result = new MPlanDateVO();  
                result.P1 = list.Any(x=>x.Date.Day == 1) ? true : false;
                result.P2 = list.Any(x=>x.Date.Day == 2) ? true : false;
                result.P3 = list.Any(x=>x.Date.Day == 3) ? true : false;
                result.P4 = list.Any(x=>x.Date.Day == 4) ? true : false;
                result.P5 = list.Any(x=>x.Date.Day == 5) ? true : false;
                result.P6 = list.Any(x=>x.Date.Day == 6) ? true : false;
                result.P7 = list.Any(x=>x.Date.Day == 7) ? true : false;
                result.P8 = list.Any(x=>x.Date.Day == 8) ? true : false;
                result.P9 = list.Any(x=>x.Date.Day == 9) ? true : false;
                result.P10 = list.Any(x=>x.Date.Day == 10) ? true : false;
                result.P11 = list.Any(x=>x.Date.Day == 11) ? true : false;
                result.P12 = list.Any(x=>x.Date.Day == 12) ? true : false;
                result.P13 = list.Any(x=>x.Date.Day == 13) ? true : false;
                result.P14 = list.Any(x=>x.Date.Day == 14) ? true : false;
                result.P15 = list.Any(x=>x.Date.Day == 15) ? true : false;
                result.P16 = list.Any(x=>x.Date.Day == 16) ? true : false;
                result.P17 = list.Any(x=>x.Date.Day == 17) ? true : false;
                result.P18 = list.Any(x=>x.Date.Day == 18) ? true : false;
                result.P19 = list.Any(x=>x.Date.Day == 19) ? true : false;
                result.P20 = list.Any(x=>x.Date.Day == 20) ? true : false;
                result.P21 = list.Any(x=>x.Date.Day == 21) ? true : false;
                result.P22 = list.Any(x=>x.Date.Day == 22) ? true : false;
                result.P23 = list.Any(x=>x.Date.Day == 23) ? true : false;
                result.P24 = list.Any(x=>x.Date.Day == 24) ? true : false;
                result.P25 = list.Any(x=>x.Date.Day == 25) ? true : false;
                result.P26 = list.Any(x=>x.Date.Day == 26) ? true : false;
                result.P27 = list.Any(x=>x.Date.Day == 27) ? true : false;
                result.P28 = list.Any(x=>x.Date.Day == 28) ? true : false;
                result.P29 = list.Any(x=>x.Date.Day == 29) ? true : false;
                result.P30 = list.Any(x=>x.Date.Day == 30) ? true : false;
                result.P31 = list.Any(x=>x.Date.Day == 31) ? true : false;
                return result;
            }
        }

        public static MActualDateVO ToMonthlyActualDateVO(this List<tbl_ActualDate> list)
        {
            if (list == null || list.Count() == 0)
            {
                return null;
            }
            else
            {
                MActualDateVO result = new MActualDateVO();
                result.A1 = list.Any(x => x.Date.Day == 1) ? true : false;
                result.A2 = list.Any(x => x.Date.Day == 2) ? true : false;
                result.A3 = list.Any(x => x.Date.Day == 3) ? true : false;
                result.A4 = list.Any(x => x.Date.Day == 4) ? true : false;
                result.A5 = list.Any(x => x.Date.Day == 5) ? true : false;
                result.A6 = list.Any(x => x.Date.Day == 6) ? true : false;
                result.A7 = list.Any(x => x.Date.Day == 7) ? true : false;
                result.A8 = list.Any(x => x.Date.Day == 8) ? true : false;
                result.A9 = list.Any(x => x.Date.Day == 9) ? true : false;
                result.A10 = list.Any(x => x.Date.Day == 10) ? true : false;
                result.A11 = list.Any(x => x.Date.Day == 11) ? true : false;
                result.A12 = list.Any(x => x.Date.Day == 12) ? true : false;
                result.A13 = list.Any(x => x.Date.Day == 13) ? true : false;
                result.A14 = list.Any(x => x.Date.Day == 14) ? true : false;
                result.A15 = list.Any(x => x.Date.Day == 15) ? true : false;
                result.A16 = list.Any(x => x.Date.Day == 16) ? true : false;
                result.A17 = list.Any(x => x.Date.Day == 17) ? true : false;
                result.A18 = list.Any(x => x.Date.Day == 18) ? true : false;
                result.A19 = list.Any(x => x.Date.Day == 19) ? true : false;
                result.A20 = list.Any(x => x.Date.Day == 20) ? true : false;
                result.A21 = list.Any(x => x.Date.Day == 21) ? true : false;
                result.A22 = list.Any(x => x.Date.Day == 22) ? true : false;
                result.A23 = list.Any(x => x.Date.Day == 23) ? true : false;
                result.A24 = list.Any(x => x.Date.Day == 24) ? true : false;
                result.A25 = list.Any(x => x.Date.Day == 25) ? true : false;
                result.A26 = list.Any(x => x.Date.Day == 26) ? true : false;
                result.A27 = list.Any(x => x.Date.Day == 27) ? true : false;
                result.A28 = list.Any(x => x.Date.Day == 28) ? true : false;
                result.A29 = list.Any(x => x.Date.Day == 29) ? true : false;
                result.A30 = list.Any(x => x.Date.Day == 30) ? true : false;
                result.A31 = list.Any(x => x.Date.Day == 31) ? true : false;
                return result;
            }
        }

        #endregion
    }
}
