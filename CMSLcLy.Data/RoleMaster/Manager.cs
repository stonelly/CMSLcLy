using MAT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.RoleMaster
{
    public class Manager : DbModels.BaseManager
    {
        public IQueryable<RoleMasterItemViewModel> List()
        {
            var q = (from model in Context.aspnetroles
                     select new RoleMasterItemViewModel
                     {
                         Id = model.Id,
                         Name = model.Name,
                         OldName = model.Name,
                     });


            return q;
        }

        public IQueryable<RoleMasterItemViewModel> ListNotAdmin()
        {
            var q = (from model in Context.aspnetroles.Where(c => !c.Name.Contains("Superadmin"))
                     select new RoleMasterItemViewModel
                     {
                         Id = model.Id,
                         Name = model.Name,
                         OldName = model.Name,
                     });


            return q;
        }

        public virtual RoleMasterItemViewModel Get(string Id)
        {
            var q = (from model in Context.aspnetroles
                     where model.Id == Id
                     select new RoleMasterItemViewModel
                     {
                         Id = model.Id,
                         Name = model.Name,
                         OldName = model.Name,
                     }).FirstOrDefault();

            return q;
        }

        public string Save(RoleMasterItemViewModel model)
        {
            if (model == null) return Resources.GlobalResource.NotificationMsg_InvalidNotificationType;

            if (!String.IsNullOrEmpty(model.Id))
            {
                var workFlowModel = Context.aspnetroles.Find(model.Id);
                workFlowModel.Name = model.Name;

                //BindUpdateData(workFlowModel);
                SaveChanges();

            }
            //else
            //{
            //    var item = new DbModels.aspnetrole
            //    {
            //        Name = model.Name,
            //    };
            //    Context.aspnetroles.Add(item);
            //    SaveChanges();
            //}

            return "OK";
        }

        public string Delete(string ID)
        {
            var q = (from n in Context.aspnetroles
                     where n.Id == ID
                     select n).ToList();

            q.ForEach(r => Context.aspnetroles.Remove(r));

            SaveChanges();

            return "OK";
        }
    }
}
