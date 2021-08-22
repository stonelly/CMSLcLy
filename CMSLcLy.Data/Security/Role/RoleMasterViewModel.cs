using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.Security.Role
{
    public class RoleMasterViewModel
    {
        [ComponentModel.DataAnnotations.AuditLog(IsPrimaryKeyId = true)]
        public Guid RoleId { get; set; }
        [Required, StringLength(200)]
        [ComponentModel.DataAnnotations.AuditLog(IsKeyword = true)]
        public string Name { get; set; }

        public DateTime ModifiedDate { get; set; }//for descendingorder grid view list sort

        [ComponentModel.DataAnnotations.AuditLog(Name = "AccessRight")]
        public string AuditLogWriteString_UserRole { get; set; }//for auditlog record text
        public Dictionary<Guid, List<string>> RoleFunctions { get; set; } = new Dictionary<Guid, List<string>>();

    }
}
