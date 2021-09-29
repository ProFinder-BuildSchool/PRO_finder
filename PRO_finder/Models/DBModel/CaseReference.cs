namespace PRO_finder.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CaseReference")]
    public partial class CaseReference
    {
        [Key]
        public int CaseRefID { get; set; }

        public string CaseRef { get; set; }

        public int? CaseID { get; set; }
    }
}
