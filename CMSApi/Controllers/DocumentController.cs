using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMSApi.Models;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using System.IO;
using DevExpress.Web.Mvc;

namespace CMSApi.Controllers
{
    public class DocumentController : Controller
    {
        // GET: Document
        public ActionResult Export(string id = "")
        {
            if (id == "")
                id = "1";

            DocumentModel doc = DataHelper.GetDocument("1", id);
            RichEditDocumentServer server = new RichEditDocumentServer();
            server.LoadDocument(doc.DocumentPath + "\\" + doc.DocumentName);
            //using (Stream stream = System.IO.File.Create(doc.DocumentPath + "\\" +"test.pdf"))
            //{
            //    server.Options.MailMerge.DataSource = doc.DocumentDs;
            //    server.Options.MailMerge.ViewMergedData = true;

            //    RichEditDocumentServer tempServer = new RichEditDocumentServer();
            //    server.Document.MailMerge(tempServer.Document);
            //    tempServer.ExportToPdf(stream);
            //}

            MemoryStream stream = new MemoryStream();
            server.Options.MailMerge.DataSource = doc.DocumentDs;
            server.Options.MailMerge.ViewMergedData = true;

            RichEditDocumentServer tempServer = new RichEditDocumentServer();
            server.Document.MailMerge(tempServer.Document);
            tempServer.ExportToPdf(stream);
            stream.Position = 0;
            return File(stream, "application/pdf", "DownloadName.pdf");

            //DataTable dt = DataHelper.getList("1");
            //exportmodel ex = new exportmodel();
            //ex.SelectList = dt;
            //ex.SelectValue = 1;
            //ex.doc = DataHelper.GetDocument("1", "1");
            //return View("Contact");
        }
        [HttpPost]
        public ActionResult Export(exportmodel ex)
        {
            return View("Contact", ex);
        }
        public ActionResult RichEdit2Partial(string documentid)
        {

            DocumentModel docModel = DataHelper.GetDocument("1");

            return PartialView("_RichEdit2Partial", docModel);
        }

        public ActionResult RichEditPartial(exportmodel ex)
        {
            return PartialView("_RichEditPartial", ex);
        }
        [HttpPost]
        public ActionResult ExportToPdf()
        {
            return RichEditExtension.ExportToPDF("RichEdit", "ExportedDocument");
            //return PartialView("_RichEditPartial");
        }
    }
}