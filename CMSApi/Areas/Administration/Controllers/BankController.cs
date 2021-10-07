using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using CMSLcLy.Data.Bank;
using CMSLcLy.Data.Bank.BankShortCut;
using CMSLcLy.Data.Bank.CAC;
using COMM = CMSLcLy.Common;

namespace CMSApi.Areas.Administration.Controllers
{
    [Authorize]
    public class BankController : Controller
    {
        // GET: Administration/Bank
        public ActionResult Index()
        {
            IEnumerable<bankmasterItemViewModel> bankmaster = null;
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
                    var responseTask = client.GetAsync("bank");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<bankmasterItemViewModel>>();
                        readTask.Wait();

                        bankmaster = readTask.Result;
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        bankmaster = Enumerable.Empty<bankmasterItemViewModel>();

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                        TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to retrieve Bank Information. ";
                    }
                }

            }
            catch (Exception ex)
            {
                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to retrieve Bank Information: " + ex.Message;
            }
            ViewBag.Title = "Home Page";

            bankmaster = CombineAddress(bankmaster);

            return View(bankmaster);
        }

        // GET: Administration/Bank/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administration/Bank/Create
        public ActionResult Create()
        {
            var model = InitializeNewModel();
            return View("Create", model);
        }

        // GET: Administration/Bank/Edit/5
        public ActionResult Edit(int id)
        {
            bankmasterItemViewModel bankmaster = null;
            string strPathAndQuery = Request.Url.PathAndQuery;
            string apiAddress = Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/api/bank/");
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
                        var readTask = result.Content.ReadAsAsync<bankmasterItemViewModel>();
                        readTask.Wait();

                        bankmaster = readTask.Result;
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        bankmaster = new bankmasterItemViewModel();

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }

            }
            catch (Exception ex)
            {
                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to retrieve Bank Information: " + ex.Message;
            }
            ViewBag.Title = "Home Page";
            bankmaster = InitializeNewModel(bankmaster);

            return View("Edit", bankmaster);
        }

        // POST: Administration/Bank/Create
        [HttpPost]
        [OverrideAuthorization]
        //[RoleAuthorize(Roles = DefaultFunction.ManageVehicle, AccessType = AccessTypes.Create)]
        public ActionResult Save(HttpPostedFileBase imageFile, bankmasterItemViewModel bankmasterItemViewModel, FormCollection form, string submit)
        {
            if (bankmasterItemViewModel.CACID == 0)
                ModelState.AddModelError("CACID", "CAC Required!");
            if (bankmasterItemViewModel.BankShortCutID == 0)
                ModelState.AddModelError("BankShortCutID", "Bank Shortcut Required!");

            if (!ModelState.IsValid)
            {
                bankmasterItemViewModel = InitializeNewModel(bankmasterItemViewModel);

                if (!String.IsNullOrEmpty(submit) && submit.Equals("Add"))
                    return View("Create", bankmasterItemViewModel);
                else
                    return View("Edit", bankmasterItemViewModel);
            }

            try
            {
                string strPathAndQuery = Request.Url.PathAndQuery;
                string apiAddress = Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/api/bank/");
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
                    var postTask = client.PostAsJsonAsync<bankmasterItemViewModel>("values", bankmasterItemViewModel);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData[COMM.Constants.WebUI.Message] = "Bank has been updated successfully.";
                        return RedirectToAction("Index");
                    }
                }

                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to update Bank : " + ex.Message;
                return RedirectToAction("Index", bankmasterItemViewModel);
            }
        }
        
        // GET: Administration/Bank/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                string strPathAndQuery = Request.Url.PathAndQuery;
                string apiAddress = Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/api/bank/");
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
                        TempData[COMM.Constants.WebUI.Message] = "Bank has been deleted";
                        return RedirectToAction("Index");
                    }
                } 

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to delete Bank : " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult GetBankShortCut()
        {           
            SelectList objList = new SelectList(GetBankShortCuts(), "ID", "BankShortCut", 0);
            return Json(objList);
        }

        public IEnumerable<bankmasterItemViewModel> CombineAddress(IEnumerable<bankmasterItemViewModel> model)
        {
            if (model == null) return model;

            foreach (var n in model)
                CombineAddress(n);

            return model;
        }


        public bankmasterItemViewModel CombineAddress(bankmasterItemViewModel model)
        {
            if (model == null) return model;
            model.Address = $"{model.Address}, {model.Address2}, {model.Address3} ";

            return model;
        }

        public bankmasterItemViewModel InitializeNewModel(bankmasterItemViewModel model = null)
        {
            if(model == null)
            model = new bankmasterItemViewModel();
            model.BankShortCuts = GetBankShortCuts().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.BankShortCut }).ToList();
            model.BankShortCuts.Insert(0, new SelectListItem() { Value = "0", Text = "Please select ..." });


            model.BankCACs = GetBankCACs().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.CACName }).ToList();
            model.BankCACs.Insert(0, new SelectListItem() { Value = "0", Text = "Please select ..." });

            return model;
        }

        public IEnumerable<bankshortcutmasterItemViewModel> GetBankShortCuts()
        {
            IEnumerable<bankshortcutmasterItemViewModel> bankshortmaster = null;
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
                    var responseTask = client.GetAsync("bankshortcut");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<bankshortcutmasterItemViewModel>>();
                        readTask.Wait();

                        bankshortmaster = readTask.Result;
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        bankshortmaster = Enumerable.Empty<bankshortcutmasterItemViewModel>();

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                        TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to retrieve Bank Shortcut Information. ";
                    }
                }

            }
            catch (Exception ex)
            {
                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to retrieve Bank Shortcut Information: " + ex.Message;
            }

            return bankshortmaster;
        }



        public IEnumerable<CACmasterItemViewModel> GetBankCACs()
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

            return cacmaster;
        }


    }
}
