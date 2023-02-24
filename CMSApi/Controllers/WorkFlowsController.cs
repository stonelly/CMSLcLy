using CMSLcLy.Data.File;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CMSApi.Controllers
{
    [Authorize]
    //[EnableCors("*", "*", "*")]
    public class WorkFlowsController : ApiController
    {
        private const string LocalLoginProvider = "Local";
        private ApplicationUserManager _userManager;

        public WorkFlowsController()
        {
        }

        public WorkFlowsController(ApplicationUserManager userManager,
            ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            UserManager = userManager;
            AccessTokenFormat = accessTokenFormat;
        }
        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        public IHttpActionResult WorkFlowList()
        {
            String userID = User.Identity.GetUserId();

            //userID = "3c60fc6d-cb6f-47fd-844f-0924f7574aad";

            IList<DocumentItemViewModel> documentItemViewModel = null;

            using (var mgr = new CMSLcLy.Data.File.Manager())
            {
                documentItemViewModel = mgr.List(userID).ToList();
            }

            List<WFMasterItemViewModel> wfItemList = new List<WFMasterItemViewModel>();

            foreach (var doc in documentItemViewModel)
            {
                using (var mgr = new CMSLcLy.Data.File.Manager())
                {
                    var WFItem = mgr.ListByFileNo(doc.FileNo).ToList();

                    wfItemList.Add(WFItem.Where(x => x.isCompleted == 0).FirstOrDefault());
                }
            }

            if (documentItemViewModel == null) return NotFound();

            return Ok(documentItemViewModel);
        }

        public IHttpActionResult UpdateToDo(int id, int documentWorkflowId)
        {
            String userID = User.Identity.GetUserId();

            //userID = "3c60fc6d-cb6f-47fd-844f-0924f7574aad";

            IList<DocumentItemViewModel> documentItemViewModel = null;

            using (var mgr = new CMSLcLy.Data.File.Manager())
            {
                documentItemViewModel = mgr.List(userID).ToList();
            }

            List<WFMasterItemViewModel> wfItemList = new List<WFMasterItemViewModel>();

            foreach (var doc in documentItemViewModel)
            {
                using (var mgr = new CMSLcLy.Data.File.Manager())
                {
                    var WFItem = mgr.ListByFileNo(doc.FileNo).ToList();

                    wfItemList.Add(WFItem.Where(x => x.isCompleted == 0).FirstOrDefault());
                }
            }

            if (documentItemViewModel == null) return NotFound();

            return Ok(documentItemViewModel);
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
