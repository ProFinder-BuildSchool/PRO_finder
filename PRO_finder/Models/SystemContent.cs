namespace PRO_finder.Models
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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MemberID { get; set; }

        public DateTime SentTime { get; set; }

        [Required]
        [StringLength(50)]
        public string EmailTitle { get; set; }

        public string Content { get; set; }

        public virtual MemberInfo MemberInfo { get; set; }
    }
}
