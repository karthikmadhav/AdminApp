using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.App.Common.Models
{
   public class LoginDetails
    {
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        public int UserAuthID { get; set; }
        public int UserID { get; set; }
        public string ErrorMessage { get; set; }
    }
}
