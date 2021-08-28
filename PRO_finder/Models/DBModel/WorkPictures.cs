namespace PRO_finder.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WorkPictures
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WorkPictureID { get; set; }

        public int WorkID { get; set; }

        public int SortNumber { get; set; }

        [Required]
        public string WorkPicture { get; set; }

        public virtual Works Works { get; set; }
    }
}
