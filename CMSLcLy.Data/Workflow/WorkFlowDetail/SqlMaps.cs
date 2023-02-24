using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.Workflow.WorkFlowDetail
{
    public class SqlMaps
    {
        public static string UpdateWorkFlowMasterDuration()
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("UPDATE workflowmaster ");
            sql.AppendLine("SET WorkFlowMasterDuration = (SELECT SUM(Duration) FROM workflowdetail WHERE WorkflowMasterID = @workflowMasterID)");
            sql.AppendLine("WHERE ID=@workflowMasterID");

            return sql.ToString();
        }


        public static string UpdateWorkFlowDuration()
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("UPDATE workflow ");
            sql.AppendLine("SET WorkflowTotalDuration = (SELECT SUM(WorkFlowMasterDuration) FROM workflowmaster WHERE WorkflowID = (SELECT WorkflowID FROM workflowmaster WHERE ID = @workflowMasterID ))");
            sql.AppendLine("WHERE ID=(SELECT WorkflowID FROM workflowmaster WHERE ID = @workflowMasterID )   ;");

            return sql.ToString();
        }
    }
}
