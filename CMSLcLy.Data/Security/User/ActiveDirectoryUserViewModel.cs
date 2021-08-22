using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CMSLcLy.Data.Security.User
{
    public class ActiveDirectoryUserViewModel
    {
        [ComponentModel.DataAnnotations.AuditLog()]
        public string LogonName { get; set; }
        [StringLength(200)]
        [ComponentModel.DataAnnotations.AuditLog()]
        public string FirstName { get; set; }
        [StringLength(200)]
        [ComponentModel.DataAnnotations.AuditLog()]
        public string LastName { get; set; }
        [StringLength(401)]
        [ComponentModel.DataAnnotations.AuditLog()]
        public string DisplayName { get; set; }
        [StringLength(200)]
        [ComponentModel.DataAnnotations.AuditLog()]
        public string Email { get; set; }
    }
}
