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

    [System.ComponentModel.DataAnnotations.Schema.Table("documentworkflow")]
    public partial class documentworkflow
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int ID { get; set; }
        public int WorkflowDetailID { get; set; }
        public string UserID { get; set; }
        public System.DateTime DueDate { get; set; }
        public int isCompleted { get; set; }
        public bool isRPA { get; set; }
        public int Sequence { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
