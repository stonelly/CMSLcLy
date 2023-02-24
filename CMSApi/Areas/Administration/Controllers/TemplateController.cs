using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using CMSApi.Models;
using static CMSApi.ApplicationUserManager;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Owin.Security.Cookies;
using System.Security.Principal;
using COMM = CMSLcLy.Common;
using DATA = CMSLcLy.Data;
using CMSApi.Areas.Administration.Models;
using System.Net.Http.Headers;

namespace CMSApi.Areas.Administration.Controllers
{
    [Authorize]
    public class TemplateController : Controller
    {
        // GET: Administration/Template
        private ApplicationUserManager _userManager;
        public TemplateController()
        {
        }

        public TemplateController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ActionResult Index()
        {
            List<DocumentModel> documentTemplateViewModel = null;

            documentTemplateViewModel = DataHelper.GetDocumentList();

            return View(documentTemplateViewModel);
        }

        public ActionResult Edit(string documentid)
        {
            ViewBag.DocID = documentid;
            return View();
        }

        public ActionResult RichEdit2Partial(string documentid)
        {

            DocumentModel docModel = DataHelper.GetDocument(documentid);

            return PartialView("_RichEdit2Partial", docModel);
        }

        public ActionResult Delete(string documentid)
        {
            try
            {
                if (string.IsNullOrEmpty(documentid))
                {
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                    return RedirectToAction("Index");
                }

                bool ret = false;
                ret = DataHelper.deleteDocument(documentid);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to delete Template: " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult Create()
        {
            var model = new DocumentModel();
            model.dataSource = "dsspa_loan_for_loan";
            model.primary_key = "ClientID";
            ViewBag.DocumentTypeList = DataHelper.GetDocumentTypeList();
            return View("Create", model);
        }
        [HttpPost]
        [OverrideAuthorization]
        //[RoleAuthorize(Roles = DefaultFunction.ManageVehicle, AccessType = AccessTypes.Create)]
        public ActionResult Save(HttpPostedFileBase DocumentFile, DocumentModel documentmodel, FormCollection form, string submit)
        {
            if (string.IsNullOrEmpty(documentmodel.DocumentType))
                ModelState.AddModelError("DocumentType", "Document Type Required!");
            if (string.IsNullOrEmpty(documentmodel.DocumentName))
                ModelState.AddModelError("DocumentName", "DocumentName Required!");

            if (!ModelState.IsValid)
            {
                return View("Create", documentmodel);
                //if (!String.IsNullOrEmpty(submit) && submit.Equals("Add"))
                //    return View("Create", bankmasterItemViewModel);
                //else
                //    return View("Edit", bankmasterItemViewModel);
            }

            try
            {
                //string strPathAndQuery = Request.Url.PathAndQuery;
                //string apiAddress = Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/api/Template/");
                ////Fetch the Cookie using its Key.
                //HttpCookie tokenCookie = Request.Cookies["apiToken"];

                ////If Cookie exists fetch its value.
                //string ApiToken = tokenCookie != null ? tokenCookie.Value.Split('=')[1] : "undefined";

                //using (var client = new HttpClient())
                //{
                //    client.BaseAddress = new Uri(apiAddress);
                //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", ApiToken);
                //    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Session["ApiToken"].ToString());

                //    //HTTP POST
                //    var postTask = client.PostAsJsonAsync<DocumentModel>("values", documentmodel);
                //    postTask.Wait();

                //    var result = postTask.Result;
                //    if (result.IsSuccessStatusCode)
                //    {
                //        TempData[COMM.Constants.WebUI.Message] = "Bank has been updated successfully.";
                //        return RedirectToAction("Index");
                //    }
                //}

                //ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                documentmodel.dataSource = "dsspa_loan_for_loan";
                documentmodel.primary_key = "ClientID";

                DataHelper.AddDocumentTemplate(documentmodel);

                return RedirectToAction("Index");
                
            }
            catch (Exception ex)
            {
                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to Create Template : " + ex.Message;
                //return RedirectToAction("Index", documentmodel);
                return View("Create", documentmodel);
            }
        }
    }
}