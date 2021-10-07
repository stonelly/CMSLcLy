using MAT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.Bank
{
    public class Manager : DbModels.BaseManager
    {
        public IQueryable<bankmasterItemViewModel> List()
        {
            var q = (from model in Context.bankmasters
                     join t2 in Context.bankshortcutmasters on model.BankShortCutID equals t2.Id into gj
                     from t21 in gj.DefaultIfEmpty()
                     join t3 in Context.cacmasters on model.CACID equals t3.Id into gj2
                     from t31 in gj2.DefaultIfEmpty()
                     select new bankmasterItemViewModel
                     {
                         Id = model.Id,
                         BankShortCutID = model.BankShortCutID,
                         BranchName = model.BranchName,
                         BankName = t21.BankName,
                         BankShortCut = t21.BankShortCut,
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
                         CACID = model.CACID,
                         CAC = t31.CACName,
                         Remarks = model.Remarks,
                         CreatedBy = model.CreatedBy,
                         CreatedDate = model.CreatedDate,
                     });


            return q;
        }

        public virtual bankmasterItemViewModel Get(int Id)
        {
            var q = (from model in Context.bankmasters
                     join t2 in Context.bankshortcutmasters on model.BankShortCutID equals t2.Id into gj
                     from t21 in gj.DefaultIfEmpty()
                     join t3 in Context.cacmasters on model.CACID equals t3.Id into gj2
                     from t31 in gj2.DefaultIfEmpty()
                     where model.Id == Id 
                     select new bankmasterItemViewModel
                     {
                         Id = model.Id,
                         BankShortCutID = model.BankShortCutID,
                         BranchName = model.BranchName,
                         BankName = t21.BankName,
                         BankShortCut = t21.BankShortCut,
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
                         CACID = model.CACID,
                         CAC = t31.CACName,
                         Remarks = model.Remarks,
                         CreatedBy = model.CreatedBy,
                         CreatedDate = model.CreatedDate,
                     }).FirstOrDefault(); 

            return q;
        }

        public string Save(bankmasterItemViewModel model)
        {
            if (model == null) return Resources.GlobalResource.NotificationMsg_InvalidNotificationType;

            if (model.Id > 0)
            {
                var workFlowModel = Context.bankmasters.Find(model.Id);
                workFlowModel.BankShortCutID = model.BankShortCutID;
                workFlowModel.BranchName = model.BranchName;
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
                workFlowModel.CACID = model.CACID;
                workFlowModel.Remarks = model.Remarks;
                workFlowModel.ModifyBy = model.ModifyBy;
                workFlowModel.ModifyDate = DateTime.Now;

                //BindUpdateData(workFlowModel);
                SaveChanges();

            }
            else
            {

                //var bankShortCut = Context.bankshortcutmasters.Find(model.BankShortCutID);

                //var cacmaster = Context.cacmasters.Find(model.CACID);

                var item = new DbModels.bankmaster
                {
                    BankShortCutID = model.BankShortCutID,
                    BranchName = model.BranchName,
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
                    CACID = model.CACID,
                    Remarks = model.Remarks,
                    CreatedDate = DateTime.Now,
                    CreatedBy = model.CreatedBy,
                    ModifyDate = DateTime.Now,
                    ModifyBy = model.ModifyBy,
                };

                //item.cacmaster = cacmaster;
                //item.bankshortcutmaster = bankShortCut;

                Context.bankmasters.Add(item);
                SaveChanges();
            }

            return "OK";
        }

        public string Delete(int bankID)
        {
            var q = (from n in Context.bankmasters
                     where n.Id == bankID
                     select n).ToList();

            q.ForEach(r => Context.bankmasters.Remove(r));

            SaveChanges();

            return "OK";
        }
    }

}
