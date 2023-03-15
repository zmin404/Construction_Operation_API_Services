using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISOServiceVO;
using System.Transactions;

namespace ISODAL
{
    public static class OperationOrderRegDAL
    {
        public static List<OperationOrderRegVO> GetAllOperationOrderReg()
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                return context.tbl_OperationOrderReg.ToList().ToOperationOrderRegVOList();
            }
        }

        public static void AddOperationOrderReg(OperationOrderRegVO OperationOrderRegVO)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (ISOFormatEntities context = new ISOFormatEntities())
                {
                    context.tbl_OperationOrderReg.Add(OperationOrderRegVO.ToOperationOrderRegTbl());
                    context.SaveChanges();
                    if (OperationOrderRegVO.MasterSchedulePDFList != null)
                    {
                        foreach (MasterSchedulePDFVO detail in OperationOrderRegVO.MasterSchedulePDFList)
                        {
                            context.tbl_MasterSchedulePDF.Add(detail.ToMasterSchedulePDFTbl());
                            context.SaveChanges();
                        }
                    }
                    if (OperationOrderRegVO.ContractPDFList != null)
                    {
                        foreach (ContractPDFVO detail in OperationOrderRegVO.ContractPDFList)
                        {
                            context.tbl_ContractPDF.Add(detail.ToContractPDFTbl());
                            context.SaveChanges();
                        }
                    }
                }
                scope.Complete();
            }
        }

        public static void EditOperationOrderReg(OperationOrderRegVO OperationOrderRegVO)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (ISOFormatEntities context = new ISOFormatEntities())
                {
                    tbl_OperationOrderReg temp = OperationOrderRegVO.ToOperationOrderRegTbl();
                    context.tbl_OperationOrderReg.Attach(temp);
                    context.Entry(temp).State = System.Data.EntityState.Modified;
                    context.SaveChanges();

                    List<tbl_MasterSchedulePDF> oldDetail = context.tbl_MasterSchedulePDF.Where(x => x.SiteID == temp.SiteID).ToList();
                    foreach (tbl_MasterSchedulePDF detail in oldDetail)
                    {
                        context.tbl_MasterSchedulePDF.Attach(detail);
                        context.Entry(detail).State = System.Data.EntityState.Deleted;
                        context.SaveChanges();
                    }
                    if (OperationOrderRegVO.MasterSchedulePDFList != null)
                    {
                        foreach (MasterSchedulePDFVO detail in OperationOrderRegVO.MasterSchedulePDFList)
                        {
                            context.tbl_MasterSchedulePDF.Add(detail.ToMasterSchedulePDFTbl());
                            context.SaveChanges();
                        }
                    }

                    List<tbl_ContractPDF> oldDetail1 = context.tbl_ContractPDF.Where(x => x.SiteID == temp.SiteID).ToList();
                    foreach (tbl_ContractPDF detail in oldDetail1)
                    {
                        context.tbl_ContractPDF.Attach(detail);
                        context.Entry(detail).State = System.Data.EntityState.Deleted;
                        context.SaveChanges();
                    }
                    if (OperationOrderRegVO.ContractPDFList != null)
                    {
                        foreach (ContractPDFVO detail in OperationOrderRegVO.ContractPDFList)
                        {
                            context.tbl_ContractPDF.Add(detail.ToContractPDFTbl());
                            context.SaveChanges();
                        }
                    }
                    scope.Complete();
                }
            }
        }

        public static string GetNewOrderNo(int siteID)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                //int count = context.tbl_OperationOrderReg.Where(x => x.OrderDate.Year == DateTime.Now.Year).Count() + 1;
                //return string.Format("{0}-{1}", DateTime.Now.Year.ToString().Substring(2, 2), count.ToString("D5"));
                int count = context.tbl_OperationOrderReg.Where(x => x.SiteID == siteID && x.OrderDate.Year == DateTime.Now.Year).Count() + 1;
                string sitename = context.tbl_Site.Where(x => x.SiteID == siteID).FirstOrDefault().SiteName.Substring(0,3);
                return string.Format("{0}-{1}-{2}", sitename,DateTime.Now.Year.ToString().Substring(2, 2), count.ToString("D5"));
            }
        }

        public static OperationOrderRegVO GetOperationOrderRegByOORID(int OORID)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                return context.tbl_OperationOrderReg.Where(x => x.OORID == OORID).FirstOrDefault().ToOperationOrderRegVO();
            }
        }

        public static List<OperationOrderRegVO> GetOORListByFilter(DateTime fromDate, DateTime toDate, int siteID, int buildingID, string orderNo)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                context.Configuration.ProxyCreationEnabled = false;
                IQueryable<tbl_OperationOrderReg> query = context.tbl_OperationOrderReg.Include("tbl_Site").Include("tbl_BuildingType").Include("tbl_Person");

                if (fromDate != DateTime.MinValue && toDate != DateTime.MinValue)
                {
                    query = query.Where(x => EntityFunctions.TruncateTime(x.OrderDate) >= fromDate.Date && EntityFunctions.TruncateTime(x.OrderDate) <= toDate);
                }
                if (siteID != 0)
                {
                    query = query.Where(x => x.tbl_Site.SiteID == siteID);
                }
                if (buildingID != 0)
                {
                    query = query.Where(x => x.tbl_BuildingType.BuildingTypeID  == buildingID);
                }
                if (orderNo != null)
                {
                    query = query.Where(x=>x.OrderNo==orderNo);
                }
                if (query != null)
                {
                    var list = query.Select(x => new OperationOrderRegVO ()
                    {
                        OORID=x.OORID,
                        OrderNo=x.OrderNo,
                        Site=x.tbl_Site.SiteName,
                        BuildingType=x.tbl_BuildingType.BuildingType,
                        CustomerName=x.tbl_Site.CustomerName,
                        SiteEngineer = x.tbl_Person2.PersonName,
                        SeniorIncharge = x.tbl_Person.PersonName,
                        StartingDate=x.StartingDate,
                        Remark=x.Remark,
                    }).ToList();
                    return list;
                }
                return null;
            }
        }


        #region Translate

        public static OperationOrderRegVO ToOperationOrderRegVO(this tbl_OperationOrderReg that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new OperationOrderRegVO()
                {
                    OORID = that.OORID,
                    OrderDate = that.OrderDate,
                    OrderNo = that.OrderNo,
                    BuildingTypeId = that.BuildingTypeId,
                    Remark = that.Remark,
                    SeniorInchargeID = that.SeniorInchargeID,
                    SiteEngineerID = that.SiteEngineerID,
                    SiteID = that.SiteID,
                    StoreKeeperID = that.StoreKeeperID,
                    StartingDate = that.StartingDate,
                    ModifiedBy = that.ModifiedBy,
                    ModifiedDate = that.ModifiedDate,

                    BuildingType = (that.tbl_BuildingType.BuildingTypeID != 0) ? that.tbl_BuildingType.BuildingType : null,
                    Site = (that.tbl_Site.SiteID != 0) ? that.tbl_Site.SiteName : null,
                    SeniorIncharge = (that.tbl_Person.PersonID != 0) ? that.tbl_Person.PersonName : null,
                    StoreKeeper = (that.tbl_Person1.PersonID != 0) ? that.tbl_Person1.PersonName : null,
                    SiteEngineer = (that.tbl_Person2.PersonID != 0) ? that.tbl_Person2.PersonName : null,
                    CustomerName = (that.tbl_Site.CustomerName != null) ? that.tbl_Site.CustomerName : null,
                    MasterSchedulePDFList = (that.tbl_Site.tbl_MasterSchedulePDF != null) ? that.tbl_Site.tbl_MasterSchedulePDF.Select(x => new MasterSchedulePDFVO() { ID = x.ID, MasterSchedulePDF = x.MasterSchedulePDF, SiteID = x.SiteID }).ToList() : null,
                    ContractPDFList = (that.tbl_Site.tbl_ContractPDF != null) ? that.tbl_Site.tbl_ContractPDF.Select(x => new ContractPDFVO() { ID = x.ID, ContractPDF = x.ContractPDF, SiteID = x.SiteID }).ToList() : null,
                };
            }
        }

        public static List<OperationOrderRegVO> ToOperationOrderRegVOList(this List<tbl_OperationOrderReg> list)
        {
            if (list == null || list.Count() == 0)
            {
                return null;
            }
            else
            {
                List<OperationOrderRegVO> result = new List<OperationOrderRegVO>();

                foreach (tbl_OperationOrderReg OperationOrderReg in list)
                {
                    result.Add(OperationOrderReg.ToOperationOrderRegVO());
                }
                return result;
            }
        }

        public static tbl_OperationOrderReg ToOperationOrderRegTbl(this OperationOrderRegVO that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new tbl_OperationOrderReg()
                {
                    OORID = that.OORID,
                    OrderDate = that.OrderDate,
                    OrderNo = that.OrderNo,
                    BuildingTypeId = that.BuildingTypeId,
                    Remark = that.Remark,
                    SeniorInchargeID = that.SeniorInchargeID,
                    SiteEngineerID = that.SiteEngineerID,
                    SiteID = that.SiteID,
                    StoreKeeperID = that.StoreKeeperID,
                    StartingDate = that.StartingDate,
                    ModifiedBy = that.ModifiedBy,
                    ModifiedDate = that.ModifiedDate,
                };
            }
        }

        #endregion
    }
}
