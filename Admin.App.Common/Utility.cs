using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.App.Common
{
   public class Utility
    {
        public enum PageAccessType
        {
            CanView = 1,
            CanCreate = 2,
            CanEdit = 3,
            CanDelete = 4
        }
    }
}
