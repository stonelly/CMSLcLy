using CMSLcLy.Data.Workflow.WorkFlowDetail;
using MAT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.Workflow.WorkFlowMaster
{
    public class Manager : DbModels.BaseManager
    {
        public string Add(WorkflowMasterItemViewModel model)
        {
            if (model == null) return Resources.GlobalResource.NotificationMsg_InvalidNotificationType;

            var item = new DbModels.workflowmaster
            {
                ID = model.ID,
                WorkflowID = model.WorkflowID,
                WorkFlowMasterDesc = model.WorkFlowMasterDesc,
                WorkFlowMasterDesc_BM = model.WorkFlowMasterDesc_BM,
                WorkFlowMasterDesc_CN = model.WorkFlowMasterDesc_CN,
                WorkFlowMasterDuration = model.WorkFlowMasterDuration,
                CreatedDate = DateTime.Now,
                CreatedBy = model.CreatedBy,
                //ModifyBy = workflowmasterItemViewModel.ModifyBy,
                //ModifyDate = DateTime.Now,
            };

          
            Context.workflowmasters.Add(item);
            SaveChanges();

            return "OK";
        }

        public virtual WorkflowMasterItemViewModel Get(int workFlowId)
        {
            var q = (from model in Context.workflowmasters
                     where model.ID == workFlowId 
                     select new WorkflowMasterItemViewModel
                     {
                         ID = model.ID,
                         WorkflowID = model.WorkflowID,
                         WorkFlowMasterDesc = model.WorkFlowMasterDesc,
                         WorkFlowMasterDesc_BM = model.WorkFlowMasterDesc_BM,
                         WorkFlowMasterDesc_CN = model.WorkFlowMasterDesc_CN,
                         WorkFlowMasterDuration = model.WorkFlowMasterDuration,
                         Sequence = model.Sequence,
                         CreatedBy = model.CreatedBy,
                         CreatedDate = model.CreatedDate, 
                     }).FirstOrDefault();



            //q.WorkFlowDetails = (from model in Context.workflowdetails
            //                     where model.WorkflowMasterID == q.ID
            //                     select new WorkFlowDetailMasterItemViewModel
            //                     {
            //                         ID = model.ID,
            //                         WorkflowMasterID = model.WorkflowMasterID,
            //                         Sequence = model.Sequence,
            //                         Description = model.Description,
            //                         Description_BM = model.Description_BM,
            //                         Description_CN = model.Description_CN,
            //                         CreatedBy = model.CreatedBy,
            //                         CreatedDate = model.CreatedDate,
            //                     }).ToList();


            return q;
        }

        public IQueryable<WorkflowMasterItemViewModel> List()
        {
            var q = (from model in Context.workflowmasters
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
                     });


            return q;
        }
        
        public ActionResult Delete(int workFlowId)
        {
            var q = (from n in Context.workflowmasters
                     where n.ID == workFlowId
                     select n).ToList();

            q.ForEach(r => Context.workflowmasters.Remove(r));

            SaveChanges();

            return ActionResult.SucceededResult;
        }

        public ActionResult Update(WorkflowMasterItemViewModel model)
        {             
            var workFlowModel = Context.workflowmasters.Find(model.ID);
            workFlowModel.WorkFlowMasterDesc = model.WorkFlowMasterDesc;
            workFlowModel.WorkFlowMasterDesc_BM = model.WorkFlowMasterDesc_BM;
            workFlowModel.WorkFlowMasterDesc_CN = model.WorkFlowMasterDesc_CN;
            workFlowModel.WorkFlowMasterDuration = model.WorkFlowMasterDuration;
            workFlowModel.Sequence = model.Sequence;
            workFlowModel.CreatedDate = DateTime.Now;
             
           // BindUpdateData(workFlowModel);
            SaveChanges();

            return ActionResult.SucceededResult;
        }



        public String Save(WorkflowMasterItemViewModel model)
        {

            if (model == null) return Resources.GlobalResource.NotificationMsg_InvalidNotificationType;

            if (model.ID > 0)
            {
                var workFlowModel = Context.workflowmasters.Find(model.ID);
                workFlowModel.WorkflowID = model.WorkflowID;
                workFlowModel.WorkFlowMasterDesc = model.WorkFlowMasterDesc;
                workFlowModel.WorkFlowMasterDesc_BM = model.WorkFlowMasterDesc_BM;
                workFlowModel.WorkFlowMasterDesc_CN = model.WorkFlowMasterDesc_CN;
                workFlowModel.WorkFlowMasterDuration = model.WorkFlowMasterDuration;
                workFlowModel.Sequence = model.Sequence;
                workFlowModel.CreatedDate = DateTime.Now;

                //BindUpdateData(workFlowModel);
                SaveChanges();

            }
            else
            {
                var item = new DbModels.workflowmaster
                {
                    WorkflowID = model.WorkflowID,
                    WorkFlowMasterDesc = model.WorkFlowMasterDesc,
                    WorkFlowMasterDesc_BM = model.WorkFlowMasterDesc_BM,
                    WorkFlowMasterDesc_CN = model.WorkFlowMasterDesc_CN,
                    WorkFlowMasterDuration = model.WorkFlowMasterDuration,
                    Sequence = model.Sequence,
                    CreatedDate = DateTime.Now,
                    CreatedBy = model.CreatedBy
                };
                Context.workflowmasters.Add(item);
                SaveChanges();
            }

            return "OK";
        }
    }

}
