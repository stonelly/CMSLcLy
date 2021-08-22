using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.Security.User
{
    public class UserViewModel
    {
        // User info
        [ComponentModel.DataAnnotations.AuditLog(IsPrimaryKeyId = true)]
        public Guid UserId { get; set; }// primary key
        [Required]
        [MaxLength(200), StringLength(200)]
        [ComponentModel.DataAnnotations.AuditLog(Name = "UserName", IsKeyword = true)]
        public string Username { get; set; }
        [ComponentModel.DataAnnotations.AuditLog(Name = "Status")]
        public UserStatus UserStatus { get; set; }
        [Required, UIHint("Password")]
        public string Password { get; set; }
        [Required, UIHint("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        [ComponentModel.DataAnnotations.AuditLog()]
        public AuthenticationType AuthenticationType { get; set; }

        // Person Info
        public string DisplayName { get; set; }
        [Required]
        [MaxLength(200), StringLength(200)]
        [ComponentModel.DataAnnotations.AuditLog()]
        public string FirstName { get; set; }
        [MaxLength(200), StringLength(200)]
        [ComponentModel.DataAnnotations.AuditLog()]
        public string LastName { get; set; }
        [MaxLength(100), StringLength(100)]
        [ComponentModel.DataAnnotations.AuditLog()]
        public string Email { get; set; }
        [MaxLength(50), StringLength(50)]
        [ComponentModel.DataAnnotations.AuditLog()]
        public string MobilePhone { get; set; }
        [MaxLength(1000), StringLength(1000)]
        [ComponentModel.DataAnnotations.AuditLog(Name = "ProfileImage")]
        public string ProfileImagePath { get; set; }
        [ComponentModel.DataAnnotations.AuditLog()]
        public Guid? BelongsToEId { get; set; }

        // Role Info
        [Required, UIHint("DropDownList"), ComponentModel.DataAnnotations.DropDownList(typeof(Role.DropDown), "Role")]
        [ComponentModel.DataAnnotations.AuditLog(IsPrimaryKeyId = true, DropDownName = "Role")]
        public Guid RoleId { get; set; }
        [StringLength(200)]
        [ComponentModel.DataAnnotations.AuditLog()]
        public string UserRole { get; set; }

        // Data Access Right Info
        public List<Guid> AccessToEntityIdList { get; set; }

        [Required]
        [ComponentModel.DataAnnotations.AuditLog(Name = "UserGroup")]
        public CMSLcLy.Data.Security.User.UserGroup UserGroup { get; set; }
    }
}
