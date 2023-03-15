using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ISOBLL;
using ISOServiceVO;

namespace ISOServiceLibrary
{
    public class ISOService : ISOIService
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetAllUser Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetAllUser Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetActiveUser Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "AddUser Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "EditUser Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetAllUserRole Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetActiveUserRole Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "AddUserRole Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "EditUserRole Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetActiveFormMenu Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetAllFormMenu Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "AddFormMenu Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "EditFormMenu Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetAllBuildingType Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetActiveBuildingType Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "AddBuildingType Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "EditBuildingType Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetAllSite Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetActiveSite Exception!");
            }
        }

        public List<SiteVO> GetIsCompleteSite(bool status)
        {
            try
            {
                SiteBLL BLL = new SiteBLL();
                return BLL.GetIsCompleteSite(status);
            }
            catch (Exception ex)
            {
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetIsCompleteSite Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "AddSite Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "EditSite Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetAllPerson Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetActivePerson Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "AddPerson Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "EditPerson Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetAllPersonAndSite Exception!");
            }
        }

        public List<PersonAndSiteVO> GetFinishedPersonAndSite(bool status)
        {
            try
            {
                PersonAndSiteBLL BLL = new PersonAndSiteBLL();
                return BLL.GetFinishedPersonAndSite(status);
            }
            catch (Exception ex)
            {
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetFinishedPersonAndSite Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "AddPersonAndSite Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "EditPersonAndSite Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetAllPersonType Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetActivePersonType Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "AddPersonType Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "EditPersonType Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetAllResponsibilityType Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "AddResponsibilityType Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "EditResponsibilityType Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetAllOperationOrderReg Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "AddOperationOrderReg Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "EditOperationOrderReg Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetNewOrderNo Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetOperationOrderByOrderID Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetOORListByFilter Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetAllOperationOrder Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "AddOperationOrder Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "EditOperationOrder Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetOperationOrderCompletePrepare Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetOperationOrderCompleteApprove Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetOOListByFilter Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetAllNameOfWork Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetActiveNameOfWork Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "AddNameOfWork Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "EditNameOfWork Exception!");
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
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetAllOPType Exception!");
            }
        }

        #endregion

        #region MonthlyPlan

        public List<MonthlyPlanVO> GetAllMonthlyPlan()
        {
            try
            {
                MonthlyPlanBLL BLL = new MonthlyPlanBLL();
                return BLL.GetAllMonthlyPlan();
            }
            catch (Exception ex)
            {
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetAllMonthlyPlan Exception!");
            }
        }

        public void AddMonthlyPlan(MonthlyPlanVO MonthlyPlanVO)
        {
            try
            {
                MonthlyPlanBLL BLL = new MonthlyPlanBLL();
                BLL.AddMonthlyPlan(MonthlyPlanVO);
            }
            catch (Exception ex)
            {
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "AddMonthlyPlan Exception!");
            }
        }

        public void EditMonthlyPlan(MonthlyPlanVO MonthlyPlanVO)
        {
            try
            {
                MonthlyPlanBLL BLL = new MonthlyPlanBLL();
                BLL.EditMonthlyPlan(MonthlyPlanVO);
            }
            catch (Exception ex)
            {
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "EditMonthlyPlan Exception!");
            }
        }

        public void DeleteMonthlyPlan(MonthlyPlanVO MonthlyPlanVO)
        {
            try
            {
                MonthlyPlanBLL BLL = new MonthlyPlanBLL();
                BLL.DeleteMonthlyPlan(MonthlyPlanVO);
            }
            catch (Exception ex)
            {
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "DeleteMonthlyPlan Exception!");
            }
        }

        public List<MonthlyPlanSummaryVO> GetMonthlyPlanByFilter(DateTime date, int siteID)
        {
            try
            {
                MonthlyPlanBLL BLL = new MonthlyPlanBLL();
                return BLL.GetMonthlyPlanByFilter(date, siteID);
            }
            catch (Exception ex)
            {
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetMonthlyPlanByFilter Exception!");
            }
        }

        #endregion

        #region WeeklyPlan

        public List<WeeklyPlanVO> GetAllWeeklyPlan()
        {
            try
            {
                WeeklyPlanBLL BLL = new WeeklyPlanBLL();
                return BLL.GetAllWeeklyPlan();
            }
            catch (Exception ex)
            {
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetAllWeeklyPlan Exception!");
            }
        }

        public void AddWeeklyPlan(WeeklyPlanVO WeeklyPlanVO)
        {
            try
            {
                WeeklyPlanBLL BLL = new WeeklyPlanBLL();
                BLL.AddWeeklyPlan(WeeklyPlanVO);
            }
            catch (Exception ex)
            {
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "AddWeeklyPlan Exception!");
            }
        }

        public void EditWeeklyPlan(WeeklyPlanVO WeeklyPlanVO)
        {
            try
            {
                WeeklyPlanBLL BLL = new WeeklyPlanBLL();
                BLL.EditWeeklyPlan(WeeklyPlanVO);
            }
            catch (Exception ex)
            {
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "EditWeeklyPlan Exception!");
            }
        }

        public void DeleteWeeklyPlan(WeeklyPlanVO WeeklyPlanVO)
        {
            try
            {
                WeeklyPlanBLL BLL = new WeeklyPlanBLL();
                BLL.DeleteWeeklyPlan(WeeklyPlanVO);
            }
            catch (Exception ex)
            {
                throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "DeleteWeeklyPlan Exception!");
            }
        }

        //public List<WeeklyPlanSummaryVO> GetWeeklyPlanByFilter(DateTime date, int siteID)
        //{
        //    try
        //    {
        //        WeeklyPlanBLL BLL = new WeeklyPlanBLL();
        //        return BLL.GetWeeklyPlanByFilter(date, siteID);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new FaultException<ServerSvcFault>(new ServerSvcFault(ex.Message), "GetWeeklyPlanByFilter Exception!");
        //    }
        //}

        #endregion
    }
}
