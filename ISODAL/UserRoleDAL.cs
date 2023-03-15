using ISOServiceVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISODAL
{
    public static class UserRoleDAL
    {
        public static List<UserRoleVO> GetAllUserRole()
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                return context.tbl_UserRole.ToList().ToUserRoleVOList();
            }
        }

        public static List<UserRoleVO> GetActiveUserRole(bool status)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                return context.tbl_UserRole.Where(x => x.IsActive == status).ToList().ToUserRoleVOList();
            }
        }

        public static void AddUserRole(UserRoleVO UserRoleVO)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                context.tbl_UserRole.Add(UserRoleVO.ToUserRoleTbl());
                context.SaveChanges();
            }
        }

        public static void EditUserRole(UserRoleVO UserRoleVO)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                tbl_UserRole temp = UserRoleVO.ToUserRoleTbl();
                context.tbl_UserRole.Attach(temp);
                context.Entry(temp).State = System.Data.EntityState.Modified;
                context.SaveChanges();
            }
        }

        #region Translate

        public static UserRoleVO ToUserRoleVO(this tbl_UserRole that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new UserRoleVO()
                {
                    ID = that.ID,
                    RoleName = that.RoleName,
                    IsActive = that.IsActive,
                };
            }
        }

        public static List<UserRoleVO> ToUserRoleVOList(this List<tbl_UserRole> list)
        {
            if (list == null || list.Count() == 0)
            {
                return null;
            }
            else
            {
                List<UserRoleVO> result = new List<UserRoleVO>();

                foreach (tbl_UserRole UserRole in list)
                {
                    result.Add(UserRole.ToUserRoleVO());
                }
                return result;
            }
        }

        public static tbl_UserRole ToUserRoleTbl(this UserRoleVO that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new tbl_UserRole()
                {
                    ID = that.ID,
                    RoleName = that.RoleName,
                    IsActive = that.IsActive,
                };
            }
        }

        #endregion
    }
}
