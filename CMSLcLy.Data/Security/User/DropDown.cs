using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.Security.User
{
    public class DropDown:DbModels.BaseManager
    {
        public List<KeyValuePair<string, string>> GetAllUser(MAT.Enumerate.DropDownDefaultText defaultText = MAT.Enumerate.DropDownDefaultText.None)
        {
            // Get list of active employee for staff
            var q = (from u in base.Context.Users
                     join el in base.Context.EmployeeLogins on u.UserId equals el.UserId
                     join e in base.Context.Employees on el.EmployeeId equals e.EmployeeId
                     join p in Context.People on e.PersonId equals p.PersonId
                     join eh in base.Context.EmployeeEmploymentHistories on e.EmployeeId equals eh.EmployeeId
                     where e.EmployeeStatus == (byte)Employee.EmployeeStatus.Active
                     orderby p.DisplayName
                     select new { u.UserId, p.DisplayName });

            var result = q.ToList().Select(p => new KeyValuePair<string, string>(p.UserId.ToString(), p.DisplayName)).ToList();
            Helper.DropDownList.BindDefaultDropDownList(result, defaultText);
            return result;

        }
    }
}
