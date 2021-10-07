using MAT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.Bank.CAC
{
    public class Manager : DbModels.BaseManager
    {
        public IQueryable<CACmasterItemViewModel> List()
        {
            var q = (from model in Context.cacmasters
                     select new CACmasterItemViewModel
                     {
                         Id = model.Id,
                         BankName = model.BankName,
                         CACName = model.CACName,
                         Address = model.Address,
                         Address2 = model.Address2,
                         Address3 = model.Address3,
                         PostCode = model.PostCode,
                         State = model.State,
                         Phone = model.Phone,
                         Phone2 = model.Phone2,
                         Phone3 = model.Phone3,
                         Fax = model.Fax,
                         Fax2 = model.Fax2,
                         Email = model.Email,
                         CreatedBy = model.CreatedBy,
                         CreatedDate = model.CreatedDate,
                         ModifyBy = model.ModifyBy,
                         ModifyDate = model.ModifyDate,
                     });


            return q;
        }

        public virtual CACmasterItemViewModel Get(int Id)
        {
            var q = (from model in Context.cacmasters
                     where model.Id == Id
                     select new CACmasterItemViewModel
                     {
                         Id = model.Id,
                         BankName = model.BankName,
                         CACName = model.CACName,
                         Address = model.Address,
                         Address2 = model.Address2,
                         Address3 = model.Address3,
                         PostCode = model.PostCode,
                         State = model.State,
                         Phone = model.Phone,
                         Phone2 = model.Phone2,
                         Phone3 = model.Phone3,
                         Fax = model.Fax,
                         Fax2 = model.Fax2,
                         Email = model.Email,
                         CreatedBy = model.CreatedBy,
                         CreatedDate = model.CreatedDate,
                         ModifyBy = model.ModifyBy,
                         ModifyDate = model.ModifyDate,
                     }).FirstOrDefault();

            return q;
        }

        public string Save(CACmasterItemViewModel model)
        {
            if (model == null) return Resources.GlobalResource.NotificationMsg_InvalidNotificationType;

            if (model.Id > 0)
            {
                var workFlowModel = Context.cacmasters.Find(model.Id);
                workFlowModel.BankName = model.BankName;
                workFlowModel.CACName = model.CACName;
                workFlowModel.Address = model.Address;
                workFlowModel.Address2 = model.Address2;
                workFlowModel.Address3 = model.Address3;
                workFlowModel.PostCode = model.PostCode;
                workFlowModel.State = model.State;
                workFlowModel.Phone = model.Phone;
                workFlowModel.Phone2 = model.Phone2;
                workFlowModel.Phone3 = model.Phone3;
                workFlowModel.Fax = model.Fax;
                workFlowModel.Fax2 = model.Fax2;
                workFlowModel.Email = model.Email;
                workFlowModel.ModifyBy = model.ModifyBy;
                workFlowModel.ModifyDate = DateTime.Now;

                //BindUpdateData(workFlowModel);
                SaveChanges();

            }
            else
            {
                var item = new DbModels.cacmaster
                {
                    BankName = model.BankName,
                    CACName = model.CACName,
                    Address = model.Address,
                    Address2 = model.Address2,
                    Address3 = model.Address3,
                    PostCode = model.PostCode,
                    State = model.State,
                    Phone = model.Phone,
                    Phone2 = model.Phone2,
                    Phone3 = model.Phone3,
                    Fax = model.Fax,
                    Fax2 = model.Fax2,
                    Email = model.Email,
                    CreatedDate = DateTime.Now,
                    CreatedBy = model.CreatedBy
                };
                Context.cacmasters.Add(item);
                SaveChanges();
            }

            return "OK";
        }

        public string Delete(int ID)
        {
            var q = (from n in Context.cacmasters
                     where n.Id == ID
                     select n).ToList();

            q.ForEach(r => Context.cacmasters.Remove(r));

            SaveChanges();

            return "OK";
        }
    }
}
