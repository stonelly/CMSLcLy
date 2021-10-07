using CMSLcLy.Common.Enums;
using MAT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.EnumMaster
{
    public class Manager : DbModels.BaseManager
    {
        public IQueryable<EnumMasterItemViewModel> List(string enumType)
        {
            var q = (from model in Context.enummasters
                     where model.EnumType == enumType & model.Status == 1
                     select new EnumMasterItemViewModel
                     {
                         Id = model.Id,
                         EnumType = model.EnumType,
                         EnumName = model.EnumName,
                         EnumValue = model.EnumValue,
                         Status = model.Status,
                         CreatedDate = model.CreatedDate,
                         CreatedBy = model.CreatedBy,
                         ModifyBy = model.ModifyBy,
                         ModifyDate = model.ModifyDate,
                     });


            return q;
        }

        public virtual EnumMasterItemViewModel Get(int Id)
        {
            var q = (from model in Context.enummasters
                     where model.Id == Id
                     select new EnumMasterItemViewModel
                     {
                         Id = model.Id,
                         EnumType = model.EnumType,
                         EnumName = model.EnumName,
                         EnumValue = model.EnumValue,
                         Status = model.Status,
                         CreatedDate = model.CreatedDate,
                         CreatedBy = model.CreatedBy,
                         ModifyBy = model.ModifyBy,
                         ModifyDate = model.ModifyDate,
                     }).FirstOrDefault();

            return q;
        }

        public string Save(EnumMasterItemViewModel model)
        {
            if (model == null) return Resources.GlobalResource.NotificationMsg_InvalidNotificationType;

            if (model.Id > 0)
            {
                var workFlowModel = Context.enummasters.Find(model.Id);
                workFlowModel.EnumName = model.EnumName;
                workFlowModel.EnumValue = model.EnumValue;
                workFlowModel.ModifyBy = model.ModifyBy;
                workFlowModel.ModifyDate = DateTime.Now;

                //BindUpdateData(workFlowModel);
                SaveChanges();

            }
            else
            {
                var item = new DbModels.enummaster
                {
                    EnumType = model.EnumType,
                    EnumName = model.EnumName,
                    EnumValue = model.EnumValue,
                    Status = (int)EnumStatus.Active,
                    CreatedDate = DateTime.Now,
                    CreatedBy = model.CreatedBy
                };
                Context.enummasters.Add(item);
                SaveChanges();
            }

            return "OK";
        }


        public string Delete(int Id)
        {
            var q = (from n in Context.enummasters
                     where n.Id == Id
                     select n).ToList();

            q.ForEach(r => Context.enummasters.Remove(r));

            SaveChanges();

            return "OK";
        }

        public string Delete(EnumMasterItemViewModel model)
        {
            if (model.Id > 0)
            {
                var workFlowModel = Context.enummasters.Find(model.Id);
                workFlowModel.Status = (int)EnumStatus.InActive;
                workFlowModel.ModifyBy = model.ModifyBy;
                workFlowModel.ModifyDate = DateTime.Now;

                //BindUpdateData(workFlowModel);
                SaveChanges();

            }

            //var q = (from n in Context.enummasters
            //         where n.Id == ID
            //         select n).ToList();

            //q.ForEach(r => Context.enummasters.Remove(r));

            //SaveChanges();

            return "OK";
        }
    }

}
