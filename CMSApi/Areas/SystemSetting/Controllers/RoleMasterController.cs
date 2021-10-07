using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMSApi.Areas.SystemSetting.Models;
using CMSApi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using CMSLcLy.Data.RoleMaster;
using COMM = CMSLcLy.Common;

namespace CMSApi.Areas.SystemSetting.Controllers
{
    [Authorize]
    public class RoleMasterController : Controller
    {

        // GET: SystemSetting/RoleMaster
        public ActionResult Index()
        {
            IList<RoleMasterItemViewModel> model = null;

            using (var mgr = new CMSLcLy.Data.RoleMaster.Manager())
            {
                model = mgr.ListNotAdmin().ToList();
            }

            return View(model);
        }
        // GET: Administration/Bank/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: SystemSetting/RoleMaster/Edit/5
        public ActionResult Edit(string id)
        {
            RoleMasterItemViewModel model = null;
            try
            {
                using (var mgr = new CMSLcLy.Data.RoleMaster.Manager())
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

        [HttpPost]
        [OverrideAuthorization]
        //[RoleAuthorize(Roles = DefaultFunction.ManageVehicle, AccessType = AccessTypes.Create)]
        public ActionResult Save(HttpPostedFileBase imageFile, RoleMasterItemViewModel model, FormCollection form)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                    return RedirectToAction("Index");
                }

                if (String.IsNullOrEmpty(model.OldName) && !String.IsNullOrEmpty(model.Name))
                {
                    ApplicationDbContext context = new ApplicationDbContext();

                    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                    if (!roleManager.RoleExists(model.Name))
                    {

                        // first we create Admin rool    
                        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                        role.Name = model.Name;
                        roleManager.Create(role);
                    }
                }
                else if (model.Name != model.OldName)
                {
                    using (var mgr = new CMSLcLy.Data.RoleMaster.Manager())
                    {
                        var result = mgr.Save(model);
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to update User: " + ex.Message;
                return RedirectToAction("Index", model);
            }
        }
    }
}
