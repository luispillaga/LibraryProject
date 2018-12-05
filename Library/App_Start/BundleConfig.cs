using System.Web;
using System.Web.Optimization;

namespace Library
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/js/jquery.js",
                      "~/Scripts/all.js",
                      "~/Scripts/all.min.js",
                      "~/Scripts/brands.js",
                      "~/Scripts/brands.js",
                      "~/Scripts/brands.min.js",
                      "~/Scripts/fontawesome.js",
                      "~/Scripts/fontawesome.js",
                      "~/Content/js/jquery-ui-1.10.4.min.js",
                      "~/Content/js/jquery-1.8.3.min.js",
                      "~/Content/js/jquery-ui-1.9.2.custom.min.js",
                      "~/Content/js/bootstrap.min.js",
                      "~/Content/js/jquery.scrollTo.min.js",
                      "~/Content/js/jquery.nicescroll.js",
                      "~/Content/assets/jquery-knob/js/jquery.knob.js",
                      "~/Content/js/jquery.sparkline.js",
                      "~/Content/assets/jquery-easy-pie-chart/jquery.easy-pie-chart.js",
                      "~/Content/js/owl.carousel.js",
                      "~/Content/js/fullcalendar.min.js",
                      "~/Content/assets/fullcalendar/fullcalendar/fullcalendar.js",
                      "~/Content/js/calendar-custom.js",
                      "~/Content/js/jquery.rateit.min.js",
                      "~/Content/js/jquery.customSelect.min.js",
                      "~/Content/assets/chart-master/Chart.js",
                      "~/Content/js/scripts.js",
                      "~/Content/js/sparkline-chart.js",
                      "~/Content/js/easy-pie-chart.js",
                      "~/Content/js/jquery-jvectormap-1.2.2.min.js",
                      "~/Content/js/jquery-jvectormap-world-mill-en.js",
                      "~/Content/js/xcharts.min.js",
                      "~/Content/js/jquery.autosize.min.js",
                      "~/Content/js/jquery.placeholder.min.js",
                      "~/Content/js/gdp-data.js",
                      "~/Content/js/morris.min.js",
                      "~/Content/js/sparklines.js",
                      "~/Content/js/charts.js",
                      "~/Content/js/jquery.slimscroll.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/bootstrap-theme.css",
                      "~/Content/css/elegant-icons-style.css",
                      "~/Content/css/all.css",
                      "~/Content/css/fontawesome.min.css",
                      "~/Content/assets/fullcalendar/fullcalendar/bootstrap-fullcalendar.css",
                      "~/Content/assets/fullcalendar/fullcalendar/fullcalendar.css",
                      "~/Content/assets/jquery-easy-pie-chart/jquery.easy-pie-chart.css",
                      "~/Content/css/owl.carousel.css",
                      "~/Content/css/jquery-jvectormap-1.2.2.css",
                      "~/Content/css/fullcalendar.css",
                      "~/Content/css/widgets.css",
                      "~/Content/css/style.css",
                      "~/Content/css/style-responsive.css",
                      "~/Content/css/xcharts.min.css",
                      "~/Content/css/jquery-ui-1.10.4.min.css"));
        }
    }
}
