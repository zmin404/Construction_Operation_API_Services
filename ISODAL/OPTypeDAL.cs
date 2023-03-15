using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISOServiceVO;

namespace ISODAL
{
    public static class OPTypeDAL
    {
        public static List<OPTypeVO> GetAllOPType()
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                return context.tbl_OPType.ToList().ToOPTypeVOList();
            }
        }
        

        #region Translate

        public static OPTypeVO ToOPTypeVO(this tbl_OPType that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new OPTypeVO()
                {
                    OPTypeID = that.OPTypeID,
                    OperationPlan = that.OperationPlan,
                    Active = that.Active,
                    ModifiedBy = that.ModifiedBy,
                    ModifiedDate = that.ModifiedDate,
                };
            }
        }

        public static List<OPTypeVO> ToOPTypeVOList(this List<tbl_OPType> list)
        {
            if (list == null || list.Count() == 0)
            {
                return null;
            }
            else
            {
                List<OPTypeVO> result = new List<OPTypeVO>();

                foreach (tbl_OPType OPType in list)
                {
                    result.Add(OPType.ToOPTypeVO());
                }
                return result;
            }
        }

        #endregion
    }
}
