using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISOServiceVO;

namespace ISODAL
{
    public static class PersonTypeDAL
    {
        public static List<PersonTypeVO> GetAllPersonType()
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                return context.tbl_PersonType.ToList().ToPersonTypeVOList();
            }
        }

        public static List<PersonTypeVO> GetActivePersonType(bool status)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                return context.tbl_PersonType.Where(x => x.Active == status).ToList().ToPersonTypeVOList();
            }
        }

        public static void AddPersonType(PersonTypeVO PersonTypeVO)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                context.tbl_PersonType.Add(PersonTypeVO.ToPersonTypeTbl());
                context.SaveChanges();
            }
        }

        public static void EditPersonType(PersonTypeVO PersonTypeVO)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                tbl_PersonType temp = PersonTypeVO.ToPersonTypeTbl();
                context.tbl_PersonType.Attach(temp);
                context.Entry(temp).State = System.Data.EntityState.Modified;
                context.SaveChanges();
            }
        }

        #region Translate

        public static PersonTypeVO ToPersonTypeVO(this tbl_PersonType that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new PersonTypeVO()
                {
                    PersonTypeID = that.PersonTypeID,
                    PersonType = that.PersonType ,
                    Active = that.Active,
                    ModifiedBy = that.ModifiedBy,
                    ModifiedDate = that.ModifiedDate,
                };
            }
        }

        public static List<PersonTypeVO> ToPersonTypeVOList(this List<tbl_PersonType> list)
        {
            if (list == null || list.Count() == 0)
            {
                return null;
            }
            else
            {
                List<PersonTypeVO> result = new List<PersonTypeVO>();

                foreach (tbl_PersonType PersonType in list)
                {
                    result.Add(PersonType.ToPersonTypeVO());
                }
                return result;
            }
        }

        public static tbl_PersonType ToPersonTypeTbl(this PersonTypeVO that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new tbl_PersonType()
                {
                    PersonTypeID = that.PersonTypeID,
                    PersonType = that.PersonType,
                    Active = that.Active,
                    ModifiedBy = that.ModifiedBy,
                    ModifiedDate = that.ModifiedDate,
                };
            }
        }

        #endregion
    }
}
