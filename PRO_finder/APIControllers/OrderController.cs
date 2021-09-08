using PRO_finder.Models.ViewModels;
using PRO_finder.Models.ViewModels.APIModels.APIBase;
using PRO_finder.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PRO_finder.APIControllers
{
    public class OrderController : ApiController
    {
        private readonly OrderService _orderService;

        public OrderController()
        {
            _orderService = new OrderService();
        }
        public APIResult GetOrder(int id)
        {
            try 
            {
                var result = _orderService.GetOrderList(id);
                 return new APIResult(APIStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new APIResult(APIStatus.Fail, ex.Message, "");
            }
            
        }

        public APIResult GetQtOrder(int id)
        {
            try
            {
                var result = _orderService.GetQtOrderList(id);
                return new APIResult(APIStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new APIResult(APIStatus.Fail, ex.Message, "");
            }

        }



        public APIResult CancelOrder(int id)
        {
            try
            {
                var result = _orderService.GetOrderList(id);
                return new APIResult(APIStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new APIResult(APIStatus.Fail, ex.Message, "");
            }

        }




        public APIResult AddOrder(OrderViewModel[] OrderVM)
        {
  

            try
            {
                var result = _orderService.AddOrder(OrderVM);
                return new APIResult(APIStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new APIResult(APIStatus.Fail, ex.Message, "");
            }
           
        }



    
        public APIResult UpdateOrderMemo(int Orderid, OrderViewModel data)
        {

            var result = false;
            try
            {
                 result = _orderService.UpdateOrderMemo(Orderid, data);
                return new APIResult(APIStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                result = false;
                return new APIResult(APIStatus.Fail, ex.Message, result);
            }

        }
    }
}
