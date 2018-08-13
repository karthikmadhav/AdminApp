using Admin.App.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.App.Common.Models;
using Admin.App.DataAccessLayer.Provider;

namespace Admin.App.BusinessLayer.Services
{
   public class UserDetailsService : IUserDetails
    {
        private IUserDetails _IUserDetails;
        public UserDetailsService()
        {
            _IUserDetails = new UserDetailsProvider();
        }

        public List<UserDetails> GetAllUser()
        {
            return _IUserDetails.GetAllUser();
        }

        public UserDetails GetUserByID(int userID)
        {
            throw new NotImplementedException();
        }

        public int SaveUser(UserDetails userDetails)
        {
            return _IUserDetails.SaveUser(userDetails);
        }
        public bool UpdateUser(UserDetails userDetails)
        {
            return _IUserDetails.UpdateUser(userDetails);

        }
    }
}
