using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Models.ViewModels
{
    public class CaseViewModel
    {
       








        public string title { get; set; }
        public enum PriceEnum
        {
            五千以下 , 五千到一萬, 一萬到五萬, 五萬到十萬, 十萬到三十萬, 三十萬到五十萬, 五十萬到八十萬, 八十萬到一百萬, 一百萬到三百萬, 三百萬以上
        }
        public PriceEnum Price { get; set; }

        public int LocationID{ get; set; }

        public string LocationName { get;  set; }

        public int SubCategoryID { get; set; }

        public string Description { get; set; }

        public DateTime UpdateDate { get; set; }



    }
}