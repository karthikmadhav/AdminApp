using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.App.Common.Models
{
    public class MenuPermission
    {
        public int PrivilegeID { get; set; }
        public int MenuID{get;set;}
        public int RoleID { get; set; }
        public bool CanView { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public bool CanCreate { get; set; }
        public List<RoleDetails> RolesItems { get; set; }
        public List<Menu> MenuItems { get; set; }
        public string MenuName { get; set; }
        public string ControllerName { get; set; }
    }
}
