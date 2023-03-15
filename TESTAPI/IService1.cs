using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ISOServiceVO;

namespace TESTAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        #region User

        [OperationContract][WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        UserVO GetUser(string name, string password);

        [OperationContract][WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        List<UserVO> GetAllUser();

        [OperationContract][WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        List<UserVO> GetActiveUser();

        [OperationContract][WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]        
        void AddUser(UserVO UserVO);

        [OperationContract][WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
         
        void EditUser(UserVO UserVO);

        #endregion

        #region UserRole

        [OperationContract][WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
         
        List<UserRoleVO> GetAllUserRole();

        [OperationContract][WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
         
        List<UserRoleVO> GetActiveUserRole();

        [OperationContract][WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
         
        void AddUserRole(UserRoleVO UserRoleVO);

        [OperationContract][WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
         
        void EditUserRole(UserRoleVO UserRoleVO);

        #endregion

        #region FormMenu

        [OperationContract][WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
         
        List<FormMenuVO> GetActiveFormMenu();

        //For System Configure
        [OperationContract][WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
         
        List<FormMenuVO> GetAllFormMenu();

        [OperationContract][WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
         
        void AddFormMenu(FormMenuVO FormMenuVO);

        [OperationContract][WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
         
        void EditFormMenu(FormMenuVO FormMenuVO);

        #endregion

        #region BuildingType
        [OperationContract][WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
         
        List<BuildingTypeVO> GetAllBuildingType();

        [OperationContract][WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
         
        List<BuildingTypeVO> GetActiveBuildingType();

        [OperationContract][WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
         
        void AddBuildingType(BuildingTypeVO BuildingTypeVO);

        [OperationContract][WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
         
        void EditBuildingType(BuildingTypeVO BuildingTypeVO);

        #endregion

        #region Site

        [OperationContract][WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
         
        List<SiteVO> GetAllSite();

        [OperationContract][WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
         
        List<SiteVO> GetActiveSite();

        [OperationContract][WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
         
        void AddSite(SiteVO SiteVO);

        [OperationContract][WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
         
        void EditSite(SiteVO SiteVO);
        #endregion

        #region Person

        [OperationContract][WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
         
        List<PersonVO> GetAllPerson();

        [OperationContract][WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
         
        List<PersonVO> GetActivePerson();

        [OperationContract][WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
         
        void AddPerson(PersonVO PersonVO);

        [OperationContract][WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
         
        void EditPerson(PersonVO PersonVO);
        #endregion

        #region PersonAndSite

        [OperationContract][WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
         
        List<PersonAndSiteVO> GetAllPersonAndSite();

        [OperationContract][WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
         
        List<PersonAndSiteVO> GetActivePersonAndSite();

        [OperationContract][WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
         
        void AddPersonAndSite(PersonAndSiteVO PersonAndSiteVO);

        [OperationContract][WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
         
        void EditPersonAndSite(PersonAndSiteVO PersonAndSiteVO);
        #endregion

        #region BuildingType
        [OperationContract][WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
         
        List<PersonTypeVO> GetAllPersonType();

        [OperationContract][WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
         
        List<PersonTypeVO> GetActivePersonType();

        [OperationContract][WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
         
        void AddPersonType(PersonTypeVO PersonTypeVO);

        [OperationContract][WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
         
        void EditPersonType(PersonTypeVO PersonTypeVO);

        #endregion

        #region ResponsibilityType

        [OperationContract][WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
         
        List<ResponsibilityTypeVO> GetAllResponsibilityType();

        [OperationContract][WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
         
        void AddResponsibilityType(ResponsibilityTypeVO ResponsibilityTypeVO);

        [OperationContract][WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
         
        void EditResponsibilityType(ResponsibilityTypeVO ResponsibilityTypeVO);

        #endregion

        #region OperationOrderReg

        [OperationContract][WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
         
        List<OperationOrderRegVO> GetAllOperationOrderReg();

        [OperationContract][WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
         
        void AddOperationOrderReg(OperationOrderRegVO OperationOrderRegVO);

        [OperationContract][WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
         
        void EditOperationOrderReg(OperationOrderRegVO OperationOrderRegVO);

        [OperationContract][WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
         
        string GetNewOrderNo();


        [OperationContract][WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
         
        OperationOrderRegVO GetOperationOrderRegByOORID(int OORID);

        [OperationContract][WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
         
        List<OperationOrderRegVO> GetOORListByFilter(DateTime fromDate, DateTime toDate, int siteID, int buildingID, string orderNo);

        #endregion

        #region OperationOrder

        [OperationContract][WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
         
        List<OperationOrderVO> GetAllOperationOrder();

        [OperationContract][WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
         
        void AddOperationOrder(OperationOrderVO OperationOrderVO);

        [OperationContract][WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
         
        void EditOperationOrder(OperationOrderVO OperationOrderVO);

        [OperationContract][WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
         
        List<OperationOrderVO> GetOperationOrderCompletePrepare();

        [OperationContract][WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
         
        List<OperationOrderVO> GetOperationOrderCompleteApprove();

        [OperationContract][WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
         
        List<OperationOrderVO> GetOOListByFilter(string orderNo);

        #endregion

        #region NameOfWork

        [OperationContract][WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
         
        List<NameOfWorkVO> GetAllNameOfWork();

        [OperationContract][WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
         
        List<NameOfWorkVO> GetActiveNameOfWork();

        [OperationContract][WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
         
        void AddNameOfWork(NameOfWorkVO NameOfWorkVO);

        [OperationContract][WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
         
        void EditNameOfWork(NameOfWorkVO NameOfWorkVO);

        #endregion

        #region OPType

        [OperationContract][WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
         
        List<OPTypeVO> GetAllOPType();

        #endregion
    }
}
