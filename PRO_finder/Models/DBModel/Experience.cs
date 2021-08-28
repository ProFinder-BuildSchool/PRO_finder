namespace PRO_finder.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Experience")]
    public partial class Experience
    {
        public int MemberID { get; set; }

        public int SubCategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string PieceworkExp { get; set; }

        [Key]
        public int ExpID { get; set; }

        public virtual MemberInfo MemberInfo { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}
