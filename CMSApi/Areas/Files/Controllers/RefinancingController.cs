﻿using CMSLcLy.Data.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace CMSApi.Areas.Files.Controllers
{
    public class RefinancingController : Controller
    {
        // GET: Files/Refinancing
        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Http.HttpPost]
        public ActionResult SaveFile([FromBody] DocumentMasterViewModel model)
        {

            model.CreatedBy = User.Identity.Name;
            model.ModifyBy = User.Identity.Name;

            var result = "";
            using (var mgr = new CMSLcLy.Data.File.Manager())
            {
                result = mgr.Save(model,"Refinancing");
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}