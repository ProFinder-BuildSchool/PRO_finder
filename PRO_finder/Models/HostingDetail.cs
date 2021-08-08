namespace PRO_finder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HostingDetail")]
    public partial class HostingDetail
    {
        public int MemberID { get; set; }

        public int CaseID { get; set; }

        [Column(TypeName = "money")]
        public decimal HostedAmount { get; set; }

        public DateTime HostedTime { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HostID { get; set; }

        public virtual Case Case { get; set; }

        public virtual MemberInfo MemberInfo { get; set; }
    }
}
