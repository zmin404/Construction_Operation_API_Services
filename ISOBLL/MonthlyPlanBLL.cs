using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISODAL;
using ISOServiceVO;

namespace ISOBLL
{
    public class MonthlyPlanBLL
    {
        public List<MonthlyPlanVO> GetAllMonthlyPlan()
        {
            try
            {
                return MonthlyPlanDAL.GetAllMonthlyPlan();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddMonthlyPlan(AddMonthlyPlanVO addMonthlyPlanVO)
        {
            try
            {
                MonthlyPlanDAL.AddMonthlyPlan(addMonthlyPlanVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditMonthlyPlan(MonthlyPlanVO MonthlyPlanVO)
        {
            try
            {
                MonthlyPlanDAL.EditMonthlyPlan(MonthlyPlanVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteMonthlyPlan(MonthlyPlanVO MonthlyPlanVO)
        {
            try
            {
                MonthlyPlanDAL.DeleteMonthlyPlan(MonthlyPlanVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MonthlyPlanSummaryVO> GetMonthlyPlanByFilter(DateTime date, int siteID)
        {
            try
            {
                return MonthlyPlanDAL.GetMonthlyPlanByFilter(date, siteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MonthlyPlanVO> GetAllMonthlyPlanBySiteIDAndPersonRole(int siteID, string personRole)
        {
            try
            {
                return MonthlyPlanDAL.GetAllMonthlyPlanBySiteIDAndPersonRole(siteID, personRole);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<MonthlyPlanVO> GetAllMonthlyPlanByPersonIDAndPersonRole(int personID, string personRole)
        {
            try
            {
                return MonthlyPlanDAL.GetAllMonthlyPlanByPersonIDAndPersonRole(personID,personRole);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MonthlyPlanDetailVO> GetAllMonthlyPlanDetailsBySiteIDAndForthemonth(int siteID, DateTime month)
        {
            try
            {
                return MonthlyPlanDAL.GetAllMonthlyPlanDetailsBySiteIDAndForthemonth(siteID, month);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MonthlyPlanDetailVO> GetAllMonthlyPlanDetailsByMOPIDAndNameOfWorkID(int mopID, int nameOfWorkID)
        {
            try
            {
                return MonthlyPlanDAL.GetAllMonthlyPlanDetailsByMOPIDAndNameOfWorkID(mopID, nameOfWorkID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MonthlyPlanDetailVO GetMonthlyPlanDetailsIDByMOPIDAndNameOfWorkID(int mopID, int nameOfWorkID)
        {
            try
            {
                return MonthlyPlanDAL.GetMonthlyPlanDetailsIDByMOPIDAndNameOfWorkID(mopID,nameOfWorkID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteMonthlyPlanBySiteIDAndForTheMonth(int siteID, string forMonth)
        {
            try
            {
                MonthlyPlanDAL.DeleteMonthlyPlanBySiteIDAndForTheMonth(siteID, forMonth);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateMonthlyPlanStatusByMOPID(int mopID)
        {
            try
            {
                MonthlyPlanDAL.UpdateMonthlyPlanStatusByMOPID(mopID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateMonthlyPlanStatusByMOPIDAndPersonRoleAndStatus(int mopID, string personRole, string status)
        {
            try
            {
                MonthlyPlanDAL.UpdateMonthlyPlanStatusByMOPIDAndPersonRoleAndStatus(mopID, personRole, status);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<MonthlyPlanVO> GetAllMonthlyPlanBySiteIDAndForTheMonth(int siteID, string forMonth)
        {
            try
            {
                return MonthlyPlanDAL.GetAllMonthlyPlanBySiteIDAndForTheMonth(siteID, forMonth);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MonthlyPlanVO GetMonthlyPlanBySiteIDAndForTheMonth(int siteID, string forMonth)
        {
            try
            {
                return MonthlyPlanDAL.GetMonthlyPlanBySiteIDAndForTheMonth(siteID, forMonth);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddMonthlyPlanDetail(List<MonthlyPlanDetailByStringValueVO> detailPlanList)
        {
            try
            {
                MonthlyPlanDAL.AddMonthlyPlanDetail(detailPlanList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateMonthlyPlanDetail(List<MonthlyPlanDetailByStringValueVO> planDetail)
        {
            try
            {
                MonthlyPlanDAL.UpdateMonthlyPlanDetail(planDetail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddMonthlyPlanDetailByPlanDate(List<PlanDateByStringValueVO> detailPlanDateList)
        {
            try
            {
                MonthlyPlanDAL.AddMonthlyPlanDetailByPlanDate(detailPlanDateList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddMonthlyPlanDetailByActualDate(List<ActualDateByStringValueVO> detailActualDateList)
        {
            try
            {
                MonthlyPlanDAL.AddMonthlyPlanDetailByActualDate(detailActualDateList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
