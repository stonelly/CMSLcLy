using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
namespace CMSApi.Controllers
{
    [Authorize]
    //[EnableCors("*", "*", "*")]
    public class UserDetailsController : ApiController
    {
        private ApplicationUserManager _userManager;

        public UserDetailsController()
        {

        }

        public UserDetailsController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

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


        // GET: api/UserDetails
        public async Task<IHttpActionResult> Get()
        {
            var aspNetuserObj = await UserManager.FindByNameAsync(User.Identity.Name);

            if (aspNetuserObj != null)
            {
                using (var mgr = new CMSLcLy.Data.UserDetails.Manager())
                {
                    return Ok(mgr.List(aspNetuserObj.Id));
                }
            }
            return NotFound();
        }

        // GET: api/UserDetails/5
        //public async Task<IHttpActionResult> Get()
        //{
        //    var aspNetuserObj = await UserManager.FindByNameAsync(User.Identity.Name);

        //    if (aspNetuserObj != null)
        //    {
        //        using (var mgr = new CMSLcLy.Data.UserDetails.Manager())
        //        {
        //            return mgr.List(aspNetuserObj.Id);
        //        }
        //    }
        //    return NotFound();
        //}

        
        public async Task<IHttpActionResult> Post(CMSLcLy.Data.UserDetails.userDetailsItemViewModel userDetailsViewModel)
        {
            userDetailsViewModel.CreatedBy = User.Identity.Name;
            userDetailsViewModel.ModifiedBy = User.Identity.Name;

            var aspNetuserObj = await UserManager.FindByNameAsync(User.Identity.Name);

            if (aspNetuserObj != null)
                userDetailsViewModel.AspNetUserId = aspNetuserObj.Id;
            
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var mgr = new CMSLcLy.Data.UserDetails.Manager())
            {
                var result = mgr.Add(userDetailsViewModel);
            }

            return Ok();
        }

        // PUT: api/UserDetails/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserDetails/5
        public void Delete(int id)
        {
        }
    }
}
