using PRO_finder.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Models.ViewModels
{
    public class OrderViewModel
    {
        public decimal Schedule { get; set; }
        public string OrderSetupDay { get; set; }
        public string PredictDays { get; set; }
        public int Remaindays{ get; set; }
        public int OrderID { get; set; }
        public int CartID { get; set; } 
        public int ProposerID { get; set; }
       
        public int ClientID { get; set; }
        public string QuotationImg { get; set; }
        public string StudioName { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public string LineID { get; set; }
        public string Memo { get; set; }

        public string OrderStatus { get; set; }

        public string ProposerEmail { get; set; }
        public string ProposerQuotationTitle { get; set; }

        public string ProposerCellPhone { get; set; }
        public int ContactTime { get; set; }
        public int OrderStatusNumber { get; set; }

        public int QuotationID { get; set; }

        public string PaymentCode { get; set; }

    }

    
}