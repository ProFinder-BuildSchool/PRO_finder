using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Models.ViewModels
{
    public class PaymentViewModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Sum { get { return Price * Quantity; } }
        public int OrderID { get; set; }
    }
    public class ECPaymentRtnViewModel
    {
        public string RtnCode { get; set; }
        public string RtnMsg { get; set; }
        public string CustomField1 { get; set; }
    }
    public class PaymentResultViewModel
    {
        public string ResultMsg { get; set; }
        public string ReturnPageTitle { get; set; }
        public string ReturnPageUrl { get; set; }
        public bool Result { get; set; }
    }
}