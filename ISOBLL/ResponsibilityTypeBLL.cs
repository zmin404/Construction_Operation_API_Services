using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISODAL;
using ISOServiceVO;

namespace ISOBLL
{
    public class ResponsibilityTypeBLL
    {
        public List<ResponsibilityTypeVO> GetAllResponsibilityType()
        {
            try
            {
                return ResponsibilityTypeDAL.GetAllResponsibilityType();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResponsibilityTypeVO GetAllResponsibilityTypeByType(String type)
        {
            try
            {
                return ResponsibilityTypeDAL.GetAllResponsibilityTypeByType(type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddResponsibilityType(ResponsibilityTypeVO ResponsibilityTypeVO)
        {
            try
            {
                Validation(ResponsibilityTypeVO);
                ResponsibilityTypeDAL.AddResponsibilityType(ResponsibilityTypeVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditResponsibilityType(ResponsibilityTypeVO ResponsibilityTypeVO)
        {
            try
            {
                Validation(ResponsibilityTypeVO);
                ResponsibilityTypeDAL.EditResponsibilityType(ResponsibilityTypeVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Validation(ResponsibilityTypeVO ResponsibilityTypeVO)
        {
            if (ResponsibilityTypeVO == null)
            {
                throw new Exception("ResponsibilityType Object is null.");
            }
            if (string.IsNullOrEmpty(ResponsibilityTypeVO.Type ))
            {
                throw new Exception("Invalid Responsibility Type  in ResponsibilityType Object.");
            }
        }
    }
}
