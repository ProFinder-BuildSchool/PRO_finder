using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Models.ViewModels
{
    public class QuotationCartViewModel
    {
        public int CaseID { get; set; }
        public string CaseTitle { get; set; }
        public int ProposerID { get; set; }
        public int PredictDays { get; set; }
        public string ProposeDescription { get; set; }
        public string ProposeDate { get; set; }
        public decimal ProposePrice { get; set; }
        public string NickName { get; set; }

        //大頭貼
        public string ProfilePicture { get; set; }

        //成交筆數
        public int DealedCount { get; set; }
        public int QuotationDetailID { get; set; }
        public bool Status { get; set; }

        //public enum statusEnum { 已成交, 未成交 }
        //public statusEnum Status { get; set; }



    }

}