using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.Firm
{
    public class FirmMasterItemViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Display(Name = "User ID")]
        public string AspNetUserID { get; set; }
        [Display(Name = "Firm Name")]
        public string FirmName { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Address")]
        public string Address2 { get; set; }
        [Display(Name = "Address")]
        public string Address3 { get; set; }
        [Display(Name = "PostCode")]
        public string PostCode { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        [Display(Name = "Phone")]
        public string Phone2 { get; set; }
        [Display(Name = "Phone")]
        public string Phone3 { get; set; }
        [Display(Name = "Fax")]
        public string Fax { get; set; }
        [Display(Name = "Fax")]
        public string Fax2 { get; set; }
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Remark")]
        public string Remark { get; set; }
        [Display(Name = "Created Date")]
        public Nullable<System.DateTime> CreatedDate { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Modify Date")]
        public Nullable<System.DateTime> ModifyDate { get; set; }
        [Display(Name = "Modify By")]
        public string ModifyBy { get; set; }
        public List<System.Web.Mvc.SelectListItem> Users { get; set; }
    }
}
