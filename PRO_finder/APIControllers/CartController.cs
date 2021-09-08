using ECPay.Payment.Integration;
using Microsoft.AspNet.Identity;
using PRO_finder.Models.DBModel;
using PRO_finder.Models.ViewModels;
using PRO_finder.Models.ViewModels.APIModels.APIBase;
using PRO_finder.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;


namespace PRO_finder.APIControllers
{
    public class CartController : ApiController
    {
        private readonly CartService _cartservice;
        private readonly MemberinfoService _memInfoService;
        private readonly CartService _cartService;

        public CartController()
        {
            _cartservice = new CartService();
            _memInfoService = new MemberinfoService();
            _cartService = new CartService();
        }
        //[Route("{id}")]
        public APIResult GetCart(int id)
        {
            var result = _cartservice.GetCart(id);
            return new APIResult(APIStatus.Success, string.Empty, result);


        }


        [HttpPut]
        public APIResult UpDateCart(int id, UpDateCartViewModel updateVM)
        {
            bool result;
            try
            {
                result = _cartservice.UpDateCart(id, updateVM);
                return new APIResult(APIStatus.Success, string.Empty, result);

            }
            catch (Exception ex)
            {
                result = false;
                return new APIResult(APIStatus.Fail, ex.Message, result);
            };

        }


        [HttpDelete]
        public APIResult DelCart(int id, int CartID)
        {
            bool result;
            try
            {
                result = _cartservice.DelCart(id, CartID);
                return new APIResult(APIStatus.Success, string.Empty, result);

            }
            catch (Exception ex)
            {
                result = false;
                return new APIResult(APIStatus.Fail, ex.Message, result);
            };

        }


        [HttpPost]
        [Authorize]
        public APIResult AddCart(ClientCartViewModel Cart, int memberID)
        {


            bool result;
            try
            {
                result = _cartservice.addCart(Cart, memberID);
                return new APIResult(APIStatus.Success, string.Empty, result);

            }
            catch (Exception ex)
            {
                result = false;
                return new APIResult(APIStatus.Fail, ex.Message, result);
            };

        }


        //人才報價cart api
        //1. 接收報價資料表單
        [HttpPost]
        public APIResult PostQuotationInfo([FromBody] QuotationCartViewModel newQ)
        {
            string userID = User.Identity.GetUserId();
            int memberID = _memInfoService.GetMemberID(userID);
            var operationResult = _cartService.CreateQuotationCart(memberID, newQ);
            if (operationResult.IsSuccessful)
            {
                return new APIResult(APIStatus.Success, string.Empty, "加入成功");
            }
            else
            {
                return new APIResult(APIStatus.Fail, operationResult.Exception.ToString(), "");
            }

        }
        //2.提取當前QuotationDetail cart資料
        public APIResult GetQuotationCart()
        {
            string result = "";
            try
            {
                string userID = User.Identity.GetUserId();
                int memberID = _memInfoService.GetMemberID(userID);
                result = _cartService.GetAllQuotationCart(memberID);
                return new APIResult(APIStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new APIResult(APIStatus.Fail, ex.Message, result);
            }
        }
        //public APIResult RefuseQuotation(int qdID)
        //{
        //    string result = "";
        //    try
        //    {
        //        _cartService.RefuseQd(qdID);
        //        result = "加入成功";
        //        return new APIResult(APIStatus.Success, string.Empty, result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new APIResult(APIStatus.Fail, ex.Message, result);
        //    }
        //}

        //public APIResult AddQuotationOrder(int qdID)
        //{
        //    string result = "";
        //    try
        //    {
        //        _cartService.QdToOrder(qdID);
        //        result = "加入成功";
        //        return new APIResult(APIStatus.Success, string.Empty, result);
        //    }
        //    catch(Exception ex)
        //    {
        //        return new APIResult(APIStatus.Fail, ex.Message, result);
        //    }
        //}
    }
}
