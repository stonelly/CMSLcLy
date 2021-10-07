using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.UserDetails
{
    public class Manager : DbModels.BaseManager
    {
        public string Add(userDetailsItemViewModel userDetailsVM)
        {
            try
            {

                if (userDetailsVM == null) return Resources.GlobalResource.NotificationMsg_InvalidNotificationType;

                
                if (Context.userdetails.Any(x => x.AspNetUserId.Equals(userDetailsVM.AspNetUserId)))
                {
                    var existingObj = Context.userdetails.FirstOrDefault(x => x.AspNetUserId.Equals(userDetailsVM.AspNetUserId));

                    existingObj.FullName = userDetailsVM.FullName;
                    existingObj.PhoneNumber = userDetailsVM.PhoneNumber;
                    existingObj.Email = userDetailsVM.Email;
                    existingObj.Address = userDetailsVM.Address;
                    existingObj.City = userDetailsVM.City;
                    existingObj.PostCode = userDetailsVM.PostCode;
                    existingObj.Country = userDetailsVM.Country;
                    existingObj.ModifiedBy = userDetailsVM.ModifiedBy;
                    existingObj.ModifiedDate = DateTime.Now;
                    
                    SaveChanges();
                }
                else
                {
                    var item = new DbModels.userdetail
                    {
                        FullName = userDetailsVM.FullName,
                        PhoneNumber = userDetailsVM.PhoneNumber,
                        Email = userDetailsVM.Email,
                        Address = userDetailsVM.Address,
                        City = userDetailsVM.City,
                        PostCode = userDetailsVM.PostCode,
                        Country = userDetailsVM.Country,
                        AspNetUserId = userDetailsVM.AspNetUserId,
                        CreatedBy = userDetailsVM.CreatedBy,
                        CreatedDate = DateTime.Now,
                        ModifiedBy = userDetailsVM.ModifiedBy,
                        ModifiedDate = DateTime.Now
                    };

                Context.userdetails.Add(item);
                SaveChanges();
                }

                return "OK";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public IEnumerable<userDetailsItemViewModel> List(string aspUserId)
        {
            try
            {
                var q = (from n in Context.userdetails
                         where n.AspNetUserId == aspUserId
                         select new userDetailsItemViewModel
                         {
                             FullName = n.FullName,
                             PhoneNumber = n.PhoneNumber,
                             Address = n.Address,
                             City = n.City,
                             PostCode = n.PostCode,
                             Country = n.Country,
                             AspNetUserId = n.AspNetUserId,
                             Email = n.Email,
                             CreatedBy = n.CreatedBy,
                             ModifiedBy = n.ModifiedBy,
                         }).ToList();


                return q;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
