using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.Bank.CAC
{
    public class CACmasterItemViewModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "CAC Name")]
        public string CACName { get; set; }
        [Display(Name = "Bank Name")]
        public string BankName { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Address")]
        public string Address2 { get; set; }
        [Display(Name = "Address")]
        public string Address3 { get; set; }
        [Display(Name = "PostCode")]
        public string PostCode { get; set; }
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
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Created Date")]
        public Nullable<System.DateTime> CreatedDate { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Modify Date")]
        public Nullable<System.DateTime> ModifyDate { get; set; }
        [Display(Name = "Modify By")]
        public string ModifyBy { get; set; }
    }
}
