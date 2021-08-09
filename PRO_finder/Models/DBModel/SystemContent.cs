namespace PRO_finder.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SystemContent")]
    public partial class SystemContent
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MemberID { get; set; }

        public DateTime? SentTime { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string EmailTitle { get; set; }

        public string Content { get; set; }
    }
}
