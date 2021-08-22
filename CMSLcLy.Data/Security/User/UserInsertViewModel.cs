using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.Security.User
{
    public class UserInsertViewModel
    {
        // User info
        [ComponentModel.DataAnnotations.AuditLog(IsPrimaryKeyId = true)]
        public Guid UserId { get; set; }// primary key
        [Required]
        [MaxLength(200), StringLength(200)]
        [ComponentModel.DataAnnotations.AuditLog(Name = "UserName", IsKeyword = true)]
        public string Username { get; set; }
        //public UserStatus UserStatus { get; set; }
        [Required, UIHint("Password")]
        public string Password { get; set; }
        [Required, UIHint("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        [ComponentModel.DataAnnotations.AuditLog()]
        public AuthenticationType AuthenticationType { get; set; }

        // Person Info
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

        //// Employee Info
        //[MaxLength(20), StringLength(20)]
        //public string EmployeeNo { get; set; }
        //[Required]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ConvertEmptyStringToNull = true, ApplyFormatInEditMode = true)]
        //public DateTime JoinedDate { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ConvertEmptyStringToNull = true, ApplyFormatInEditMode = true)]
        //public DateTime? ResignationDate { get; set; }

        // Job Info
        [Required, UIHint("DropDownList"), ComponentModel.DataAnnotations.DropDownList(typeof(General.OrganizationalHierarchy.DropDown), "OrganizationalHierarchy")]
        [ComponentModel.DataAnnotations.AuditLog(DropDownName = "OrganizationalHierarchy")]
        public Guid BelongsToEId { get; set; }
        //public string Department { get; set; }
        //[UIHint("DropDownList"), ComponentModel.DataAnnotations.DropDownList(typeof(Employee.DropDown), "Employee")]
        //public Guid? SupervisorEmpId { get; set; }
        //[UIHint("DropDownList"), ComponentModel.DataAnnotations.DropDownList(typeof(General.CodeMaster.DropDown), "CostCenter")]
        //public Guid? CostCenterCid { get; set; }
        //[UIHint("DropDownList"), ComponentModel.DataAnnotations.DropDownList(typeof(General.Currency.DropDown), "Currency")]
        //public  Guid? CurrencyId { get; set; }
        //[UIHint("DropDownList"), ComponentModel.DataAnnotations.DropDownList(typeof(General.HolidayCalendar.DropDown), "HolidayCalendar")]
        //public Guid? HolidayCalendarId { get; set; }

        // Role Info
        [Required, UIHint("DropDownList"), ComponentModel.DataAnnotations.DropDownList(typeof(Role.DropDown), "Role")]
        [ComponentModel.DataAnnotations.AuditLog(IsPrimaryKeyId =true, DropDownName = "UserRole")]
        public Guid RoleId { get; set; }

        // Data Access Right Info
        [Display(Name = "Data Access Right")]
        [ComponentModel.DataAnnotations.AuditLog()]
        public List<Guid> AccessToEntityIdList { get; set; }
    }
}
