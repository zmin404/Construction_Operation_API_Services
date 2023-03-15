using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ISOServiceVO;

namespace ISOServiceLibrary
{
    [ServiceContract]
    public interface ISOIService
    {
        #region User

        [OperationContract]
        [FaultContract(typeof(ServerSvcFault))]
        UserVO GetUser(string name, string password);

        [OperationContract]
        [FaultContract(typeof(ServerSvcFault))]
        List<UserVO> GetAllUser();

        [OperationContract]
        [FaultContract(typeof(ServerSvcFault))]
        List<UserVO> GetActiveUser();

        [OperationContract]
        [FaultContract(typeof(ServerSvcFault))]
        void AddUser(UserVO UserVO);

        [OperationContract]
        [FaultContract(typeof(ServerSvcFault))]
        void EditUser(UserVO UserVO);

        #endregion

        #region UserRole

        [OperationContract]
        [FaultContract(typeof(ServerSvcFault))]
        List<UserRoleVO> GetAllUserRole();

        [OperationContract]
        [FaultContract(typeof(ServerSvcFault))]
        List<UserRoleVO> GetActiveUserRole();

        [OperationContract]
        [FaultContract(typeof(ServerSvcFault))]
        void AddUserRole(UserRoleVO UserRoleVO);

        [OperationContract]
        [FaultContract(typeof(ServerSvcFault))]
        void EditUserRole(UserRoleVO UserRoleVO);

        #endregion

        #region FormMenu
        
        [OperationContract]
        [FaultContract(typeof(ServerSvcFault))]
        List<FormMenuVO> GetActiveFormMenu();

        //For System Configure
        [OperationContract]
        [FaultContract(typeof(ServerSvcFault))]
        List<FormMenuVO> GetAllFormMenu();

        [OperationContract]
        [FaultContract(typeof(ServerSvcFault))]
        void AddFormMenu(FormMenuVO FormMenuVO);

        [OperationContract]
        [FaultContract(typeof(ServerSvcFault))]
        void EditFormMenu(FormMenuVO FormMenuVO);

        #endregion

        #region BuildingType
        [OperationContract]
        [FaultContract(typeof(ServerSvcFault))]
        List<BuildingTypeVO> GetAllBuildingType();

        [OperationContract]
        [FaultContract(typeof(ServerSvcFault))]
        List<BuildingTypeVO> GetActiveBuildingType();

        [OperationContract]
        [FaultContract(typeof(ServerSvcFault))]
        void AddBuildingType(BuildingTypeVO BuildingTypeVO);

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         void EditBuildingType(BuildingTypeVO BuildingTypeVO);

        #endregion

        #region Site

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         List<SiteVO> GetAllSite();

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         List<SiteVO> GetActiveSite();

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         List<SiteVO> GetIsCompleteSite(bool status);

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         void AddSite(SiteVO SiteVO);

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         void EditSite(SiteVO SiteVO);
        #endregion

        #region Person

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         List<PersonVO> GetAllPerson();

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         List<PersonVO> GetActivePerson();

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         void AddPerson(PersonVO PersonVO);

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         void EditPerson(PersonVO PersonVO);
        #endregion

        #region PersonAndSite

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         List<PersonAndSiteVO> GetAllPersonAndSite();

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         List<PersonAndSiteVO> GetFinishedPersonAndSite(bool status);

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         void AddPersonAndSite(PersonAndSiteVO PersonAndSiteVO);

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         void EditPersonAndSite(PersonAndSiteVO PersonAndSiteVO);
        #endregion

         #region BuildingType
         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         List<PersonTypeVO> GetAllPersonType();

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         List<PersonTypeVO> GetActivePersonType();

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         void AddPersonType(PersonTypeVO PersonTypeVO);

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         void EditPersonType(PersonTypeVO PersonTypeVO);

         #endregion

        #region ResponsibilityType

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         List<ResponsibilityTypeVO> GetAllResponsibilityType();

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         void AddResponsibilityType(ResponsibilityTypeVO ResponsibilityTypeVO);

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         void EditResponsibilityType(ResponsibilityTypeVO ResponsibilityTypeVO);

        #endregion 

        #region OperationOrderReg

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         List<OperationOrderRegVO> GetAllOperationOrderReg();

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         void AddOperationOrderReg(OperationOrderRegVO OperationOrderRegVO);

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         void EditOperationOrderReg(OperationOrderRegVO OperationOrderRegVO);

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         string GetNewOrderNo();


         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         OperationOrderRegVO GetOperationOrderRegByOORID(int OORID);

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         List<OperationOrderRegVO> GetOORListByFilter(DateTime fromDate, DateTime toDate, int siteID, int buildingID, string orderNo);

        #endregion

        #region OperationOrder
         
        [OperationContract]
        [FaultContract(typeof(ServerSvcFault))]
        List<OperationOrderVO> GetAllOperationOrder();

        [OperationContract]
        [FaultContract(typeof(ServerSvcFault))]
        void AddOperationOrder(OperationOrderVO OperationOrderVO);

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         void EditOperationOrder(OperationOrderVO OperationOrderVO);

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         List<OperationOrderVO> GetOperationOrderCompletePrepare();

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         List<OperationOrderVO> GetOperationOrderCompleteApprove();

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         List<OperationOrderVO> GetOOListByFilter(string orderNo);

        #endregion

         #region NameOfWork

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         List<NameOfWorkVO> GetAllNameOfWork();

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         List<NameOfWorkVO> GetActiveNameOfWork();

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         void AddNameOfWork(NameOfWorkVO NameOfWorkVO);

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         void EditNameOfWork(NameOfWorkVO NameOfWorkVO);

         #endregion
        
         #region OPType

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         List<OPTypeVO> GetAllOPType();

         #endregion

         #region MonthlyPlan

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         List<MonthlyPlanVO> GetAllMonthlyPlan();
        
         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
          void AddMonthlyPlan(MonthlyPlanVO MonthlyPlanVO);
        
         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         void EditMonthlyPlan(MonthlyPlanVO MonthlyPlanVO);
        
         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         void DeleteMonthlyPlan(MonthlyPlanVO MonthlyPlanVO);

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         List<MonthlyPlanSummaryVO> GetMonthlyPlanByFilter(DateTime date, int siteID);
        

         #endregion

         #region WeeklyPlan

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         List<WeeklyPlanVO> GetAllWeeklyPlan();

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         void AddWeeklyPlan(WeeklyPlanVO WeeklyPlanVO);

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         void EditWeeklyPlan(WeeklyPlanVO WeeklyPlanVO);

         [OperationContract]
         [FaultContract(typeof(ServerSvcFault))]
         void DeleteWeeklyPlan(WeeklyPlanVO WeeklyPlanVO);

         //[OperationContract]
         //[FaultContract(typeof(ServerSvcFault))]
         //List<WeeklyPlanSummaryVO> GetWeeklyPlanByFilter(DateTime date, int siteID);


         #endregion
    }
}
