using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISODAL;
using ISOServiceVO;

namespace ISOBLL
{
    public class OPTypeBLL
    {
        public List<OPTypeVO> GetAllOPType()
        {
            try
            {
                return OPTypeDAL.GetAllOPType();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
