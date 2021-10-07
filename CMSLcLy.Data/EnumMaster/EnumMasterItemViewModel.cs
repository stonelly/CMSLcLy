using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.EnumMaster
{
    public class EnumMasterItemViewModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Parameter")]
        public string EnumType { get; set; }
        [Display(Name = "Parameter Name")]
        public string EnumName { get; set; }
        [Display(Name = "Description")]
        public string EnumValue { get; set; }
        [Display(Name = "Status")]
        public int Status { get; set; }
        [Display(Name = "Created Date")]
        public System.DateTime CreatedDate { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Modify Date")]
        public Nullable<System.DateTime> ModifyDate { get; set; }
        [Display(Name = "Modify By")]
        public string ModifyBy { get; set; }
    }
}
