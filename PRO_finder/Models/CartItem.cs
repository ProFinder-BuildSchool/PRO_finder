using PRO_finder.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Models
{
    [Serializable]

    public class CartItem
    {
        //public int CartItemId { get; set; }
        //public int CartId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Contact { get; set; }
        public int CaseStatus { get; set; }
        public TimeSpan UpdateDate { get; set; }
        public Case Case { get; set; }

    }
}