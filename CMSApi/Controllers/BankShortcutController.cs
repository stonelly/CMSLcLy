using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CMSLcLy.Data.Bank.BankShortCut;

namespace CMSApi.Controllers
{
    [Authorize]
    public class BankShortcutController : ApiController
    {
        public BankShortcutController()
        {
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            IList<bankshortcutmasterItemViewModel> bankshortcutmasterItemViewModel = null;

            using (var mgr = new CMSLcLy.Data.Bank.BankShortCut.Manager())
            {
                bankshortcutmasterItemViewModel = mgr.List().ToList();
            }

            if (bankshortcutmasterItemViewModel == null) return NotFound();


            return Ok(bankshortcutmasterItemViewModel);
        }

        // GET api/<controller>/5
        public IHttpActionResult GetBank(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Bank Shortcut id");

            bankshortcutmasterItemViewModel bankshortcutmasterItemViewModel = null;

            using (var mgr = new Manager())
            {
                bankshortcutmasterItemViewModel = mgr.Get(id);
            }

            if (bankshortcutmasterItemViewModel == null) return NotFound();

            return Ok(bankshortcutmasterItemViewModel);
        }

        // POST api/<controller>
        public IHttpActionResult Post(bankshortcutmasterItemViewModel bankshortcutmasterItemViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            bankshortcutmasterItemViewModel.CreatedBy = User.Identity.Name;

            using (var mgr = new Manager())
            {
                var result = mgr.Save(bankshortcutmasterItemViewModel);
            }

            return Ok();
        }


        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Bank Shortcut id");

            using (var mgr = new Manager())
            {
                var result = mgr.Delete(id);
            }

            return Ok();
        }
    }
}