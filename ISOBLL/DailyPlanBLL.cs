using ISODAL;
using ISOServiceVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISOBLL
{
    public class DailyPlanBLL
    {
        public List<DailyPlanDetailVO> GetDailyPlanByFilter(DateTime date, int siteID)
        {
            try
            {
                return DailyPlanDAL.GetDailyPlanByFilter(date,siteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
