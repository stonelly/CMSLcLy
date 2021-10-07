using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMSApi.Areas.SystemSetting.Controllers
{
    public class UserController : Controller
    {
        // GET: SystemSetting/User
        public ActionResult Index()
        {
            return View();
        }

        // GET: SystemSetting/User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SystemSetting/User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SystemSetting/User/Create
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

        // GET: SystemSetting/User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SystemSetting/User/Edit/5
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

        // GET: SystemSetting/User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SystemSetting/User/Delete/5
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
