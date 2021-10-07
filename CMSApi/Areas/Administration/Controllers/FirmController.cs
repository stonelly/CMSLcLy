using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using static CMSApi.ApplicationUserManager;
using CMSLcLy.Data.Firm;
using COMM = CMSLcLy.Common;
using DATA = CMSLcLy.Data;
using System.Net;

namespace CMSApi.Areas.Administration.Controllers
{
    [Authorize]
    public class FirmController : Controller
    {
        private ApplicationUserManager _userManager;

        public FirmController()
        {
        }

        public FirmController(ApplicationUserManager userManager)
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

        // GET: Administration/Bank
        public ActionResult Index()
        {
            IEnumerable<FirmMasterItemViewModel> model = null;
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
                    var responseTask = client.GetAsync("firm");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<FirmMasterItemViewModel>>();
                        readTask.Wait();

                        model = readTask.Result;
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        model = Enumerable.Empty<FirmMasterItemViewModel>();

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                        TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to retrieve Firm Information. ";
                    }
                }

            }
            catch (Exception ex)
            {
                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to retrieve Firm Information: " + ex.Message;
            }
            ViewBag.Title = "Home Page";

            model = CombineAddress(model);

            return View(model);
        }

        // GET: Administration/Bank/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administration/Bank/Create
        public ActionResult Create()
        {
            var model = new FirmMasterItemViewModel();
            model = InitializeNewModel(model);
            return View("Create", model);
        }

        // GET: Administration/Bank/Edit/5
        public ActionResult Edit(int id)
        {
            FirmMasterItemViewModel model = null;
            string strPathAndQuery = Request.Url.PathAndQuery;
            string apiAddress = Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/api/firm/");
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
                        var readTask = result.Content.ReadAsAsync<FirmMasterItemViewModel>();
                        readTask.Wait();

                        model = readTask.Result;
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        model = new FirmMasterItemViewModel();

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }

            }
            catch (Exception ex)
            {
                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to retrieve Firm Information: " + ex.Message;
            }
            ViewBag.Title = "Home Page";
            model = InitializeNewModel(model);

            return View(model);
        }

        // POST: Administration/Bank/Create
        [HttpPost]
        [OverrideAuthorization]
        //[RoleAuthorize(Roles = DefaultFunction.ManageVehicle, AccessType = AccessTypes.Create)]
        public ActionResult Save(HttpPostedFileBase imageFile, FirmMasterItemViewModel model, FormCollection form)
        {
            try
            {
                string strPathAndQuery = Request.Url.PathAndQuery;
                string apiAddress = Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/api/firm/");
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
                    var postTask = client.PostAsJsonAsync<FirmMasterItemViewModel>("values", model);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData[COMM.Constants.WebUI.Message] = "Firm has been updated successfully.";
                        return RedirectToAction("Index");
                    }
                    else if (result.StatusCode == HttpStatusCode.Conflict)
                    {
                        TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to Create Firm. Duplicate User";
                        return RedirectToAction("Index");

                    }
                }

                TempData[COMM.Constants.WebUI.ErrorMessage] = "Server Error. Please contact administrator.";
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to update Firm : " + ex.Message;
                return RedirectToAction("Index", model);
            }
        }

        // GET: Administration/Bank/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                string strPathAndQuery = Request.Url.PathAndQuery;
                string apiAddress = Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/api/firm/");
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
                        TempData[COMM.Constants.WebUI.Message] = "Firm has been deleted";
                        return RedirectToAction("Index");
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to delete Firm: " + ex.Message;
                return RedirectToAction("Index");
            }
        }
                          
        public FirmMasterItemViewModel InitializeNewModel(FirmMasterItemViewModel model = null)
        {
            if (model == null)
                model = new FirmMasterItemViewModel();
            model.Users = GetRoles().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.UserName }).ToList();
            model.Users.Insert(0, new SelectListItem() { Value = "0", Text = "Please select ..." }); 


            return model;
        }


        public List<DATA.User.UserMasterItemViewModel> GetRoles()
        {
            List<DATA.User.UserMasterItemViewModel> userMasterItemViewModel = null;

            try
            {
                using (var mgr = new CMSLcLy.Data.User.Manager())
                {
                    userMasterItemViewModel = mgr.List().ToList();


                    foreach (var model in userMasterItemViewModel)
                    {
                        model.Role = UserManager.GetRoles(model.AspNetUserID).FirstOrDefault();
                    }

                    userMasterItemViewModel.RemoveAll(x => x.Role != "Firm");
                }

            }
            catch (Exception ex)
            {
                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to retrieve Roles: " + ex.Message;
            }

            return userMasterItemViewModel;
        }

        public IEnumerable<FirmMasterItemViewModel> CombineAddress(IEnumerable<FirmMasterItemViewModel> model)
        {
            if (model == null) return model;

            foreach (var n in model)
                CombineAddress(n);

            return model;
        }        
         
        public FirmMasterItemViewModel CombineAddress(FirmMasterItemViewModel model)
        {
            if (model == null) return model;
            model.Address = $"{model.Address}, {model.Address2}, {model.Address3} ";

            return model;
        }
    }
}
