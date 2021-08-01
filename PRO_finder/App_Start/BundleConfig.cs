using System.Web;
using System.Web.Optimization;

namespace PRO_finder
{
    public class BundleConfig
    {
        // 如需統合的詳細資訊，請瀏覽 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Assets/js/jquery.min.js","~/Assets/js/jquery.fancybox.min.js", "~/Assets/js/jquery.easing.1.3.js", "~/Assets/js/jquery.waypoints.min.js",
                        "~/Assets/js/jquery.animateNumber.min.js", "~/Assets/js/isotope.pkgd.min.js", "~/Assets/js/stickyfill.min.js", "~/Assets/js/owl.carousel.min.js", "~/Assets/js/custom.js"));

            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好可進行生產時，請使用 https://modernizr.com 的建置工具，只挑選您需要的測試。
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Assets/js/bootstrap.bundle.min.js", "~/Assets/js/bootstrap-select.min.js"));



             bundles.Add(new StyleBundle("~/bundles/css").Include(
            "~/Assets/css/custom-bs.css", "~/Assets/css/jquery.fancybox.min.css", "~/Assets/css/bootstrap-select.min.css",
             "~/Assets/fonts/icomoon/style.css", "~/Assets/fonts/line-icons/style.css", "~/Assets/css/owl.carousel.min.css",
            "~/Assets/css/animate.min.css", "~/Assets/css/style.css"));
        }
   
    }
}
