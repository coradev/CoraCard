using System.Web;
using System.Web.Optimization;

namespace WebApp
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            //javascript
            bundles.Add(new ScriptBundle("~/assets/js").Include(
                        "~/assets/js/vendor/modernizr-3.5.0.min.js",
                        "~/assets/js/vendor/jquery-1.12.4.min.js",
                        "~/assets/js/popper.min.js",
                        "~/assets/js/bootstrap.min.js",
                        "~/assets/js/owl.carousel.min.js",
                        "~/assets/js/isotope.pkgd.min.js",
                        "~/assets/js/one-page-nav-min.js",
                        "~/assets/js/slick.min.js",
                        "~/assets/js/jquery.meanmenu.min.js",
                        "~/assets/js/wow.min.js",
                        "~/assets/js/jquery.scrollUp.min.js",
                        "~/assets/js/imagesloaded.pkgd.min.js",
                        "~/assets/js/jquery.magnific-popup.min.js",
                        "~/assets/js/*.js"
                        ));

            //css
            bundles.Add(new StyleBundle("~/assets/css").Include(
                        "~/assets/css/bootstrap.min.css",
                        "~/assets/css/owl.carousel.min.css",
                        "~/assets/css/animate.min.css",
                        "~/assets/css/fontawesome-all.min.css",
                        "~/assets/css/*.css"
                        ));
            //css profile
            bundles.Add(new StyleBundle("~/assets/profile").Include(
            "~/assets/css/profile/*.css"));

        }
    }
}
