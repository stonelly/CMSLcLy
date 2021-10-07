using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CMSLcLy.Data.Bank
{
    public class bankmasterItemViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Bank Shortcut")]
        public int BankShortCutID { get; set; }
        
        [Display(Name = "Bank Shortcut")]
        public string BankShortCut { get; set; }
        [Required]
        [Display(Name = "Bank Name")]
        public string BankName { get; set; }
        [Required]
        [Display(Name = "Branch Name")]
        public string BranchName { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Address 2")]
        public string Address2 { get; set; }
        [Display(Name = "Address 3")]
        public string Address3 { get; set; }
        [Required]
        [Display(Name = "PostCode")]
        public string PostCode { get; set; }
        [Required]
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        [Display(Name = "Phone 2")]
        public string Phone2 { get; set; }
        [Display(Name = "Phone 3")]
        public string Phone3 { get; set; }
       
        [Display(Name = "Fax")]
        public string Fax { get; set; }
        [Display(Name = "Fax 2")]
        public string Fax2 { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "CAC")]
        public int CACID { get; set; }
       
        [Display(Name = "CAC")]
        public string CAC { get; set; }
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }
        [Display(Name = "Created Date")]
        public Nullable<System.DateTime> CreatedDate { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Modify Date")]
        public Nullable<System.DateTime> ModifyDate { get; set; }
        [Display(Name = "Modify By")]
        public string ModifyBy { get; set; }


        public List<SelectListItem> BankShortCuts { get; set; }
        public List<SelectListItem> BankCACs { get; set; }
    }
}
