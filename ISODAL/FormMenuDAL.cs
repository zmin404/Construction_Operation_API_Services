using ISOServiceVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISODAL
{
    public static class FormMenuDAL
    {

        //public static List<FormMenuVO> GetPermissionFormByRoleID(int id)
        //{
        //    using (ISOFormatEntities context = new ISOFormatEntities())
        //    {
        //        List<tbl_FormMenu> list = (from c in context.tbl_UserRolePermission where c.RoleID == id && c.tbl_FormMenu.Active == true
        //                                   select c.tbl_FormMenu).OrderBy(x => x.FormID).ToList();
        //        return list.ToFormMenuVOList();
        //    }
        //}

        public static List<FormMenuVO> GetActiveFormMenu()
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                var query = context.tbl_FormMenu.Where(x => x.Active == true).OrderBy(x=>x.FormID).ToList();

                return query.ToFormMenuVOList();
            }
        }

        //For System Configure
        public static List<FormMenuVO> GetAllFormMenu()
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                return context.tbl_FormMenu.ToList().ToFormMenuVOList();
            }
        }

        public static void AddFormMenu(FormMenuVO FormMenuVO)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                context.tbl_FormMenu.Add(FormMenuVO.ToFormMenuTbl());
                context.SaveChanges();
            }
        }

        public static void EditFormMenu(FormMenuVO FormMenuVO)
        {
            using (ISOFormatEntities context = new ISOFormatEntities())
            {
                tbl_FormMenu temp = FormMenuVO.ToFormMenuTbl();
                context.tbl_FormMenu.Attach(temp);
                context.Entry(temp).State = System.Data.EntityState.Modified;
                context.SaveChanges();
            }
        }

        #region Translate

        public static FormMenuVO ToFormMenuVO(this tbl_FormMenu that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new FormMenuVO()
                {
                    FormID = that.FormID,
                    FormDescription = that.FormDescription,
                    FormName = that.FormName,
                    ParentFormID = that.ParentFormID,
                    GroupName = that.GroupName,
                    Active = that.Active
                };
            }
        }

        public static List<FormMenuVO> ToFormMenuVOList(this List<tbl_FormMenu> list)
        {
            if (list == null || list.Count() == 0)
            {
                return null;
            }
            else
            {
                List<FormMenuVO> result = new List<FormMenuVO>();

                foreach (tbl_FormMenu formmenu in list)
                {
                    result.Add(formmenu.ToFormMenuVO());
                }
                return result;
            }
        }

        public static tbl_FormMenu ToFormMenuTbl(this FormMenuVO that)
        {
            if (that == null)
            {
                return null;
            }
            else
            {
                return new tbl_FormMenu()
                {
                    FormID = that.FormID,
                    FormDescription = that.FormDescription,
                    FormName = that.FormName,
                    ParentFormID = that.ParentFormID,
                    GroupName = that.GroupName,
                    Active = that.Active
                };
            }
        }

        #endregion

    }
}
