using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISOServiceVO;

namespace ISODAL
{
    public static class PersonDAL
    {
        public static List<PersonVO> GetAllPerson()
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                return context.tbl_Person.ToList().ToPersonVOList();
            }
        }

        public static List<PersonVO> GetActivePerson(bool status)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                return context.tbl_Person.Where(x => x.Active == status).ToList().ToPersonVOList();
            }
        }

        public static void AddPerson(PersonVO PersonVO)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                context.tbl_Person.Add(PersonVO.ToPersonTbl());
                context.SaveChanges();
            }
        }

        public static void EditPerson(PersonVO PersonVO)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                tbl_Person temp = PersonVO.ToPersonTbl();
                context.tbl_Person.Attach(temp);
                context.Entry(temp).State = System.Data.EntityState.Modified;
                context.SaveChanges();
            }
        }

        #region Translate

        public static PersonVO ToPersonVO(this tbl_Person that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new PersonVO()
                {
                    PersonID = that.PersonID,
                    PersonName= that.PersonName,
                    PersonTypeID = that.PersonTypeID,
                    Active = that.Active,
                    ModifiedBy = that.ModifiedBy,
                    ModifiedDate = that.ModifiedDate,

                    PersonType = (that.tbl_PersonType.PersonType !=null)?that.tbl_PersonType.PersonType:null,
                };
            }
        }

        public static List<PersonVO> ToPersonVOList(this List<tbl_Person> list)
        {
            if (list == null || list.Count() == 0)
            {
                return null;
            }
            else
            {
                List<PersonVO> result = new List<PersonVO>();

                foreach (tbl_Person Person in list)
                {
                    result.Add(Person.ToPersonVO());
                }
                return result;
            }
        }

        public static tbl_Person ToPersonTbl(this PersonVO that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new tbl_Person()
                {
                    PersonID = that.PersonID,
                    PersonName = that.PersonName,
                    PersonTypeID = that.PersonTypeID,
                    Active = that.Active,
                    ModifiedBy = that.ModifiedBy,
                    ModifiedDate = that.ModifiedDate,
                };
            }
        }

        #endregion
    }
}
