using Admin.App.Common;
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
    public class AccountController : Controller
    {
        private IUserAuthentication _IUserAuthentication;
        private IUserDetails _IUserDetails;
        private ICommon _ICommon;

        public AccountController(IUserAuthentication userAuthentication, IUserDetails UserDetails, ICommon iCommon)
        {
            _IUserAuthentication = userAuthentication;
            _IUserDetails = UserDetails;
            _ICommon = iCommon;
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginDetails details)
        {
            if (ModelState.IsValid)
            {
                LoginDetails logingDetails = _IUserAuthentication.GetUserAuthentication(details);
                if (logingDetails != null)
                {
                    UserDetails userDetails = _IUserDetails.GetAllUser().Where(x => x.UserId == logingDetails.UserID).FirstOrDefault();
                    List<MenuPermission> permission = _ICommon.GetPrivilegeByRole((int)userDetails.RoleId);
                    List<Menu> menuList = _ICommon.GetMenu();
                    if (permission != null)
                    {
                        permission.ForEach(mName =>
                        {
                            mName.MenuName = menuList.Where(x => x.MID == mName.MenuID).FirstOrDefault().MenuName;
                            mName.ControllerName = menuList.Where(x => x.MID == mName.MenuID).FirstOrDefault().ControllerName;
                        });
                    }

                    SessionPersister._userID = logingDetails.UserID;
                    SessionPersister._UserInfo = userDetails;
                    SessionPersister._PrivilegeInfo = permission;
                    Session["UserName"] = userDetails.FirstName + userDetails.LastName;

                    FormsAuthentication.SetAuthCookie(Convert.ToString(logingDetails.UserID), true);
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                else
                {
                    ViewBag.Message = "User not Exists !";
                    return View();
                }
                   
            }
            return View();
        }
        public ActionResult LogOff()
        {
            SessionPersister._userID = 0;
            SessionPersister._UserInfo = null;
            SessionPersister._PrivilegeInfo = null;
            FormsAuthentication.SetAuthCookie("", false);
            return RedirectToAction("Login");
        }
        [HttpPost]
        public ActionResult URLRedirect(string contrl,string viewName)
        {
            return RedirectToAction("Index", "Home", new { area = "" });
        }
        public ActionResult UnAuthorized()
        {
            return View();
        }
    }
}