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

    [System.ComponentModel.DataAnnotations.Schema.Table("messagemaster")]
    public partial class messagemaster
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public string RoomName { get; set; }
        public string Message { get; set; }
        public sbyte IsMessageRead { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    }
}
