namespace PRO_finder.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FeaturedWork")]
    public partial class FeaturedWork
    {
        [Key]
        public int FeaturedID { get; set; }

        public int? WorkID { get; set; }

        public string Memo { get; set; }

        public virtual Works Works { get; set; }
    }
}
