using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using CMSLcLy.Data.Bank.CAC;
using COMM = CMSLcLy.Common;

namespace CMSApi.Areas.Administration.Controllers
{
    [Authorize]
    public class BankCACController : Controller
    {
        // GET: Administration/Bank
        public ActionResult Index()
        {
            IEnumerable<CACmasterItemViewModel> cacmaster = null;
            string strPathAndQuery = Request.Url.PathAndQuery;
            string apiAddress = Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/api/");
            //Fetch the Cookie using its Key.
            HttpCookie tokenCookie = Request.Cookies["apiToken"];

            //If Cookie exists fetch its value.
            string ApiToken = tokenCookie != null ? tokenCookie.Value.Split('=')[1] : "undefined";

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiAddress);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", ApiToken);
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Session["ApiToken"].ToString());

                    //HTTP GET
                    var responseTask = client.GetAsync("bankcac");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<CACmasterItemViewModel>>();
                        readTask.Wait();

                        cacmaster = readTask.Result;
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        cacmaster = Enumerable.Empty<CACmasterItemViewModel>();

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                        TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to retrieve Bank CAC Information. ";
                    }
                }

            }
            catch (Exception ex)
            {
                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to retrieve Bank CAC Information: " + ex.Message;
            }
            ViewBag.Title = "Home Page";

            cacmaster = CombineAddress(cacmaster);

            return View(cacmaster);
        }

        // GET: Administration/Bank/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administration/Bank/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Administration/Bank/Edit/5
        public ActionResult Edit(int id)
        {
            CACmasterItemViewModel cacmaster = null;
            string strPathAndQuery = Request.Url.PathAndQuery;
            string apiAddress = Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/api/bankcac/");
            //Fetch the Cookie using its Key.
            HttpCookie tokenCookie = Request.Cookies["apiToken"];

            //If Cookie exists fetch its value.
            string ApiToken = tokenCookie != null ? tokenCookie.Value.Split('=')[1] : "undefined";
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiAddress);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", ApiToken);
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Session["ApiToken"].ToString());
                    //HTTP GET
                    var responseTask = client.GetAsync(id.ToString());
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<CACmasterItemViewModel>();
                        readTask.Wait();

                        cacmaster = readTask.Result;
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        cacmaster = new CACmasterItemViewModel();

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }

            }
            catch (Exception ex)
            {
                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to retrieve Bank CAC Information: " + ex.Message;
            }
            ViewBag.Title = "Home Page";

            return View(cacmaster);
        }

        // POST: Administration/Bank/Create
        [HttpPost]
        [OverrideAuthorization]
        //[RoleAuthorize(Roles = DefaultFunction.ManageVehicle, AccessType = AccessTypes.Create)]
        public ActionResult Save(HttpPostedFileBase imageFile, CACmasterItemViewModel CACmasterItemViewModel, FormCollection form)
        {
            try
            {
                string strPathAndQuery = Request.Url.PathAndQuery;
                string apiAddress = Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/api/bankcac/");
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
                    var postTask = client.PostAsJsonAsync<CACmasterItemViewModel>("values", CACmasterItemViewModel);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData[COMM.Constants.WebUI.Message] = "Bank CAC has been updated successfully.";
                        return RedirectToAction("Index");
                    }
                }

                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to update Bank CAC : " + ex.Message;
                return RedirectToAction("Index", CACmasterItemViewModel);
            }
        }
        
        // GET: Administration/Bank/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                string strPathAndQuery = Request.Url.PathAndQuery;
                string apiAddress = Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/api/bankcac/");
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
                    var deleteTask = client.DeleteAsync(id.ToString());
                    deleteTask.Wait();

                    var result = deleteTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData[COMM.Constants.WebUI.Message] = "Bank CAC has been deleted";
                        return RedirectToAction("Index");
                    }
                } 

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to delete Bank CAC: " + ex.Message;
                return RedirectToAction("Index");
            }
        }


        public IEnumerable<CACmasterItemViewModel> CombineAddress(IEnumerable<CACmasterItemViewModel> model)
        {
            if (model == null) return model;

            foreach (var n in model)
                CombineAddress(n);

            return model;
        }


        public CACmasterItemViewModel CombineAddress(CACmasterItemViewModel model)
        {
            if (model == null) return model;
            model.Address = $"{model.Address}, {model.Address2}, {model.Address3} ";

            return model;
        }

    }
}
