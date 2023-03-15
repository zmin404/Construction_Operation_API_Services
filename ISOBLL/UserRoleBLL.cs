using ISODAL;
using ISOServiceVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISOBLL
{
    public class UserRoleBLL
    {
        public List<UserRoleVO> GetAllUserRole()
        {
            try
            {
                return UserRoleDAL.GetAllUserRole();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UserRoleVO> GetActiveUserRole(bool status)
        {
            try
            {
                return UserRoleDAL.GetActiveUserRole(status);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddUserRole(UserRoleVO UserRoleVO)
        {
            try
            {
                Validation(UserRoleVO);
                UserRoleDAL.AddUserRole(UserRoleVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditUserRole(UserRoleVO UserRoleVO)
        {
            try
            {
                Validation(UserRoleVO);
                UserRoleDAL.EditUserRole(UserRoleVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Validation(UserRoleVO UserRoleVO)
        {
            if (UserRoleVO == null)
            {
                throw new Exception("User Role Object is null.");
            }
            if (string.IsNullOrEmpty(UserRoleVO.RoleName))
            {
                throw new Exception("Invalid UserRole Name in UserRole Object.");
            }
        }
    }
}
