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
    public class CommonService : ICommon
    {
        private ICommon _common;
        public CommonService()
        {
            _common = new CommonProvider();
        }
        public List<Menu> GetMenu()
        {
            return _common.GetMenu();
        }

        public List<MenuPermission> GetPrivilegeByRole(int roleID)
        {
            return _common.GetPrivilegeByRole(roleID);
        }

        public bool SavePrivilege(MenuPermission priv)
        {
            return _common.SavePrivilege(priv);
        }
    }
}
