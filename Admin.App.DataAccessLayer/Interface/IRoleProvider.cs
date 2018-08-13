using Admin.App.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.App.DataAccessLayer.Interface
{
   public interface IRoleProvider
    {
        List<RoleDetails> GetAllRoles();
        bool SaveRole(RoleDetails roleDetails);
        bool UpdateRole(RoleDetails roleDetails);
    }
}
