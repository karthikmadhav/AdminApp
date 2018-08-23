using Admin.App.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.App.Common.Models;
using Admin.App.DataAccessLayer.Provider;

namespace Admin.App.BusinessLayer.Services
{
    public class CustomerService : ICustomerDetails
    {
        public ICustomerDetails _ICustomerDetails;
        public CustomerService()
        {
            _ICustomerDetails = new CustomerProvider();
        }
        public bool DeleteCustomer(int CustomerId)
        {
            throw new NotImplementedException();
        }

        public CustomerDet GetCustomerByID(int custID)
        {
            return _ICustomerDetails.GetCustomerByID(custID);
        }

        public List<CustomerDet> GetCustomerList()
        {
            return _ICustomerDetails.GetCustomerList();
        }

        public int SaveCustomer(CustomerDet CustDetails)
        {
            return _ICustomerDetails.SaveCustomer(CustDetails);
        }

        public bool UpdateCustomer(CustomerDet CustDetails)
        {
            return _ICustomerDetails.UpdateCustomer(CustDetails);
        }
    }
}
