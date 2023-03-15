using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISOServiceVO;

namespace ISODAL
{
    public static class SiteDAL
    {
        public static List<SiteVO> GetAllSite()
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                return context.tbl_Site.ToList().ToSiteVOList();
            }
        }

        public static List<SiteVO> GetActiveSite(bool status)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                return context.tbl_Site.Where(x => x.Active == status).ToList().ToSiteVOList();
            }
        }

        public static List<SiteVO> GetIsCompleteSite(bool isCompleteStatus , bool activeStatus)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                return context.tbl_Site.Where(x => x.IsComplete == isCompleteStatus && x.Active == activeStatus).ToList().ToSiteVOList();
            }
        }

        public static void AddSite(SiteVO SiteVO)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                context.tbl_Site.Add(SiteVO.ToSiteTbl());
                context.SaveChanges();
            }
        }

        public static void EditSite(SiteVO SiteVO)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                tbl_Site temp = SiteVO.ToSiteTbl();
                context.tbl_Site.Attach(temp);
                context.Entry(temp).State = System.Data.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static string GetNewSiteCode() 
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                int count = context.tbl_Site.Where(x => x.ModifiedDate.Year == DateTime.Now.Year).Count() + 11;
                return string.Format("ASC-{0}-{1}", DateTime.Now.Year.ToString().Substring(2, 2), count.ToString("D3"));
            }
        }

        //public static List<SiteVO> GetAllProjectByUserID(int id)   
        //{
        //    using (ISOFormatEntities context = new ISOFormatEntities())
        //    {
        //        var result = context.tbl_OperationOrder.Where(x => x.SiteEngineerID == id || x.SeniorInchargeID == id).Select(x => new SiteVO() 
        //                            {
        //                                SiteID = x.SiteID,
        //                                SiteCode = x.tbl_Site.SiteCode,
        //                                SiteName = x.tbl_Site.SiteName,
        //                                CustomerName = x.tbl_Site.CustomerName,
        //                                IsComplete = x.tbl_Site.IsComplete,
        //                                Active = x.tbl_Site.Active,
        //                                ModifiedBy = x.ModifiedBy,
        //                                ModifiedDate = x.ModifiedDate,
        //                            }).GroupBy(x => x).Select(i => i.Key).ToList();
        //        return result.GroupBy(x => x).Select(i => i.Key).ToList();
        //    }
        //}

        public static List<SiteVO> GetAllProjectByUserID(int id)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                var result = context.tbl_PersonAndSite.Where(x => x.PersonID == context.tbl_User.Where(z=>z.ID==id).FirstOrDefault().PersonID).Select(x => new SiteVO()
                {
                    SiteID = x.SiteID,
                    SiteCode = x.tbl_Site.SiteCode,
                    SiteName = x.tbl_Site.SiteName,
                    CustomerName = x.tbl_Site.CustomerName,
                    IsComplete = x.tbl_Site.IsComplete,
                    Active = x.tbl_Site.Active,
                    ModifiedBy = x.ModifiedBy,
                    ModifiedDate = DateTime.Now,
                }).GroupBy(x => x).Select(i => i.Key).ToList();
                return result.GroupBy(x => x).Select(i => i.Key).ToList();
            }
        }

        #region Translate

        public static SiteVO ToSiteVO(this tbl_Site that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new SiteVO()
                {
                    SiteID = that.SiteID,
                    SiteCode = that.SiteCode,
                    SiteName = that.SiteName,
                    CustomerName = that.CustomerName,
                    IsComplete = that.IsComplete,
                    Active = that.Active,
                    ModifiedBy = that.ModifiedBy,
                    ModifiedDate = that.ModifiedDate,

                    PersonAndSitelist = that.tbl_PersonAndSite.Select(a => new PersonAndSiteVO
                    {
                        ID = a.ID,
                        PersonID = a.PersonID,
                        SiteID = a.SiteID,
                        ResponsibilityTypeID = a.ResponsibilityTypeID,
                        Finished = a.Finished,
                        ModifiedBy = a.ModifiedBy,
                        ModifiedDate = a.ModifiedDate,
                    }).ToList(),

                };
            }
        }

        public static List<SiteVO> ToSiteVOList(this List<tbl_Site> list)
        {
            if (list == null || list.Count() == 0)
            {
                return null;
            }
            else
            {
                List<SiteVO> result = new List<SiteVO>();

                foreach (tbl_Site Site in list)
                {
                    result.Add(Site.ToSiteVO());
                }
                return result;
            }
        }

        public static tbl_Site ToSiteTbl(this SiteVO that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new tbl_Site()
                {
                    SiteID = that.SiteID,
                    SiteCode = that.SiteCode,
                    SiteName = that.SiteName,
                    CustomerName = that.CustomerName,
                    IsComplete = that.IsComplete,
                    Active = that.Active,
                    ModifiedBy = that.ModifiedBy,
                    ModifiedDate = that.ModifiedDate,
                };
            }
        }

        #endregion
    }
}
