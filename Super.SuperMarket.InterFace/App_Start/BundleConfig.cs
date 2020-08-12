using System.Web;
using System.Web.Optimization;

namespace Super.SuperMarket.InterFace
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-3.4.1.js",
                        "~/Scripts/ExtraFunction.js",
                        "~/Scripts/jquery-1.9.1.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryValidate").Include(
                "~/Scripts/jquery-1.9.1.js",
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap2_toggel").Include(
                "~/Scripts/bootstrap-toggle.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/TooltipFun.js").Include("~/Scripts/TooltipFun.js"));

            bundles.Add(new ScriptBundle("~/Scripts/DatePicker").Include("~/Scripts/bootstrap-datepicker.min.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/Themes-defult.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/Style-Main.css",
                      "~/Content/padding-margin.css",
                      "~/Content/bootstrap-theme.css", 
                      "~/Content/ErrorStyles.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/DatePicker").Include("~/Content/bootstrap-datepicker.min.css"));
            bundles.Add(new StyleBundle("~/Content/bootstrap2_toggel").Include("~/Content/bootstrap2-toggle.min.css"));

        }
    }
}
