using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using CMSApi.Models;
using CMSLcLy.Data;
using DATA = CMSLcLy.Data.Workflow.WorkFlowMaster;
using COMM = CMSLcLy.Common;

namespace CMSApi.Areas.SystemSetting.Controllers
{
    [Authorize]
    public class WorkFlowMasterController : Controller
    {
        // GET: SystemSetting/Checklist
        public ActionResult Index()
        {
            IEnumerable<CMSLcLy.Data.Workflow.WorkFlowMaster.WorkflowMasterItemViewModel> workflowmaster = null;
            string strPathAndQuery = Request.Url.PathAndQuery;
            string apiAddress = Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/api/workflowsmaster/");
            try
            {
                //Fetch the Cookie using its Key.
                HttpCookie tokenCookie = Request.Cookies["apiToken"];

                //If Cookie exists fetch its value.
                string ApiToken = tokenCookie != null ? tokenCookie.Value.Split('=')[1] : "undefined";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiAddress);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", ApiToken);
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Session["ApiToken"].ToString());
                    //HTTP GET
                    var responseTask = client.GetAsync("5");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<CMSLcLy.Data.Workflow.WorkFlowMaster.WorkflowMasterItemViewModel>>();
                        readTask.Wait();

                        workflowmaster = readTask.Result;
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        workflowmaster = Enumerable.Empty<CMSLcLy.Data.Workflow.WorkFlowMaster.WorkflowMasterItemViewModel>();

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }

            }
            catch (Exception ex)
            {
                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to retrieve WorkFlow Information: " + ex.Message;
            }
            ViewBag.Title = "Home Page";

            return View(workflowmaster);
        }

        // GET: SystemSetting/Checklist/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SystemSetting/Checklist/Create
        public ActionResult Create(int id = 1)
        {
            DATA.WorkflowMasterItemViewModel model = new DATA.WorkflowMasterItemViewModel();
            model.WorkflowID = id;

            return View(model);
        }

        // POST: SystemSetting/Checklist/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SystemSetting/Checklist/Edit/5
        public ActionResult Edit(int id)
        {
            DATA.WorkflowMasterItemViewModel model = null;
            try
            {
                using (var mgr = new CMSLcLy.Data.Workflow.WorkFlowMaster.Manager())
                {
                    model = mgr.Get(id);
                }

            }
            catch (Exception ex)
            {
                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to retrieve Role Information: " + ex.Message;
            }

            return View(model);
        }

        // POST: SystemSetting/Checklist/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        [OverrideAuthorization]
        //[RoleAuthorize(Roles = DefaultFunction.ManageVehicle, AccessType = AccessTypes.Create)]
        public ActionResult Save(HttpPostedFileBase imageFile, DATA.WorkflowMasterItemViewModel model, FormCollection form)
        {
            bool isAdd = true;

            if (model.ID > 0) isAdd = false;
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                    return RedirectToAction("Index");
                }


                using (var mgr = new CMSLcLy.Data.Workflow.WorkFlowMaster.Manager())
                {
                    var result = mgr.Save(model);
                }

                if(isAdd)
                    return RedirectToAction("Edit","WorkFlow", new { id = model.WorkflowID});

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to update User: " + ex.Message;
                return RedirectToAction("Index", model);
            }
        }

        // GET: SystemSetting/Checklist/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SystemSetting/Checklist/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
