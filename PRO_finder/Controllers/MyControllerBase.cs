using Microsoft.AspNet.Identity;
using PRO_finder.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRO_finder.Controllers
{
    
    public class MyControllerBase : Controller
    {
        private readonly CartService _cartService;

        public MyControllerBase()
        {
            _cartService = new CartService();
        }
        // GET: MyControllerBase
        public int  memberID => _cartService.GetMemberID(HttpContext.User.Identity.GetUserId());
       
    }
}