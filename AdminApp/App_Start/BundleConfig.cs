using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace AdminApp.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/scripts/Plugins/jquery-3.2.1.min.js"                   
                        ));
            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                        "~/scripts/Plugins/popper.min.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                       "~/scripts/Plugins/bootstrap.min.js"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/adminApp").Include(
                      "~/scripts/Plugins/main.js",
                      "~/scripts/Plugins/chart.js",
                       "~/scripts/AdminApp/GlobalErrorHandler.js",
                       "~/scripts/AdminApp/common.js",
                       "~/scripts/AdminApp/Company.js",
                        "~/scripts/AdminApp/Role.js"
                      ));
            bundles.Add(new StyleBundle("~/Content/AdminAppStyle").Include(
               "~/Content/main.css"));
        }
    }
}