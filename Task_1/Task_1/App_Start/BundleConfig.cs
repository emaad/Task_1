using System.Web;
using System.Web.Optimization;

namespace Task_1
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));


            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            var bundleHeadJs = new Bundle("~/bundles/jqueryval");
            bundleHeadJs.Include("~/scripts/bootstrap.min.js");
            bundleHeadJs.Include("~/Scripts/jquery.validate.min.js");
            bundleHeadJs.Include("~/Scripts/jquery.validate.unobtrusive.min.js");
            bundleHeadJs.Include("~/Scripts/jquery.unobtrusive-ajax.min.js");
            bundleHeadJs.Include("~/Scripts/mvcfoolproof.unobtrusive.min.js");

            bundleHeadJs.Transforms.Add(new JsMinify());
            BundleTable.Bundles.Add(bundleHeadJs);




            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
