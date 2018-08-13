using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.App.Common.Models
{
    public class UserDetails
    {
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeCode { get; set; }
        [Required]
        public int CompanyID{get;set;}
        [Required]
        public int RoleId { get; set; }
        public bool Active { get; set; }
        public List<RoleDetails> roleDetails { get; set; }
        public List<CompanyDetails> companyDetails { get; set; }
        public string RoleName { get; set; }
        public string CompanyName { get; set; }
        [Required]
        public string Address { get; set; }
        public string Address1 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Pincode { get; set; }
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        public string PrimaryEmailID { get; set; }
        public string PhoneNumber { get; set; }
    }
}
