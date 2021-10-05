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
    [Authorize]
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
        
       

        public ActionResult GoToConfirmPayment(string paymentCode)
        {
            var orderDetails = _cartservice.GetOrderDetail(paymentCode);
            ViewBag.Total = orderDetails.Sum(x => x.Sum);
            ViewBag.PaymentCode = paymentCode;
            return View("ConfirmPayment", orderDetails);
        }

        public ActionResult ConfirmPayment()
        {
            List<PaymentViewModel> payment = new List<PaymentViewModel>();
            return View(payment);
        }

        public ActionResult ECPaymentPage(string paymentCode)
        {
            Session["thePayment"] = _cartservice.GetTheOrderToPay(paymentCode);
            Session["PaymentCode"] = paymentCode;
            Response.Write("成功進入");
            return Redirect("/ECPay/AioCheckOut.aspx");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult ECPaymentResult(ECPaymentRtnViewModel result)
        {
            PaymentResultViewModel paymentRst = new PaymentResultViewModel();
            if (result.RtnCode == "1")
            {
                paymentRst = new PaymentResultViewModel()
                {
                    ResultMsg = "付款成功",
                    ReturnPageTitle = "進行中案件",
                    ReturnPageUrl = "OrderDoing",
                    Result = true
                };
                string paymenCode = result.CustomField1;
                _cartservice.PaymentSucceed(paymenCode);
            }else if(result.RtnCode == "2")
            {
                paymentRst = new PaymentResultViewModel()
                {
                    ResultMsg = "付款失敗",
                    ReturnPageTitle = "待付款案件",
                    ReturnPageUrl = "OrderPendingPayment",
                    Result = false
                };
            }
            return View("ECPaymentResultPage", paymentRst);
        }
        public ActionResult ECPaymentResultPage()
        {
            PaymentResultViewModel paymentResult = new PaymentResultViewModel();
            return View(paymentResult);
        }
    }
}