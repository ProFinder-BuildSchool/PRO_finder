namespace PRO_finder.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceRecord")]
    public partial class ServiceRecord
    {
        [Key]
        public string MemberID { get; set; }

        public int CaseID { get; set; }

        [Column(TypeName = "date")]
        public DateTime SavedDate { get; set; }

        public int CustomerID { get; set; }

        [StringLength(50)]
        public string Message { get; set; }

        [StringLength(50)]
        public string CaseReview { get; set; }
    }
}
