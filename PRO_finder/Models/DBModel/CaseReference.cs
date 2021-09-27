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
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CaseID { get; set; }

        public string CaseRefImg { get; set; }

        public int CaseCase { get; set; }
    }
}
