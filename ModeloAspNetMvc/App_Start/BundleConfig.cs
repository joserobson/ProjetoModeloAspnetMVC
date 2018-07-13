using System.Web.Optimization;

namespace ModeloAspNetMvc
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/cssBundle").Include(
                     "~/Content/css/lib/lobipanel.min.css",
                     "~/Content/css/separate/lobipanel.min.css",
                     "~/Content/css/lib/jquery-ui.min.css",
                     "~/Content/css/separate/widgets.min.css",
                     "~/Content/css/separate/blockui.min.css",
                     "~/Content/css/lib/font-awesome.min.css",
                     "~/Content/css/lib/bootstrap.min.css",
                     "~/Content/bootstrap-datepicker3.min.css",
                     "~/Content/css/main.css"
                     ));

            //bundles.Add(new StyleBundle("~/Login/cssBundle").Include(
            //          "~/Content/css/separate/login.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/jsBundle").Include(
                        "~/Scripts/lib/jquery/jquery.min.js",
                        "~/Scripts/lib/tether/tether.min.js",
                        "~/Scripts/lib/bootstrap/bootstrap.min.js",
                        "~/Scripts/lib/plugins.js",
                        "~/Scripts/lib/input-mask/jquery.mask.min.js",
                        "~/Scripts/lib/input-mask/input-mask-init.js",
                        "~/Scripts/lib/app.js",                        
                        "~/Scripts/moment.min.js",
                        "~/Scripts/bootstrap-datepicker.min.js",
                        "~/Scripts/locales/bootstrap-datepicker.pt-BR.min.js"));
        }
    }
}
