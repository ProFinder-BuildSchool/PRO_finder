namespace PRO_finder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WorkPicture
    {
        public int WorkID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WorkPictureID { get; set; }

        [Column("WorkPicture", TypeName = "image")]
        [Required]
        public byte[] WorkPicture1 { get; set; }

        public int SortNumber { get; set; }

        public virtual Work Work { get; set; }
    }
}
