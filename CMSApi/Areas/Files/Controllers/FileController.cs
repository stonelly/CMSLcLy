using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMSApi.Areas.Files.Controllers
{
    public class FileController : Controller
    {
        // GET: Files/File
        public ActionResult FileListing()
        {
            return View();
        }
    }
}