using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISOServiceVO;

namespace ISODAL
{
    public static class OperationOrderDAL
    {
        public static List<OperationOrderVO> GetAllOperationOrder()
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                return context.tbl_OperationOrder.ToList().ToOperationOrderVOList();
            }
        }

        public static void AddOperationOrder(OperationOrderVO OperationOrderVO)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                context.tbl_OperationOrder.Add(OperationOrderVO.ToOperationOrderTbl());
                context.SaveChanges();
            }
        }

        public static void EditOperationOrder(OperationOrderVO OperationOrderVO)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                tbl_OperationOrder temp = OperationOrderVO.ToOperationOrderTbl();
                context.tbl_OperationOrder.Attach(temp);
                context.Entry(temp).State = System.Data.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static List<OperationOrderVO> GetOperationOrderCompletePrepare()
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                return context.tbl_OperationOrder.Where(x => x.CompletePrepare == true || x.CompleteApprove == true).ToList().ToOperationOrderVOList();
            }
        }

        public static List<OperationOrderVO> GetOperationOrderCompleteApprove() 
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                return context.tbl_OperationOrder.Where(x => x.CompleteApprove == true).ToList().ToOperationOrderVOList();
            }
        }

        public static List<OperationOrderVO> GetOOListByFilter(string orderNo)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                context.Configuration.ProxyCreationEnabled = false;
                IQueryable<tbl_OperationOrder> query = context.tbl_OperationOrder.Include("tbl_Site").Include("tbl_BuildingType").Include("tbl_Person").Include("tbl_OperationOrderReg");

                
                if (orderNo != null)
                {
                    query = query.Where(x => x.tbl_OperationOrderReg.OrderNo == orderNo);
                }
                if (query != null)
                {
                    var list = query.Select(x => new OperationOrderVO()
                    {
                        OOID = x.OOID,
                        OrderNo = x.tbl_OperationOrderReg.OrderNo,
                        OODate = x.OODate,
                        BuildingType = x.tbl_BuildingType.BuildingType,
                        Site = x.tbl_Site.SiteName, 
                        SiteEngineer = x.tbl_Person1.PersonName,
                        SeniorIncharge = x.tbl_Person.PersonName,
                        StoreKeeper = x.tbl_Person2.PersonName,
                        ApprovedByName = x.tbl_User1.LoginName,
                        Duration = x.Duration,
                        DetailInstruction = x.DetailInstruction,
                    }).ToList();
                    return list;
                }
                return null;
            }
        }

        #region Translate

        public static OperationOrderVO ToOperationOrderVO(this tbl_OperationOrder that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new OperationOrderVO()
                {
                    OOID = that.OOID,
                    OODate = that.OODate,
                    OORID = that.OORID,
                    BuildingTypeID = that.BuildingTypeID,
                    ApprovedBy = that.ApprovedBy,
                    CompleteApprove = that.CompleteApprove,
                    CompletePrepare = that.CompletePrepare,
                    DetailInstruction = that.DetailInstruction,
                    Duration = that.Duration,
                    SeniorInchargeID = that.SeniorInchargeID,
                    SiteEngineerID = that.SiteEngineerID,
                    SiteID = that.SiteID,
                    StoreKeeperID = that.StoreKeeperID,
                    ModifiedBy = that.ModifiedBy,
                    ModifiedDate = that.ModifiedDate,

                    BuildingType = (that.tbl_BuildingType.BuildingTypeID != 0) ? that.tbl_BuildingType.BuildingType : null,
                    Site = (that.tbl_Site.SiteID != 0) ? that.tbl_Site.SiteName : null,
                    SiteEngineer = (that.tbl_Person1.PersonID != 0) ? that.tbl_Person1.PersonName : null,
                    SeniorIncharge = (that.tbl_Person.PersonID != 0) ? that.tbl_Person.PersonName : null,
                    StoreKeeper = (that.tbl_Person2.PersonID != 0) ? that.tbl_Person2.PersonName : null,
                    OrderNo = that.tbl_OperationOrderReg.OrderNo,
                    ApprovedByName = (that.tbl_User1 != null)?that.tbl_User1.LoginName:null,
                   
                };
            }
        }

        public static List<OperationOrderVO> ToOperationOrderVOList(this List<tbl_OperationOrder> list)
        {
            if (list == null || list.Count() == 0)
            {
                return null;
            }
            else
            {
                List<OperationOrderVO> result = new List<OperationOrderVO>();

                foreach (tbl_OperationOrder OperationOrder in list)
                {
                    result.Add(OperationOrder.ToOperationOrderVO());
                }
                return result;
            }
        }

        public static tbl_OperationOrder ToOperationOrderTbl(this OperationOrderVO that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new tbl_OperationOrder()
                {
                    OOID = that.OOID,
                    OODate = that.OODate,
                    OORID = that.OORID,
                    BuildingTypeID = that.BuildingTypeID,
                    ApprovedBy = that.ApprovedBy,
                    CompleteApprove = that.CompleteApprove,
                    CompletePrepare = that.CompletePrepare,
                    DetailInstruction = that.DetailInstruction,
                    Duration = that.Duration,
                    SeniorInchargeID = that.SeniorInchargeID,
                    SiteEngineerID = that.SiteEngineerID,
                    SiteID = that.SiteID,
                    StoreKeeperID = that.StoreKeeperID,
                    ModifiedBy = that.ModifiedBy,
                    ModifiedDate = that.ModifiedDate,
                };
            }
        }

        #endregion
    }
}
