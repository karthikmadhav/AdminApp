using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.App.Common.Models
{
   public class Menu
    {
        public int MID { get; set; }
        public string MenuName { get; set; }
        public string MenuURL { get; set; }
        public int MenuParentID { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string IconStyle { get; set; }
    }
}
