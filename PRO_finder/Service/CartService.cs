using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PRO_finder.Models.DBModel;
using PRO_finder.Models.ViewModels;
using PRO_finder.Repositories;
using static PRO_finder.Enum.Enum;
using static PRO_finder.Models.ViewModels.QuotationCartViewModel;

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

                    CartID = item.CartID,
                    MemberID = (int)item.ClientID,
                    QuotationImg = item.QuotationImg,
                    SubCategory = item.SubCategoryName,
                    StudioName = item.StudioName,
                    Count = (int)item.Count,
                    Price = (int)item.Price,
                    Unit = System.Enum.GetName(typeof(UnitEnum), item.Unit),
                    Email = item.Email,
                    Name = item.Name,
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
            try
            {
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

        //人才提案紀錄刪除 //取消提案

        public void DeleOfQTRecord(int? caseID,int memberID)
        {
            var QTRecordDB = _repo.GetAll<QuotationDetail>().FirstOrDefault(q => q.CaseID == caseID && q.ProposerID == memberID);
            _repo.Delete<QuotationDetail>(QTRecordDB);
            _repo.SaveChanges();
        }

        public string GetAllQuotationCart(int memberID)
        {
            //取得quotationCart
            List<QuotationDetail> quoCart = new List<QuotationDetail>();
            try
            {
                var myCase = _repo.GetAll<Case>().Where(x => x.MemberID == memberID).ToList();
                foreach(var item in myCase)
                {
                    var qd = _repo.GetAll<QuotationDetail>().Where(x => x.CaseID == item.CaseID).ToList();
                    foreach(var j in qd)
                    {
                        quoCart.Add(j);
                    }
                }
                
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
                    string date = item.ProposeDate.ToString("yyyy-MM-dd");
                    Case theCase = _repo.GetAll<Case>().FirstOrDefault(x => x.CaseID == item.CaseID);

                    //取得proposer memberInfo
                    MemberInfo memInfo = _repo.GetAll<MemberInfo>().FirstOrDefault(x => x.MemberID == item.ProposerID);
                    //取得成交order數量
                    int count = 0;
                    try
                    {
                        count = _repo.GetAll<Order>().Where(x => x.ProposerID == item.ProposerID).Count();
                    }
                    catch
                    {
                        count = 0;
                    }

                    //回傳資料
                    allInfoInCart.Add(new QuotationCartViewModel
                    {
                        //ProfilePicture = memInfo.ProfilePicture,
                        ProfilePicture = "https://s1.tasker.com.tw/img/62M4ye/Zg/BL?update=1",
                        NickName = memInfo.NickName,
                        ProposeDate = date,
                        ProposePrice = item.ProposePrice,
                        PredictDays = item.PredictDays,
                        ProposeDescription = item.ProposeDescription,
                        ProposerID = item.ProposerID,
                        CaseID = item.CaseID,
                        DealedCount = count,
                        CaseTitle = theCase.CaseTitle,
                        QuotationDetailID = item.QuotaionDetailID
                    });
                }
            }
            
            return JsonConvert.SerializeObject(allInfoInCart);
        }


        public List<QuotationCartViewModel> GetAllQTRecords(int memberID)
        {
            List<QuotationCartViewModel> allInfoInQTR = new List<QuotationCartViewModel>();
            var quoRecord = _repo.GetAll<QuotationDetail>()
                .Where(x => x.ProposerID == memberID).ToList();

                foreach (var item in quoRecord)
                {
                    string date = item.ProposeDate.ToString("yyyy-MM-dd");
                    Case theCase = _repo.GetAll<Case>().FirstOrDefault(x => x.CaseID == item.CaseID);
                    allInfoInQTR.Add(new QuotationCartViewModel
                    {
                        ProposeDate = date,
                        ProposePrice = item.ProposePrice,
                        CaseTitle = theCase.CaseTitle,
                        CaseID = item.CaseID,
                        //Status = (QuotationCartViewModel.statusEnum)(statusEnum)item.Status
                    });
                }
            return allInfoInQTR;
        }

        
        public void QdToOrder(int qdID)
        {
            var qdCart = _repo.GetAll<QuotationDetail>().FirstOrDefault(x => x.QuotaionDetailID == qdID);
            var caseInfo = _repo.GetAll<Case>().FirstOrDefault(x => x.CaseID == qdCart.CaseID);
            var clientInfo = _repo.GetAll<MemberInfo>().FirstOrDefault(x => x.MemberID == caseInfo.MemberID);
            var proposerInfo = _repo.GetAll<MemberInfo>().FirstOrDefault(x => x.MemberID == qdCart.ProposerID);
            Order newOrder = new Order()
            {
                ProposerID = qdCart.ProposerID,
                OrderStatus = 1,
                DepositStatus = 0,
                Price = qdCart.ProposePrice,
                DealedDate = DateTime.UtcNow,
                ClientID = caseInfo.MemberID,
                QuotationImg = "~/Assets/images/hero_1.jpg",
                Email = clientInfo.Email,
                //Name = clientInfo.NickName,
                StudioName = proposerInfo.NickName,
                Tel = clientInfo.Cellphone,
                PredictDays = qdCart.PredictDays
            };
            _repo.Create(newOrder);
            _repo.SaveChanges();
        }
    }
}