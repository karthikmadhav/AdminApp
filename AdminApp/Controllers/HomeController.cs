using Admin.App.Common.Interface;
using Admin.App.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminApp.Controllers
{
    public class HomeController : Controller
    {
        private ICommon _common;
        public HomeController(ICommon common)
        {
            _common = common;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SiteMenu()
        {
            IEnumerable<Menu> menuList = null;
            menuList = _common.GetMenu();
            //if (SessionPersister.MenuList != null)
            //{
            //    menuList = SessionPersister.MenuList;
            //}
            //else
            //{
            //    int loginUserID = 0;
            //    loginUserID = SessionPersister._userID;
            //    menuList = MenuData.GetMenus(loginUserID);
            //    SessionPersister.MenuList = menuList;
            //}
            return PartialView("SiteMenu", menuList);
        }
        
    }
}