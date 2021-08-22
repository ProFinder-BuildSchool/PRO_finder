namespace PRO_finder.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OtherPicture")]
    public partial class OtherPicture
    {
        public int QuotationID { get; set; }

        public int OtherPictureID { get; set; }

        public int SortNumber { get; set; }

        public bool? IsDefault { get; set; }

        [Column("OtherPicture")]
        public string OtherPicture1 { get; set; }
    }
}
