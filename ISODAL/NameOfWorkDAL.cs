using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISOServiceVO;

namespace ISODAL
{
    public static class NameOfWorkDAL
    {
        public static List<NameOfWorkVO> GetAllNameOfWork()
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                return context.tbl_NameOfWork.ToList().ToNameOfWorkVOList(); 
            }
        }
        public static List<NameOfWorkVO> GetAllNameOfWorkByOPTypeID(int opTypeID)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                var temp = context.tbl_NameOfWork.Where(x => x.OPTypeID == opTypeID && x.Active == true).ToList().ToNameOfWorkVOList();
                return temp;
            }
        }

        public static List<NameOfWorkVO> GetActiveNameOfWork(bool status)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                return context.tbl_NameOfWork.Where(x => x.Active == status).ToList().ToNameOfWorkVOList();
            }
        }

        public static void AddNameOfWork(NameOfWorkVO NameOfWorkVO)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                context.tbl_NameOfWork.Add(NameOfWorkVO.ToNameOfWorkTbl());
                context.SaveChanges();
            }
        }

        public static void EditNameOfWork(NameOfWorkVO NameOfWorkVO)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                tbl_NameOfWork temp = NameOfWorkVO.ToNameOfWorkTbl();
                context.tbl_NameOfWork.Attach(temp);
                context.Entry(temp).State = System.Data.EntityState.Modified;
                context.SaveChanges();
            }
        }

        #region Translate

        public static NameOfWorkVO ToNameOfWorkVO(this tbl_NameOfWork that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new NameOfWorkVO()
                {
                    ID = that.ID,
                    NameofWork = that.NameofWork,
                    OPTypeID = that.OPTypeID,
                    Active = that.Active,
                    ModifiedBy = that.ModifiedBy,
                    ModifiedDate = that.ModifiedDate,

                    OPTypeName=that.tbl_OPType.OperationPlan,
                };
            }
        }

        public static List<NameOfWorkVO> ToNameOfWorkVOList(this List<tbl_NameOfWork> list)
        {
            if (list == null || list.Count() == 0)
            {
                return null;
            }
            else
            {
                List<NameOfWorkVO> result = new List<NameOfWorkVO>();

                foreach (tbl_NameOfWork NameOfWork in list)
                {
                    result.Add(NameOfWork.ToNameOfWorkVO());
                }
                return result;
            }
        }

        public static tbl_NameOfWork ToNameOfWorkTbl(this NameOfWorkVO that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new tbl_NameOfWork()
                {
                    ID = that.ID,
                    NameofWork = that.NameofWork,
                    OPTypeID = that.OPTypeID,
                    Active = that.Active,
                    ModifiedBy = that.ModifiedBy,
                    ModifiedDate = that.ModifiedDate,
                    
                };
            }
        }

        #endregion
    }
}
