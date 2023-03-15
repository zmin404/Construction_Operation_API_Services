using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISODAL;
using ISOServiceVO;

namespace ISOBLL
{
    public class PersonBLL
    {
        public List<PersonVO> GetAllPerson()
        {
            try
            {
                return PersonDAL.GetAllPerson();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PersonVO> GetActivePerson(bool status)
        {
            try
            {
                return PersonDAL.GetActivePerson(status);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddPerson(PersonVO PersonVO)
        {
            try
            {
                Validation(PersonVO);
                PersonDAL.AddPerson(PersonVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditPerson(PersonVO PersonVO)
        {
            try
            {
                Validation(PersonVO);
                PersonDAL.EditPerson(PersonVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Validation(PersonVO PersonVO)
        {
            if (PersonVO == null)
            {
                throw new Exception("Person Object is null.");
            }
            if (string.IsNullOrEmpty(PersonVO.PersonName))
            {
                throw new Exception("Invalid Person Name in Person Object.");
            }
            if (Convert.ToInt32(PersonVO.PersonTypeID) == 0 )
            {
                throw new Exception("Invalid Person Type in Person Object.");
            }
        }
    }
}
