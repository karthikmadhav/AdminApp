using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminApp.App_Start
{
    public class UserAuthorizationFilter : AuthorizeAttribute
    {
        public UserAuthorizationFilter()
        {

        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            string controller = filterContext.RouteData.Values["controller"].ToString();
            string action = filterContext.RouteData.Values["action"].ToString();

            filterContext.HttpContext.Response.Cache.SetNoServerCaching();
            filterContext.HttpContext.Response.Cache.SetNoStore();

            if ((controller == "Account" && (action == "Login" || action == "LogOff" || action == "Error" || action == "PageNotFound" || action == "UnAuthenticated"))||
                (controller == "Home" && (action == "SiteMenu")))
                return;

            string uname = filterContext.HttpContext.User.Identity.Name.ToString();
            bool isAuthenticated = filterContext.HttpContext.User.Identity.IsAuthenticated;

            bool isAuthorized = false;

            if (isAuthenticated)
            {
                //Take Role based access and verify
                string requiredPermission = controller;


            }
        }
        public bool HasPermission(string requiredPermission, List<string> roles)
        {
            bool bFound = false;
            bool res = false;
            foreach (string role in roles)
            {
                //res = role.Permissions.Any(x => x.PermissionDescription.Equals(requiredPermission));
                if (res)
                    bFound = true;
            }
            return bFound;
        }
    }
}