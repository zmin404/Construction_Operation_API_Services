using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISODAL;
using ISOServiceVO;

namespace ISOBLL
{
    public class ContractPDFBLL
    {
        public List<ContractPDFVO> GetContractPDFListBySite(int siteID)
        {
            try
            {
                return ContractPDFDAL.GetContractPDFListBySite(siteID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
