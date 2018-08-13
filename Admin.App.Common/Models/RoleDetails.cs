using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.App.Common.Models
{
   public class RoleDetails
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
