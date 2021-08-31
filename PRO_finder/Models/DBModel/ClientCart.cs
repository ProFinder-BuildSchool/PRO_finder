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
        public int? MemberID { get; set; }

        [Key]
        public int CartID { get; set; }

        public string QuotationImg { get; set; }

        public string SubCategoryName { get; set; }

        [StringLength(50)]
        public string StudioName { get; set; }

        public int? Count { get; set; }

        public decimal? Price { get; set; }

        public int? Unit { get; set; }
       
    }
}
