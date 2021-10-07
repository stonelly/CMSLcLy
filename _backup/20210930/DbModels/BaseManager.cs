using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.DbModels
{
    public class BaseManager : Module<DbModels.DefaultConnection>, IDisposable
    {
        public BaseManager() : base(new DbModels.DefaultConnection()) { }

        public void SaveChanges(bool forceSaveChanges = false)
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            this.Context.SaveChanges();
            this.Context.Dispose();
        }
    }
}
