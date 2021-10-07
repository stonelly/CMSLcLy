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
using CMSLcLy.Data.User;
using COMM = CMSLcLy.Common;
using DATA = CMSLcLy.Data;

namespace CMSApi.Areas.Administration.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        private ApplicationUserManager _userManager;

        public ClientController()
        {
        }

        public ClientController(ApplicationUserManager userManager)
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
        // GET: Administration/Client
        public ActionResult Index()
        {

            List<UserMasterItemViewModel> userMasterItemViewModel = null;

            using (var mgr = new CMSLcLy.Data.User.Manager())
            {
                userMasterItemViewModel = mgr.List().ToList();
            }

            userMasterItemViewModel = CombineAddress(userMasterItemViewModel);

            foreach (var model in userMasterItemViewModel)
            {
                model.Role = UserManager.GetRoles(model.AspNetUserID).FirstOrDefault();
            }

            userMasterItemViewModel.RemoveAll(x => x.Role != "Client");

            return View(userMasterItemViewModel);
        } 

        // GET: Administration/Client/Edit/5
        public ActionResult Edit(string userId)
        {
            UserMasterItemViewModel model = null;
            try
            {

                using (var mgr = new CMSLcLy.Data.User.Manager())
                {
                    model = mgr.Get(userId);
                }

            }
            catch (Exception ex)
            {
                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to retrieve Bank CAC Information: " + ex.Message;
            }
            ViewBag.Title = "Home Page";
            model.Role = UserManager.GetRoles(model.AspNetUserID).FirstOrDefault();
            model = InitializeNewUserModel(model);

            return View(model);
        }

        [HttpPost]
        [OverrideAuthorization]
        //[RoleAuthorize(Roles = DefaultFunction.ManageVehicle, AccessType = AccessTypes.Create)]
        public ActionResult Save(HttpPostedFileBase imageFile, UserMasterItemViewModel model, FormCollection form)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                    return RedirectToAction("Index");
                }

                model.CreatedBy = User.Identity.Name;

                using (var mgr = new CMSLcLy.Data.User.Manager())
                {
                    var result = mgr.Save(model);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to update User: " + ex.Message;
                return RedirectToAction("Index", model);
            }
        }

        // GET: Administration/Bank/Delete/5
        public ActionResult Delete(string userId)
        {
            try
            {
                if (string.IsNullOrEmpty(userId))
                {
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                    return RedirectToAction("Index");
                }

                using (var mgr = new CMSLcLy.Data.User.Manager())
                {
                    var result = mgr.DeleteUserDetail(userId);
                }
                ApplicationUser UserToDelete = UserManager.FindById(userId);

                if (UserToDelete != null)
                {
                    IdentityResult result = UserManager.Delete(UserToDelete);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }

                    string errorMsg = string.Empty;

                    foreach (string error in result.Errors)
                    {
                        errorMsg += error + ",";
                        ModelState.AddModelError("", error);
                    }


                    TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to delete User: " + errorMsg;
                }


                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to delete User: " + ex.Message;
                return RedirectToAction("Index");
            }
        }



        public UserMasterItemViewModel InitializeNewUserModel(UserMasterItemViewModel model = null)
        {
            if (model == null)
                model = new UserMasterItemViewModel();
            model.IdentityTypes = GetIdentityTypes(COMM.Constants.EnumMaster.IdentityType).Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.EnumValue }).ToList();
            model.IdentityTypes.Insert(0, new SelectListItem() { Value = "0", Text = "Please select ..." });

            model.UserTypes = GetIdentityTypes(COMM.Constants.EnumMaster.UserType).Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.EnumValue }).ToList();
            model.UserTypes.Insert(0, new SelectListItem() { Value = "0", Text = "Please select ..." });
            

            return model;
        }

        public IEnumerable<DATA.EnumMaster.EnumMasterItemViewModel> GetIdentityTypes(string type)
        {
            IEnumerable<DATA.EnumMaster.EnumMasterItemViewModel> model = null;

            try
            {
                using (var mgr = new CMSLcLy.Data.EnumMaster.Manager())
                {
                    model = mgr.List(type).ToList();
                }

            }
            catch (Exception ex)
            {
                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to retrieve Identity Types: " + ex.Message;
            }

            return model;
        }
        public List<UserMasterItemViewModel> CombineAddress(List<UserMasterItemViewModel> model)
        {
            if (model == null) return model;

            foreach (var n in model)
                CombineAddress(n);

            return model;
        }


        public UserMasterItemViewModel CombineAddress(UserMasterItemViewModel model)
        {
            if (model == null) return model;
            model.Address = $"{model.Address}, {model.Address2}, {model.Address3} ";

            return model;
        }
    }
}
