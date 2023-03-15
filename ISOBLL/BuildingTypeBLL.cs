using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISODAL;
using ISOServiceVO;

namespace ISOBLL
{
    public class BuildingTypeBLL
    {
        public List<BuildingTypeVO> GetAllBuildingType()
        {
            try
            {
                return BuildingTypeDAL.GetAllBuildingType();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BuildingTypeVO> GetActiveBuildingType(bool status)
        {
            try
            {
                return BuildingTypeDAL.GetActiveBuildingType(status);
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
                Validation(BuildingTypeVO);
                BuildingTypeDAL.AddBuildingType(BuildingTypeVO);
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
                Validation(BuildingTypeVO);
                BuildingTypeDAL.EditBuildingType(BuildingTypeVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Validation(BuildingTypeVO BuildingTypeVO)
        {
            if (BuildingTypeVO == null)
            {
                throw new Exception("BuildingType Object is null.");
            }
            if (string.IsNullOrEmpty(BuildingTypeVO.BuildingType))
            {
                throw new Exception("Invalid BuildingType Name in BuildingType Object.");
            }
        }
    }
}
