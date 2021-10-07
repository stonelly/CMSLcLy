//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CMSLcLy.Data.DbModels
{
    using System;
    using System.Collections.Generic;

    [System.ComponentModel.DataAnnotations.Schema.Table("userdetail")]
    public partial class userdetail
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long UserDetailsId { get; set; }
        public string AspNetUserId { get; set; }
        public Nullable<int> UserTypeID { get; set; }
        public Nullable<int> IdentityType { get; set; }
        public string IdentityNo { get; set; }
        public string ConsumptionTaxNo { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeContactNo { get; set; }
        public string OfficeContactNo { get; set; }
        public string MobileContactNo { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string TaxFileNo { get; set; }
        public string TaxBranch { get; set; }
        public string RegAddress { get; set; }
        public string RegAddress2 { get; set; }
        public string RegAddress3 { get; set; }
        public string RegPostCode { get; set; }
        public string RegCity { get; set; }
        public string RegState { get; set; }
        public string BussAddress { get; set; }
        public string BussAddress2 { get; set; }
        public string BussAddress3 { get; set; }
        public string BussPostCode { get; set; }
        public string BussCity { get; set; }
        public string BussState { get; set; }
        public string DirectorName { get; set; }
        public string DirectorIDNo { get; set; }
        public string DirectorSectName { get; set; }
        public string DirectorSectIDNo { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    
        public virtual aspnetuser aspnetuser { get; set; }
    }
}