using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.Security.User
{
    public class ChangePasswordViewModel
    {
        [ComponentModel.DataAnnotations.AuditLog(IsPrimaryKeyId = true)]
        public Guid UserId { get; set; }
        [UIHint("Password"), Required, StringLength(128)]
        public string OldPassword { get; set; }
        [UIHint("Password"), Required, StringLength(128)]
        public string NewPassword { get; set; }
        [UIHint("Password"), Required, StringLength(128)]
        public string ConfirmNewPassword { get; set; }
    }
}
