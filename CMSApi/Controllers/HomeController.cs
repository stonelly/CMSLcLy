using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using CMSApi.Models;
using CMSLcLy.Data;
using COMM = CMSLcLy.Common;

namespace CMSApi.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult AddWorkflow()
        {

            return View();
        }

        public ActionResult TestListing()
        {
            IEnumerable<CMSLcLy.Data.Workflow.WorkFlowMaster.WorkflowMasterItemViewModel> workflowmaster = null;
            string strPathAndQuery = Request.Url.PathAndQuery;
            string apiAddress = Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/api/workflows/");
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
            catch(Exception ex)
            { 
                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to retrieve WorkFlow Information: " + ex.Message;
            }
            ViewBag.Title = "Home Page";

            return View(workflowmaster);
        }


        [HttpPost]
        [OverrideAuthorization]
        //[RoleAuthorize(Roles = DefaultFunction.ManageVehicle, AccessType = AccessTypes.Create)]
        public ActionResult Save(HttpPostedFileBase imageFile, CMSLcLy.Data.Workflow.WorkFlowMaster.WorkflowMasterItemViewModel workflowmasterItemViewModel, FormCollection form)
        { 
            try
            {
                string strPathAndQuery = Request.Url.PathAndQuery;
                string apiAddress = Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/api/workflows/");
                //Fetch the Cookie using its Key.
                HttpCookie tokenCookie = Request.Cookies["apiToken"];

                //If Cookie exists fetch its value.
                string ApiToken = tokenCookie != null ? tokenCookie.Value.Split('=')[1] : "undefined";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiAddress);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", ApiToken);
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Session["ApiToken"].ToString());

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<CMSLcLy.Data.Workflow.WorkFlowMaster.WorkflowMasterItemViewModel>("values", workflowmasterItemViewModel);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData[COMM.Constants.WebUI.Message] = "Work has been updated successfully.";
                        return RedirectToAction("TestListing");
                    }
                }
                 
                return RedirectToAction("TestListing");
            }
            catch (Exception ex)
            {
                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to updated WorkFlow: " + ex.Message;
                return RedirectToAction("TestListing", workflowmasterItemViewModel);
            }
        }
    }
}
