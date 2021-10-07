using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CMSLcLy.Data.Bank;

namespace CMSApi.Controllers
{
    [Authorize]
    public class BankController : ApiController
    {
        public BankController()
        {
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            IList<bankmasterItemViewModel> bankmasterItemViewModel = null;

            using (var mgr = new CMSLcLy.Data.Bank.Manager())
            {
                bankmasterItemViewModel = mgr.List().ToList();
            }

            if (bankmasterItemViewModel == null) return NotFound();


            return Ok(bankmasterItemViewModel);
        }

        // GET api/<controller>/5
        public IHttpActionResult GetBank(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Bank id");

            bankmasterItemViewModel bankmasterItemViewModel = null;

            using (var mgr = new Manager())
            {
                bankmasterItemViewModel = mgr.Get(id);
            }

            if (bankmasterItemViewModel == null) return NotFound();

            return Ok(bankmasterItemViewModel);
        }

        // POST api/<controller>
        public IHttpActionResult Post(bankmasterItemViewModel bankmasterItemViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            bankmasterItemViewModel.CreatedBy = User.Identity.Name;
            bankmasterItemViewModel.ModifyBy = User.Identity.Name;

            using (var mgr = new Manager())
            {
                var result = mgr.Save(bankmasterItemViewModel);
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