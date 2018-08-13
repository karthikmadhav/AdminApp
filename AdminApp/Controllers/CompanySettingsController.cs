using Admin.App.Common;
using Admin.App.Common.Interface;
using Admin.App.Common.Models;
using AdminApp.App_Start;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminApp.Controllers
{
    public class CompanySettingsController : Controller
    {
        public ICompanyDetails _ICompanyDetails;
        public CompanySettingsController(ICompanyDetails CompanyDetails)
        {
            _ICompanyDetails = CompanyDetails;
        }
        public ActionResult Company()
        {
            return View(_ICompanyDetails.GetCompanyList());
        }
        //Authorization Filter on Controller Level
        public ActionResult NewCompany(CompanyDetails details)
        {
            //Authorization for Controller and Action Method Level
            if (this.HasPermission(Utility.PageAccessType.CanCreate))
            {
                return View(details);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult NewCompany(CompanyDetails details, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                var validImageTypes = new string[] { "image/gif", "image/jpeg", "image/pjpeg", "image/png" };
                if (image != null)
                {
                    if (validImageTypes.Contains(image.ContentType))
                    {
                        string[] res = image.FileName.Split('.');
                        details.ImageExt = res[1];
                    }
                }
                int recVal = 0;
                if (details.CompanyID > 0)
                {
                    bool res = _ICompanyDetails.UpdateCompany(details);
                    if (res)
                        recVal = details.CompanyID;
                }
                else
                {
                    recVal = _ICompanyDetails.SaveCompany(details);
                }

                if (recVal > 0 && image != null)
                {
                    if (validImageTypes.Contains(image.ContentType))
                    {
                        string _FileName = "compLogo" + "_" + recVal + ".";
                        string[] res = image.FileName.Split('.');

                        if (details.CompanyID > 0)
                            _FileName = _FileName + details.ImageExt;
                        else
                            _FileName = _FileName + res[1];
                        var absolutePath = Path.Combine(Server.MapPath("~/Content/images/CompanyLogo"), _FileName);
                        if (System.IO.File.Exists(absolutePath))
                        {
                            System.IO.File.Delete(absolutePath);
                            image.SaveAs(absolutePath);
                            return RedirectToAction("Company");
                        }
                    }
                }
                return RedirectToAction("Company");
            }
            return View();
        }
        public ActionResult UpdateCompany(int id)
        {
            CompanyDetails comp = new CompanyDetails();
            if (id > 0)
            {
                comp = _ICompanyDetails.GetCompanyByID(id);
                comp.ImagePath = "~/Content/images/CompanyLogo/" + "compLogo" + "_" + id + "." + comp.ImageExt;
                return View("NewCompany", comp);
            }
            return View("NewCompany", comp);
        }
        public ActionResult GetCompanyDetails(string CompanyID)
        {
            int cID = Convert.ToInt32(CompanyID);
            CompanyDetails compDet = _ICompanyDetails.GetCompanyList().Where(x => x.CompanyID == cID).FirstOrDefault();
            return Json(compDet, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Test(DateTime param1, DateTime param2, string param3)
        {
            var urlBuilder = new UrlHelper(Request.RequestContext);
            var url = urlBuilder.Action("NewCompany", "CompanySettings");
            return Json(new { redirectUrl = url, JsonRequestBehavior.AllowGet });
        }
    }
}