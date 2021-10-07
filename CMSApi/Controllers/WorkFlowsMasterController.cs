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
    public class WorkFlowsMasterController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public IHttpActionResult GetWorkFlow(int id)
        {
            IList<CMSLcLy.Data.Workflow.WorkFlowMaster.WorkflowMasterItemViewModel> model = null;

            using (var mgr = new CMSLcLy.Data.Workflow.WorkFlowMaster.Manager())
            {
                model = mgr.List().ToList();
            }

            if(model.Count == 0) return NotFound();
        

            return Ok(model);
             
        }

        // POST api/values
        public IHttpActionResult Post(CMSLcLy.Data.Workflow.WorkFlowMaster.WorkflowMasterItemViewModel model)
        {
            model.CreatedBy = User.Identity.Name;

            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var mgr = new CMSLcLy.Data.Workflow.WorkFlowMaster.Manager())
            {
                var result = mgr.Add(model);
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
