﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.App.Common.Models
{
   public class CustomerDet
    {
        public int CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string CEOName { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonNumber { get; set; }
        public string Notes { get; set; }
        public string GSTNO { get; set; }
        public string PAN { get; set; }
        public string Adhar { get; set; }
        public string PrimaryMailID { get; set; }
        public string PrimaryPhoneNo { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string BillingAddress { get; set; }
        public string BillingAddress1 { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingCountry { get; set; }
        public string BillingPincode { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingAddress1 { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }
        public string ShippingCountry { get; set; }
        public string ShippingPincode { get; set; }
        public string AdharExt { get; set; }
        public string PanExt { get; set; }
        public string AdharFilePath { get; set; }
        public string PanFilePath { get; set; }

    }
}
