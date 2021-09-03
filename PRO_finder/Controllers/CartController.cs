using Microsoft.AspNet.Identity;
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
    }
}