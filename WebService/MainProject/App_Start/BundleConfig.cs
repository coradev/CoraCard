using System.Web;
using System.Web.Optimization;

namespace MainProject
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Js/fontawe").Include(
            "~/Assets/js/font-awesome.min.js"
            ));
            bundles.Add(new ScriptBundle("~/Js/richtext").Include(
            "~/Assets/js/jquery.richtext.js"
            ));
            bundles.Add(new ScriptBundle("~/Js/script").Include(
            "~/Assets/js/scripts.js"
            ));

            bundles.Add(new ScriptBundle("~/Js/bootstrap").Include(
            "~/Assets/js/bootstrap.bundle.min.js"
            ));

            bundles.Add(new ScriptBundle("~/Js/card").Include(
            "~/Assets/js/card.js"
            ));

            bundles.Add(new StyleBundle("~/Css/profile").Include(
                        "~/Assets/css/profilestyle.css"));

            bundles.Add(new StyleBundle("~/Css/style").Include(
                      "~/Assets/css/styles.css"));

            bundles.Add(new StyleBundle("~/Css/richtext").Include(
                      "~/Assets/css/richtext.min.css"));

            bundles.Add(new StyleBundle("~/Css/cover").Include(
                      "~/Assets/css/cover.css"));

            bundles.Add(new StyleBundle("~/Css/card").Include(
                      "~/Assets/css/card.css"));
        }
    }
}
