using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Office.Interop.Word;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using CMSLcLy.Data.Workflow;
using Microsoft.AspNet.Identity;
using CMSLcLy.Data.File;
using System.Web.Http;
using CMSLcLy.Data.EnumMaster;
using CMSLcLy.Data.Bank;
using CMSLcLy.Data.Bank.BankShortCut;
using CMSApi.Models;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using System.IO;

namespace CMSApi.Areas.Files.Controllers
{
    [System.Web.Http.Authorize]
    public class SPAnLoanController : Controller
    {
        // GET: Files/SPAnLoan
        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Http.HttpGet]
        public JsonResult Details(string fileNo)
        {
            DocumentMasterViewModel model = new DocumentMasterViewModel();
            using (var mgr = new CMSLcLy.Data.File.Manager())
            {
                model = mgr.Details(fileNo);
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }


        [System.Web.Http.HttpPost]
        public ActionResult SaveFile([FromBody] DocumentMasterViewModel model)
        {

            model.CreatedBy = User.Identity.Name;
            model.ModifyBy = User.Identity.Name;

            var result = "";
            using (var mgr = new CMSLcLy.Data.File.Manager())
            {
                result = mgr.Save(model,"SPA");
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GenerateDoc(string Clientid, string FileNo, string documentId)
        {
            
            DocumentModel doc = DataHelper.GetDocument(documentId, Clientid);
            RichEditDocumentServer server = new RichEditDocumentServer();
            server.LoadDocument(doc.DocumentPath + "\\" + doc.DocumentName);

            MemoryStream stream = new MemoryStream();
            server.Options.MailMerge.DataSource = doc.DocumentDs;
            server.Options.MailMerge.ViewMergedData = true;

            RichEditDocumentServer tempServer = new RichEditDocumentServer();
            server.Document.MailMerge(tempServer.Document);
            tempServer.ExportToPdf(stream);
            stream.Position = 0;
            return File(stream, "application/pdf", FileNo + ".pdf");
        }

        //public ActionResult GenerateDoc_org()
        //{
        //    //OBJECT OF MISSING "NULL VALUE"


        //    string strPath = AppDomain.CurrentDomain.BaseDirectory + "Upload\\SPA\\DemoMailMerge.docx";
        //    Object oMissing = System.Reflection.Missing.Value;

        //    Object oTemplatePath = strPath;


        //    Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
        //    Document wordDoc = new Document();

        //    wordDoc = wordApp.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oMissing);

        //    foreach (Field myMergeField in wordDoc.Fields)
        //    {
        //        Range rngFieldCode = myMergeField.Code;
        //        String fieldText = rngFieldCode.Text;
                

        //        // ONLY GETTING THE MAILMERGE FIELDS

        //        if (fieldText.StartsWith(" MERGEFIELD"))
        //        {

        //            // THE TEXT COMES IN THE FORMAT OF

        //            // MERGEFIELD  MyFieldName  \\* MERGEFORMAT

        //            // THIS HAS TO BE EDITED TO GET ONLY THE FIELDNAME "MyFieldName"

        //            Int32 endMerge = fieldText.IndexOf("\\");

        //            Int32 fieldNameLength = fieldText.Length - endMerge;

        //            String fieldName = fieldText.Substring(11, endMerge - 11);

        //            // GIVES THE FIELDNAMES AS THE USER HAD ENTERED IN .dot FILE

        //            fieldName = fieldName.Trim();

        //            // **** FIELD REPLACEMENT IMPLEMENTATION GOES HERE ****//

        //            // THE PROGRAMMER CAN HAVE HIS OWN IMPLEMENTATIONS HERE

        //            if (fieldName == "C1")
        //            {

        //                myMergeField.Select();

        //                wordApp.Selection.TypeText("Vivek");

        //            }
        //            else
        //            if (fieldName == "C2")
        //            {

        //                myMergeField.Select();

        //                wordApp.Selection.TypeText("901112-01-1234");

        //            }
        //            else if (fieldName == "C3")
        //            {

        //                myMergeField.Select();

        //                wordApp.Selection.TypeText("NO 3, Jalan USJ 2, Pusat Bandar Subanga Jaya, 53112 Subang, Selangor");

        //            }
        //            else if (fieldName == "C4")
        //            {

        //                myMergeField.Select();

        //                wordApp.Selection.TypeText("THis is free text !");

        //            }

        //        }

        //    }
        //    //wordDoc.SaveAs2("newDocument.docx");

        //    wordDoc.Activate();
        //    //wordDoc.PrintPreview();
        //    //wordDoc.PrintOut();
        //    wordApp.ActiveDocument.PrintPreview();
            


        //    //Response.Clear();
        //    //Response.Buffer = true;
        //    //Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
        //    //Response.AddHeader("Content-Disposition", "attachment;filename=test.docx");
        //    //Response.BinaryWrite(wordApp.Documents.Open("newDocument.docx"));
        //    //Response.Flush();
        //    //Response.End();
        //    //wordDoc.Close();
        //    //wordApp.Application.Quit();



        //    return View("Index"); 
        //}
    }
}