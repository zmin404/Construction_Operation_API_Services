using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISOServiceVO;

namespace ISODAL
{
    public static class ContractPDFDAL
    {
        public static List<ContractPDFVO> GetContractPDFListBySite(int siteID)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                return context.tbl_ContractPDF.Where(x => x.tbl_Site.SiteID == siteID).ToList().ToContractPDFVOList();
            }
        }

        #region ContractPDF

        public static ContractPDFVO ToContractPDFVO(this tbl_ContractPDF that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new ContractPDFVO()
                {
                    ID = that.ID,
                    SiteID = that.SiteID,
                    ContractPDF = that.ContractPDF,
                    
                };
            }
        }

        public static List<ContractPDFVO> ToContractPDFVOList(this List<tbl_ContractPDF> list)
        {
            if (list == null || list.Count() == 0)
            {
                return null;
            }
            else
            {
                List<ContractPDFVO> result = new List<ContractPDFVO>();

                foreach (tbl_ContractPDF MSPDF in list)
                {
                    result.Add(MSPDF.ToContractPDFVO());
                }
                return result;
            }
        }

        public static tbl_ContractPDF ToContractPDFTbl(this ContractPDFVO that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new tbl_ContractPDF()
                {
                    ID = that.ID,
                    SiteID = that.SiteID,
                    ContractPDF = that.ContractPDF,
                };
            }
        }

        #endregion

    }
}
