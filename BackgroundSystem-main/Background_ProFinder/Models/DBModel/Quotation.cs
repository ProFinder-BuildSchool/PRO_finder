using System;
using System.Collections.Generic;

#nullable disable

namespace Background_ProFinder.Models.DBModel
{
    public partial class Quotation
    {
        public int QuotationId { get; set; }
        public string QuotationTitle { get; set; }
        public DateTime UpdateDate { get; set; }
        public int QuotationUnit { get; set; }
        public int ExecuteDate { get; set; }
        public int? MemberId { get; set; }
        public string Description { get; set; }
        public decimal? Evaluation { get; set; }
        public int SubCategoryId { get; set; }
        public decimal? Price { get; set; }
        public string MainPicture { get; set; }
        public bool? Status { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}
