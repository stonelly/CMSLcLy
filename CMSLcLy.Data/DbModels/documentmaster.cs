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

    [System.ComponentModel.DataAnnotations.Schema.Table("documentmaster")]
    public partial class documentmaster
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int ID { get; set; }
        public string FileNo { get; set; }
        public Nullable<System.DateTime> FileOpenDate { get; set; }
        public string ClientID { get; set; }
        public string PartnerID { get; set; }
        public string FirmID { get; set; }
        public Nullable<int> Status { get; set; }
        public string RelatedFileNo { get; set; }
        public string Remark { get; set; }
        public string VendorID { get; set; }
        public string VendorFirmID { get; set; }
        public string VendorFirmTel { get; set; }
        public string VendorFirmEmail { get; set; }
        public string VendorFirmFileRefNo { get; set; }
        public string PurchaserID { get; set; }
        public string PurchaserFirmID { get; set; }
        public string PurchaserFirmTel { get; set; }
        public string PurchaserFirmEmail { get; set; }
        public string PurchaserFirmFileRefNo { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifyBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public string VendorFirmAddress1 { get; set; }
        public string VendorFirmAddress2 { get; set; }
        public string VendorFirmZipCode { get; set; }
        public string VendorFirmCity { get; set; }
        public string PurchaserFirmAddress1 { get; set; }
        public string PurchaserFirmAddress2 { get; set; }
        public string PurchaserFirmZipCode { get; set; }
        public string PurchaserFirmCity { get; set; }
        public string FileReference { get; set; }
        public string FileType { get; set; }
        public string VendorFirmState { get; set; }
        public string PurchaserFirmState { get; set; }
    }
}
