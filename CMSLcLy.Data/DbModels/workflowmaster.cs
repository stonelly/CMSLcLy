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

    [System.ComponentModel.DataAnnotations.Schema.Table("workflowmaster")]
    public partial class workflowmaster
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int WorkFlowMasterID { get; set; }
        public string WorkFlowName { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
    }
}