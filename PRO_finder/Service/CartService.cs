using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PRO_finder.Models.DBModel;
using PRO_finder.Models.ViewModels;
using PRO_finder.Repositories;
using static PRO_finder.Enum.Enum;

namespace PRO_finder.Service
{


    public class CartService
    {
        private readonly GeneralRepository _repo;

        public CartService()
        {
            _repo = new GeneralRepository(new ProFinderContext());
        }

        public bool addCart(ClientCartViewModel Cart, string memberId)
        {
            var member = _repo.GetAll<MemberInfo>().FirstOrDefault(x => x.UserId == memberId);
            if (member == null) return false;
            var clientCart = new ClientCart()
            {
                MemberID = member.MemberID,
                QuotationImg = Cart.QuotationImg,
                SubCategoryName = Cart.SubCategory,
                StudioName = Cart.StudioName,
                Count = Cart.Count,
                Price = Cart.Price,
                Unit = (int)System.Enum.Parse(typeof(UnitEnum), Cart.Unit),
                //OrdersInformation = new OrdersInformation
                //{
                //    Email = Cart.OrderInfo.Email,
                //    Name = Cart.OrderInfo.Name,
                //    Tel = Cart.OrderInfo.Tel,
                //    LineID = Cart.OrderInfo.LineID,
                //    Memo = Cart.OrderInfo.Memo
                //    //TODO ContactTime 
                //}
            };
            _repo.Create<ClientCart>(clientCart);
            _repo.SaveChanges();

            return true;
        }

        //人才【我要報價】
        public OperationResult CreateQuotationCart(int memberID,QuotationCartViewModel newQ)
        {
            var result = new OperationResult();
            //var input = JObject.Parse(newQ);
            try
            {
                //var entity = new QuotationDetail
                //{
                //    ProposerID = memberID,
                //    CaseID = input.GetValue("CaseID").ToObject<int>(),
                //    PredictDays = input.GetValue("PredictDays").ToObject<int>(),
                //    ProposeDescription = input.GetValue("ProposeDescription").ToString(),
                //    ProposeDate = DateTime.UtcNow,
                //    ProposePrice = input.GetValue("ProposePrice").ToObject<int>()
                //};
                var entity = new QuotationDetail
                {
                    ProposerID = memberID,
                    CaseID = newQ.CaseID,
                    PredictDays = newQ.PredictDays,
                    ProposeDescription = newQ.ProposeDescription,
                    ProposeDate = DateTime.UtcNow,
                    ProposePrice = newQ.ProposePrice
                };
                _repo.Create(entity);
                _repo.SaveChanges();
                result.IsSuccessful = true;
            }
            catch(Exception ex)
            {
                result.IsSuccessful = false;
                result.Exception = ex;
            }
            return result;
        }
        public string GetAllQuotationCart(int memberID)
        {
            //取得memberInfo
            MemberInfo memInfo = _repo.GetAll<MemberInfo>().FirstOrDefault(x => x.MemberID == memberID);
            
            //取得成交order數量
            int count = 0;
            try
            {
                count = _repo.GetAll<Order>().Where(x => x.DealedTalentMemberID == memberID).Count();
            }
            catch
            {
                count = 0;
            }

            //取得quotationCart
            List<QuotationDetail> quoCart = new List<QuotationDetail>();
            try
            {
                quoCart = _repo.GetAll<QuotationDetail>().Where(x => x.ProposerID == memberID).ToList();
            }
            catch
            {
                quoCart = null;
            }

            List<QuotationCartViewModel> allInfoInCart = new List<QuotationCartViewModel>();
            if (quoCart != null)
            {
                
                foreach (var item in quoCart)
                {
                    allInfoInCart.Add(new QuotationCartViewModel
                    {
                        //ProfilePicture = memInfo.ProfilePicture,
                        NickName = memInfo.NickName,
                        ProposeDate = item.ProposeDate,
                        ProposePrice = item.ProposePrice,
                        PredictDays = item.PredictDays,
                        ProposeDescription = item.ProposeDescription
                    });
                }
            }
            
            return JsonConvert.SerializeObject(allInfoInCart);
        }
    }
}