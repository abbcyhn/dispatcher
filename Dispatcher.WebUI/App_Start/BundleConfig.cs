namespace Dispatcher.WebUI
{
    using Helpers;
    using System.Web.Optimization;
    using System.Collections.Generic;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region General
            var generalStyleBundle = new StyleBundle("~/Content/Styles/GeneralStyles")
                .Include(
                    "~/Content/Styles/bootstrap.min.css",
                    "~/Content/Styles/bootstrap-responsive.min.css",
                    "~/Content/Styles/style.css",
                    "~/Content/Styles/style-responsive.css"
                );

            var generalScriptBundle = new ScriptBundle("~/Content/Scripts/GeneralScripts")
                .Include(
                    "~/Content/Scripts/jquery-1.9.1.min.js",
                    "~/Content/Scripts/jquery-migrate-1.0.0.min.js",
                    //"~/Content/Scripts/jquery.ui.touch-punch.js",
                    //"~/Content/Scripts/modernizr.js",
                    "~/Content/Scripts/bootstrap.min.js",
                    //"~/Content/Scripts/jquery.cookie.js",
                    //"~/Content/Scripts/fullcalendar.min.js",
                    "~/Content/Scripts/jquery.dataTables.min.js",
                    //"~/Content/Scripts/excanvas.js",
                    //"~/Content/Scripts/jquery.flot.js",
                    //"~/Content/Scripts/jquery.flot.pie.js",
                    //"~/Content/Scripts/jquery.flot.stack.js",
                    //"~/Content/Scripts/jquery.flot.resize.min.js",
                    "~/Content/Scripts/jquery.chosen.min.js",
                    "~/Content/Scripts/jquery.uniform.min.js",
                    "~/Content/Scripts/jquery.cleditor.min.js",
                    //"~/Content/Scripts/jquery.noty.js",
                    "~/Content/Scripts/jquery.elfinder.min.js",
                    "~/Content/Scripts/jquery.raty.min.js",
                    "~/Content/Scripts/jquery.iphone.toggle.js",
                    "~/Content/Scripts/jquery.uploadify-3.1.min.js",
                    //"~/Content/Scripts/jquery.gritter.min.js",
                    //"~/Content/Scripts/jquery.imagesloaded.js",
                    //"~/Content/Scripts/jquery.masonry.min.js",
                    //"~/Content/Scripts/jquery.knob.modified.js",
                    //"~/Content/Scripts/jquery.sparkline.min.js",
                    //"~/Content/Scripts/counter.js",
                    //"~/Content/Scripts/retina.js",
                    "~/Content/Scripts/custom.js",
                    "~/Content/Scripts/jquery.validate.min.js",
                    "~/Content/Scripts/customdialogconfirm.js",
                    "~/Content/Scripts/jquery-ui-1.12.1.js"
                );
            #endregion

            #region ExamRoomRegister
            var examRoomRegisterScriptBundle = new ScriptBundle("~/Content/Scripts/ExamRoomRegisterScripts")
                .Include(
                    "~/Content/Scripts/queries/erquery.js",
                    "~/Content/Scripts/queries/roomsquery.js",
                    "~/Content/Scripts/validations/erregistervalidation.js",
                    "~/Content/Scripts/controllers/examroomregister.js"
                );
            #endregion

            #region LessonRoomRegister
            var lessonRoomRegisterScriptBundle = new ScriptBundle("~/Content/Scripts/LessonRoomRegisterScripts")
                .Include(
                    "~/Content/Scripts/queries/lrquery.js",
                    "~/Content/Scripts/queries/teachersquery.js",
                    "~/Content/Scripts/queries/roomsquery.js",
                    "~/Content/Scripts/validations/lrregistervalidation.js",
                    "~/Content/Scripts/controllers/lessonroomregister.js"
                );
            #endregion

            var bundlesss = new List<Bundle>
            {
                generalStyleBundle, generalScriptBundle,
                examRoomRegisterScriptBundle,
                lessonRoomRegisterScriptBundle
            };

            foreach (var bundle in bundlesss)
            {
                bundle.Orderer = new NonOrderingBundleOrderer();
                bundles.Add(bundle);
            }
        }
    }
}