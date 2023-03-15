using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISODAL;
using ISOServiceVO;

namespace ISOBLL
{
    public class PersonAndSiteBLL
    {
        public List<PersonAndSiteVO> GetAllPersonAndSite()
        {
            try
            {
                return PersonAndSiteDAL.GetAllPersonAndSite();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PersonAndSiteVO> GetAllPersonAndSiteBySiteIDAndPersonID(int siteID, int personID)
        {
            try
            {
                return PersonAndSiteDAL.GetAllPersonAndSiteBySiteIDAndPersonID(siteID, personID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PersonAndSiteVO> GetAllPersonAndSiteByPersonID(int personID)
        {
            try
            {
                return PersonAndSiteDAL.GetAllPersonAndSiteByPersonID(personID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PersonAndSiteVO GetAllPersonAndSiteBySiteIDAndResponsibilityTypeID(int siteID, int responsibilityTypeID)
        {
            try
            {
                return PersonAndSiteDAL.GetAllPersonAndSiteBySiteIDAndResponsibilityTypeID(siteID, responsibilityTypeID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PersonAndSiteVO> GetFinishedPersonAndSite(bool status)
        {
            try
            {
                return PersonAndSiteDAL.GetFinishedPersonAndSite(status);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddPersonAndSite(PersonAndSiteVO PersonAndSiteVO)
        {
            try
            {
                Validation(PersonAndSiteVO);
                PersonAndSiteDAL.AddPersonAndSite(PersonAndSiteVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditPersonAndSite(PersonAndSiteVO PersonAndSiteVO)
        {
            try
            {
                Validation(PersonAndSiteVO);
                PersonAndSiteDAL.EditPersonAndSite(PersonAndSiteVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Validation(PersonAndSiteVO PersonAndSiteVO)
        {
            if (PersonAndSiteVO == null)
            {
                throw new Exception("PersonAndSite Object is null.");
            }
            if (Convert.ToInt32(PersonAndSiteVO.SiteID) == 0)
            {
                throw new Exception("Invalid Stie Name in Person Object.");
            }
            if (Convert.ToInt32(PersonAndSiteVO.PersonID) == 0)
            {
                throw new Exception("Invalid Person Name in Person Object.");
            }
            if (Convert.ToInt32(PersonAndSiteVO.ResponsibilityTypeID) == 0)
            {
                throw new Exception("Invalid Responsibility in Person Object.");
            }
        }
    }
}
