using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISODAL;
using ISOServiceVO;

namespace ISOBLL
{
    public class PersonTypeBLL
    {
        public List<PersonTypeVO> GetAllPersonType()
        {
            try
            {
                return PersonTypeDAL.GetAllPersonType();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PersonTypeVO> GetActivePersonType(bool status)
        {
            try
            {
                return PersonTypeDAL.GetActivePersonType(status);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddPersonType(PersonTypeVO PersonTypeVO)
        {
            try
            {
                Validation(PersonTypeVO);
                PersonTypeDAL.AddPersonType(PersonTypeVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditPersonType(PersonTypeVO PersonTypeVO)
        {
            try
            {
                Validation(PersonTypeVO);
                PersonTypeDAL.EditPersonType(PersonTypeVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Validation(PersonTypeVO PersonTypeVO)
        {
            if (PersonTypeVO == null)
            {
                throw new Exception("PersonType Object is null.");
            }
            if (string.IsNullOrEmpty(PersonTypeVO.PersonType))
            {
                throw new Exception("Invalid PersonType in PersonType Object.");
            }
        }
    }
}
