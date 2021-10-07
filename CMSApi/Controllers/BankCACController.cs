using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CMSLcLy.Data.Bank.CAC;

namespace CMSApi.Controllers
{
    [Authorize]
    public class BankCACController : ApiController
    {
        public BankCACController()
        {
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            IList<CACmasterItemViewModel> cacmasterItemViewModel = null;

            using (var mgr = new CMSLcLy.Data.Bank.CAC.Manager())
            {
                cacmasterItemViewModel = mgr.List().ToList();
            }

            if (cacmasterItemViewModel == null) return NotFound();


            return Ok(cacmasterItemViewModel);
        }

        // GET api/<controller>/5
        public IHttpActionResult GetBank(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Bank id");

            CACmasterItemViewModel cacmasterItemViewModel = null;

            using (var mgr = new Manager())
            {
                cacmasterItemViewModel = mgr.Get(id);
            }

            if (cacmasterItemViewModel == null) return NotFound();

            return Ok(cacmasterItemViewModel);
        }

        // POST api/<controller>
        public IHttpActionResult Post(CACmasterItemViewModel cacmasterItemViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            cacmasterItemViewModel.CreatedBy = User.Identity.Name;

            using (var mgr = new Manager())
            {
                var result = mgr.Save(cacmasterItemViewModel);
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