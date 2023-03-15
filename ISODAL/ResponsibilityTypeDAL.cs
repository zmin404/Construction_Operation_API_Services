using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISOServiceVO;

namespace ISODAL
{
    public static class ResponsibilityTypeDAL
    {
        public static List<ResponsibilityTypeVO> GetAllResponsibilityType()
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                return context.tbl_ResponsibilityType.ToList().ToResponsibilityTypeVOList();
            }
        }

        public static ResponsibilityTypeVO GetAllResponsibilityTypeByType(String type)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                var temp = context.tbl_ResponsibilityType.Where(x => x.Type == type).FirstOrDefault().ToResponsibilityTypeVO();
                return temp;
            }
        }

        public static void AddResponsibilityType(ResponsibilityTypeVO ResponsibilityTypeVO)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                context.tbl_ResponsibilityType.Add(ResponsibilityTypeVO.ToResponsibilityTypeTbl());
                context.SaveChanges();
            }
        }

        public static void EditResponsibilityType(ResponsibilityTypeVO ResponsibilityTypeVO)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                tbl_ResponsibilityType temp = ResponsibilityTypeVO.ToResponsibilityTypeTbl();
                context.tbl_ResponsibilityType.Attach(temp);
                context.Entry(temp).State = System.Data.EntityState.Modified;
                context.SaveChanges();
            }
        }

        #region Translate

        public static ResponsibilityTypeVO ToResponsibilityTypeVO(this tbl_ResponsibilityType that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new ResponsibilityTypeVO()
                {
                    ID=that.ID,
                    Type=that.Type 
                };
            }
        }

        public static List<ResponsibilityTypeVO> ToResponsibilityTypeVOList(this List<tbl_ResponsibilityType> list)
        {
            if (list == null || list.Count() == 0)
            {
                return null;
            }
            else
            {
                List<ResponsibilityTypeVO> result = new List<ResponsibilityTypeVO>();

                foreach (tbl_ResponsibilityType ResponsibilityType in list)
                {
                    result.Add(ResponsibilityType.ToResponsibilityTypeVO());
                }
                return result;
            }
        }

        public static tbl_ResponsibilityType ToResponsibilityTypeTbl(this ResponsibilityTypeVO that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new tbl_ResponsibilityType()
                {
                    ID = that.ID,
                    Type = that.Type 
                };
            }
        }

        #endregion
    }
}
