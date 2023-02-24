using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CMSLcLy.Data.SystemSetting;

namespace CMSApi.Controllers
{
    [Authorize]
    public class CompanyController : ApiController
    {
        public CompanyController()
        {
        }

        public IHttpActionResult Get()
        {
            CompanyProfileViewModel cpvm = null;

            using (var v = new CMSLcLy.Data.SystemSetting.Manager())
            {
                cpvm = v.Get(1);
            }

            if (cpvm == null) return NotFound();

            return Ok(cpvm);
        }

    }
}
