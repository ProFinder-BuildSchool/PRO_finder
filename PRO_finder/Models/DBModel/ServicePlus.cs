namespace PRO_finder.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ServicePlus
    {
        public int MemberID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ServicePlusID { get; set; }

        public int EnhancedService { get; set; }

        [Column(TypeName = "money")]
        public decimal Cost { get; set; }

        public byte Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual MemberInfo MemberInfo { get; set; }
    }
}
