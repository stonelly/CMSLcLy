using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CMSLcLy.Data.Security.User
{
    public class ResetPasswordViewModel
    {
        public Guid UserId { get; set; }
        [StringLength(128)]
        public string Password { get; set; }
    }
}
