using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Models.ViewModels
{
    public class UpDateCartViewModel
    {
        public int CartID { get; set; }
        public int MemberID { get; set; } 
        public int Count { get; set; }     
        public string Email { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public string LineID { get; set; }
        public string Memo { get; set; }
    }
    


        public class ClientCartViewModel
        {
            public  int CartID { get; set; }
            public int MemberID { get; set; }
            public string QuotationImg { get; set; }
            public string SubCategory { get; set; }
            public string StudioName { get; set; }
            public int Count { get; set; }
            public int Price { get; set; }
            public string Unit { get; set; }
            public string Email { get; set; }
            public string Name { get; set; }
            public string Tel { get; set; }
            public string LineID { get; set; }
            public string Memo { get; set; }
        }


    public class GetClientCartViewModel
    {
        public int MemberID { get; set; }
        public string QuotationImg { get; set; }
        public string SubCategory { get; set; }
        public string StudioName { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public string Unit { get; set; }

        public string Email { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public string LineID { get; set; }
        public string Memo { get; set; }
    }




}