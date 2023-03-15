using ISODAL;
using ISOServiceVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISOBLL
{
    public class FormMenuBLL
    {

        public List<FormMenuVO> GetActiveFormMenu()
        {
            try
            {
                return FormMenuDAL.GetActiveFormMenu();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<FormMenuVO> GetPermissionFormByRoleID(int id)
        //{
        //    try
        //    {
        //        return FormMenuDAL.GetPermissionFormByRoleID(id);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //For System Configure
        public List<FormMenuVO> GetAllFormMenu()
        {
            try
            {
                return FormMenuDAL.GetAllFormMenu();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
  
        public void AddFormMenu(FormMenuVO FormMenuVO)
        {
            try
            {
                FormMenuDAL.AddFormMenu(FormMenuVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditFormMenu(FormMenuVO FormMenuVO)
        {
            try
            {
                FormMenuDAL.EditFormMenu(FormMenuVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
