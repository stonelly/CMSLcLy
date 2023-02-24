using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMSApi.Areas.Files.Models
{
    public class ChatViewModel
    {
        public string CustomerName { get; set; }
        public string Message { get; set; }
        public string RoomName { get; set; }
        public string CreatedDate { get; set; }

        //public DateTime ModifiedDate { get; set; }
    }
}