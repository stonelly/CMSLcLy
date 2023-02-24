using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CMSApi.Areas.Administration.Models
{
    public class DocumentTemplateViewModel
    {
        [Key]
        public string Id { get; set; }
        public string documentType { get; set; }
        public string documentPath { get; set; }
        public string documentName { get; set; }
        public string dataSource { get; set; }
        public string primary_key { get; set; }
    }
}