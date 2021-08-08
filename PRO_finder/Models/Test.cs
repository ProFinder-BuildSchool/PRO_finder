namespace PRO_finder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Test")]
    public partial class Test
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(50)]
        public string logoName { get; set; }

        public int? Price { get; set; }

        public int? BuyPerson { get; set; }

        [StringLength(10)]
        public string Unit { get; set; }

        [StringLength(10)]
        public string StudioName { get; set; }

        public string Img { get; set; }
    }
}
