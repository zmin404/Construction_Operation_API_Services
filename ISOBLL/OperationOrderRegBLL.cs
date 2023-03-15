using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISODAL;
using ISOServiceVO;

namespace ISOBLL
{
    public class OperationOrderRegBLL
    {
        public List<OperationOrderRegVO> GetAllOperationOrderReg()
        {
            try
            {
                return OperationOrderRegDAL.GetAllOperationOrderReg();
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
                Validation(OperationOrderRegVO);
                OperationOrderRegDAL.AddOperationOrderReg(OperationOrderRegVO);
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
                Validation(OperationOrderRegVO);
                OperationOrderRegDAL.EditOperationOrderReg(OperationOrderRegVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetNewOrderNo(int siteID)
        {
            try
            {
                return OperationOrderRegDAL.GetNewOrderNo(siteID);
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
                return OperationOrderRegDAL.GetOperationOrderRegByOORID(OORID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public  List<OperationOrderRegVO> GetOORListByFilter(DateTime fromDate, DateTime toDate, int siteID, int buildingID, string orderNo)
        {
            try
            {
                return OperationOrderRegDAL.GetOORListByFilter(fromDate,toDate,siteID,buildingID,orderNo );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Validation(OperationOrderRegVO OperationOrderRegVO)
        {
            if (OperationOrderRegVO == null)
            {
                throw new Exception("OperationOrderReg Object is null.");
            }
            if (string.IsNullOrEmpty(OperationOrderRegVO.OrderNo))
            {
                throw new Exception("Invalid Order No in OperationOrderReg Object.");
            }
        }
    }
}
