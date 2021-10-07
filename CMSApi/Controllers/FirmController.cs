using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CMSLcLy.Data.Firm;

namespace CMSApi.Controllers
{
    [Authorize]
    public class FirmController : ApiController
    {
        public FirmController()
        {
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            IList<FirmMasterItemViewModel> firmMasterItemViewModel = null;

            using (var mgr = new CMSLcLy.Data.Firm.Manager())
            {
                firmMasterItemViewModel = mgr.List().ToList();
            }

            if (firmMasterItemViewModel == null) return NotFound();


            return Ok(firmMasterItemViewModel);
        }

        // GET api/<controller>/5
        public IHttpActionResult GetBank(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Bank id");

            FirmMasterItemViewModel firmMasterItemViewModel = null;

            using (var mgr = new Manager())
            {
                firmMasterItemViewModel = mgr.Get(id);
            }

            if (firmMasterItemViewModel == null) return NotFound();

            return Ok(firmMasterItemViewModel);
        }

        // POST api/<controller>
        public IHttpActionResult Post(FirmMasterItemViewModel firmMasterItemViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            firmMasterItemViewModel.CreatedBy = User.Identity.Name;

            using (var mgr = new Manager())
            {
                var result = mgr.Save(firmMasterItemViewModel);

                if(!result.Equals("OK"))
                {
                    return Conflict();
                }
            }

            return Ok();
        }


        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Bank id");

            using (var mgr = new Manager())
            {
                var result = mgr.Delete(id);
            }

            return Ok();
        }
    }
}