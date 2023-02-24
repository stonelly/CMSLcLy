using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.Notification
{
    public class notificationmasterViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        [Required]
        [Display(Name = "Status")]
        public sbyte Status { get; set; }
        [Required]
        [Display(Name = "Room Name")]
        public string RoomName { get; set; }
        public int MessageID { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
