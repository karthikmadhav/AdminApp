using Admin.App.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.App.Common.Interface
{
   public interface IUserDetails
    {
        int SaveUser(UserDetails userDetails);
        List<UserDetails> GetAllUser();
        UserDetails GetUserByID(int userID);
        bool UpdateUser(UserDetails userDetails);
    }
}
