namespace PRO_finder
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReplyFrequency")]
    public partial class ReplyFrequency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MemberID { get; set; }

        public decimal? Degree { get; set; }

        public int Readed { get; set; }

        public int Replyed { get; set; }

        public int Propose { get; set; }

        [Column(TypeName = "date")]
        public DateTime OnlineTime { get; set; }

        public virtual MemberInfo MemberInfo { get; set; }
    }
}
