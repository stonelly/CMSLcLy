using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.Workflow
{
    public class workflowmasterItemViewModel
    {
        [Key]
        public int WorkFlowMasterID { get; set; }
        [StringLength(100)]
        public string WorkFlowName { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        [StringLength(128)]
        public string CreatedBy { get; set; }
        [StringLength(128)]
        public string ModifyBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
    }
}
