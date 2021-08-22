using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.Security.Role
{
    public class DropDown : DbModels.BaseManager
    {
        public List<KeyValuePair<string, string>> Role(MAT.Enumerate.DropDownDefaultText defaultText = MAT.Enumerate.DropDownDefaultText.None)
        {
            var q = (from e in base.Context.Roles
                     select new { e.RoleId, e.Name }
                   ).AsEnumerable()
                   .Select(r => new KeyValuePair<string, string>(r.RoleId.ToString(), r.Name))
                   .ToList();

            MAT.Helper.DropDownList.BindDefaultDropDownList(q, defaultText);

            return q;
        }
    }
}
