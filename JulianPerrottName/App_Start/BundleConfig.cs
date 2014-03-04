namespace JulianPerrottName
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Areas/Home/js/bundle").Include(
                "~/Areas/Home/js/bootstrap.js",
                "~/Areas/Home/js/jquery-1.9.1.js",
                "~/Areas/Home/js/custom.js",
                "~/Areas/Home/js/scrolltopcontrol.js",
                "~/Areas/Home/js/jquery-ui-1.10.4.custom.js",
                "~/Areas/Home/js/jquery.youtubepopup.js"));

            bundles.Add(new StyleBundle("~/Areas/Home/css/bundle").Include(
                  "~/Areas/Home/css/bootstrap.css",
                  "~/Areas/Home/css/lato.css",
                  "~/Areas/Home/css/animate.css",
                  "~/Areas/Home/css/elements.css",
                  "~/Areas/Home/css/jquery-ui-1.10.4.custom.css",
                  "~/Areas/Home/css/font-awesome.css",
                  "~/Areas/Home/css/custom.css"));

          //  // Code removed for clarity.
          BundleTable.EnableOptimizations = true;
        }
    }
}