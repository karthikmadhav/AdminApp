using Admin.App.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.App.Common.Models;
using Admin.App.DataAccessLayer.DataModel;

namespace Admin.App.DataAccessLayer.Provider
{
    public class CustomerProvider : ICustomerDetails
    {
        public bool DeleteCustomer(int CustomerId)
        {
            throw new NotImplementedException();
        }

        public CustomerDet GetCustomerByID(int custID)
        {
            using (var context = new AdminAppEntities())
            {
                var customer = context.CustomerDetails.Where(c => c.CustomerID == custID).FirstOrDefault();
                if (customer != null)
                {
                    CustomerDet custDetails = new CustomerDet
                    {
                        CustomerID = customer.CustomerID,
                        CompanyName = customer.CompanyName,
                        CEOName = customer.CEOName,
                        ContactPersonName = customer.ContactPersonName,
                        ContactPersonNumber = customer.ContactPersonNumber,
                        PrimaryMailID = customer.PrimaryMailID,
                        PrimaryPhoneNo = customer.PrimaryPhoneNo,
                        Adhar = customer.Adhar,
                        PAN = customer.PAN,
                        GSTNO = customer.GSTNO,
                        Fax = customer.Fax,
                        BillingAddress = customer.BillingAddress,
                        BillingAddress1 = customer.BillingAddress1,
                        BillingCity = customer.BillingCity,
                        BillingCountry = customer.BillingCountry,
                        BillingState = customer.BillingState,
                        BillingPincode = customer.BillingPincode,
                        ShippingAddress = customer.ShippingAddress,
                        ShippingAddress1 = customer.ShippingAddress1,
                        ShippingCity = customer.ShippingCity,
                        ShippingCountry = customer.ShippingCountry,
                        ShippingPincode = customer.ShippingPincode,
                        ShippingState = customer.ShippingState,
                        Website=customer.Website,
                        AdharExt=customer.AdharExt,
                        PanExt=customer.PanExt
                    };
                    return custDetails;
                }
                return null;
            }
        }

        public List<CustomerDet> GetCustomerList()
        {
            using (var context = new AdminAppEntities())
            {
                var customerList = context.CustomerDetails.ToList();
                if (customerList != null)
                {
                    return customerList.Select(x => new CustomerDet
                    {
                        CustomerID = x.CustomerID,
                        CompanyName = x.CompanyName,
                        CEOName = x.CEOName,
                        ContactPersonName = x.ContactPersonName,
                        ContactPersonNumber = x.ContactPersonNumber,
                        PrimaryMailID = x.PrimaryMailID,
                        PrimaryPhoneNo = x.PrimaryPhoneNo,
                        Adhar = x.Adhar,
                        PAN = x.PAN,
                        GSTNO = x.GSTNO,
                        Fax = x.Fax,
                        BillingAddress = x.BillingAddress,
                        BillingAddress1 = x.BillingAddress1,
                        BillingCity = x.BillingCity,
                        BillingCountry = x.BillingCountry,
                        BillingState = x.BillingState,
                        BillingPincode=x.BillingPincode,
                        ShippingAddress=x.ShippingAddress,
                        ShippingAddress1=x.ShippingAddress1,
                        ShippingCity=x.ShippingCity,
                        ShippingCountry=x.ShippingCountry,
                        ShippingPincode=x.ShippingPincode,
                        ShippingState=x.ShippingState,
                        AdharExt=x.AdharExt,
                        PanExt=x.PanExt
                    }).ToList();
                }
                return null;
            }
        }

        public int SaveCustomer(CustomerDet CustDetails)
        {
            using (var context = new AdminAppEntities())
            {
                CustomerDetail cust = new CustomerDetail
                {
                    CustomerID = CustDetails.CustomerID,
                    CompanyName = CustDetails.CompanyName,
                    CEOName = CustDetails.CEOName,
                    ContactPersonName = CustDetails.ContactPersonName,
                    ContactPersonNumber = CustDetails.ContactPersonNumber,
                    PrimaryMailID = CustDetails.PrimaryMailID,
                    PrimaryPhoneNo = CustDetails.PrimaryPhoneNo,
                    Adhar = CustDetails.Adhar,
                    PAN = CustDetails.PAN,
                    GSTNO = CustDetails.GSTNO,
                    Fax = CustDetails.Fax,
                    BillingAddress = CustDetails.BillingAddress,
                    BillingAddress1 = CustDetails.BillingAddress1,
                    BillingCity = CustDetails.BillingCity,
                    BillingCountry = CustDetails.BillingCountry,
                    BillingState = CustDetails.BillingState,
                    BillingPincode = CustDetails.BillingPincode,
                    ShippingAddress = CustDetails.ShippingAddress,
                    ShippingAddress1 = CustDetails.ShippingAddress1,
                    ShippingCity = CustDetails.ShippingCity,
                    ShippingCountry = CustDetails.ShippingCountry,
                    ShippingPincode = CustDetails.ShippingPincode,
                    ShippingState = CustDetails.ShippingState,
                    Website=CustDetails.Website,
                    AdharExt=CustDetails.AdharExt,
                    PanExt=CustDetails.PanExt
                   
                };
                context.CustomerDetails.Add(cust);
                context.SaveChanges();
                return cust.CustomerID;
            }
        }

        public bool UpdateCustomer(CustomerDet CustDetails)
        {
            bool result = true;
            using (var context = new AdminAppEntities())
            {
                CustomerDetail details = context.CustomerDetails.Where(x => x.CustomerID == CustDetails.CustomerID).FirstOrDefault();
                CustomerDetail updatedetails = new CustomerDetail
                {
                    CustomerID = CustDetails.CustomerID,
                    CompanyName = CustDetails.CompanyName,
                    CEOName = CustDetails.CEOName,
                    ContactPersonName = CustDetails.ContactPersonName,
                    ContactPersonNumber = CustDetails.ContactPersonNumber,
                    PrimaryMailID = CustDetails.PrimaryMailID,
                    PrimaryPhoneNo = CustDetails.PrimaryPhoneNo,
                    Adhar = CustDetails.Adhar,
                    PAN = CustDetails.PAN,
                    GSTNO = CustDetails.GSTNO,
                    Fax = CustDetails.Fax,
                    BillingAddress = CustDetails.BillingAddress,
                    BillingAddress1 = CustDetails.BillingAddress1,
                    BillingCity = CustDetails.BillingCity,
                    BillingCountry = CustDetails.BillingCountry,
                    BillingState = CustDetails.BillingState,
                    BillingPincode = CustDetails.BillingPincode,
                    ShippingAddress = CustDetails.ShippingAddress,
                    ShippingAddress1 = CustDetails.ShippingAddress1,
                    ShippingCity = CustDetails.ShippingCity,
                    ShippingCountry = CustDetails.ShippingCountry,
                    ShippingPincode = CustDetails.ShippingPincode,
                    ShippingState = CustDetails.ShippingState,
                    Website=CustDetails.Website,
                    AdharExt=CustDetails.AdharExt,
                    PanExt=CustDetails.PAN
                };
                context.Entry(details).CurrentValues.SetValues(updatedetails);
                context.SaveChanges();
                return result;
            }
        }
    }
}
