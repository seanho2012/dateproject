﻿using System.Web;
using System.Web.Optimization;

namespace web1
{
    public class BundleConfig
    {
        // 如需統合的詳細資訊，請瀏覽 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.cookie.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好可進行生產時，請使用 https://modernizr.com 的建置工具，只挑選您需要的測試。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/site.css",
                        "~/Content/bootstrap-4.css"));

            //bundles.Add(new StyleBundle("~/Content/KendoCSS").Include(
            //            "~/Content/kendo.common-material.min.css",
            //            "~/Content/kendo.material-main.min.css",
            //            "~/Content/kendo/2023.3.1114/bootstrap-4.css"));

            bundles.Add(new ScriptBundle("~/bundles/Kendo").Include(
                        "~/Scripts/kendo.all.min.js",
                        "~/Scripts/kendo.all.min.js.map"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/Common").Include(
                        "~/Scripts/Common.js"));

            bundles.Add(new ScriptBundle("~/bundles/Home").Include(
                        "~/Scripts/Home/Home.js",
                        "~/Scripts/Home/jHome.js"));
        }
    }
}
