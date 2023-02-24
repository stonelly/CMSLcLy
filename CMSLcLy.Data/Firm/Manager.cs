using MAT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.Firm
{
    public class Manager : DbModels.BaseManager
    {
        public IQueryable<FirmMasterItemViewModel> List()
        {
            var q = (from model in Context.firmmasters
                     join t2 in Context.aspnetusers on model.AspNetUserID equals t2.Id into gj
                     from t21 in gj.DefaultIfEmpty()
                     select new FirmMasterItemViewModel
                     {
                         Id = model.Id,
                         AspNetUserID = model.AspNetUserID,
                         UserName = t21.UserName,
                         FirmName = model.FirmName,
                         Address = model.Address,
                         Address2 = model.Address2,
                         Address3 = model.Address3,
                         PostCode = model.PostCode,
                         City = model.City,
                         State = model.State,
                         Phone = model.Phone,
                         Phone2 = model.Phone2,
                         Phone3 = model.Phone3,
                         Fax = model.Fax,
                         Fax2 = model.Fax2,
                         Mobile = model.Mobile,
                         Email = model.Email,
                         Remark = model.Remark,
                         CreatedBy = model.CreatedBy,
                         CreatedDate = model.CreatedDate,
                         ModifyBy = model.ModifyBy,
                         ModifyDate = model.ModifyDate,
                     });


            return q;
        }

        public FirmMasterItemViewModel GetRepFirm()
        {
            var q = (from model in Context.firmprofiles              
                     select new FirmMasterItemViewModel
                     {
                         Id = model.ID,        
                         AspNetUserID = model.freefield1,
                         FirmName = model.firm_name,
                         Address = model.add1,
                         Address2 = model.add2,
                         Address3 = model.add3,
                         PostCode = model.postcode,
                         City = model.Town,
                         State = model.state,
                         Phone = model.phone1,
                         Phone2 = model.phone2,
                         Phone3 = model.phone3,
                         Fax = model.fax1,
                         Fax2 = model.fax2,
                         Email = model.email,
                         Remark= model.freefield2
                     }).FirstOrDefault();
            return q;
        }

        public FirmMasterItemViewModel GetFirm(string firmName)
        {
            var q = (from model in Context.firmprofiles
                     where model.firm_name == firmName
                     select new FirmMasterItemViewModel
                     {
                         Id = model.ID,
                         AspNetUserID = model.freefield1,
                         FirmName = model.firm_name,
                         Address = model.add1,
                         Address2 = model.add2,
                         Address3 = model.add3,
                         PostCode = model.postcode,
                         City = model.Town,
                         State = model.state,
                         Phone = model.phone1,
                         Phone2 = model.phone2,
                         Phone3 = model.phone3,
                         Fax = model.fax1,
                         Fax2 = model.fax2,
                         Email = model.email,
                         Remark = model.freefield2
                     }).FirstOrDefault();
            return q;
        }

        public virtual FirmMasterItemViewModel Get(int Id)
        {
            var q = (from model in Context.firmmasters
                     join t2 in Context.aspnetusers on model.AspNetUserID equals t2.Id into gj
                     from t21 in gj.DefaultIfEmpty()
                     where model.Id == Id
                     select new FirmMasterItemViewModel
                     {
                         Id = model.Id,
                         AspNetUserID = model.AspNetUserID,
                         UserName = t21.UserName,
                         FirmName = model.FirmName,
                         Address = model.Address,
                         Address2 = model.Address2,
                         Address3 = model.Address3,
                         PostCode = model.PostCode,
                         City = model.City,
                         State = model.State,
                         Phone = model.Phone,
                         Phone2 = model.Phone2,
                         Phone3 = model.Phone3,
                         Fax = model.Fax,
                         Fax2 = model.Fax2,
                         Mobile = model.Mobile,
                         Email = model.Email,
                         Remark = model.Remark,
                         CreatedBy = model.CreatedBy,
                         CreatedDate = model.CreatedDate,
                         ModifyBy = model.ModifyBy,
                         ModifyDate = model.ModifyDate,
                     }).FirstOrDefault();

            return q;
        }

        public string Save(FirmMasterItemViewModel model)
        {
            if (model == null) return Resources.GlobalResource.NotificationMsg_InvalidNotificationType;

            if (model.Id > 0)
            {
                var workFlowModel = Context.firmmasters.Find(model.Id);
                workFlowModel.AspNetUserID = model.AspNetUserID;
                workFlowModel.FirmName = model.FirmName;
                workFlowModel.Address = model.Address;
                workFlowModel.Address2 = model.Address2;
                workFlowModel.Address3 = model.Address3;
                workFlowModel.PostCode = model.PostCode;
                workFlowModel.City = model.City;
                workFlowModel.State = model.State;
                workFlowModel.Phone = model.Phone;
                workFlowModel.Phone2 = model.Phone2;
                workFlowModel.Phone3 = model.Phone3;
                workFlowModel.Fax = model.Fax;
                workFlowModel.Fax2 = model.Fax2;
                workFlowModel.Mobile = model.Mobile;
                workFlowModel.Email = model.Email;
                workFlowModel.Remark = model.Remark;
                workFlowModel.ModifyBy = model.ModifyBy;
                workFlowModel.ModifyDate = DateTime.Now;

                //BindUpdateData(workFlowModel);
                SaveChanges();

            }
            else if(CheckDuplicateUser(model.AspNetUserID))
            {
                return "Duplicate User";
            }
            else
            {
                var item = new DbModels.firmmaster
                {
                    AspNetUserID = model.AspNetUserID,
                    FirmName = model.FirmName,
                    Address = model.Address,
                    Address2 = model.Address2,
                    Address3 = model.Address3,
                    PostCode = model.PostCode,
                    City = model.City,
                    State = model.State,
                    Phone = model.Phone,
                    Phone2 = model.Phone2,
                    Phone3 = model.Phone3,
                    Fax = model.Fax,
                    Fax2 = model.Fax2,
                    Mobile = model.Mobile,
                    Email = model.Email,
                    Remark = model.Remark,
                    CreatedDate = DateTime.Now,
                    CreatedBy = model.CreatedBy
                };
                Context.firmmasters.Add(item);
                SaveChanges();
            }

            return "OK";
        }

        public string Delete(int ID)
        {
            var q = (from n in Context.firmmasters
                     where n.Id == ID
                     select n).ToList();

            q.ForEach(r => Context.firmmasters.Remove(r));

            SaveChanges();

            return "OK";
        }

        public bool CheckDuplicateUser(string userID)
        {
            var q = (from n in Context.firmmasters
                     where n.AspNetUserID == userID
                     select n).ToList();

            if (q.Count() > 0) return true;

            return false;
        }
    }
}
