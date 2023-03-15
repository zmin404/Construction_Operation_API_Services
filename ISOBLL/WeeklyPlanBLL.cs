using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISODAL;
using ISOServiceVO;

namespace ISOBLL
{
    public class WeeklyPlanBLL
    {
        public List<WeeklyPlanVO> GetAllWeeklyPlan()
        {
            try
            {
                return WeeklyPlanDAL.GetAllWeeklyPlan();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddWeeklyPlan(WeeklyPlanVO WeeklyPlanVO)
        {
            try
            {
                WeeklyPlanDAL.AddWeeklyPlan(WeeklyPlanVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditWeeklyPlan(WeeklyPlanVO WeeklyPlanVO)
        {
            try
            {
                WeeklyPlanDAL.EditWeeklyPlan(WeeklyPlanVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteWeeklyPlan(WeeklyPlanVO WeeklyPlanVO)
        {
            try
            {
                WeeklyPlanDAL.DeleteWeeklyPlan(WeeklyPlanVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<WeeklyPlanDetailVO> GetWeeklyPlanByFilter(DateTime date, int siteID)
        {
            try
            {
                return WeeklyPlanDAL.GetWeeklyPlanByFilter(date, siteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
