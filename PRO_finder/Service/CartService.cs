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

        public int GetMemberID(string userID)
        {
           

            try 
            {
                if (userID == null) { return -1; }

                var memberId = _repo.GetAll<MemberInfo>().First(x => x.UserId == userID).MemberID;

                return memberId;

            }

            catch (Exception)
            {
                return -1;
            }

            
        }
        public bool DelCart(int Id, int cartId)
        {
            var CartDBList = _repo.GetAll<ClientCart>().FirstOrDefault(x => (int)x.ClientID == Id  && x.CartID == cartId);
            _repo.Delete<ClientCart>(CartDBList);
            _repo.SaveChanges();
            return true;
        }


        public List<ClientCartViewModel> GetCart(int memberId)
        {
         

            var CartDBList = _repo.GetAll<ClientCart>().Where(x => (int)x.ClientID == memberId);

            List<ClientCartViewModel> CartList = new List<ClientCartViewModel>();

            foreach (var item in CartDBList)
            {
                CartList.Add(new ClientCartViewModel
                {

                    CartID=item.CartID,
                    ClientID = (int)item.ClientID,
                    ProposerID = (int)item.ProposerID,
                    QuotationImg = item.QuotationImg,
                    SubCategory = item.SubCategoryName,
                    StudioName = item.StudioName,
                    Count =(int)item.Count,
                    Price = (int)item.Price,
                    Unit = System.Enum.GetName(typeof(UnitEnum), item.Unit),
                    Email = item.Email,
                    Name =item.Name,
                    Tel = item.Tel,
                    LineID = item.LineID,
                    Memo = item.Memo
                });
            }


            return CartList;

        }


        public bool UpDateCart(int Id ,UpDateCartViewModel VM)
        {

  
                var CartDBList = _repo.GetAll<ClientCart>().Where(x => (int)x.ClientID == Id).First(y => y.CartID == VM.CartID);
                CartDBList.Email = VM.Email;
                CartDBList.Count = VM.Count;
                CartDBList.Name = VM.Name;
                CartDBList.LineID = VM.LineID;
                CartDBList.Memo = VM.Memo;
                CartDBList.Tel = VM.Tel;
                _repo.Update<ClientCart>(CartDBList);
                _repo.SaveChanges();
                return true;
  
        }









        public bool addCart(ClientCartViewModel Cart, int memberId)
        {
            var member = _repo.GetAll<MemberInfo>().First(x => x.MemberID == memberId);
            var clientCart = new ClientCart()
            {
                ProposerID = Cart.ProposerID,
                ClientID = member.MemberID,
                QuotationImg = Cart.QuotationImg,
                SubCategoryName = Cart.SubCategory,
                StudioName = Cart.StudioName,
                Count = Cart.Count,
                Price = Cart.Price,
                Unit = (int)System.Enum.Parse(typeof(UnitEnum), Cart.Unit),
                Email = Cart.Email,
                Name = Cart.Name,
                Tel = Cart.Tel,
                LineID = Cart.LineID,
                Memo = Cart.Memo
                //TODO ContactTime 

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
                count = _repo.GetAll<Order>().Where(x => x.ProposerID == memberID).Count();
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