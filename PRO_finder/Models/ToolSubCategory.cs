namespace PRO_finder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ToolSubCategory")]
    public partial class ToolSubCategory
    {
        public int TalentCategoryID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubTalentCategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string SubTalentCategoryName { get; set; }

        public virtual ToolCategory ToolCategory { get; set; }
    }
}
