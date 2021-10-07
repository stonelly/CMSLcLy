using CMSLcLy.Data.Workflow.WorkFlowMaster;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.Workflow
{
    public class WorkflowItemViewModel
    { 
        public int ID { get; set; }
        [Display(Name = "Checklist Descrption")]
        public string WorkflowDescrption { get; set; }
        [Display(Name = "Checklist Descrption BM")]
        public string WorkflowDescrption_BM { get; set; }
        [Display(Name = "Checklist Descrption CN")]
        public string WorkflowDescrption_CN { get; set; }
        [Display(Name = "Total Duration")]
        public Nullable<int> WorkflowTotalDuration { get; set; }
        [Display(Name = "Critical Duration")]
        public Nullable<int> CriticalDuration { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Created Date")]
        public System.DateTime CreatedDate { get; set; }

        public List<WorkflowMasterItemViewModel> WorkFlowMasters { get; set; }
    }
}
