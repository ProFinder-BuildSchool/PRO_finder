namespace PRO_finder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ServicePlu
    {
        public int MemberID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ServicePlusID { get; set; }

        public int EnhancedService { get; set; }

        [Column(TypeName = "money")]
        public decimal Cost { get; set; }

        public byte Status { get; set; }

        public TimeSpan StartDate { get; set; }

        public TimeSpan EndDate { get; set; }

        public virtual MemberInfo MemberInfo { get; set; }
    }
}
