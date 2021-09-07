using ECPay.Payment.Integration;
using Microsoft.AspNet.Identity;
using PRO_finder.Models.ViewModels;
using PRO_finder.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRO_finder.Controllers
{
    
    public class CartController : MyControllerBase
    {
        private readonly CartService _cartservice;

        public CartController()
        {
            _cartservice = new CartService();
        }


        // GET: Cart
        [Authorize]
        public ActionResult CartList()
        {
            string userID = HttpContext.User.Identity.GetUserId();
            int MemberID = _cartservice.GetMemberID(userID);
            ViewBag.MemberID = MemberID;
            return View();
        }

        public ActionResult PaymentTest()
        {
            string userID = HttpContext.User.Identity.GetUserId();
            int MemberID = _cartservice.GetMemberID(userID);
            return View();
        }
        [HttpPost]
        public ActionResult PostECPayment([System.Web.Http.FromBody]List<PaymentViewModel> data)
        {
            Session["thePayment"] = data;
            Response.Write("成功進入");
            return Redirect("/ECPay/AioCheckOut.aspx");
        }

    }
}