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

    [System.ComponentModel.DataAnnotations.Schema.Table("workflowdetail")]
    public partial class workflowdetail
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int ID { get; set; }
        public int WorkflowMasterID { get; set; }
        public Nullable<int> Sequence { get; set; }
        public string Description { get; set; }
        public string Description_BM { get; set; }
        public string Description_CN { get; set; }
        public int Duration { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
