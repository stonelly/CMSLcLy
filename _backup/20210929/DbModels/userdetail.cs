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
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string AspNetUserId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string Email { get; set; }
    
        public virtual aspnetuser aspnetuser { get; set; }
    }
}
