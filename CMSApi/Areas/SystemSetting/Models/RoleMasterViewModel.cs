using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CMSApi.Areas.SystemSetting.Models
{
    public class RoleMasterViewModel
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string OldName { get; set; }
    }
}