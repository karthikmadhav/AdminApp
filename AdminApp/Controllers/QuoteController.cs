using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminApp.Controllers
{
    public class QuoteController : Controller
    {
        // GET: Quote
        public ActionResult NewQuote()
        {
            return View();
        }
    }
}