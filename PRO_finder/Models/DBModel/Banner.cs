namespace PRO_finder.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Banner")]
    public partial class Banner
    {
        public int BannerID { get; set; }

        [StringLength(50)]
        public string BannerTitle { get; set; }

        public string BannerImgUrl { get; set; }
    }
}
