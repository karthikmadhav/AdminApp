using Admin.App.Common;
using Admin.App.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminApp.App_Start
{
    public static class RBAC_ExtendedMethods
    {
        public static bool HasPermission(this ControllerBase controller, Utility.PageAccessType permission)
        {
            //Verify authorization with controller name and type of action
            bool valRes = false;
            string controllerName = controller.ControllerContext.RouteData.Values["controller"].ToString();
            if (controllerName == "CompanySettings")
                controllerName = "MasterSettings";
            if (controllerName == "UserDetails")
                controllerName = "MasterSettings";
            List<MenuPermission> menuPer = SessionPersister._PrivilegeInfo;
            if (menuPer != null)
            {
                MenuPermission menuPermission = menuPer.Where(x => x.ControllerName == controllerName).FirstOrDefault();
                switch (permission)
                {
                    case Utility.PageAccessType.CanView:
                        if (menuPermission.CanView == true)
                            valRes= true;
                        break;
                    case Utility.PageAccessType.CanCreate:
                        if (menuPermission.CanCreate == true)
                            valRes = true;
                        break;
                    case Utility.PageAccessType.CanEdit:
                        if (menuPermission.CanEdit == true)
                            valRes = true;
                        break;
                    case Utility.PageAccessType.CanDelete:
                        if (menuPermission.CanDelete == true)
                            valRes = true;
                        break;
                }
            }
            return valRes;
        }
        public static bool HasPermission(string requiredPermission)
        {
            bool bFound = false;
            if (requiredPermission == "CompanySettings")
                requiredPermission = "MasterSettings";
            if(requiredPermission== "UserDetails")
                requiredPermission = "MasterSettings";

            List<MenuPermission> menuPer = SessionPersister._PrivilegeInfo;
            if (menuPer != null)
            {
                MenuPermission permission = menuPer.Where(x => x.ControllerName == requiredPermission).FirstOrDefault();
                if ((permission != null) && (permission.CanCreate == true || permission.CanDelete == true || permission.CanEdit == true || permission.CanView == true))
                {
                    bFound = true;
                }
            }
            return bFound;
        }
    }
}