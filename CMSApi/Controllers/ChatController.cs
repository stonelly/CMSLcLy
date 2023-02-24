using CMSApi.Models;
using CMSLcLy.Data.Chat;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CMSApi.Controllers
{
    [Authorize]
    //[EnableCors("*", "*", "*")]
    public class ChatController : ApiController
    {
        private ApplicationUserManager _userManager;

        public ChatController(ApplicationUserManager userManager)
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

        // GET api/<controller>
        [HttpGet]
        [Route("api/chat/")]
        public IHttpActionResult Get()
        {
            IList<chatmasterViewModel> chatmasterViewModel = null;

            using (var mgr = new CMSLcLy.Data.Chat.Manager())
            {
                chatmasterViewModel = mgr.List().ToList();
            }

            if (chatmasterViewModel == null) return NotFound();


            return Ok(chatmasterViewModel);
        }

        // GET api/<controller>
        [HttpGet]
        [Route("api/chat/get")]
        public IHttpActionResult GetByCustomerNameAndRoomName(string customerName, string roomName)
        {
            IList<chatmasterViewModel> chatmasterViewModel = null;

            using (var mgr = new CMSLcLy.Data.Chat.Manager())
            {
                chatmasterViewModel = mgr.GetByCustomerNameAndRoomName(customerName,roomName).ToList();
            }

            if (chatmasterViewModel == null) return NotFound();

            return Ok(chatmasterViewModel);
        }

        // POST api/<controller>
        [HttpPost]
        [Route("api/chat/save")]
        public IHttpActionResult Post(ChatMessageModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            chatmasterViewModel viewModel = new chatmasterViewModel();
            viewModel.CustomerName = model.CustomerName;
            viewModel.RoomName = model.RoomName;
            viewModel.Message = model.Message;
            viewModel.CreatedDate = DateTime.Now;
            viewModel.ModifiedDate = DateTime.Now;

            using (var mgr = new Manager())
            {
                var result = mgr.Save(viewModel);
            }

            return Ok();
        }


        [HttpGet]
        [Route("api/chat/notification")]
        public async Task<IHttpActionResult> GetNotificationAsync()
        {
            var aspNetuserObj = await UserManager.FindByNameAsync(User.Identity.Name);

            var notificationCount = 0;
            //using (var mgr = new CMSLcLy.Data.Notification.Manager())
            //{
            //    notificationCount = mgr.GetByCustomerName(aspNetuserObj.Id).Count();
            //}

            return Ok(notificationCount);
        }

    }
}