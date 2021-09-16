using System;
using System.Collections.Generic;

#nullable disable

namespace Background_ProFinder.Models.DBModel
{
    public partial class ClientCart
    {
        public int CartId { get; set; }
        public int? ClientId { get; set; }
        public string QuotationImg { get; set; }
        public string SubCategoryName { get; set; }
        public string StudioName { get; set; }
        public int? Count { get; set; }
        public decimal? Price { get; set; }
        public int? Unit { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public string LineId { get; set; }
        public string Memo { get; set; }
        public int? ContactTime { get; set; }
        public int? ProposerId { get; set; }
        public int? PredictDays { get; set; }
        public int? QuotationId { get; set; }
    }
}
