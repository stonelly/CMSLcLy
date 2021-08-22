using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.Security.User
{
    public class MyProfileViewModel
    {
        public Guid UserId { get; set; }
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string ProfileImagePath { get; set; }
    }
}
