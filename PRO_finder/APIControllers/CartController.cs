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
        private readonly MemberinfoService _memInfoService;
        private readonly CartService _cartService;
        public CartController()
        {
            _memInfoService = new MemberinfoService();
            _cartService = new CartService();
        }
        //人才報價cart api
        //1. 接收報價資料表單
        [HttpPost]
        public APIResult PostQuotationInfo([FromBody]QuotationCartViewModel newQ)
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
            catch(Exception ex)
            {
                return new APIResult(APIStatus.Fail, ex.Message, result);
            }
        }

    }
}
