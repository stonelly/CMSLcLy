using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.SystemSetting
{
    public class CompanyProfileViewModel
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Firm Name")]
        public string firm_name { get; set; }
        [Display(Name = "Address1")]
        public string add1 { get; set; }
        [Display(Name = "Address2")]
        public string add2 { get; set; }
        [Display(Name = "Address3")]
        public string add3 { get; set; }
        [Display(Name = "Address4")]
        public string add4 { get; set; }
        [Display(Name = "Postcode")]
        public string postcode { get; set; }
        [Display(Name = "Town")]
        public string Town { get; set; }
        [Display(Name = "State")]
        public string state { get; set; }
        [Display(Name = "Country")]
        public string Country { get; set; }
        [Display(Name = "Phone1")]
        public string phone1 { get; set; }
        [Display(Name = "Phone2")]
        public string phone2 { get; set; }
        [Display(Name = "Phone3")]
        public string phone3 { get; set; }
        [Display(Name = "Fax1")]
        public string fax1 { get; set; }
        [Display(Name = "Fax2")]
        public string fax2 { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Irb No")]
        public string irb_no { get; set; }
        [Display(Name = "Irb branch")]
        public string irb_branch { get; set; }
        [Display(Name = "Socso No")]
        public string socso_no { get; set; }
        [Display(Name = "Socso branch")]
        public string socso_branch { get; set; }
        [Display(Name = "EPF No")]
        public string epf_no { get; set; }
        [Display(Name = "EPF branch")]
        public string epf_branch { get; set; }
        [Display(Name = "GST/SST No")]
        public string gst_sst_no { get; set; }
        [Display(Name = "Freefield1")]
        public string freefield1 { get; set; }
        [Display(Name = "Freefield2")]
        public string freefield2 { get; set; }
        [Display(Name = "Freefield3")]
        public string freefield3 { get; set; }
        [Display(Name = "Freefield4")]
        public string freefield4 { get; set; }
        [Display(Name = "Freefield5")]
        public string freefield5 { get; set; }
    }
}