using Admin.App.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.App.Common.Interface
{
   public interface ICustomerDetails
    {
        List<CustomerDet> GetCustomerList();
        int SaveCustomer(CustomerDet CustDetails);
        bool UpdateCustomer(CustomerDet CustDetails);
        bool DeleteCustomer(int CustomerId);
        CustomerDet GetCustomerByID(int custID);
    }
}
