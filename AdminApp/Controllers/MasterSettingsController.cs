using Admin.App.Common.Interface;
using Admin.App.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AdminApp.Controllers
{
    public class MasterSettingsController : Controller
    {
        private IRole _IRole;
        private ICommon _ICommon;

        public MasterSettingsController(IRole iRole, ICommon iCommon)
        {
            _IRole = iRole;
            _ICommon = iCommon;
        }
        // GET: MasterSettings
        public ActionResult Role()
        {
            Session["UserID"] = "Karthik";
            //Assing values to form auth cookies
            FormsAuthentication.SetAuthCookie("KarthikMadhavan", true);

            List<RoleDetails> roles = new List<RoleDetails>();
            roles = _IRole.GetAllRoles();
            return View(roles);
        }
        [HttpPost]
        public ActionResult SaveRole(RoleDetails roleDetails)
        {
            if (roleDetails.Name != string.Empty)
            {
                _IRole.SaveRole(roleDetails);
                return Json("Success");
            }
            else
            {
                return Json("error");
            }
        }
        public ActionResult RolePrivileges()
        {
            MenuPermission privilege = new MenuPermission();
            privilege.RolesItems = _IRole.GetAllRoles();
            privilege.MenuItems = _ICommon.GetMenu().Where(x => x.MenuParentID == 0).ToList();
            return View(privilege);
        }
        public ActionResult SaveRolePrivilege(MenuPermission menuPermission)
        {
            if(_ICommon.SavePrivilege(menuPermission))
            return Json("Success");
            else
            return Json("error");
        }
        public ActionResult GetPrivilegeByRole(MenuPermission menuPermission)
        {
           List<MenuPermission> permission = _ICommon.GetPrivilegeByRole((int)menuPermission.RoleID);
            List<Menu> menuList = _ICommon.GetMenu();
            if (permission != null)
            {
                permission.ForEach(mName =>
                {
                    mName.MenuName = menuList.Where(x => x.MID == mName.MenuID).FirstOrDefault().MenuName;
                });
            }
            return Json(permission);
        }
        public ActionResult Privilege()
        {
            MenuPermission privilege = new MenuPermission();
            privilege.RolesItems = _IRole.GetAllRoles();
            privilege.MenuItems = _ICommon.GetMenu().Where(x => x.MenuParentID == 0).ToList();
            return View(privilege);
        }
    }
}