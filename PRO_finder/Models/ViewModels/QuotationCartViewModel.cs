using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Models.ViewModels
{
    public class QuotationCartViewModel
    {
        public int CaseID { get; set; }
        public int ProposerID { get; set; }
        public int PredictDays { get; set; }
        public string ProposeDescription { get; set; }
        public DateTime ProposeDate { get; set; }
        public decimal ProposePrice { get; set; }
        public string NickName { get; set; }

        //大頭貼
        //public string ProfilePicture { get; set; }

        //成交筆數
        public int DealedCount { get; set; }

    }
}