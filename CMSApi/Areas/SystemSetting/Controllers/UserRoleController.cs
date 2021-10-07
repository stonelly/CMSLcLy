using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMSApi.Areas.SystemSetting.Controllers
{
    public class UserRoleController : Controller
    {
        // GET: SystemSetting/UserRole
        public ActionResult Index()
        {
            return View();
        }

        // GET: SystemSetting/UserRole/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SystemSetting/UserRole/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SystemSetting/UserRole/Create
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

        // GET: SystemSetting/UserRole/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SystemSetting/UserRole/Edit/5
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

        // GET: SystemSetting/UserRole/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SystemSetting/UserRole/Delete/5
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
