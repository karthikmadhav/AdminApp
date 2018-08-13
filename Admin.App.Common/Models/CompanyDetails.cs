using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Admin.App.Common.Models
{
   public class CompanyDetails
    {
        public int CompanyID { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [Required]
        public string PrimaryMailID { get; set; }
        [Required]
        public string PrimaryPhoneNo { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Pincode { get; set; }
        public string GSTNO { get; set; }
        public string ImagePath { get; set; }
        public string ImageExt { get; set; }
    }
}
