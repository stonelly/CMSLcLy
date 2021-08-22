using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using CMSApi.Models;
using CMSLcLy.Data; 

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
        public ActionResult TestListing()
        {
            IEnumerable<CMSLcLy.Data.Workflow.workflowmasterItemViewModel> workflowmaster = null;
            string strPathAndQuery = Request.Url.PathAndQuery;
            string apiAddress = Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/api/workflows/");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiAddress);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Session["ApiToken"].ToString());
                //HTTP GET
                var responseTask = client.GetAsync("5");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<CMSLcLy.Data.Workflow.workflowmasterItemViewModel>>();
                    readTask.Wait();

                    workflowmaster = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    workflowmaster = Enumerable.Empty<CMSLcLy.Data.Workflow.workflowmasterItemViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            ViewBag.Title = "Home Page";

            return View(workflowmaster);
        }

        public ActionResult AddWorkflow()
        {

            return View();
        }

        [HttpPost]
        [OverrideAuthorization]
        //[RoleAuthorize(Roles = DefaultFunction.ManageVehicle, AccessType = AccessTypes.Create)]
        public ActionResult Save(HttpPostedFileBase imageFile, CMSLcLy.Data.Workflow.workflowmasterItemViewModel workflowmasterItemViewModel, FormCollection form)
        { 
            try
            {
                string strPathAndQuery = Request.Url.PathAndQuery;
                string apiAddress = Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/api/workflows/");

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiAddress);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Session["ApiToken"].ToString());

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<CMSLcLy.Data.Workflow.workflowmasterItemViewModel>("values", workflowmasterItemViewModel);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("TestListing");
                    }
                }

                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");




                //using (var mgr = new CMSLcLy.Data.Workflow.Manager())
                //{
                //    var result = mgr.Add(workflowmasterItemViewModel, "TestingUser");
                //}
                return RedirectToAction("TestListing");
            }
            catch (Exception ex)
            {
                
                return RedirectToAction("TestListing", workflowmasterItemViewModel);
            }
        }
    }
}
