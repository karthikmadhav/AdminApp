using Admin.App.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using System.Web.Security;

namespace AdminApp.App_Start
{
    public class UserAuthenticationFilter: ActionFilterAttribute, IAuthenticationFilter
    {
        public string type = string.Empty;
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            string controller = filterContext.RouteData.Values["controller"].ToString();
            string action = filterContext.RouteData.Values["action"].ToString();
            string verb = filterContext.HttpContext.Request.HttpMethod;

            if ((controller == "Account" && (action == "Login" || action == "LogOff" || action == "Error" || action == "PageNotFound" || action == "UnAuthorized"))
                ||(controller == "Home" && (action=="SiteMenu" || action== "Index")))
                return;

            //Authentication
            bool isAuthenticated=false;
            bool isAuthorized = false;
            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket != null && !authTicket.Expired)
                {
                    if (string.IsNullOrEmpty(authTicket.Name) || (SessionPersister._userID < 0))
                    {
                        filterContext.Result = new HttpUnauthorizedResult();
                        isAuthenticated = false;
                        type = "Authentication";
                    }
                    else
                    {
                        isAuthenticated = true;
                    }
                }
            }
            //Authorization on Controller Level
            if (isAuthenticated)
            {
                string requiredPermission = controller;

                //Get Role based access and check this controller has permission to access
                isAuthorized = RBAC_ExtendedMethods.HasPermission(requiredPermission);
                if (!isAuthorized)
                {
                    filterContext.Result = new HttpUnauthorizedResult();
                    type = "Authorization";
                }
            }
        }
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                if (type == "Authorization")
                {
                     filterContext.Result = new RedirectToRouteResult(
                     new RouteValueDictionary
                         {
                                { "action", "UnAuthorized" },
                                { "controller", "Account" }
                         });
                    filterContext.HttpContext.Response.StatusCode = 401;
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(
                      new RouteValueDictionary
                          {
                                { "action", "Login" },
                                { "controller", "Account" }
                          });
                    filterContext.HttpContext.Response.StatusCode = 403;
                }
            }
        }
       
    }
}