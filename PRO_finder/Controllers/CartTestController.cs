using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRO_finder.Controllers
{
    public class CartTestController : Controller
    {
        //GET: CartTest
        public ActionResult GetCart()
        {
            var cart = Models.CartOperation.GetCurrentCart();
            //cart.AddCartCase();

            if (cart.cartItems.Count == 0)
            {
                cart.cartItems.Add(
                    new Models.CartItem()
                    {

                        Name = "協助金屬拋光",
                        Price = 5000,
                        Contact = "羅**",
                        CaseStatus = 1


                    });
            }


            return View(cart);


        }
    }
}