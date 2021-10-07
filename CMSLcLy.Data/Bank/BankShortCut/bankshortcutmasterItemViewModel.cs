using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.Bank.BankShortCut
{
    public class bankshortcutmasterItemViewModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "ShortCut Name")]
        public string BankShortCut { get; set; }
        [Display(Name = "Bank Name")]
        public string BankName { get; set; }
        [Display(Name = "Company No.")]
        public string CompanyNo { get; set; }
        [Display(Name = "Registration Address")]
        public string RegistrationAddress { get; set; }
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
