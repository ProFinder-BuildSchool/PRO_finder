using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PRO_finder.Models;
using PRO_finder.Service;

namespace PRO_finder.Controllers
{
    
    public class ClientController : MyControllerBase
    {
        // GET: Client
        private readonly OrderService _orderservice;
        private readonly MemberinfoService _memberservice;

        public ClientController()
        {
            _orderservice = new OrderService();
            _memberservice = new MemberinfoService();        
        }

        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult OrderPendingPayment()
        {
            
            var MemberId = _orderservice.GetMemberID(HttpContext.User.Identity.GetUserId());
            ViewBag.MemberId = MemberId;

            return View();
        }


        public ActionResult OrderDoing()
        {

            var MemberId = _orderservice.GetMemberID(HttpContext.User.Identity.GetUserId());
            ViewBag.MemberId = MemberId;

            return View();
        }

        public ActionResult OrderAccepting()
        {

            var MemberId = _orderservice.GetMemberID(HttpContext.User.Identity.GetUserId());
            ViewBag.MemberId = MemberId;

            return View();
        }

        public ActionResult OrderDeal()
        {

            var MemberId = _orderservice.GetMemberID(HttpContext.User.Identity.GetUserId());
            ViewBag.MemberId = MemberId;

            return View();
        }

        public ActionResult ReviseAccount(int userId)
        {
            ViewBag.MemberId = _orderservice.GetMemberID(HttpContext.User.Identity.GetUserId());
            ViewBag.MemberList = _memberservice.GetAccountInfo(userId);

            return View();
        }

        public ActionResult ReviseProposerAccount(int userId)
        {
            ViewBag.MemberId = _orderservice.GetMemberID(HttpContext.User.Identity.GetUserId());
            ViewBag.MemberList = _memberservice.GetAccountInfo(userId);

            return View();
        }

        [Authorize]
        public ActionResult CreateCase()
        {
            return View();
        }
    }
}