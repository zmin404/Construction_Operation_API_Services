using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ISOBLL;
using ISOServiceVO;

namespace TESTAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        #region User

        public UserVO GetUser(string name, string password)
        {
            try
            {
                UserBLL BLL = new UserBLL();
                return BLL.GetUser(name, password);
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
                UserBLL BLL = new UserBLL();
                return BLL.GetAllUser();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UserVO> GetActiveUser()
        {
            try
            {
                UserBLL BLL = new UserBLL();
                return BLL.GetActiveUser();
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
                UserBLL BLL = new UserBLL();
                BLL.AddUser(UserVO);
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
                UserBLL BLL = new UserBLL();
                BLL.EditUser(UserVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region UserRole

        public List<UserRoleVO> GetAllUserRole()
        {
            try
            {
                UserRoleBLL BLL = new UserRoleBLL();
                return BLL.GetAllUserRole();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UserRoleVO> GetActiveUserRole()
        {
            try
            {
                UserRoleBLL BLL = new UserRoleBLL();
                return BLL.GetActiveUserRole();
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
                UserRoleBLL BLL = new UserRoleBLL();
                BLL.AddUserRole(UserRoleVO);
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
                UserRoleBLL BLL = new UserRoleBLL();
                BLL.EditUserRole(UserRoleVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region FormMenu

        public List<FormMenuVO> GetActiveFormMenu()
        {
            try
            {
                FormMenuBLL BLL = new FormMenuBLL();
                return BLL.GetActiveFormMenu();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<FormMenuVO> GetAllFormMenu()
        {
            try
            {
                FormMenuBLL BLL = new FormMenuBLL();
                return BLL.GetAllFormMenu();
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
                FormMenuBLL BLL = new FormMenuBLL();
                BLL.AddFormMenu(FormMenuVO);
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
                FormMenuBLL BLL = new FormMenuBLL();
                BLL.EditFormMenu(FormMenuVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region BuildingType

        public List<BuildingTypeVO> GetAllBuildingType()
        {
            try
            {
                BuildingTypeBLL BLL = new BuildingTypeBLL();
                return BLL.GetAllBuildingType();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BuildingTypeVO> GetActiveBuildingType()
        {
            try
            {
                BuildingTypeBLL BLL = new BuildingTypeBLL();
                return BLL.GetActiveBuildingType();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddBuildingType(BuildingTypeVO BuildingTypeVO)
        {
            try
            {
                BuildingTypeBLL BLL = new BuildingTypeBLL();
                BLL.AddBuildingType(BuildingTypeVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditBuildingType(BuildingTypeVO BuildingTypeVO)
        {
            try
            {
                BuildingTypeBLL BLL = new BuildingTypeBLL();
                BLL.EditBuildingType(BuildingTypeVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Site

        public List<SiteVO> GetAllSite()
        {
            try
            {
                SiteBLL BLL = new SiteBLL();
                return BLL.GetAllSite();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SiteVO> GetActiveSite()
        {
            try
            {
                SiteBLL BLL = new SiteBLL();
                return BLL.GetActiveSite();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddSite(SiteVO SiteVO)
        {
            try
            {
                SiteBLL BLL = new SiteBLL();
                BLL.AddSite(SiteVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditSite(SiteVO SiteVO)
        {
            try
            {
                SiteBLL BLL = new SiteBLL();
                BLL.EditSite(SiteVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Person

        public List<PersonVO> GetAllPerson()
        {
            try
            {
                PersonBLL BLL = new PersonBLL();
                return BLL.GetAllPerson();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PersonVO> GetActivePerson()
        {
            try
            {
                PersonBLL BLL = new PersonBLL();
                return BLL.GetActivePerson();
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
                PersonBLL BLL = new PersonBLL();
                BLL.AddPerson(PersonVO);
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
                PersonBLL BLL = new PersonBLL();
                BLL.EditPerson(PersonVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region PersonAndSite

        public List<PersonAndSiteVO> GetAllPersonAndSite()
        {
            try
            {
                PersonAndSiteBLL BLL = new PersonAndSiteBLL();
                return BLL.GetAllPersonAndSite();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PersonAndSiteVO> GetActivePersonAndSite()
        {
            try
            {
                PersonAndSiteBLL BLL = new PersonAndSiteBLL();
                return BLL.GetActivePersonAndSite();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddPersonAndSite(PersonAndSiteVO PersonAndSiteVO)
        {
            try
            {
                PersonAndSiteBLL BLL = new PersonAndSiteBLL();
                BLL.AddPersonAndSite(PersonAndSiteVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditPersonAndSite(PersonAndSiteVO PersonAndSiteVO)
        {
            try
            {
                PersonAndSiteBLL BLL = new PersonAndSiteBLL();
                BLL.EditPersonAndSite(PersonAndSiteVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region PersonTypeType

        public List<PersonTypeVO> GetAllPersonType()
        {
            try
            {
                PersonTypeBLL BLL = new PersonTypeBLL();
                return BLL.GetAllPersonType();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PersonTypeVO> GetActivePersonType()
        {
            try
            {
                PersonTypeBLL BLL = new PersonTypeBLL();
                return BLL.GetActivePersonType();
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
                PersonTypeBLL BLL = new PersonTypeBLL();
                BLL.AddPersonType(PersonTypeVO);
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
                PersonTypeBLL BLL = new PersonTypeBLL();
                BLL.EditPersonType(PersonTypeVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region ResponsibilityType

        public List<ResponsibilityTypeVO> GetAllResponsibilityType()
        {
            try
            {
                ResponsibilityTypeBLL BLL = new ResponsibilityTypeBLL();
                return BLL.GetAllResponsibilityType();
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
                ResponsibilityTypeBLL BLL = new ResponsibilityTypeBLL();
                BLL.AddResponsibilityType(ResponsibilityTypeVO);
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
                ResponsibilityTypeBLL BLL = new ResponsibilityTypeBLL();
                BLL.EditResponsibilityType(ResponsibilityTypeVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region OperationOrderReg

        public List<OperationOrderRegVO> GetAllOperationOrderReg()
        {
            try
            {
                OperationOrderRegBLL BLL = new OperationOrderRegBLL();
                return BLL.GetAllOperationOrderReg();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddOperationOrderReg(OperationOrderRegVO OperationOrderRegVO)
        {
            try
            {
                OperationOrderRegBLL BLL = new OperationOrderRegBLL();
                BLL.AddOperationOrderReg(OperationOrderRegVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditOperationOrderReg(OperationOrderRegVO OperationOrderRegVO)
        {
            try
            {
                OperationOrderRegBLL BLL = new OperationOrderRegBLL();
                BLL.EditOperationOrderReg(OperationOrderRegVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetNewOrderNo()
        {
            try
            {
                OperationOrderRegBLL BLL = new OperationOrderRegBLL();
                return BLL.GetNewOrderNo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OperationOrderRegVO GetOperationOrderRegByOORID(int OORID)
        {
            try
            {
                OperationOrderRegBLL BLL = new OperationOrderRegBLL();
                return BLL.GetOperationOrderRegByOORID(OORID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OperationOrderRegVO> GetOORListByFilter(DateTime fromDate, DateTime toDate, int siteID, int buildingID, string orderNo)
        {
            try
            {
                OperationOrderRegBLL BLL = new OperationOrderRegBLL();
                return BLL.GetOORListByFilter(fromDate, toDate, siteID, buildingID, orderNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region OperationOrder

        public List<OperationOrderVO> GetAllOperationOrder()
        {
            try
            {
                OperationOrderBLL BLL = new OperationOrderBLL();
                return BLL.GetAllOperationOrder();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddOperationOrder(OperationOrderVO OperationOrderVO)
        {
            try
            {
                OperationOrderBLL BLL = new OperationOrderBLL();
                BLL.AddOperationOrder(OperationOrderVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditOperationOrder(OperationOrderVO OperationOrderVO)
        {
            try
            {
                OperationOrderBLL BLL = new OperationOrderBLL();
                BLL.EditOperationOrder(OperationOrderVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OperationOrderVO> GetOperationOrderCompletePrepare()
        {
            try
            {
                OperationOrderBLL BLL = new OperationOrderBLL();
                return BLL.GetOperationOrderCompletePrepare();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OperationOrderVO> GetOperationOrderCompleteApprove()
        {
            try
            {
                OperationOrderBLL BLL = new OperationOrderBLL();
                return BLL.GetOperationOrderCompleteApprove();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OperationOrderVO> GetOOListByFilter(string orderNo)
        {
            try
            {
                OperationOrderBLL BLL = new OperationOrderBLL();
                return BLL.GetOOListByFilter(orderNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region NameOfWork

        public List<NameOfWorkVO> GetAllNameOfWork()
        {
            try
            {
                NameOfWorkBLL BLL = new NameOfWorkBLL();
                return BLL.GetAllNameOfWork();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<NameOfWorkVO> GetActiveNameOfWork()
        {
            try
            {
                NameOfWorkBLL BLL = new NameOfWorkBLL();
                return BLL.GetActiveNameOfWork();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddNameOfWork(NameOfWorkVO NameOfWorkVO)
        {
            try
            {
                NameOfWorkBLL BLL = new NameOfWorkBLL();
                BLL.AddNameOfWork(NameOfWorkVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditNameOfWork(NameOfWorkVO NameOfWorkVO)
        {
            try
            {
                NameOfWorkBLL BLL = new NameOfWorkBLL();
                BLL.EditNameOfWork(NameOfWorkVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region OPType

        public List<OPTypeVO> GetAllOPType()
        {
            try
            {
                OPTypeBLL BLL = new OPTypeBLL();
                return BLL.GetAllOPType();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
