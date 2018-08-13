using Admin.App.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.App.Common.Models;
using Admin.App.DataAccessLayer.DataModel;

namespace Admin.App.DataAccessLayer.Provider
{
    public class CommonProvider : ICommon
    {
        public CommonProvider()
        {

        }
        public List<Menu> GetMenu()
        {
            using (var context = new AdminAppEntities())
            {
                var menuList = context.MenuMasters.ToList();
                if (menuList != null)
                {
                    return menuList.Select(x => new Menu
                    {
                        MenuName = x.MenuName,
                        MID = x.MenuId,
                        ActionName = x.ActionName,
                        ControllerName = x.ControllerName,
                        MenuParentID = (int)x.MenuParentId,
                        IconStyle = x.IconStyle,
                        MenuURL = x.MenuUrl
                    }).ToList();
                }
                else
                    return null;

            }
        }

        public List<MenuPermission> GetPrivilegeByRole(int roleID)
        {
            using (var context = new AdminAppEntities())
            {
                var privItems = context.MenuPrivileges.Where(x=>x.RoleID==roleID).ToList();
                if(privItems!=null && privItems.Count > 0)
                {
                    return privItems.Select(x => new MenuPermission {
                        MenuID=x.MenuID,
                        RoleID=x.RoleID,
                        CanCreate=(bool)x.CanCreate,
                        CanEdit= (bool)x.CanEdit,
                        CanDelete= (bool)x.CanDelete,
                        CanView= (bool)x.CanView
                    }).ToList();
                }
                return null;
            }
        }

        public bool SavePrivilege(MenuPermission priv)
        {
            bool result=false;
            using (var context = new AdminAppEntities())
            {
                var privilege = context.MenuPrivileges.ToList();
                MenuPrivilege menuPriv = new MenuPrivilege();
                menuPriv = privilege.Where(x => x.RoleID == priv.RoleID && x.MenuID == priv.MenuID).FirstOrDefault();
                if (menuPriv != null)
                {
                    context.MenuPrivileges.Remove(menuPriv);
                    context.SaveChanges();
                }
                    MenuPrivilege menu = new MenuPrivilege
                    {
                        MenuID = priv.MenuID,
                        RoleID = priv.RoleID,
                        CanCreate = priv.CanCreate,
                        CanEdit = priv.CanEdit,
                        CanView = priv.CanView,
                        CanDelete = priv.CanDelete
                    };
                    context.MenuPrivileges.Add(menu);
                    context.SaveChanges();
                    if (menu.PrivilegeID > 0)
                        result = true;
                    else
                        result = false;
            }
            return result;
        }
    }
}
