using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISODAL;
using ISOServiceVO;

namespace ISOBLL
{
    public class OperationOrderBLL
    {
        public List<OperationOrderVO> GetAllOperationOrder()
        {
            try
            {
                return OperationOrderDAL.GetAllOperationOrder();
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
                Validation(OperationOrderVO);
                OperationOrderDAL.AddOperationOrder(OperationOrderVO);
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
                Validation(OperationOrderVO);
                OperationOrderDAL.EditOperationOrder(OperationOrderVO);
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
               return OperationOrderDAL.GetOperationOrderCompletePrepare();
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
                return OperationOrderDAL.GetOperationOrderCompleteApprove();
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
                return OperationOrderDAL.GetOOListByFilter(orderNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Validation(OperationOrderVO OperationOrderVO)
        {
            if (OperationOrderVO == null)
            {
                throw new Exception("OperationOrder Object is null.");
            }
        }
    }
}
