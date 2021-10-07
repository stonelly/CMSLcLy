using CMSLcLy.Data.Workflow.WorkFlowMaster;
using MAT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.Workflow
{
    public class Manager : DbModels.BaseManager
    {
        public string Add(WorkflowItemViewModel model)
        {
            if (model == null) return Resources.GlobalResource.NotificationMsg_InvalidNotificationType;

            var item = new DbModels.workflow
            {
                ID = model.ID,
                WorkflowDescrption = model.WorkflowDescrption,
                WorkflowDescrption_BM = model.WorkflowDescrption_BM,
                WorkflowDescrption_CN = model.WorkflowDescrption_CN,
                WorkflowTotalDuration = model.WorkflowTotalDuration,
                CriticalDuration = model.CriticalDuration,
                CreatedDate = DateTime.Now,
                CreatedBy = model.CreatedBy, 
            };

          
            Context.workflows.Add(item);
            SaveChanges();

            return "OK";
        }

        public virtual WorkflowItemViewModel Get(int workFlowId)
        {
            var q = (from model in Context.workflows
                     where model.ID == workFlowId 
                     select new WorkflowItemViewModel
                     {
                         ID = model.ID,
                         WorkflowDescrption = model.WorkflowDescrption,
                         WorkflowDescrption_BM = model.WorkflowDescrption_BM,
                         WorkflowDescrption_CN = model.WorkflowDescrption_CN,
                         WorkflowTotalDuration = model.WorkflowTotalDuration,
                         CriticalDuration = model.CriticalDuration,
                         CreatedDate = DateTime.Now,
                         CreatedBy = model.CreatedBy,
                     }).FirstOrDefault();


            q.WorkFlowMasters = (from model in Context.workflowmasters
                     where model.WorkflowID == q.ID
                     select new WorkflowMasterItemViewModel
                     {
                         ID = model.ID,
                         WorkflowID = model.WorkflowID,
                         WorkFlowMasterDesc = model.WorkFlowMasterDesc,
                         WorkFlowMasterDesc_BM = model.WorkFlowMasterDesc_BM,
                         WorkFlowMasterDesc_CN = model.WorkFlowMasterDesc_CN,
                         WorkFlowMasterDuration = model.WorkFlowMasterDuration,
                         CreatedBy = model.CreatedBy,
                         CreatedDate = model.CreatedDate,
                     }).ToList();             

            return q;
        }

        public IQueryable<WorkflowItemViewModel> List()
        {
            var q = (from model in Context.workflows
                     select new WorkflowItemViewModel
                     {
                         ID = model.ID,
                         WorkflowDescrption = model.WorkflowDescrption,
                         WorkflowDescrption_BM = model.WorkflowDescrption_BM,
                         WorkflowDescrption_CN = model.WorkflowDescrption_CN,
                         WorkflowTotalDuration = model.WorkflowTotalDuration,
                         CriticalDuration = model.CriticalDuration,
                         CreatedDate = DateTime.Now,
                         CreatedBy = model.CreatedBy,
                     });


            return q;
        }
        
        public ActionResult Delete(int workFlowId)
        {
            var q = (from n in Context.workflows
                     where n.ID == workFlowId
                     select n).ToList();

            q.ForEach(r => Context.workflows.Remove(r));

            SaveChanges();

            return ActionResult.SucceededResult;
        }

        public String Save(WorkflowItemViewModel model)
        {             

            if (model == null) return Resources.GlobalResource.NotificationMsg_InvalidNotificationType;

            if (model.ID > 0)
            {
                var workFlowModel = Context.workflows.Find(model.ID);
                workFlowModel.WorkflowDescrption = model.WorkflowDescrption;
                workFlowModel.WorkflowDescrption_BM = model.WorkflowDescrption_BM;
                workFlowModel.WorkflowDescrption_CN = model.WorkflowDescrption_CN;
                workFlowModel.WorkflowTotalDuration = model.WorkflowTotalDuration;
                workFlowModel.CriticalDuration = model.CriticalDuration;
                workFlowModel.CreatedDate = DateTime.Now;

                //BindUpdateData(workFlowModel);
                SaveChanges();

            }
            else
            {
                var item = new DbModels.workflow
                {
                    WorkflowDescrption = model.WorkflowDescrption,
                    WorkflowDescrption_BM = model.WorkflowDescrption_BM,
                    WorkflowDescrption_CN = model.WorkflowDescrption_CN,
                    WorkflowTotalDuration = model.WorkflowTotalDuration,
                    CriticalDuration = model.CriticalDuration,
                    CreatedDate = DateTime.Now,
                    CreatedBy = model.CreatedBy
                };
                Context.workflows.Add(item);
                SaveChanges();
            }

            return "OK";
        }
    }

}
