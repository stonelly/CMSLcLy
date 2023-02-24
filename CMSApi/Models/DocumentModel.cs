using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DevExpress.XtraRichEdit;

namespace CMSApi.Models
{
    public class DocumentModel
    {
        public string DocumentId { get; set; }
        public string DocumentType { get; set; }

        public DataTable DocumentDs { get; set; }
        public string DocumentPath { get; set; }
        public string DocumentName { get; set; }

        public string dataSource { get; set; }
        public string primary_key { get; set; }

        public DevExpress.XtraRichEdit.DocumentFormat DocumentFormat { get; set; }

        public HttpPostedFileBase DocumentFile { get; set; }
    }
}