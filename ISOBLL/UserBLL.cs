using ISODAL;
using ISOServiceVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISOBLL
{
    public class UserBLL
    {
        public UserVO GetUser(string name, string password)
        {
            try
            {
                password = Utils.HashPassword(password);
                return UserDAL.GetUser(name, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public byte[] GetUserImageByUserID(int userID)
        {
            try
            {
                return UserDAL.GetUserImageByUserID(userID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<UserVO> GetAllUser()
        {
            try
            {
                return UserDAL.GetAllUser();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UserVO> GetActiveUser(bool status)
        {
            try
            {
                return UserDAL.GetActiveUser(status);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddUser(UserVO UserVO)
        {
            try
            {
                Validation(UserVO);
                //UserVO.Password = Utils.HashPassword(UserVO.Password);
                UserDAL.AddUser(UserVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditUser(UserVO UserVO)
        {
            try
            {
                Validation(UserVO);
                //UserVO.Password = Utils.HashPassword(UserVO.Password);
                UserDAL.EditUser(UserVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateUser(int userID, int personID, string personName, string email, string password)
        {
            try
            {
                password = Utils.HashPassword(password);
                UserDAL.UpdateUser(userID, personID, personName, email, password);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Validation(UserVO UserVO)
        {
            if (UserVO == null)
            {
                throw new Exception("User Object is null.");
            }
            if (string.IsNullOrEmpty(UserVO.LoginName))
            {
                throw new Exception("Invalid Login Name in User Object.");
            }
            if (string.IsNullOrEmpty(UserVO.Password))
            {
                throw new Exception("Invalid Password in User Object.");
            }
            if (UserVO.UserRoleID == 0)
            {
                throw new Exception("Invalid UserRoleID in User Object.");
            }
        }
    }
}
