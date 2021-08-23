using PRO_finder.Models.DBModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Models
{
    //[Serializable]
    //: IEnumerable<CartItem>
    public class Cart
    {

        public Cart()
        {
            this.cartItems = new List<CartItem>();
        }
        public List<CartItem> cartItems;

        //public object Price { get; internal set; }


        //public bool AddCartCase (Case _case)
        //{
        //    var cartItem = new Models.CartItem()
        //    {
        //        Id=_case.CaseID,
        //        Name=_case.CaseTitle,
        //        Price = _case.Price,
        //        Contact = _case.Contact,
        //        CaseStatus = _case.CaseStatus,
        //        UpdateDate = _case.UpdateDate
        //    };


        //---

        //    this.cartItems.Add(cartItem);
        //    return true;

        //var findItem = this.cartItems
        //    .Where(s => s.Id == CaseID)
        //    .Select(s => s)
        //    .FirstOrDefault();

        //if (findItem==default(Models.CartItem))
        //{
        //    using (Models.DBModel.SaveCase db = new SaveCase())
        //    {
        //        var case = ()
        //    }
        //}
    }
}