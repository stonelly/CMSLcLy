using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMSApi.Models
{
    public class ChatMessageModel
    {
        [Required]
        [JsonProperty("customerName")]
        public string CustomerName { get; set; }
        [Required]
        [JsonProperty("message")]
        public string Message { get; set; }
        [Required]
        [JsonProperty("roomName")]
        public string RoomName { get; set; }

    }
}