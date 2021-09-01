namespace PRO_finder.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClientCart")]
    public partial class ClientCart
    {
        [Key]
        public int CartID { get; set; }

        public int? MemberID { get; set; }

        public string QuotationImg { get; set; }

        public string SubCategoryName { get; set; }

        [StringLength(50)]
        public string StudioName { get; set; }

        public int? Count { get; set; }

        public decimal? Price { get; set; }

        public int? Unit { get; set; }

        public string Email { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Tel { get; set; }

        [StringLength(50)]
        public string LineID { get; set; }

        public string Memo { get; set; }

        public int? ContactTime { get; set; }
    }
}
