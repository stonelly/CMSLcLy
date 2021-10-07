using System.Web;
using System.Web.Optimization;

namespace CMSApi
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //++ Styles

            // for error layout 
            bundles.Add(new StyleBundle("~/content/commonDisplayLayout").Include(
                "~/content/css/bootstrap.min.css",
                "~/content/css/font-awesome.min.css",
                "~/content/css/smartadmin-production-plugins.min.css",
                "~/content/css/smartadmin-production.min.css",
                "~/content/css/smartadmin-skins.min.css",
                "~/content/css/smartadmin-rtl.min.css"
                ));

            //https://sciactive.com/pnotify/ - using pnotify3 download
            bundles.Add(new StyleBundle("~/content/pnotifycss").Include(
                "~/content/css/animate.css",
                "~/content/css/pnotify.custom.min.css"
                ));

            bundles.Add(new StyleBundle("~/content/smartadmin").IncludeDirectory("~/content/css", "*.min.css"));

            // jquery layout style
            bundles.Add(new StyleBundle("~/content/jquerylayout").Include("~/content/css/layout-default-latest.css"));

            bundles.Add(new StyleBundle("~/content/DTables").Include(
                "~/content/DataTables/css/jquery.dataTables.min.css",
                "~/content/DataTables/css/dataTables.bootstrap.min.css"
                ));

            bundles.Add(new StyleBundle("~/content/bootstrapDateTimePicker").Include(
                "~/content/bootstrap-datetimepicker.css"));

            bundles.Add(new StyleBundle("~/content/customstyle").Include(
                "~/scripts/alertify/css/alertify.css",
                "~/content/css/mf_custom.css"
               ));

            bundles.Add(new StyleBundle("~/content/customstylegeneral").Include(
                "~/content/css/mf_custom_general.css"
               ));

            bundles.Add(new StyleBundle("~/content/customcheckbox").Include(
                "~/content/css/mf_fix_checkbox_style.css"
                ));

            bundles.Add(new StyleBundle("~/content/bootstrapDateRangePicker").Include(
                "~/content/daterangepicker.css"
                ));

            // ------------------------------------------------------------------------------------------

            //++ Scripts

            bundles.Add(new ScriptBundle("~/scripts/smartadmin").Include(
                "~/scripts/app.config.js",
                "~/scripts/plugin/jquery-touch/jquery.ui.touch-punch.min.js",
                "~/scripts/moment.min.js",
                "~/scripts/bootstrap/bootstrap.min.js",
                "~/scripts/notification/SmartNotification.min.js",
                "~/scripts/smartwidgets/jarvis.widget.min.js",
                "~/scripts/plugin/jquery-validate/jquery.validate.min.js",
                "~/scripts/plugin/masked-input/jquery.maskedinput.min.js",
                "~/scripts/plugin/select2/select2.min.js",
                "~/scripts/plugin/bootstrap-slider/bootstrap-slider.min.js",
                "~/scripts/plugin/bootstrap-progressbar/bootstrap-progressbar.min.js",
                "~/scripts/plugin/msie-fix/jquery.mb.browser.min.js",
                "~/scripts/plugin/fastclick/fastclick.min.js",
                "~/scripts/app.min.js",
                "~/scripts/plugin/bootstrapSelect/bootstrap-select.min.js",
                "~/scripts/plugin/ion-slider/ion.rangeSlider.min.js",
                "~/scripts/bootstrap-datetimepicker.min.js",
                "~/scripts/daterangepicker.js",
                "~/scripts/plugin/bootstrap-duallistbox/jquery.bootstrap-duallistbox.min.js",
                "~/scripts/alertify/alertify.js",
                "~/scripts/genericModal.js" // generic modal
                ));

            // Jquery layout script (not included at the moment)
            bundles.Add(new ScriptBundle("~/scripts/jquerylayout").Include(
                "~/scripts/plugin/jquery-layout/jquery.layout-latest.js"));

            bundles.Add(new ScriptBundle("~/scripts/full-calendar").Include(
                "~/scripts/plugin/moment/moment.min.js",
                "~/scripts/plugin/fullcalendar/jquery.fullcalendar.min.js"
                ));

            bundles.Add(new ScriptBundle("~/scripts/jquery").Include(
                "~/Scripts/jquery-{version}.js"
                ));

            bundles.Add(new ScriptBundle("~/scripts/charts").Include(
                "~/scripts/plugin/easy-pie-chart/jquery.easy-pie-chart.min.js",
                "~/scripts/plugin/sparkline/jquery.sparkline.min.js",
                "~/scripts/plugin/morris/morris.min.js",
                "~/scripts/plugin/morris/raphael.min.js",
                "~/scripts/plugin/flot/jquery.flot.cust.min.js",
                "~/scripts/plugin/flot/jquery.flot.resize.min.js",
                "~/scripts/plugin/flot/jquery.flot.time.min.js",
                "~/scripts/plugin/flot/jquery.flot.fillbetween.min.js",
                "~/scripts/plugin/flot/jquery.flot.orderBar.min.js",
                "~/scripts/plugin/flot/jquery.flot.pie.min.js",
                "~/scripts/plugin/flot/jquery.flot.tooltip.min.js",
                "~/scripts/plugin/dygraphs/dygraph-combined.min.js",
                "~/scripts/plugin/chartjs/chart.min.js",
                "~/scripts/chartjs-plugin-annotation.min.js",
                "~/scripts/plugin/highChartCore/highcharts-custom.min.js",
                "~/scripts/plugin/highchartTable/jquery.highchartTable.min.js"
                ));


            bundles.Add(new ScriptBundle("~/scripts/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.unobtrusive*"));

            // make sure the script bundle name is not the same as existing physical path
            // https://stackoverflow.com/a/36660875/727575
            bundles.Add(new ScriptBundle("~/scripts/DTables").Include(
                "~/scripts/plugin/datatables/jquery.dataTables.min.js",
                "~/scripts/plugin/datatables/dataTables.colVis.min.js",
                "~/scripts/plugin/datatables/dataTables.tableTools.min.js",
                "~/scripts/plugin/datatables/dataTables.bootstrap.min.js",
                "~/scripts/plugin/datatable-responsive/datatables.responsive.min.js"
                ));

            bundles.Add(new ScriptBundle("~/scripts/datatables").Include(
               "~/scripts/plugin/datatables/jquery.dataTables.min.js",
               "~/scripts/plugin/datatables/dataTables.colVis.min.js",
               "~/scripts/plugin/datatables/dataTables.tableTools.min.js",
               "~/scripts/plugin/datatables/dataTables.bootstrap.min.js",
               "~/scripts/plugin/datatable-responsive/datatables.responsive.min.js"
               ));

            bundles.Add(new ScriptBundle("~/scripts/jq-grid").Include(
                "~/scripts/plugin/jqgrid/jquery.jqGrid.min.js",
                "~/scripts/plugin/jqgrid/grid.locale-en.min.js"
                ));

            bundles.Add(new ScriptBundle("~/scripts/forms").Include(
                "~/scripts/plugin/jquery-form/jquery-form.min.js"
                ));

            bundles.Add(new ScriptBundle("~/scripts/smart-chat").Include(
                "~/scripts/smart-chat-ui/smart.chat.ui.min.js",
                "~/scripts/smart-chat-ui/smart.chat.manager.min.js"
                ));

            bundles.Add(new ScriptBundle("~/scripts/vector-map").Include(
                "~/scripts/plugin/vectormap/jquery-jvectormap-1.2.2.min.js",
                "~/scripts/plugin/vectormap/jquery-jvectormap-world-mill-en.js"
                ));

            bundles.Add(new ScriptBundle("~/scripts/daterangepickerjs").Include(
                "~/scripts/general/daterangepicker.js"
                ));

            bundles.Add(new ScriptBundle("~/scripts/datetimepickerjs").Include(
                "~/scripts/general/datetimepicker.js"
                ));

            bundles.Add(new ScriptBundle("~/scripts/displayLayoutScript").Include(
                "~/scripts/bootstrap/bootstrap.min.js"
                ));

            //https://sciactive.com/pnotify/ - using pnotify3 download
            bundles.Add(new ScriptBundle("~/scripts/pnotifyscripts").Include(
                "~/scripts/pnotify.custom.min.js"
                ));

            BundleTable.EnableOptimizations = true;
        }
    }
}
