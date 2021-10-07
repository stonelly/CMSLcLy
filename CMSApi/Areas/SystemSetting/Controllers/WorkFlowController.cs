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
using CMSLcLy.Data.Workflow;
using COMM = CMSLcLy.Common;

namespace CMSApi.Areas.SystemSetting.Controllers
{
    [Authorize]
    public class WorkFlowController : Controller
    {

        // GET: SystemSetting/RoleMaster
        public ActionResult Index()
        {
            IList<WorkflowItemViewModel> model = null;

            using (var mgr = new CMSLcLy.Data.Workflow.Manager())
            {
                model = mgr.List().ToList();
            }

            return View(model);
        }
        // GET: Administration/Bank/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: SystemSetting/RoleMaster/Edit/5
        public ActionResult Edit(int id)
        {
            WorkflowItemViewModel model = null;
            try
            {
                using (var mgr = new CMSLcLy.Data.Workflow.Manager())
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
        public ActionResult Save(HttpPostedFileBase imageFile, WorkflowItemViewModel model, FormCollection form)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                    return RedirectToAction("Index");
                }

                 
                using (var mgr = new CMSLcLy.Data.Workflow.Manager())
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
    }
}
