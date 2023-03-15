using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISODAL;
using ISOServiceVO;

namespace ISOBLL
{
    public class MasterSchedulePDFBLL
    {
        public List<MasterSchedulePDFVO> GetMasterSchedulePDFListBySite(int siteID)
        {
            try
            {
                return MasterSchedulePDFDAL.GetMasterSchedulePDFListBySite(siteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
