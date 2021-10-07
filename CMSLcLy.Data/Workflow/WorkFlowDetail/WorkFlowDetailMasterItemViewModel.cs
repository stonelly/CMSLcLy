using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.Workflow.WorkFlowDetail
{
    public class WorkFlowDetailMasterItemViewModel
    {
        public int ID { get; set; }
        public int WorkflowMasterID { get; set; }
        public Nullable<int> Sequence { get; set; }
        public string Description { get; set; }
        public string Description_BM { get; set; }
        public string Description_CN { get; set; }
        public int Duration { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
