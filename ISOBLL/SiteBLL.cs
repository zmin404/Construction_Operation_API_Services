using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISODAL;
using ISOServiceVO;

namespace ISOBLL
{
    public  class SiteBLL
    {
        public List<SiteVO> GetAllSite()
        {
            try
            {
                return SiteDAL.GetAllSite();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SiteVO> GetActiveSite(bool status)
        {
            try
            {
                return SiteDAL.GetActiveSite(status);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SiteVO> GetIsCompleteSite(bool isCompleteStatus, bool activeStatus)
        {
            try
            {
                return SiteDAL.GetIsCompleteSite(isCompleteStatus, activeStatus);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddSite(SiteVO SiteVO)
        {
            try
            {
                Validation(SiteVO);
                SiteDAL.AddSite(SiteVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditSite(SiteVO SiteVO)
        {
            try
            {
                Validation(SiteVO);
                SiteDAL.EditSite(SiteVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetNewSiteCode() 
        {
            try
            {
                return SiteDAL.GetNewSiteCode();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Validation(SiteVO SiteVO)
        {
            if (SiteVO == null)
            {
                throw new Exception("Site Object is null.");
            }
            if (string.IsNullOrEmpty(SiteVO.SiteCode))
            {
                throw new Exception("Invalid Site Code in Site Object.");
            }
            if (string.IsNullOrEmpty(SiteVO.SiteName))
            {
                throw new Exception("Invalid Site Name in Site Object.");
            }
            if (string.IsNullOrEmpty(SiteVO.CustomerName))
            {
                throw new Exception("Invalid Customer Name in Site Object.");
            }
        }

        public List<SiteVO> GetAllProjectByUserID(int id)   
        {
            try
            {
                return SiteDAL.GetAllProjectByUserID(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
