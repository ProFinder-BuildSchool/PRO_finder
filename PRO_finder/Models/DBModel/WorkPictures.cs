namespace PRO_finder.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WorkPictures
    {
        public int WorkID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WorkPictureID { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] WorkPicture { get; set; }

        public int SortNumber { get; set; }

        public virtual Works Works { get; set; }
    }
}
