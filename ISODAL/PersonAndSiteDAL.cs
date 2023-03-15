using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISOServiceVO;

namespace ISODAL
{
    public static class PersonAndSiteDAL
    {
        public static List<PersonAndSiteVO> GetAllPersonAndSite()
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                return context.tbl_PersonAndSite.OrderBy(x => x.tbl_Site.SiteName).ToList().ToPersonAndSiteVOList();
                //return context.tbl_PersonAndSite.ToList().ToPersonAndSiteVOList();
            }
        }
        public static List<PersonAndSiteVO> GetAllPersonAndSiteBySiteIDAndPersonID(int siteID, int personID)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                context.Configuration.ProxyCreationEnabled = true;
                var temp = context.tbl_PersonAndSite.Where(x => x.SiteID == siteID && x.PersonID == personID).ToList().ToPersonAndSiteVOList();
                return temp;
            }
        }
        public static List<PersonAndSiteVO> GetAllPersonAndSiteByPersonID(int personID)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                context.Configuration.ProxyCreationEnabled = true;
                var temp = context.tbl_PersonAndSite.Where(x => x.PersonID == personID).ToList().ToPersonAndSiteVOList();
                return temp;
            }
        }
        public static PersonAndSiteVO GetAllPersonAndSiteBySiteIDAndResponsibilityTypeID(int siteID, int responsibilityTypeID)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                context.Configuration.ProxyCreationEnabled = true;
                var temp = context.tbl_PersonAndSite.Where(x => x.SiteID == siteID && x.ResponsibilityTypeID == responsibilityTypeID).FirstOrDefault().ToPersonAndSiteVO();
                return temp;
            }
        }

        public static List<PersonAndSiteVO> GetFinishedPersonAndSite(bool status)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                return context.tbl_PersonAndSite.Where(x => x.Finished == status).ToList().ToPersonAndSiteVOList();
            }
        }

        public static void AddPersonAndSite(PersonAndSiteVO PersonAndSiteVO)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                context.Configuration.ProxyCreationEnabled = false;
                tbl_PersonAndSite temp = PersonAndSiteVO.ToPersonAndSiteTbl();
                context.tbl_PersonAndSite.Add(temp);
                context.SaveChanges();
            }
        }

        public static void EditPersonAndSite(PersonAndSiteVO PersonAndSiteVO)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                tbl_PersonAndSite temp = PersonAndSiteVO.ToPersonAndSiteTbl();
                context.tbl_PersonAndSite.Attach(temp);
                context.Entry(temp).State = System.Data.EntityState.Modified;
                context.SaveChanges();
            }
        }

        #region Translate

        public static PersonAndSiteVO ToPersonAndSiteVO(this tbl_PersonAndSite that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new PersonAndSiteVO()
                {
                    ID = that.ID,
                    PersonID = that.PersonID,
                    SiteID = that.SiteID,
                    ResponsibilityTypeID = that.ResponsibilityTypeID,
                    Finished = that.Finished,
                    ModifiedBy = that.ModifiedBy,
                    ModifiedDate = that.ModifiedDate,

                    PersonName = (that.tbl_Person.PersonName != null)?that.tbl_Person.PersonName:null,
                    ResponsibilityType = (that.tbl_ResponsibilityType.Type != null)?that.tbl_ResponsibilityType.Type:null,
                    SiteName = (that.tbl_Site.SiteName != null)?that.tbl_Site.SiteName:null,
                };
            }
        }

        public static List<PersonAndSiteVO> ToPersonAndSiteVOList(this List<tbl_PersonAndSite> list)
        {
            if (list == null || list.Count() == 0)
            {
                return null;
            }
            else
            {
                List<PersonAndSiteVO> result = new List<PersonAndSiteVO>();

                foreach (tbl_PersonAndSite PersonAndSite in list)
                {
                    result.Add(PersonAndSite.ToPersonAndSiteVO());
                }
                return result;
            }
        }

        public static tbl_PersonAndSite ToPersonAndSiteTbl(this PersonAndSiteVO that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new tbl_PersonAndSite()
                {
                    ID = that.ID,
                    PersonID = that.PersonID,
                    SiteID = that.SiteID,
                    ResponsibilityTypeID = that.ResponsibilityTypeID,
                    Finished = that.Finished,
                    ModifiedBy = that.ModifiedBy,
                    ModifiedDate = that.ModifiedDate,
                };
            }
        }      

        #endregion
    }
}
