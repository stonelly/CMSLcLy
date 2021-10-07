using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Office.Interop.Word;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace CMSApi.Areas.Files.Controllers
{
    public class SPAnLoanController : Controller
    {
        // GET: Files/SPAnLoan
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GenerateDoc()
        {
            //OBJECT OF MISSING "NULL VALUE"


            string strPath = AppDomain.CurrentDomain.BaseDirectory + "Upload\\SPA\\DemoMailMerge.docx";
            Object oMissing = System.Reflection.Missing.Value;

            Object oTemplatePath = strPath;


            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            Document wordDoc = new Document();

            wordDoc = wordApp.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oMissing);

            foreach (Field myMergeField in wordDoc.Fields)
            {
                Range rngFieldCode = myMergeField.Code;
                String fieldText = rngFieldCode.Text;
                

                // ONLY GETTING THE MAILMERGE FIELDS

                if (fieldText.StartsWith(" MERGEFIELD"))
                {

                    // THE TEXT COMES IN THE FORMAT OF

                    // MERGEFIELD  MyFieldName  \\* MERGEFORMAT

                    // THIS HAS TO BE EDITED TO GET ONLY THE FIELDNAME "MyFieldName"

                    Int32 endMerge = fieldText.IndexOf("\\");

                    Int32 fieldNameLength = fieldText.Length - endMerge;

                    String fieldName = fieldText.Substring(11, endMerge - 11);

                    // GIVES THE FIELDNAMES AS THE USER HAD ENTERED IN .dot FILE

                    fieldName = fieldName.Trim();

                    // **** FIELD REPLACEMENT IMPLEMENTATION GOES HERE ****//

                    // THE PROGRAMMER CAN HAVE HIS OWN IMPLEMENTATIONS HERE

                    if (fieldName == "C1")
                    {

                        myMergeField.Select();

                        wordApp.Selection.TypeText("Vivek");

                    }
                    else
                    if (fieldName == "C2")
                    {

                        myMergeField.Select();

                        wordApp.Selection.TypeText("901112-01-1234");

                    }
                    else if (fieldName == "C3")
                    {

                        myMergeField.Select();

                        wordApp.Selection.TypeText("NO 3, Jalan USJ 2, Pusat Bandar Subanga Jaya, 53112 Subang, Selangor");

                    }
                    else if (fieldName == "C4")
                    {

                        myMergeField.Select();

                        wordApp.Selection.TypeText("THis is free text !");

                    }

                }

            }
            //wordDoc.SaveAs2("newDocument.docx");

            wordDoc.Activate();
            //wordDoc.PrintPreview();
            //wordDoc.PrintOut();
            wordApp.ActiveDocument.PrintPreview();
            


            //Response.Clear();
            //Response.Buffer = true;
            //Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            //Response.AddHeader("Content-Disposition", "attachment;filename=test.docx");
            //Response.BinaryWrite(wordApp.Documents.Open("newDocument.docx"));
            //Response.Flush();
            //Response.End();
            //wordDoc.Close();
            //wordApp.Application.Quit();



            return View("Index"); 
        }
    }
}