using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CMSLcLy.Data.EnumMaster;

namespace CMSApi.Controllers
{
    [Authorize]
    public class EnumMasterController : ApiController
    {
        public EnumMasterController()
        {
        }

        // GET api/<controller>
        [HttpGet]
        [Route("api/EnumMaster/")]
        public IHttpActionResult Get(string enumType)
        {
            IList<EnumMasterItemViewModel> EnumMasterItemViewModel = null;

            using (var mgr = new CMSLcLy.Data.EnumMaster.Manager())
            {
                EnumMasterItemViewModel = mgr.List(enumType).ToList();
            }

            if (EnumMasterItemViewModel == null) return NotFound();


            return Ok(EnumMasterItemViewModel);
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("api/EnumMaster/{id:int}")]
        public IHttpActionResult GetBank(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Enum id");

            EnumMasterItemViewModel EnumMasterItemViewModel = null;

            using (var mgr = new Manager())
            {
                EnumMasterItemViewModel = mgr.Get(id);
            }

            if (EnumMasterItemViewModel == null) return NotFound();

            return Ok(EnumMasterItemViewModel);
        }

        // POST api/<controller>
        public IHttpActionResult Post(EnumMasterItemViewModel enumMasterItemViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            enumMasterItemViewModel.CreatedBy = User.Identity.Name;

            using (var mgr = new Manager())
            {
                var result = mgr.Save(enumMasterItemViewModel);
            }

            return Ok();
        }

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
        // DELETE api/<controller>/5
        //public IHttpActionResult Delete(EnumMasterItemViewModel enumMasterItemViewModel)
        //{
        //    if (enumMasterItemViewModel != null && enumMasterItemViewModel.Id <= 0)
        //        return BadRequest("Not a valid Enum id");

        //    using (var mgr = new Manager())
        //    {
        //        var result = mgr.Delete(enumMasterItemViewModel);
        //    }

        //    return Ok();
        //}
    }
}