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
        public string Add(workflowmasterItemViewModel workflowmasterItemViewModel)
        {
            if (workflowmasterItemViewModel == null) return Resources.GlobalResource.NotificationMsg_InvalidNotificationType;

            var item = new DbModels.workflowmaster
            {
                WorkFlowName = workflowmasterItemViewModel.WorkFlowName,
                CreatedDate = DateTime.Now,
                CreatedBy = workflowmasterItemViewModel.CreatedBy,
                ModifyBy = workflowmasterItemViewModel.ModifyBy,
                ModifyDate = DateTime.Now,
            };

          
            Context.workflowmasters.Add(item);
            SaveChanges();

            return "OK";
        }

        public virtual workflowmasterItemViewModel Get(int workFlowId)
        {
            var q = (from n in Context.workflowmasters
                     where n.WorkFlowMasterID == workFlowId 
                     select new workflowmasterItemViewModel
                     {
                         WorkFlowMasterID = n.WorkFlowMasterID,
                         WorkFlowName = n.WorkFlowName,
                         CreatedBy = n.CreatedBy,
                         CreatedDate = n.CreatedDate,
                         ModifyBy = n.ModifyBy,
                         ModifyDate = n.ModifyDate
                     }).FirstOrDefault(); 

            return q;
        }

        public IQueryable<workflowmasterItemViewModel> List()
        {
            var q = (from n in Context.workflowmasters
                     select new workflowmasterItemViewModel
                     {
                         WorkFlowMasterID = n.WorkFlowMasterID,
                         WorkFlowName = n.WorkFlowName,
                         CreatedBy = n.CreatedBy,
                         CreatedDate = n.CreatedDate,
                         ModifyBy = n.ModifyBy,
                         ModifyDate = n.ModifyDate
                     });


            return q;
        }
        
        public ActionResult Delete(int workFlowId)
        {
            var q = (from n in Context.workflowmasters
                     where n.WorkFlowMasterID == workFlowId
                     select n).ToList();

            q.ForEach(r => Context.workflowmasters.Remove(r));

            SaveChanges();

            return ActionResult.SucceededResult;
        }

        public ActionResult Update(workflowmasterItemViewModel model)
        {             
            var workFlowModel = Context.workflowmasters.Find(model.WorkFlowMasterID);
            workFlowModel.WorkFlowName = model.WorkFlowName;
            workFlowModel.ModifyDate = DateTime.Now;
             
            BindUpdateData(workFlowModel);
            SaveChanges();

            return ActionResult.SucceededResult;
        }
    }

}
