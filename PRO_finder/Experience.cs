namespace PRO_finder
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Experience")]
    public partial class Experience
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MemberID { get; set; }

        public int SubCategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string PieceworkExp { get; set; }

        public virtual MemberInfo MemberInfo { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}
