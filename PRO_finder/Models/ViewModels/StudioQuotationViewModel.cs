using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Models.ViewModels
{
    public class StudioQuotationViewModel
    {
        public int QuotationId { get; set; }
        public int? QuotationCategoryId { get; set; }
        public int QuotationSubcategoryId { get; set; }
        public string SubcategoryName { get; set; }
        public string CategoryName { get; set; }
        public decimal? Price { get; set; }
        public int Unit { get; set; }
        public string QuotationImg { get; set; }
    }
}