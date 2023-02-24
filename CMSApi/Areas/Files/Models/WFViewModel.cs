using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CMSApi.Areas.Files.Models
{
    public class WFViewModel
    {
        public int Id { get; set; }
        public string WorkFlowMasterDesc { get; set; }
        public string Description { get; set; }

        public string IsCompleted { get; set; }
    }
}