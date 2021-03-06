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
            var CartDBList = _repo.GetAll<ClientCart>().FirstOrDefault(x => (int)x.ClientID == Id && x.CartID == cartId);
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
                    ClientID = (int)item.ClientID,
                    ProposerID = (int)item.ProposerID,
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
                    Memo = item.Memo,
                    ContactTime = (int)item.ContactTime,
                    QuotationID = (int)item.QuotationID
                });
            }


            return CartList;

        }

        public bool UpDateCart(int Id, UpDateCartViewModel VM)
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
                ProposerID = Cart.ProposerID,
                StudioName = Cart.StudioName,
                Count = Cart.Count,
                Price = Cart.Price,
                Unit = (int)System.Enum.Parse(typeof(UnitEnum), Cart.Unit),
                Email = Cart.Email,
                Name = Cart.Name,
                Tel = Cart.Tel,
                LineID = Cart.LineID,
                Memo = Cart.Memo,
                ContactTime = Cart.ContactTime,
                QuotationID = Cart.QuotationID

            };
            _repo.Create<ClientCart>(clientCart);
            _repo.SaveChanges();

            return true;
        }

        //人才【我要報價】
        public OperationResult CreateQuotationCart(int memberID, QuotationCartViewModel newQ)
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
            catch (Exception ex)
            {
                result.IsSuccessful = false;
                result.Exception = ex;
            }
            return result;
        }

        //人才提案紀錄刪除 //取消提案
        public void DeleOfQTRecord(int? caseID, int memberID)
        {
            var QTRecordDB = _repo.GetAll<QuotationDetail>().FirstOrDefault(q => q.CaseID == caseID && q.ProposerID == memberID);
            _repo.Delete<QuotationDetail>(QTRecordDB);
            _repo.SaveChanges();
        }

        public string GetAllQuotationCart(int clientID)
        {
            //取得quotationCart
            List<QuotationDetail> quoCart = new List<QuotationDetail>();
            try
            {
                var myCase = _repo.GetAll<Case>().Where(x => x.MemberID == clientID).ToList();
                foreach (var item in myCase)
                {
                    var qd = _repo.GetAll<QuotationDetail>().Where(x => x.CaseID == item.CaseID && x.Status == null).ToList();
                    foreach (var j in qd)
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
                    //Status = (bool)item.Status
                });
            }
            return allInfoInQTR;
        }


        public string QdToOrder(int qdID)
        {
            var qdCart = _repo.GetAll<QuotationDetail>().FirstOrDefault(x => x.QuotaionDetailID == qdID);

            //加入order訂單
            var caseInfo = _repo.GetAll<Case>().FirstOrDefault(x => x.CaseID == qdCart.CaseID);
            var clientInfo = _repo.GetAll<MemberInfo>().FirstOrDefault(x => x.MemberID == caseInfo.MemberID);
            var proposerInfo = _repo.GetAll<MemberInfo>().FirstOrDefault(x => x.MemberID == qdCart.ProposerID);
            
            //PaymentCode 
            string paymentRandomCode = Guid.NewGuid().ToString("N").Substring(5, 10);
            Order newOrder = new Order()
            {
                ProposerID = qdCart.ProposerID,
                OrderStatus = 0,
                DepositStatus = 0,
                Price = qdCart.ProposePrice,
                DealedDate = DateTime.UtcNow.AddHours(8),
                ClientID = caseInfo.MemberID,
                QuotationImg = "https://res.cloudinary.com/dwwmf9pyq/image/upload/v1631091232/ulqkhpiwu78f5afwruji.jpg",
                Email = clientInfo.Email,
                PredictDays = qdCart.PredictDays,
                Unit = 0,
                Count = 1,
                PaymentCode = paymentRandomCode,
                Memo = qdCart.ProposeDescription,
                CaseID = qdCart.CaseID,
                Title = caseInfo.CaseTitle,
                ProposerEmail = proposerInfo.Email,
                CloseReason = qdCart.QuotaionDetailID.ToString()
            };
            //案主接案名稱 Order Name
            newOrder.Name = clientInfo.NickName == null ? "無接案名稱" : clientInfo.NickName;
            //人才接案名稱 Order StudioName
            newOrder.StudioName = proposerInfo.NickName == null ? "無接案名稱" : proposerInfo.NickName;
            //案主電話
            newOrder.Tel = clientInfo.Cellphone == null ? "無聯絡電話" : clientInfo.Cellphone;
            //人才電話 
            newOrder.ProposerPhone = proposerInfo.Cellphone == null ? "無聯絡電話" : proposerInfo.Cellphone;

            _repo.Create(newOrder);

            //QuotationDetail表格的Status改成true
            qdCart.Status = true;
            _repo.Update(qdCart);
            _repo.SaveChanges();

            return paymentRandomCode;
        }

        public void RefuseQd(int qdID)
        {
            var theQd = _repo.GetAll<QuotationDetail>().FirstOrDefault(x => x.QuotaionDetailID == qdID);
            theQd.Status = false;
            _repo.Update(theQd);
            _repo.SaveChanges();
        }

        public List<PaymentViewModel> GetOrderDetail(string paymentCode)
        {
            List<PaymentViewModel> result = new List<PaymentViewModel>();
            List<Order> theOrder = _repo.GetAll<Order>().Where(x => x.PaymentCode == paymentCode).ToList();
            foreach (var item in theOrder)
            {
                result.Add(new PaymentViewModel
                {
                    Name = $"【{item.StudioName}】的報價",
                    Price = Decimal.ToInt32((decimal)item.Price),
                    Quantity = (int)item.Count
                });
            }
            return result;
        }
        public List<PaymentViewModel> GetTheOrderToPay(string paymentCode)
        {
            var theOrder = _repo.GetAll<Order>().Where(x => x.PaymentCode == paymentCode).ToList();
            List<PaymentViewModel> pays = new List<PaymentViewModel>();
            foreach (var item in theOrder)
            {
                pays.Add(new PaymentViewModel
                {
                    Name = $"【{item.StudioName}】的報價",
                    Price = Decimal.ToInt32((decimal)item.Price),
                    Quantity = 1,
                });
            }

            return pays;
        }
        public void PaymentSucceed(string paymentCode)
        {
            var payedOrder = _repo.GetAll<Order>().Where(x => x.PaymentCode == paymentCode).ToList();
            foreach (var item in payedOrder)
            {
                item.OrderStatus = 1;
                item.DealedDate = DateTime.UtcNow.AddHours(8);
                _repo.Update(item);
                _repo.SaveChanges();

            };
        }

        public bool IsAddQdCart(int userID, int caseID)
        {
            var InQdCart = _repo.GetAll<QuotationDetail>().Where(x => x.ProposerID == userID && x.CaseID == caseID).ToList();
            if(InQdCart.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}