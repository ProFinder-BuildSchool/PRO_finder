namespace PRO_finder.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Quotation")]
    public partial class Quotation
    {
        public int QuotationID { get; set; }

        [Required]
        [StringLength(30)]
        public string QuotationTitle { get; set; }

        public DateTime UpdateDate { get; set; }

        public int QuotationUnit { get; set; }

        public int ExecuteDate { get; set; }

        public int? MemberID { get; set; }

        [Required]
        public string Description { get; set; }

        public decimal? Evaluation { get; set; }

        public int SubCategoryID { get; set; }

        public decimal? Price { get; set; }

        public string MainPicture { get; set; }

        public bool? Status { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}
