using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminApp.App_Start
{
    public class SessionExpireAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //TO-DO implement session out url redirect
            var currentURL = filterContext.HttpContext.Request.RawUrl;
            if (currentURL == "/" || currentURL.StartsWith("/Home/"))
              return;
            string redirectUrl = null;
            if (HttpContext.Current.Session["_UserInfo"] == null)
            {

            }
            return;
        }
    }
}