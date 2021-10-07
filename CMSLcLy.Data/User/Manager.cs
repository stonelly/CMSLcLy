using MAT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.User
{
    public class Manager : DbModels.BaseManager
    {
        public IQueryable<UserMasterItemViewModel> List()
        {
            var q = (from model in Context.aspnetusers
                     join t2 in Context.userdetails on model.Id equals t2.AspNetUserId into gj
                     from t21 in gj.DefaultIfEmpty()
                     join t3 in Context.enummasters on t21.IdentityType equals t3.Id into gj2
                     from t31 in gj2.DefaultIfEmpty()
                     join t4 in Context.enummasters on t21.UserTypeID equals t4.Id into gj3
                     from t41 in gj3.DefaultIfEmpty()
                     select new UserMasterItemViewModel
                     {
                         Id = model.Id,
                         UserName = model.UserName,
                         UserDetailsId = t21.UserDetailsId,
                         AspNetUserID = t21.AspNetUserId,
                         UserTypeID = t21.UserTypeID,
                         UserType = t41.EnumValue,
                         IdentityType = t21.IdentityType,
                         IdentityTypeDesc = t31.EnumValue,
                         IdentityNo = t21.IdentityNo,
                         ConsumptionTaxNo = t21.ConsumptionTaxNo,
                         FullName = t21.FullName,
                         Address = t21.Address,
                         Address2 = t21.Address2,
                         Address3 = t21.Address3,
                         PostCode = t21.PostCode,
                         City = t21.City,
                         State = t21.State,
                         Country = t21.Country,
                         PhoneNumber = t21.PhoneNumber,
                         HomeContactNo = t21.HomeContactNo,
                         OfficeContactNo = t21.OfficeContactNo,
                         MobileContactNo = t21.MobileContactNo,
                         Fax = t21.Fax,
                         Email = t21.Email,
                         TaxFileNo = t21.TaxFileNo,
                         TaxBranch = t21.TaxBranch,
                         RegAddress = t21.RegAddress,
                         RegAddress2 = t21.RegAddress2,
                         RegAddress3 = t21.RegAddress3,
                         RegPostCode = t21.RegPostCode,
                         RegCity = t21.RegCity,
                         RegState = t21.RegState,
                         BussAddress = t21.BussAddress,
                         BussAddress2 = t21.BussAddress2,
                         BussAddress3 = t21.BussAddress3,
                         BussPostCode = t21.BussPostCode,
                         BussCity = t21.BussCity,
                         BussState = t21.BussState,
                         DirectorName = t21.DirectorName,
                         DirectorIDNo = t21.DirectorIDNo,
                         DirectorSectName = t21.DirectorSectName,
                         DirectorSectIDNo = t21.DirectorSectIDNo,
                         CreatedBy = t21.CreatedBy,
                         CreatedDate = t21.CreatedDate,
                         ModifiedBy = t21.ModifiedBy,
                         ModifiedDate = t21.ModifiedDate,
                     });


            return q;
        }

        public virtual UserMasterItemViewModel Get(string Id)
        {
            var q = (from model in Context.aspnetusers
                     join t2 in Context.userdetails on model.Id equals t2.AspNetUserId into gj
                     from t21 in gj.DefaultIfEmpty()
                     join t3 in Context.enummasters on t21.IdentityType equals t3.Id into gj2
                     from t31 in gj2.DefaultIfEmpty()
                     join t4 in Context.enummasters on t21.UserTypeID equals t4.Id into gj3
                     from t41 in gj3.DefaultIfEmpty()
                     where model.Id == Id
                     select new UserMasterItemViewModel
                     {
                         Id = model.Id,
                         UserName = model.UserName,
                         UserDetailsId = t21.UserDetailsId,
                         AspNetUserID = t21.AspNetUserId,
                         UserTypeID = t21.UserTypeID,
                         UserType = t41.EnumValue,
                         IdentityType = t21.IdentityType,
                         IdentityTypeDesc = t31.EnumValue,
                         IdentityNo = t21.IdentityNo,
                         ConsumptionTaxNo = t21.ConsumptionTaxNo,
                         FullName = t21.FullName,
                         Address = t21.Address,
                         Address2 = t21.Address2,
                         Address3 = t21.Address3,
                         PostCode = t21.PostCode,
                         City = t21.City,
                         State = t21.State,
                         Country = t21.Country,
                         PhoneNumber = t21.PhoneNumber,
                         HomeContactNo = t21.HomeContactNo,
                         OfficeContactNo = t21.OfficeContactNo,
                         MobileContactNo = t21.MobileContactNo,
                         Fax = t21.Fax,
                         Email = t21.Email,
                         TaxFileNo = t21.TaxFileNo,
                         TaxBranch = t21.TaxBranch,
                         RegAddress = t21.RegAddress,
                         RegAddress2 = t21.RegAddress2,
                         RegAddress3 = t21.RegAddress3,
                         RegPostCode = t21.RegPostCode,
                         RegCity = t21.RegCity,
                         RegState = t21.RegState,
                         BussAddress = t21.BussAddress,
                         BussAddress2 = t21.BussAddress2,
                         BussAddress3 = t21.BussAddress3,
                         BussPostCode = t21.BussPostCode,
                         BussCity = t21.BussCity,
                         BussState = t21.BussState,
                         DirectorName = t21.DirectorName,
                         DirectorIDNo = t21.DirectorIDNo,
                         DirectorSectName = t21.DirectorSectName,
                         DirectorSectIDNo = t21.DirectorSectIDNo,
                         CreatedBy = t21.CreatedBy,
                         CreatedDate = t21.CreatedDate,
                         ModifiedBy = t21.ModifiedBy,
                         ModifiedDate = t21.ModifiedDate,
                     }).FirstOrDefault();

            return q;
        }

        public string Save(UserMasterItemViewModel model)
        {
            if (model == null) return Resources.GlobalResource.NotificationMsg_InvalidNotificationType;

            if (!string.IsNullOrEmpty(model.Id))
            {
                var workFlowModel = Context.userdetails.Find(model.UserDetailsId);
                workFlowModel.UserTypeID = model.UserTypeID;
                workFlowModel.IdentityType = model.IdentityType;
                workFlowModel.IdentityNo = model.IdentityNo;
                workFlowModel.ConsumptionTaxNo = model.ConsumptionTaxNo;
                workFlowModel.FullName = model.FullName;
                workFlowModel.Address = model.Address;
                workFlowModel.Address2 = model.Address2;
                workFlowModel.Address3 = model.Address3;
                workFlowModel.PostCode = model.PostCode;
                workFlowModel.City = model.City;
                workFlowModel.State = model.State;
                workFlowModel.Country = model.Country;
                workFlowModel.PhoneNumber = model.PhoneNumber;
                workFlowModel.HomeContactNo = model.HomeContactNo;
                workFlowModel.OfficeContactNo = model.OfficeContactNo;
                workFlowModel.MobileContactNo = model.MobileContactNo;
                workFlowModel.Fax = model.Fax;
                workFlowModel.Email = model.Email;
                workFlowModel.TaxFileNo = model.TaxFileNo;
                workFlowModel.TaxBranch = model.TaxBranch;
                workFlowModel.RegAddress = model.RegAddress;
                workFlowModel.RegAddress2 = model.RegAddress2;
                workFlowModel.RegAddress3 = model.RegAddress3;
                workFlowModel.RegPostCode = model.RegPostCode;
                workFlowModel.RegCity = model.RegCity;
                workFlowModel.RegState = model.RegState;
                workFlowModel.BussAddress = model.BussAddress;
                workFlowModel.BussAddress2 = model.BussAddress2;
                workFlowModel.BussAddress3 = model.BussAddress3;
                workFlowModel.BussPostCode = model.BussPostCode;
                workFlowModel.BussCity = model.BussCity;
                workFlowModel.BussState = model.BussState;
                workFlowModel.DirectorName = model.DirectorName;
                workFlowModel.DirectorIDNo = model.DirectorIDNo;
                workFlowModel.DirectorSectName = model.DirectorSectName;
                workFlowModel.DirectorSectIDNo = model.DirectorSectIDNo;
                workFlowModel.ModifiedBy = model.ModifiedBy;
                workFlowModel.ModifiedDate = DateTime.Now;

                //BindUpdateData(workFlowModel);
                SaveChanges();

            }
            else
            {
                var item = new DbModels.userdetail
                {
                    AspNetUserId = model.AspNetUserID,
                    UserTypeID = model.UserTypeID,
                    IdentityType = model.IdentityType,
                    IdentityNo = model.IdentityNo,
                    ConsumptionTaxNo = model.ConsumptionTaxNo,
                    FullName = model.FullName,
                    Address = model.Address,
                    Address2 = model.Address2,
                    Address3 = model.Address3,
                    PostCode = model.PostCode,
                    City = model.City,
                    State = model.State,
                    Country = model.Country,
                    PhoneNumber = model.PhoneNumber,
                    HomeContactNo = model.HomeContactNo,
                    OfficeContactNo = model.OfficeContactNo,
                    MobileContactNo = model.MobileContactNo,
                    Fax = model.Fax,
                    Email = model.Email,
                    TaxFileNo = model.TaxFileNo,
                    TaxBranch = model.TaxBranch,
                    RegAddress = model.RegAddress,
                    RegAddress2 = model.RegAddress2,
                    RegAddress3 = model.RegAddress3,
                    RegPostCode = model.RegPostCode,
                    RegCity = model.RegCity,
                    RegState = model.RegState,
                    BussAddress = model.BussAddress,
                    BussAddress2 = model.BussAddress2,
                    BussAddress3 = model.BussAddress3,
                    BussPostCode = model.BussPostCode,
                    BussCity = model.BussCity,
                    BussState = model.BussState,
                    DirectorName = model.DirectorName,
                    DirectorIDNo = model.DirectorIDNo,
                    DirectorSectName = model.DirectorSectName,
                    DirectorSectIDNo = model.DirectorSectIDNo,
                    CreatedDate = DateTime.Now,
                    CreatedBy = model.CreatedBy
                };
                Context.userdetails.Add(item);
                SaveChanges();
            }

            return "OK";
        }


        public string DeleteUser(string ID)
        {

            var q = (from n in Context.aspnetusers
                     where n.Id == ID
                     select n).FirstOrDefault();

            var p = (from n in Context.userdetails
                     where n.AspNetUserId == ID
                     select n).ToList();


            p.ForEach(r => Context.userdetails.Remove(r));
            Context.aspnetusers.Remove(q);

            SaveChanges();
            return "NotOK";
        }

        public string Delete(string ID)
        {
            var q = Context.aspnetusers.Find(ID);

            Context.aspnetusers.Remove(q);

            SaveChanges();

            return "OK";
        }

        public string DeleteUserDetail(int ID)
        {
            var q = (from n in Context.userdetails
                     where n.UserDetailsId == ID
                     select n).ToList();

            q.ForEach(r => Context.userdetails.Remove(r));

            SaveChanges();

            return "OK";
        }
        public string DeleteUserDetail(string ID)
        {
            var q = (from n in Context.userdetails
                     where n.AspNetUserId == ID
                     select n).ToList();

            q.ForEach(r => Context.userdetails.Remove(r));

            SaveChanges();

            return "OK";
        }
    }
}
