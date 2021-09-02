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

        public CartController()
        {
            _cartservice = new CartService();
        }
        //[Route("{id}")]
        public APIResult GetCart(int id)
        {

            
            var result = _cartservice.GetCart(id);

            try
            {
                return new APIResult(APIStatus.Success, string.Empty, result);

            }
            catch (Exception ex)
            {
                return new APIResult(APIStatus.Fail, ex.Message, result);
            };

        }


        [HttpPut]
        public APIResult UpDateCart(int id , UpDateCartViewModel updateVM)
        {
            var result = _cartservice.UpDateCart(id, updateVM);

            try
            {
                return new APIResult(APIStatus.Success, string.Empty, result);

            }
            catch (Exception ex)
            {
                return new APIResult(APIStatus.Fail, ex.Message, result);
            };

        }


        [HttpDelete]
        public APIResult DelCart(int id, int CartID)
        {
            var result = _cartservice.DelCart(id, CartID);
            try
            {
                return new APIResult(APIStatus.Success, string.Empty, result);

            }
            catch (Exception ex)
            {
                return new APIResult(APIStatus.Fail, ex.Message, result);
            };

        }


        [HttpPost]
        [Authorize]
        public APIResult AddCart(ClientCartViewModel Cart ,int memberID)
        {

            if (_cartservice.addCart(Cart, memberID))
            {

                return new APIResult(APIStatus.Success, string.Empty, null);
            }


            return new APIResult(APIStatus.Fail, string.Empty, null);
        }

    }
}
