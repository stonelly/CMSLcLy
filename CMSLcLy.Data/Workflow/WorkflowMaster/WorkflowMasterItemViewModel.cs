using CMSLcLy.Data.Workflow.WorkFlowDetail;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.Workflow.WorkFlowMaster
{
    public class WorkflowMasterItemViewModel
    {
        public int ID { get; set; }
        [Display(Name = "WorkflowID")]
        public Nullable<int> WorkflowID { get; set; }
        [Display(Name = "Sequence")]
        public Nullable<int> Sequence { get; set; }
        [Display(Name = "Step Description")]
        public string WorkFlowMasterDesc { get; set; }
        [Display(Name = "Step Description BM")]
        public string WorkFlowMasterDesc_BM { get; set; }
        [Display(Name = "Step Description CN")]
        public string WorkFlowMasterDesc_CN { get; set; }
        [Display(Name = "Step Duration")]
        public int WorkFlowMasterDuration { get; set; }
        [Display(Name = "Created Date")]
        public Nullable<System.DateTime> CreatedDate { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        public List<WorkFlowDetailMasterItemViewModel> WorkFlowDetails { get; set; }
    }
}
