using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.Notification
{
    public class Manager : DbModels.BaseManager
    {
        public IQueryable<notificationmasterViewModel> List()
        {
            var q = (from model in Context.notificationmasters
                     select new notificationmasterViewModel
                     {
                         Id = model.ID,
                         CustomerName = model.CustomerName,
                         RoomName = model.RoomName,
                         MessageID = model.MessageID,
                         Status = model.Status,
                         CreatedDate = model.CreatedDate,
                         ModifiedDate = model.ModifiedDate
                     });


            return q;
        }

        public IQueryable<notificationmasterViewModel> GetByCustomerName(string id)
        {
            var q = (from model in Context.notificationmasters
                     where model.CustomerName == id
                     where model.Status == 0
                     select new notificationmasterViewModel
                     {
                         Id = model.ID,
                         CustomerName = model.CustomerName,
                         RoomName = model.RoomName,
                         MessageID = model.MessageID,
                         Status = model.Status,
                         CreatedDate = model.CreatedDate,
                         ModifiedDate = model.ModifiedDate
                     });

            return q;
        }


        public string Save(notificationmasterViewModel model)
        {
            if (model == null) return Resources.GlobalResource.NotificationMsg_InvalidNotificationType;

            var item = new DbModels.notificationmaster
            {
                CustomerName = model.CustomerName,
                RoomName = model.RoomName,
                MessageID = model.MessageID,
                Status = model.Status,
                CreatedDate = model.CreatedDate,
                ModifiedDate = model.ModifiedDate
            };

            Context.notificationmasters.Add(item);
            SaveChanges();

            return "OK";
        }


    }
}
