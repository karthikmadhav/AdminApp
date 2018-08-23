using Admin.App.Common.Interface;
using Admin.App.Common.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace AdminApp.Controllers
{
    public class CustomerController : Controller
    {
        public ICustomerDetails _ICustomerDetails;
        public CustomerController(ICustomerDetails customerDetails)
        {
            _ICustomerDetails = customerDetails;
        }
        public ActionResult NewCustomer(CustomerDet cust)
        {
            if (cust != null)
            {
                return View(cust);
            }
            return View();
        }
        [HttpPost]
        public ActionResult SaveCustomer(CustomerDet custDetails, HttpPostedFileBase adhar, HttpPostedFileBase pan)
        {
            int custID = custDetails.CustomerID;
            if (ModelState.IsValid)
            {
                var validImageTypes = new string[] { "application/pdf" };
                if (adhar != null)
                {
                    if (validImageTypes.Contains(adhar.ContentType))
                    {
                        string[] res = adhar.FileName.Split('.');
                        custDetails.AdharExt = res[1];
                    }
                }
                if (pan != null)
                {
                    if (validImageTypes.Contains(pan.ContentType))
                    {
                        string[] res = pan.FileName.Split('.');
                        custDetails.PanExt = res[1];
                    }
                }
                int recVal = 0;
                if (custDetails.CustomerID > 0)
                {
                    bool res = _ICustomerDetails.UpdateCustomer(custDetails);
                    if (res)
                        recVal = custDetails.CustomerID;
                }
                else
                {
                    recVal = _ICustomerDetails.SaveCustomer(custDetails);
                }
                if (recVal > 0)
                {
                    if (adhar != null)
                    {
                        if (validImageTypes.Contains(adhar.ContentType))
                        {
                            string _FileName = "Adhar" + "_" + recVal + ".";
                            string[] res = adhar.FileName.Split('.');

                            if (custDetails.CustomerID > 0)
                                _FileName = _FileName + custDetails.AdharExt;
                            else
                                _FileName = _FileName + res[1];
                            var absolutePath = Path.Combine(Server.MapPath("~/Content/CustDoc"), _FileName);
                            if (System.IO.File.Exists(absolutePath))
                            {
                                System.IO.File.Delete(absolutePath);
                                adhar.SaveAs(absolutePath);
                            }
                            else if (recVal!= custID)
                            {
                                adhar.SaveAs(absolutePath);
                            }
                        }
                    }
                    if (pan != null)
                    {
                        if (validImageTypes.Contains(pan.ContentType))
                        {
                            string _FileName = "PAN" + "_" + recVal + ".";
                            string[] res = pan.FileName.Split('.');

                            if (custDetails.CustomerID > 0)
                                _FileName = _FileName + custDetails.PanExt;
                            else
                                _FileName = _FileName + res[1];
                            var absolutePath = Path.Combine(Server.MapPath("~/Content/CustDoc"), _FileName);
                            if (System.IO.File.Exists(absolutePath))
                            {
                                System.IO.File.Delete(absolutePath);
                                pan.SaveAs(absolutePath);
                            }
                            else if (recVal != custID)
                            {
                                adhar.SaveAs(absolutePath);
                            }
                        }
                    }
                }
                return RedirectToAction("ViewCustomer");
            }
            return View();
        }
        public ActionResult ViewCustomer()
        {
            return View(_ICustomerDetails.GetCustomerList());
        }
        public ActionResult UpdateCustomer(int id)
        {
            CustomerDet custDetails = new CustomerDet();
            if (id > 0)
                custDetails = _ICustomerDetails.GetCustomerByID(id);
            return View("NewCustomer", custDetails);
        }
        public ActionResult CustomerDetails(int id)
        {
            CustomerDet custDetails = new CustomerDet();
            if (id > 0)
            {
                custDetails = _ICustomerDetails.GetCustomerByID(id);
                custDetails.AdharFilePath = custDetails.AdharExt != string.Empty ? "~/Content/CustDoc/" + "Adhar" + "_" + id + ".pdf" : "";
                custDetails.PanFilePath = custDetails.PanExt != string.Empty ? "~/Content/CustDoc/" + "PAN" + "_" + id + ".pdf" : "";
            }
            return View(custDetails);
        }
        public JsonResult GetCustomerList()
        {
            var customerCollection = _ICustomerDetails.GetCustomerList();
            return Json(customerCollection, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCustDetails(int CustomerID)
        {
            CustomerDet customerDet = new CustomerDet();
            customerDet = _ICustomerDetails.GetCustomerByID(CustomerID);
            return Json(customerDet, JsonRequestBehavior.AllowGet);
        }
    }
}