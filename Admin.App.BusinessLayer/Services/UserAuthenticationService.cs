using Admin.App.Common.Interface;
using Admin.App.Common.Models;
using Admin.App.DataAccessLayer.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.App.BusinessLayer.Services
{
   public class UserAuthenticationService : IUserAuthentication
    {
        private IUserAuthentication _IUserAuthentication;
        public UserAuthenticationService()
        {
            _IUserAuthentication = new UserAuthenticationProvider();
        }
        public LoginDetails GetUserAuthentication(LoginDetails userCred)
        {
            LoginDetails userAuth = new LoginDetails();
            userAuth = _IUserAuthentication.GetUserAuthentication(userCred);
            return userAuth;
        }
        public LoginDetails GetAuthenticationByName(int userID)
        {
            LoginDetails userAuth = new LoginDetails();
            userAuth = _IUserAuthentication.GetAuthenticationByName(userID);
            return userAuth;
        }
    }
}
