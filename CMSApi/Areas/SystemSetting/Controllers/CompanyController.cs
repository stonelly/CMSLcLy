using CMSLcLy.Data.SystemSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using COMM = CMSLcLy.Common;

namespace CMSApi.Areas.SystemSetting.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {

 

        // GET: SystemSetting/Company
        public ActionResult Index()
        {
            return View();
        }

        // GET: SystemSetting/Company/Details/5
        public ActionResult Details(int id = 1)
        {

            
            CompanyProfileViewModel model = null;
            try
            {
                using (var cp = new CMSLcLy.Data.SystemSetting.Manager())
                {
                    model = cp.Get(1);
                }

            }
            catch (Exception ex)
            {
                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to retrieve Role Information: " + ex.Message;
            }

            return View(model);           
        }

        // GET: SystemSetting/Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SystemSetting/Company/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SystemSetting/Company/Edit/5
        public ActionResult Edit(int id = 1)
        {
            CompanyProfileViewModel model = null;
            try
            {
                using (var cp = new CMSLcLy.Data.SystemSetting.Manager())
                {
                    model = cp.Get(1);
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
        public ActionResult Save(CompanyProfileViewModel model, FormCollection form)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

                    return RedirectToAction("Index");
                }


                using (var mgr = new CMSLcLy.Data.SystemSetting.Manager())
                {
                    var result = mgr.Save(model);
                }

                return RedirectToAction("details");
            }
            catch (Exception ex)
            {
                TempData[COMM.Constants.WebUI.ErrorMessage] = "Failed to update User: " + ex.Message;
                return RedirectToAction("Index", model);
            }
        }

        // POST: SystemSetting/Company/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SystemSetting/Company/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SystemSetting/Company/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
