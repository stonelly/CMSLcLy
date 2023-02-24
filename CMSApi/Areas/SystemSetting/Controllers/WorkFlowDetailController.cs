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
using CMSLcLy.Data.Workflow.WorkFlowDetail;
using COMM = CMSLcLy.Common;

namespace CMSApi.Areas.SystemSetting.Controllers
{
    [Authorize]
    public class WorkFlowDetailController : Controller
    {

        // GET: SystemSetting/RoleMaster
        public ActionResult Index()
        {
            IList<WorkFlowDetailMasterItemViewModel> model = null;

            using (var mgr = new CMSLcLy.Data.Workflow.WorkFlowDetail.Manager())
            {
                model = mgr.List().ToList();
            }

            return View(model);
        }
        // GET: Administration/Bank/Create
        public ActionResult Create(int id)
        {
            WorkFlowDetailMasterItemViewModel model = new WorkFlowDetailMasterItemViewModel();
            model.WorkflowMasterID = id;

            return View(model);
        }

        // GET: SystemSetting/RoleMaster/Edit/5
        public ActionResult Edit(int id)
        {
            WorkFlowDetailMasterItemViewModel model = null;
            try
            {
                using (var mgr = new CMSLcLy.Data.Workflow.WorkFlowDetail.Manager())
                {
                    model = mgr.Get(id);
                }

            }
            catch (Exception ex)
            {
                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to retrieve work flow detail Information: " + ex.Message;
            }

            return View(model);
        }

        [HttpPost]
        [OverrideAuthorization]
        //[RoleAuthorize(Roles = DefaultFunction.ManageVehicle, AccessType = AccessTypes.Create)]
        public ActionResult Save(HttpPostedFileBase imageFile, WorkFlowDetailMasterItemViewModel model, FormCollection form)
        {

            model.CreatedBy = User.Identity.Name;
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                    return RedirectToAction("Index");
                }


                using (var mgr = new CMSLcLy.Data.Workflow.WorkFlowDetail.Manager())
                {
                    var result = mgr.Save(model);
                }

                TempData[COMM.Constants.WebUI.Message] = "Checklist Detail has been updated successfully.";

                return RedirectToAction("Edit", "WorkFlowMaster", new { id = model.WorkflowMasterID }); 
            }
            catch (Exception ex)
            {
                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to update work flow detail: " + ex.Message;
                return RedirectToAction("Edit", "WorkFlowMaster", new { id = model.WorkflowMasterID });
            }
        }
    }
}
