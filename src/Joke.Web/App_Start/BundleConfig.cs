using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Joke.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-1.9.0.min.js", "~/Scripts/jquery-migrate-1.2.1.min.js"));

            bundles.Add(new StyleBundle("~/content/xiaohuacss").Include("~/Content/xiaohualist.css"));
        }
    }
}