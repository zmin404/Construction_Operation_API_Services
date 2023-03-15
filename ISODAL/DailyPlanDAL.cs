using ISOServiceVO;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISODAL
{
    public class DailyPlanDAL
    {
        public static List<DailyPlanDetailVO> GetDailyPlanByFilter(DateTime date, int siteID)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                IQueryable<tbl_DailyPlanDetail> query = context.tbl_DailyPlanDetail.Where(x => EntityFunctions.TruncateTime(x.tbl_DailyPlan.Date) == date.Date && x.DailyType == "A" && x.tbl_DailyPlan.DeleteStatus == false);
                if (siteID != 0)
                {
                    query = query.Where(x => x.tbl_DailyPlan.SiteID == siteID);
                }
                if (query != null)
                {
                    var temp = from s in query select s.ID;
                    List<int> IDList = temp.ToList();
                    var list = context.tbl_DailyPlanDetail.Where(x => IDList.Contains(x.ID)).Select(x => new DailyPlanDetailVO
                    {
                        NameOfWork = x.tbl_NameOfWork.NameofWork,
                        Location = x.Location,
                        SkillLabour = x.SkillLabour,
                        MaleLabour = x.MaleLabour,
                        FemaleLabour = x.FemaleLabour,
                        AssignNo = x.AssignNo,
                        AssignLength = x.AssignLength,
                        AssignBase = x.AssignBase,
                        AssignHeight = x.AssignHeight,
                        WDNo = x.WDNo,
                        WDLength = x.WDLength,
                        WDBase = x.WDBase,
                        WDHeight = x.WDHeight,
                        WDDe = x.WDDe,
                        Remark = x.Remark,
                        //Date = x.tbl_DailyPlan.Date,
                        SiteName = x.tbl_DailyPlan.tbl_Site.SiteName,
                        SiteCode = x.tbl_DailyPlan.tbl_Site.SiteCode,
                        PreparedByName = x.tbl_DailyPlan.tbl_User1.tbl_Person1.PersonName,
                        ReceivedByName = x.tbl_DailyPlan.tbl_User2.tbl_Person1.PersonName,
                        CheckedByName = x.tbl_DailyPlan.tbl_User3.tbl_Person1.PersonName,
                        ApprovedByName = x.tbl_DailyPlan.tbl_User4.tbl_Person1.PersonName,
                        SubContractorName = x.tbl_DailyPlan.tbl_Person.PersonName,
                        Weather = x.tbl_DailyPlan.tbl_Weather.Weather
                    }).ToList();
                    return list;
                }
                return null;
            }
        }
    }
}
