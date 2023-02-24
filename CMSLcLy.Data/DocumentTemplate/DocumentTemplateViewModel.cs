using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.DocumentTemplate
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
