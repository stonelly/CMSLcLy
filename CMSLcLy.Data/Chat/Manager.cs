using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.Chat
{
    public class Manager : DbModels.BaseManager
    {
        public IQueryable<chatmasterViewModel> List()
        {
            var q = (from model in Context.messagemasters
                     select new chatmasterViewModel
                     {
                         Id = model.ID,
                         CustomerName = model.CustomerName,
                         RoomName = model.RoomName,
                         Message = model.Message,
                         CreatedDate = model.CreatedDate,
                         ModifiedDate = model.ModifiedDate
                     });


            return q;
        }

        public IQueryable<chatmasterViewModel> GetByCustomerNameAndRoomName(string customerName, string roomName)
        {
            var q = (from model in Context.messagemasters
                     where model.CustomerName == customerName && model.RoomName == roomName
                     select new chatmasterViewModel
                     {
                         Id = model.ID,
                         CustomerName = model.CustomerName,
                         RoomName = model.RoomName,
                         Message = model.Message,
                         CreatedDate = model.CreatedDate,
                         ModifiedDate = model.ModifiedDate
                     });

            return q;
        }

        public IQueryable<chatmasterViewModel> GetByRoomName(string roomName)
        {
            var q = (from model in Context.messagemasters
                     where model.RoomName == roomName
                     select new chatmasterViewModel
                     {
                         Id = model.ID,
                         CustomerName = model.CustomerName,
                         RoomName = model.RoomName,
                         Message = model.Message,
                         CreatedDate = model.CreatedDate,
                         ModifiedDate = model.ModifiedDate
                     });

            return q;
        }

        public string Save(chatmasterViewModel model)
        {
            if (model == null) return Resources.GlobalResource.NotificationMsg_InvalidNotificationType;

            var item = new DbModels.messagemaster
            {
                CustomerName = model.CustomerName,
                RoomName = model.RoomName,
                Message = model.Message,
                CreatedDate = model.CreatedDate,
                ModifiedDate = model.ModifiedDate
            };

            Context.messagemasters.Add(item);
            SaveChanges();


            return "OK";
        }


    }
}
