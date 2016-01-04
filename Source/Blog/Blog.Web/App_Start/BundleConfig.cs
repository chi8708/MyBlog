using System.Web;
using System.Web.Optimization;

namespace Blog.Web
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryAjax").Include(
                "~/Scripts/jquery.unobtrusive-ajax.js"));


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css"));


            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));


        }

        public static void RegisterBundlesAdmin(BundleCollection bundles) 
        {
            //不会包括min.js
            //bundles.Add(new ScriptBundle("~/bundles/AdminJS").IncludeDirectory(
            //             "~/Scripts/Admin/js","*.js"));
            bundles.Add(new ScriptBundle("~/bundles/AdminJS")
                .Include(
                "~/Scripts/Admin/js/excanvas.min.js",
                 "~/Scripts/Admin/js/jquery.ui.custom.js",
                  "~/Scripts/Admin/js/jquery.flot.min.js",
                   "~/Scripts/Admin/js/jquery.flot.resize.min.js",
                   "~/Scripts/Admin/js/jquery.peity.min.js",
                   "~/Scripts/Admin/js/fullcalendar.min.js",
                   "~/Scripts/Admin/js/jquery.gritter.min.js",
                   "~/Scripts/Admin/js/jquery.wizard.js",
                   "~/Scripts/Admin/js/jquery.uniform.js",
                   "~/Scripts/Admin/js/fullcalendar.min.js",
                   "~/Scripts/Admin/select2.min.js",
                   "~/Scripts/Admin/js/matrix.popover.js",
                   "~/Scripts/Admin/js/jquery.dataTables.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/MatrixJS")
               .Include(
               "~/Scripts/Admin/js/matrix.js",
                "~/Scripts/Admin/js/matrix.dashboard.js",
                 "~/Scripts/Admin/js/matrix.chat.js",
                  "~/Scripts/Admin/js/matrix.form_validation.js",
                  "~/Scripts/Admin/js/matrix.popover.js",
                  "~/Scripts/Admin/js/matrix.tables.js"
               ));

            //注意不可以重复添加相同名称的文件。bootstrap* 不会比配bootstrap.css,因为~/Content/css已添加bootstrp文件
            bundles.Add(new StyleBundle("~/bundles/AdminCSS").Include(
                        "~/Scripts/Admin/css/bootstrap.css",
                        "~/Scripts/Admin/css/bootstrap-responsive.min.css",
                         "~/Scripts/Admin/css/fullcalendar.css", 
                        "~/Scripts/Admin/css/matrix*",
                         "~/Scripts/Admin/css/jquery.gritter.css"
                        ));

            bundles.Add(new StyleBundle("~/bundles/AdminFont").Include(
            "~/Scripts/Admin/font-awesome/css/font-awesome.css"));
        }
    }
}
