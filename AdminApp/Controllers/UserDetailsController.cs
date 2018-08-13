using Admin.App.Common.Interface;
using Admin.App.Common.Models;
using Admin.App.DataAccessLayer.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminApp.Controllers
{
    public class UserDetailsController : Controller
    {
        private IUserDetails _IUserDetails;
        private ICompanyDetails _ICompanyDetails;
        private IRole _IRole;
        private IUserAuthentication _IUserAuthentication;
        public UserDetailsController(IUserDetails UserDetails, ICompanyDetails CompanyDetails, IRole Role, IUserAuthentication UserAuthentication)
        {
            _IUserDetails = UserDetails;
            _ICompanyDetails = CompanyDetails;
            _IRole = Role;
            _IUserAuthentication = UserAuthentication;
        }
        [HttpGet]
        public ActionResult NewUser(UserDetails userDetails)
        {
            UserDetails userDet = new UserDetails();
            userDet.roleDetails = _IRole.GetAllRoles();
            userDet.companyDetails = _ICompanyDetails.GetCompanyList();

            return View(userDet);
        }
        [HttpPost]
        public ActionResult SaveUser(UserDetails userDet)
        {
            if (ModelState.IsValid)
            {
                if (userDet.UserId > 0)
                {
                    _IUserDetails.UpdateUser(userDet);
                }
                else
                {
                    int userID = _IUserDetails.SaveUser(userDet);
                }
                
            }
            return RedirectToAction("ViewUser");
        }
        public ActionResult ViewUser()
        {
            List<UserDetails> userDet = new List<UserDetails>();
            userDet = _IUserDetails.GetAllUser();
            userDet.ForEach(users =>
            {
                users.CompanyName = _ICompanyDetails.GetCompanyByID(users.CompanyID).CompanyName;
                users.RoleName = _IRole.GetAllRoles().Where(x => x.RoleId == users.RoleId).Select(y => y.Name).FirstOrDefault() ?? string.Empty;
            });
            return View(userDet);
        }
        public ActionResult UpdateUser(int id)
        {
            if (id > 0)
            {
                UserDetails userDetails = _IUserDetails.GetAllUser().Where(x => x.UserId == id).FirstOrDefault();
                userDetails.roleDetails = _IRole.GetAllRoles();
                userDetails.companyDetails = _ICompanyDetails.GetCompanyList();
                LoginDetails userAuth = new LoginDetails();
                userAuth = _IUserAuthentication.GetAuthenticationByName(id);
                if (userAuth != null)
                {
                    userDetails.UserName = userAuth.UserName;
                    userDetails.Password = userAuth.Password;
                }
                return View("NewUser", userDetails);
            }
            return View("ViewUser");
        }
        public ActionResult GetUserDetails(string UserID)
        {
            int uID = Convert.ToInt32(UserID);
            UserDetails users = _IUserDetails.GetAllUser().Where(x=>x.UserId== uID).FirstOrDefault();
            users.CompanyName = _ICompanyDetails.GetCompanyByID(users.CompanyID).CompanyName;
            users.RoleName = _IRole.GetAllRoles().Where(x => x.RoleId == users.RoleId).Select(s => s.Name).FirstOrDefault();
            return Json(users, JsonRequestBehavior.AllowGet);
        }
    }
}