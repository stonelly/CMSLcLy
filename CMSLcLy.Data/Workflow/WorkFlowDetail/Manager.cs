using MAT;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.Workflow.WorkFlowDetail
{
    public class Manager : DbModels.BaseManager
    {
        public string Add(WorkFlowDetailMasterItemViewModel model)
        {
            if (model == null) return Resources.GlobalResource.NotificationMsg_InvalidNotificationType;

            var item = new DbModels.workflowdetail
            {
                WorkflowMasterID = model.WorkflowMasterID,
                Sequence = model.Sequence,
                Description = model.Description,
                Description_BM = model.Description_BM,
                Description_CN = model.Description_CN,
                Duration = model.Duration,
                CreatedDate = DateTime.Now,
                CreatedBy = model.CreatedBy,
                //ModifyBy = WorkFlowDetailMasterItemViewModel.ModifyBy,
                //ModifyDate = DateTime.Now,
            };

          
            Context.workflowdetails.Add(item);
            SaveChanges();

            return "OK";
        }

        public virtual WorkFlowDetailMasterItemViewModel Get(int workFlowId)
        {
            try
            {
                var q = (from model in Context.workflowdetails
                         where model.ID == workFlowId
                         select new WorkFlowDetailMasterItemViewModel
                         {
                             ID = model.ID,
                             WorkflowMasterID = model.WorkflowMasterID,
                             Sequence = model.Sequence,
                             Description = model.Description,
                             Description_BM = model.Description_BM,
                             Description_CN = model.Description_CN,
                             Duration = model.Duration,
                             CreatedBy = model.CreatedBy,
                             CreatedDate = model.CreatedDate,
                         }).FirstOrDefault();

                return q;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }



        }

        public IQueryable<WorkFlowDetailMasterItemViewModel> List()
        {
            var q = (from model in Context.workflowdetails
                     select new WorkFlowDetailMasterItemViewModel
                     {
                         ID = model.ID,
                         WorkflowMasterID = model.WorkflowMasterID,
                         Sequence = model.Sequence,
                         Description = model.Description,
                         Description_BM = model.Description_BM,
                         Description_CN = model.Description_CN,
                         Duration = model.Duration,
                         CreatedBy = model.CreatedBy,
                         CreatedDate = model.CreatedDate,
                     });


            return q;
        }
        
        public ActionResult Delete(int workFlowId)
        {
            var q = (from n in Context.workflowdetails
                     where n.ID == workFlowId
                     select n).ToList();

            q.ForEach(r => Context.workflowdetails.Remove(r));

            SaveChanges();

            return ActionResult.SucceededResult;
        }

        public ActionResult Update(WorkFlowDetailMasterItemViewModel model)
        {             
            var workFlowModel = Context.workflowdetails.Find(model.ID);
            workFlowModel.WorkflowMasterID = model.WorkflowMasterID;
            workFlowModel.Sequence = model.Sequence;
            workFlowModel.Description = model.Description;
            workFlowModel.Description_BM = model.Description_BM;
            workFlowModel.Description_CN = model.Description_CN;
            workFlowModel.Duration = model.Duration;
            workFlowModel.CreatedDate = DateTime.Now;

            BindUpdateData(workFlowModel);
            SaveChanges();

            return ActionResult.SucceededResult;
        }

        public String Save(WorkFlowDetailMasterItemViewModel model)
        {

            if (model == null) return Resources.GlobalResource.NotificationMsg_InvalidNotificationType;

            if (model.ID > 0)
            {
                var workFlowDetailModel = Context.workflowdetails.Find(model.ID);
                workFlowDetailModel.WorkflowMasterID = model.WorkflowMasterID;
                workFlowDetailModel.Sequence = model.Sequence;
                workFlowDetailModel.Description = model.Description;
                workFlowDetailModel.Description_BM = model.Description_BM;
                workFlowDetailModel.Description_CN = model.Description_CN;
                workFlowDetailModel.Duration = model.Duration;
                workFlowDetailModel.CreatedDate = DateTime.Now;

                //BindUpdateData(workFlowModel);
                SaveChanges();

            }
            else
            {
                var item = new DbModels.workflowdetail
                {
                    WorkflowMasterID = model.WorkflowMasterID,
                    Sequence = model.Sequence,
                    Description = model.Description,
                    Description_BM = model.Description_BM,
                    Description_CN = model.Description_CN,
                    Duration = model.Duration,
                    CreatedDate = DateTime.Now,
                    CreatedBy = model.CreatedBy
                };
                Context.workflowdetails.Add(item);
                SaveChanges();
            }

            UpdateWorkFlowMasterDuration(model.WorkflowMasterID);
            UpdateWorkFlowDuration(model.WorkflowMasterID);

            return "OK";
        }

        public int UpdateWorkFlowMasterDuration(int workflowMasterID)
        {
            return MAT.Helper.Convert.ToInt32(ExecuteScalar(SqlMaps.UpdateWorkFlowMasterDuration(),
                                                           new MySqlParameter("workflowMasterID", workflowMasterID)));
        }

        public int UpdateWorkFlowDuration(int workflowMasterID)
        {
            return MAT.Helper.Convert.ToInt32(ExecuteScalar(SqlMaps.UpdateWorkFlowDuration(),
                                                           new MySqlParameter("workflowMasterID", workflowMasterID)));
        }
    }

}
