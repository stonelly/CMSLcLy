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
    
    public partial class spa_loan_without_transfer_direct_transfer
    {
        public int ID { get; set; }
        public int DocumentId { get; set; }
        public string Document_Type_Name { get; set; }
        public string Document_Agreement_Name { get; set; }
        public Nullable<int> Area_Id { get; set; }
        public string Story_No { get; set; }
        public string Building_No { get; set; }
        public string Accessory_Parcel_No { get; set; }
        public Nullable<int> Unit_Area { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<int> Developer_Id { get; set; }
        public Nullable<int> Proprietor_Id { get; set; }
        public string Project_Name { get; set; }
        public Nullable<int> Schedule_Id { get; set; }
        public string Master_Title_No { get; set; }
        public string Parcel_No { get; set; }
    }
}