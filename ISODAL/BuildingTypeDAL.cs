using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISOServiceVO;

namespace ISODAL
{
    public static class BuildingTypeDAL
    {
        public static List<BuildingTypeVO> GetAllBuildingType()
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                return context.tbl_BuildingType.ToList().ToBuildingTypeVOList();
            }
        }

        public static List<BuildingTypeVO> GetActiveBuildingType(bool status)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                return context.tbl_BuildingType.Where(x => x.Active == status).ToList().ToBuildingTypeVOList();
            }
        }

        public static void AddBuildingType(BuildingTypeVO BuildingTypeVO)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                context.tbl_BuildingType.Add(BuildingTypeVO.ToBuildingTypeTbl());
                context.SaveChanges();
            }
        }

        public static void EditBuildingType(BuildingTypeVO BuildingTypeVO)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                tbl_BuildingType temp = BuildingTypeVO.ToBuildingTypeTbl();
                context.tbl_BuildingType.Attach(temp);
                context.Entry(temp).State = System.Data.EntityState.Modified;
                context.SaveChanges();
            }
        }

        #region Translate

        public static BuildingTypeVO ToBuildingTypeVO(this tbl_BuildingType that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new BuildingTypeVO()
                {
                    BuildingTypeID = that.BuildingTypeID,
                    BuildingType = that.BuildingType ,
                    Active = that.Active,
                    ModifiedBy = that.ModifiedBy,
                    ModifiedDate = that.ModifiedDate,
                };
            }
        }

        public static List<BuildingTypeVO> ToBuildingTypeVOList(this List<tbl_BuildingType> list)
        {
            if (list == null || list.Count() == 0)
            {
                return null;
            }
            else
            {
                List<BuildingTypeVO> result = new List<BuildingTypeVO>();

                foreach (tbl_BuildingType BuildingType in list)
                {
                    result.Add(BuildingType.ToBuildingTypeVO());
                }
                return result;
            }
        }

        public static tbl_BuildingType ToBuildingTypeTbl(this BuildingTypeVO that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new tbl_BuildingType()
                {
                    BuildingTypeID = that.BuildingTypeID,
                    BuildingType = that.BuildingType,
                    Active = that.Active,
                    ModifiedBy = that.ModifiedBy,
                    ModifiedDate = that.ModifiedDate,
                };
            }
        }

        #endregion
    }
}
