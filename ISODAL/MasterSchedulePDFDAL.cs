using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISOServiceVO;

namespace ISODAL
{
    public static class MasterSchedulePDFDAL
    {
        public static List<MasterSchedulePDFVO> GetMasterSchedulePDFListBySite(int siteID)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                return context.tbl_MasterSchedulePDF.Where(x => x.tbl_Site.SiteID == siteID).ToList().ToMasterSchedulePDFVOList();
            }
        }

        #region MasterSchedulePDF

        public static MasterSchedulePDFVO ToMasterSchedulePDFVO(this tbl_MasterSchedulePDF that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new MasterSchedulePDFVO()
                {
                    ID = that.ID,
                    SiteID = that.SiteID,
                    MasterSchedulePDF = that.MasterSchedulePDF,
                };
            }
        }

        public static List<MasterSchedulePDFVO> ToMasterSchedulePDFVOList(this List<tbl_MasterSchedulePDF> list)
        {
            if (list == null || list.Count() == 0)
            {
                return null;
            }
            else
            {
                List<MasterSchedulePDFVO> result = new List<MasterSchedulePDFVO>();

                foreach (tbl_MasterSchedulePDF MSPDF in list)
                {
                    result.Add(MSPDF.ToMasterSchedulePDFVO());
                }
                return result;
            }
        }

        public static tbl_MasterSchedulePDF ToMasterSchedulePDFTbl(this MasterSchedulePDFVO that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new tbl_MasterSchedulePDF()
                {
                    ID = that.ID,
                    SiteID =that.SiteID,
                    MasterSchedulePDF = that.MasterSchedulePDF,
                };
            }
        }

        #endregion

    }
}
