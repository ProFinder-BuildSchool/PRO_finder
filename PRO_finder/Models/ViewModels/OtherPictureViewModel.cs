namespace PRO_finder.Models.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OtherPicture")]
    public partial class OtherPictureViewModel
    {
        public int QuotationID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OtherPictureID { get; set; }

        [Required]
        public string MainPicture { get; set; }

        public int SortNumber { get; set; }

        public byte IsDefault { get; set; }

        [Column("OtherPicture")]
        public string OtherPicture1 { get; set; }
    }
}
