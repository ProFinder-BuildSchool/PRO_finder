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
        public string QuotationImg { get; set; }

        public enum UnitEnum
        {
            件, 張, 頁, 份, 字, 個, 天, 時, 坪, 才, 秒, 月, 則, 幅
        }
        public UnitEnum Unit { get; set; }


    }
}