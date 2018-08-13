using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminApp.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}