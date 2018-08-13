using Admin.App.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.App.Common.Interface
{
   public interface ICommon
    {
        List<Menu> GetMenu();
        List<MenuPermission> GetPrivilegeByRole(int roleID);
        bool SavePrivilege(MenuPermission priv);

    }
}
