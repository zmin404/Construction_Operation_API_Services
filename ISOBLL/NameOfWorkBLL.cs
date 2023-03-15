using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISODAL;
using ISOServiceVO;

namespace ISOBLL
{
    public class NameOfWorkBLL
    {
        public List<NameOfWorkVO> GetAllNameOfWork()
        {
            try
            {
                return NameOfWorkDAL.GetAllNameOfWork();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<NameOfWorkVO> GetAllNameOfWorkByOPTypeID(int opTypeID)
        {
            try
            {
                return NameOfWorkDAL.GetAllNameOfWorkByOPTypeID(opTypeID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<NameOfWorkVO> GetActiveNameOfWork(bool status)
        {
            try
            {
                return NameOfWorkDAL.GetActiveNameOfWork(status);
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
                Validation(NameOfWorkVO);
                NameOfWorkDAL.AddNameOfWork(NameOfWorkVO);
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
                Validation(NameOfWorkVO);
                NameOfWorkDAL.EditNameOfWork(NameOfWorkVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Validation(NameOfWorkVO NameOfWorkVO)
        {
            if (NameOfWorkVO == null)
            {
                throw new Exception("NameOfWork Object is null.");
            }
            if (string.IsNullOrEmpty(NameOfWorkVO.NameofWork))
            {
                throw new Exception("Invalid NameOfWork Name in NameOfWork Object.");
            }
            if (Convert.ToInt32(NameOfWorkVO.OPTypeID) == 0)
            {
                throw new Exception("Invalid OP Type in NameOfWork Object.");
            }
        }
    }
}
