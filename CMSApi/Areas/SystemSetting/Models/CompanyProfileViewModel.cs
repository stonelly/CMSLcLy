using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CMSApi.Areas.SystemSetting.Models
{
    public class CompanyProfileViewModel
    {
        [Key]
        public int ID { get; set; }
        public string firm_name { get; set; }
        public string add1 { get; set; }
        public string add2 { get; set; }
        public string add3 { get; set; }
        public string add4 { get; set; }
        public string postcode { get; set; }
        public string Town { get; set; }
        public string state { get; set; }
        public string Country { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string phone3 { get; set; }
        public string fax1 { get; set; }
        public string fax2 { get; set; }
        public string email { get; set; }
        public string irb_no { get; set; }
        public string irb_branch { get; set; }
        public string socso_no { get; set; }
        public string socso_branch { get; set; }
        public string epf_no { get; set; }
        public string epf_branch { get; set; }
        public string gst_sst_no { get; set; }
        public string freefield1 { get; set; }
        public string freefield2 { get; set; }
        public string freefield3 { get; set; }
        public string freefield4 { get; set; }
        public string freefield5 { get; set; }
    }
}