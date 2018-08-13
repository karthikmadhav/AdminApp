using Admin.App.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.App.Common.Models;
using Admin.App.DataAccessLayer.Provider;
using Admin.App.DataAccessLayer.Interface;

namespace Admin.App.BusinessLayer.Services
{
    public class RoleService : IRole
    {
        IRoleProvider _iRoleProvider;
        public RoleService(IRoleProvider iRoleProvider)
        {
            _iRoleProvider = iRoleProvider;
        }
        public List<RoleDetails> GetAllRoles()
        {
            return _iRoleProvider.GetAllRoles();
        }

        public bool SaveRole(RoleDetails roleDetails)
        {
            if(roleDetails.RoleId>0)
                return _iRoleProvider.UpdateRole(roleDetails);
            else
                return _iRoleProvider.SaveRole(roleDetails);
        }

        public bool UpdateRole(RoleDetails roleDetails)
        {
            throw new NotImplementedException();
        }
    }
}
