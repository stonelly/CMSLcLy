using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CMSApi.Controllers
{
    [Authorize]
    public class WorkFlowsController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public IHttpActionResult GetWorkFlow(int id)
        {
            IList<CMSLcLy.Data.Workflow.workflowmasterItemViewModel> workflowmasterItemViewModel = null;

            using (var mgr = new CMSLcLy.Data.Workflow.Manager())
            {
                workflowmasterItemViewModel = mgr.List().ToList();
            }

            if(workflowmasterItemViewModel.Count == 0) return NotFound();
        

            return Ok(workflowmasterItemViewModel);
             
        }

        // POST api/values
        public IHttpActionResult Post(CMSLcLy.Data.Workflow.workflowmasterItemViewModel workflowmasterItemViewModel)
        {
            workflowmasterItemViewModel.CreatedBy = User.Identity.Name;
            workflowmasterItemViewModel.ModifyBy = User.Identity.Name;

            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var mgr = new CMSLcLy.Data.Workflow.Manager())
            {
                var result = mgr.Add(workflowmasterItemViewModel);
            }

            return Ok();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
