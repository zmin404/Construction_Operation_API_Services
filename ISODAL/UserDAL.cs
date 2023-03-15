using ISOServiceVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ISODAL
{
    public static class UserDAL
    {
        public static UserVO GetUser(string name, string password)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                tbl_User user = context.tbl_User.Where(x => x.IsActive == true && x.LoginName.ToUpper() == name.ToUpper() && x.Password == password).FirstOrDefault();

                if (user != null)
                {
                    UserVO userVO = user.ToUserVO();
                    return userVO;
                }
                else
                {
                    return null;
                }
            }
        }

        public static byte[] GetUserImageByUserID(int userID)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                tbl_User user = context.tbl_User.Where(x => x.IsActive == true && x.ID == userID).FirstOrDefault();

                if (user != null)
                {
                    UserVO userVO = user.ToUserVO();
                    return userVO.Image;
                }
                else
                {
                    return null;
                }
            }
        }
        public static List<UserVO> GetAllUser()
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                return context.tbl_User.ToList().ToUserVOList();
            }
        }

        public static List<UserVO> GetActiveUser(bool status)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                return context.tbl_User.Where(x => x.IsActive == status).ToList().ToUserVOList();
            }
        }

        public static void AddUser(UserVO UserVO)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                context.tbl_User.Add(UserVO.ToUserTbl());
                context.SaveChanges();
            }
        }

        public static void EditUser(UserVO UserVO)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                tbl_User temp = UserVO.ToUserTbl();
                context.tbl_User.Attach(temp);
                context.Entry(temp).State = System.Data.EntityState.Modified;
                context.SaveChanges();
            }
        }
        
        public static void UpdateUser(int userID, int personID, string personName, string email, string password)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (ISOFormatEntities context = new ISOFormatEntities())
                {
                    tbl_User user = context.tbl_User.Where(x => x.ID == userID).FirstOrDefault();
                    user.Email = email;
                    user.Password = password;
                    context.tbl_User.Attach(user);
                    context.Entry(user).State = System.Data.EntityState.Modified;
                    context.SaveChanges();

                    tbl_Person person = context.tbl_Person.Where(x => x.PersonID == personID).FirstOrDefault();
                    person.PersonName = personName;
                    context.tbl_Person.Attach(person);
                    context.Entry(person).State = System.Data.EntityState.Modified;
                    context.SaveChanges();

                    scope.Complete();
                }
            }
        }

        #region Translate

        public static UserVO ToUserVO(this tbl_User that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new UserVO()
                {
                    ID = that.ID,
                    LoginName = that.LoginName,
                    Password = that.Password,
                    Email = that.Email,
                    Image = that.Image,
                    IsActive = that.IsActive,
                    LastModifiedBy=that.LastModifiedBy,
                    LastModifiedOn = that.LastModifiedOn,
                    //PersonandSiteID = (that.PersonandSiteID != 0) ? that.PersonandSiteID : null,
                    PersonID = (that.PersonID != 0) ? that.PersonID :null,
                    UserRoleID = that.tbl_UserRole.ID,

                    PersonName = (that.tbl_Person1 != null) ? that.tbl_Person1.PersonName : null,
                    UserRole = that.tbl_UserRole.RoleName,
                };
            }
        }

        public static List<UserVO> ToUserVOList(this List<tbl_User> list)
        {
            if (list == null || list.Count() == 0)
            {
                return null;
            }
            else
            {
                List<UserVO> result = new List<UserVO>();

                foreach (tbl_User user in list)
                {
                    result.Add(user.ToUserVO());
                }
                return result;
            }
        }

        public static tbl_User ToUserTbl(this UserVO that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new tbl_User()
                {
                    ID = that.ID,
                    LoginName = that.LoginName,
                    Password = that.Password,
                    Email = that.Email,
                    Image = that.Image,
                    IsActive = that.IsActive,
                    LastModifiedBy = that.LastModifiedBy,
                    LastModifiedOn = that.LastModifiedOn,
                    //PersonandSiteID = that.PersonandSiteID,
                    PersonID = (that.PersonID != 0) ? that.PersonID : null,
                    UserRoleID = that.UserRoleID,
                };
            }
        }

        #endregion
    }
}
