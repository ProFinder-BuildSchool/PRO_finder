using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Models.ViewModels
{
    public class SaveCaseViewModel
    {
        public int CaseID { get; set; }

        public DateTime SavedDate { get; set; }

        public int MemberID { get; set; }


        public string title { get; set; }
        public enum PriceEnum
        { 不可為零, 五千元以下, 五千至一萬元間, 一萬至五萬元間, 五萬至十萬元間, 十萬至三十萬元間, 查無資料 }
        public PriceEnum Price { get; set; }
        public string Contact { get; set; }
        public int CaseStatus { get; set; }
        public DateTime UpdateDate { get; set; }



    }
}