using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using CMSLcLy.Data.EnumMaster;
using COMM = CMSLcLy.Common;

namespace CMSApi.Areas.Administration.Controllers
{
    [Authorize]
    public class EnumController : Controller
    {
        // GET: Administration/Bank
        public ActionResult Index(string enumType)
        {
            if (string.IsNullOrEmpty(enumType) && TempData[COMM.Constants.EnumMaster.EnumMasterType] != null)
                enumType = TempData[COMM.Constants.EnumMaster.EnumMasterType].ToString();

            TempData[COMM.Constants.EnumMaster.EnumMasterType] = enumType;
            IEnumerable<EnumMasterItemViewModel> enumMaster = null;
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
                    var responseTask = client.GetAsync("enummaster?enumType=" + enumType);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<EnumMasterItemViewModel>>();
                        readTask.Wait();

                        enumMaster = readTask.Result;
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        enumMaster = Enumerable.Empty<EnumMasterItemViewModel>();

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                        TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to retrieve Parameter Information. ";
                    }
                }

            }
            catch (Exception ex)
            {
                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to retrieve Parameter Information: " + ex.Message;
            }
            ViewBag.Title = COMM.Utils.DataTypeUtils.ConvertUpperLower(enumType);

            return View(enumMaster);
        }

        // GET: Administration/Bank/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administration/Bank/Create
        public ActionResult Create(string enumType)
        {
            TempData[COMM.Constants.EnumMaster.EnumMasterType] = enumType;
            ViewBag.Title = COMM.Utils.DataTypeUtils.ConvertUpperLower(enumType);
            return View();
        }

        // GET: Administration/Bank/Edit/5
        public ActionResult Edit(int id, string enumType)
        {
            TempData[COMM.Constants.EnumMaster.EnumMasterType] = enumType;
            EnumMasterItemViewModel enumMaster = null;
            string strPathAndQuery = Request.Url.PathAndQuery;
            string apiAddress = Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/api/enummaster/");
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
                        var readTask = result.Content.ReadAsAsync<EnumMasterItemViewModel>();
                        readTask.Wait();

                        enumMaster = readTask.Result;
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        enumMaster = new EnumMasterItemViewModel();

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }

            }
            catch (Exception ex)
            {
                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to retrieve Parameter Information: " + ex.Message;
            }
            ViewBag.Title = COMM.Utils.DataTypeUtils.ConvertUpperLower(enumType);

            return View(enumMaster);
        }

        // POST: Administration/Bank/Create
        [HttpPost]
        [OverrideAuthorization]
        //[RoleAuthorize(Roles = DefaultFunction.ManageVehicle, AccessType = AccessTypes.Create)]
        public ActionResult Save(HttpPostedFileBase imageFile, EnumMasterItemViewModel enumMasterItemViewModel, FormCollection form, string enumType)
        {
            TempData[COMM.Constants.EnumMaster.EnumMasterType] = enumType;
            enumMasterItemViewModel.EnumType = enumType;
            try
            {
                string strPathAndQuery = Request.Url.PathAndQuery;
                string apiAddress = Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/api/enummaster/");
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
                    var postTask = client.PostAsJsonAsync<EnumMasterItemViewModel>("values", enumMasterItemViewModel);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData[COMM.Constants.WebUI.Message] = "Parameter has been updated successfully.";
                        return RedirectToAction("Index");
                    }
                }

                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to update Parameter : " + ex.Message;
                return RedirectToAction("Index", enumMasterItemViewModel);
            }
        }
        
        // GET: Administration/Bank/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                string strPathAndQuery = Request.Url.PathAndQuery;
                string apiAddress = Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/api/enummaster/");
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
                        TempData[COMM.Constants.WebUI.Message] = "Parameter has been deleted";
                        return RedirectToAction("Index");
                    }
                } 

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to delete Parameter: " + ex.Message;
                return RedirectToAction("Index");
            }
        }


    }
}
