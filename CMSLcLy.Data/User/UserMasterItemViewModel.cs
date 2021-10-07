using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSLcLy.Data.User
{
    public class UserMasterItemViewModel
    {
        [Key]
        public string Id { get; set; }
        public string AspNetUserID { get; set; }
        [Display(Name = "Role")]
        public string Role { get; set; }
        public long? UserDetailsId { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Display(Name = "User Type")]
        public int? UserTypeID { get; set; }
        [Display(Name = "User Type")]
        public string UserType { get; set; }

        [Display(Name = "Identity")]
        public int? IdentityType { get; set; }
        [Display(Name = "Identity")]
        public string IdentityTypeDesc { get; set; }

        [Display(Name = "Identity No.")]
        public string IdentityNo { get; set; }

        [Display(Name = "Consumption Tax No.")]
        public string ConsumptionTaxNo { get; set; }

        [Display(Name = "Name")]
        public string FullName { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Address")]
        public string Address2 { get; set; }

        [Display(Name = "Address")]
        public string Address3 { get; set; }

        [Display(Name = "Postcode")]
        public string PostCode { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Contact (Hp)")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Contact (Home)")]
        public string HomeContactNo { get; set; }

        [Display(Name = "Contact (Office)")]
        public string OfficeContactNo { get; set; }

        [Display(Name = "Contact (Mobile)")]
        public string MobileContactNo { get; set; }

        [Display(Name = "Fax")]
        public string Fax { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Tax File No.")]
        public string TaxFileNo { get; set; }

        [Display(Name = "Tax Branch")]
        public string TaxBranch { get; set; }

        [Display(Name = "Address")]
        public string RegAddress { get; set; }

        [Display(Name = "Address")]
        public string RegAddress2 { get; set; }

        [Display(Name = "Address")]
        public string RegAddress3 { get; set; }

        [Display(Name = "Postcode")]
        public string RegPostCode { get; set; }

        [Display(Name = "City")]
        public string RegCity { get; set; }

        [Display(Name = "State")]
        public string RegState { get; set; }

        [Display(Name = "Address")]
        public string BussAddress { get; set; }

        [Display(Name = "Address")]
        public string BussAddress2 { get; set; }

        [Display(Name = "Address")]
        public string BussAddress3 { get; set; }

        [Display(Name = "Postcode")]
        public string BussPostCode { get; set; }

        [Display(Name = "City")]
        public string BussCity { get; set; }

        [Display(Name = "State")]
        public string BussState { get; set; }

        [Display(Name = "Name")]
        public string DirectorName { get; set; }

        [Display(Name = "IC")]
        public string DirectorIDNo { get; set; }

        [Display(Name = "Name")]
        public string DirectorSectName { get; set; }

        [Display(Name = "IC")]
        public string DirectorSectIDNo { get; set; }

        [Display(Name = "Created Date")]
        public Nullable<System.DateTime> CreatedDate { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Modify Date")]
        public Nullable<System.DateTime> ModifiedDate { get; set; }

        [Display(Name = "Modify By")]
        public string ModifiedBy { get; set; }


        public List<System.Web.Mvc.SelectListItem> IdentityTypes { get; set; }
        public List<System.Web.Mvc.SelectListItem> UserTypes { get; set; }
        public List<System.Web.Mvc.SelectListItem> Roles { get; set; }

    }
}
