using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace VANHACK_Forum_Project.App_Start
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/CSS").Include(
                         "~/vendor/bootstrap/css/bootstrap.min.css",
                         "~/vendor/bootstrap/css/bootstrap.css",
               
            "~/css/blog-post.css"
            
            ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/vendor/jquery/jquery.min.js",
                        "~/vendor/bootstrap/js/bootstrap.bundle.min.js"
                       
                        ));
    
            
        }
    }
}