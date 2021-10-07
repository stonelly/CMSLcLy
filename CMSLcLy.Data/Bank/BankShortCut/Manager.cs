using MAT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.Bank.BankShortCut
{
    public class Manager : DbModels.BaseManager
    {
        public IQueryable<bankshortcutmasterItemViewModel> List()
        {
            var q = (from n in Context.bankshortcutmasters
                     select new bankshortcutmasterItemViewModel
                     {
                         Id = n.Id,
                         BankName = n.BankName,
                         BankShortCut = n.BankShortCut,
                         CompanyNo = n.CompanyNo,
                         RegistrationAddress = n.RegistrationAddress,
                         CreatedBy = n.CreatedBy,
                         CreatedDate = n.CreatedDate,
                         ModifyBy = n.ModifyBy,
                         ModifyDate = n.ModifyDate,
                     });


            return q;
        }

        public virtual bankshortcutmasterItemViewModel Get(int Id)
        {
            var q = (from n in Context.bankshortcutmasters
                     where n.Id == Id
                     select new bankshortcutmasterItemViewModel
                     {
                         Id = n.Id,
                         BankName = n.BankName,
                         BankShortCut = n.BankShortCut,
                         CompanyNo = n.CompanyNo,
                         RegistrationAddress = n.RegistrationAddress,
                         CreatedBy = n.CreatedBy,
                         CreatedDate = n.CreatedDate,
                         ModifyBy = n.ModifyBy,
                         ModifyDate = n.ModifyDate,
                     }).FirstOrDefault();

            return q;
        }

        public string Save(bankshortcutmasterItemViewModel model)
        {
            if (model == null) return Resources.GlobalResource.NotificationMsg_InvalidNotificationType;

            if (model.Id > 0)
            {
                var workFlowModel = Context.bankshortcutmasters.Find(model.Id);
                workFlowModel.BankName = model.BankName;
                workFlowModel.BankShortCut = model.BankShortCut;
                workFlowModel.CompanyNo = model.CompanyNo;
                workFlowModel.RegistrationAddress = model.RegistrationAddress;
                workFlowModel.ModifyBy = model.ModifyBy;
                workFlowModel.ModifyDate = DateTime.Now;

                //BindUpdateData(workFlowModel);
                SaveChanges();

            }
            else
            {
                var item = new DbModels.bankshortcutmaster
                {
                    BankName = model.BankName,
                    BankShortCut = model.BankShortCut,
                    CompanyNo = model.CompanyNo,
                    RegistrationAddress = model.RegistrationAddress,
                    CreatedDate = DateTime.Now,
                    CreatedBy = model.CreatedBy
                };
                Context.bankshortcutmasters.Add(item);
                SaveChanges();
            }

            return "OK";
        }

        public string Delete(int ID)
        {
            var q = (from n in Context.bankshortcutmasters
                     where n.Id == ID
                     select n).ToList();

            q.ForEach(r => Context.bankshortcutmasters.Remove(r));

            SaveChanges();

            return "OK";
        }
    }
}
