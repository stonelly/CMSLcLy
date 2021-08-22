using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.Security.User
{
    public static class UserExtension
    {
        public static long UserIntId
        {
            get
            {
                if (Context.GetSession("CMSLcLy.Data.Security.User.UserExtension.UserIntId") == null)
                    Context.SetSession("CMSLcLy.Data.Security.User.UserExtension.UserIntId", new long());
                return (long)Context.GetSession("CMSLcLy.Data.Security.User.UserExtension.UserIntId");
            }
            set
            {
                Context.SetSession("CMSLcLy.Data.Security.User.UserExtension.UserIntId", (long)value);
            }
        }
    }
}
