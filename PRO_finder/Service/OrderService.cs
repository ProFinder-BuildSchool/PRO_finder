using PRO_finder.Models.DBModel;
using PRO_finder.Models.ViewModels;
using PRO_finder.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static PRO_finder.Enum.Enum;

namespace PRO_finder.Service
{
    public class OrderService
    {
        private readonly GeneralRepository _repo;
        public OrderService()
        {
            _repo = new GeneralRepository(new ProFinderContext());
        }

        public bool UpdateOrderMemo(int Orderid, OrderViewModel data)
        {

            _repo.GetAll<Order>().First(x => x.OrderID == Orderid).Memo = data.Memo;
            _repo.SaveChanges();

            return true;
        }

        public bool UpdateOrderStatus(int Orderid, OrderViewModel OrderStatusNumber)
        {

            _repo.GetAll<Order>().First(x => x.OrderID == Orderid).OrderStatus = OrderStatusNumber.OrderStatusNumber;
            _repo.GetAll<Order>().First(x => x.OrderID == Orderid).OrderType = 0;
            _repo.SaveChanges();

            return true;
        }

        public bool AddFinishedDate(int Orderid, OrderViewModel CompleteDate) 
        {
            var completeDate = DateTime.UtcNow.AddHours(8);
            _repo.GetAll<Order>().First(x => x.OrderID == Orderid).CompleteDate = completeDate;
            _repo.GetAll<Order>().First(x => x.OrderID == Orderid).OrderType = 1;
            _repo.SaveChanges();

            return true;
        }

        public bool UpdateOrderUnreadNumber(int Memberid,int status)
        {

            var order = _repo.GetAll<Order>().Where(x => x.ClientID == Memberid && x.OrderStatus == status && x.OrderType == 0).ToList();

            foreach (var item in order)
            {
                _repo.GetAll<Order>().First(x => x.OrderID == item.OrderID).OrderType = 1;
                _repo.Update(item);

            }

            _repo.SaveChanges();
            return true;
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

        public bool CancelOrder(int OrderID)
        {
            var Order = _repo.GetAll<Order>().First(x => x.OrderID == OrderID);
            Order.OrderStatus = 2;
            _repo.Update<Order>(Order);
            _repo.SaveChanges();



            return true;

        }

        public List<OrderViewModel> GetOrderList(int memberId, int status)
        {
            List<Order> OrderDB;
            if (status != 3)
            {
                OrderDB = _repo.GetAll<Order>().Where(x => x.ClientID == memberId && x.OrderStatus == status).ToList();
            }
            else
            {
                OrderDB = _repo.GetAll<Order>().Where(x => x.ClientID == memberId && x.OrderStatus == status || x.ClientID == memberId && x.OrderStatus == 4).ToList();
            }



            List<OrderViewModel> OrderList = new List<OrderViewModel>();

            foreach (var item in OrderDB)
            {
                if(item.CaseID == null)
                {
                    var QuotationID = item.QuotationID;
                    var ProposerID = item.ProposerID;
                    var ProposerEmail = _repo.GetAll<MemberInfo>().First(x => x.MemberID == ProposerID).Email;
                    var ProposerCellPhone = _repo.GetAll<MemberInfo>().First(x => x.MemberID == ProposerID).Cellphone;
                    var ProposerQuotationTitle = _repo.GetAll<Quotation>().First(x => x.QuotationID == (int)QuotationID).QuotationTitle;
                    var ProposerExecuteDate = _repo.GetAll<Quotation>().First(x => x.MemberID == (int)ProposerID).ExecuteDate;
                    OrderList.Add(new OrderViewModel
                    {
                        OrderID = item.OrderID,
                        ProposerID = (int)item.ProposerID,
                        OrderSetupDay = ((DateTime)item.DealedDate).ToString("yyyy-MM-dd"),
                        PredictDays = CalcLastDate(item.DealedDate, ProposerExecuteDate * (int)item.Count),
                        Schedule = GetSchedule(item.DealedDate, ProposerExecuteDate * (int)item.Count),
                        Remaindays = GetRemaindays(item.DealedDate, ProposerExecuteDate * (int)item.Count),
                        ClientID = (int)item.ClientID,
                        QuotationImg = item.QuotationImg,
                        StudioName = item.StudioName,
                        Count = (int)item.Count,
                        Price = (decimal)item.Price,
                        Unit = System.Enum.GetName(typeof(UnitEnum), item.Unit),
                        Email = item.Email,
                        Name = item.Name,
                        Tel = item.Tel,
                        LineID = item.LineID,
                        Memo = item.Memo,
                        OrderStatus = System.Enum.GetName(typeof(OrderStatus), item.OrderStatus),
                        ProposerQuotationTitle = ProposerQuotationTitle,
                        ProposerEmail = ProposerEmail,
                        ProposerCellPhone = ProposerCellPhone,
                        OrderStatusNumber = (int)item.OrderStatus,
                        PaymentCode = item.PaymentCode,
                        QuotationID = (int)item.QuotationID,
                        OrderFinshedDay = ((DateTime)item.CompleteDate).ToString("yyyy-MM-dd")
                    });
                }
                else
                {
                    var ProposerID = item.ProposerID;
                    var ProposerEmail = _repo.GetAll<MemberInfo>().First(x => x.MemberID == ProposerID).Email;
                    var ProposerCellPhone = _repo.GetAll<MemberInfo>().First(x => x.MemberID == ProposerID).Cellphone;

                    OrderList.Add(new OrderViewModel
                    {
                        OrderID = item.OrderID,
                        ProposerID = (int)item.ProposerID,
                        OrderSetupDay = ((DateTime)item.DealedDate).ToString("yyyy-MM-dd"),
                        PredictDays = CalcLastDate(item.DealedDate, (int)(item.PredictDays * (int)item.Count)),
                        Schedule = GetSchedule(item.DealedDate, (int)(item.PredictDays * (int)item.Count)),
                        Remaindays = GetRemaindays(item.DealedDate, (int)(item.PredictDays * (int)item.Count)),
                        ClientID = (int)item.ClientID,
                        QuotationImg = item.QuotationImg,
                        StudioName = item.StudioName,
                        Count = (int)item.Count,
                        Price = item.Price,
                        Unit = System.Enum.GetName(typeof(UnitEnum), item.Unit),
                        Email = item.Email,
                        Name = item.Name,
                        Tel = item.Tel,
                        LineID = item.LineID,
                        Memo = item.Memo,
                        OrderStatus = System.Enum.GetName(typeof(OrderStatus), item.OrderStatus),
                        Title = item.Title,
                        ProposerEmail = ProposerEmail,
                        ProposerCellPhone = ProposerCellPhone,
                        OrderStatusNumber = (int)item.OrderStatus,
                        CaseID = (int)item.CaseID,
                        OrderFinshedDay = ((DateTime)item.CompleteDate).ToString("yyyy-MM-dd")

                    });
                }
                
            }
            return OrderList;
        }

        public List<OrderViewModel> TalentGetOrderList(int memberId,int status)
        {
            List<Order> OrderDB = new List<Order>();

            
            if (status == 9)
            {
                OrderDB = _repo.GetAll<Order>().Where(x => (x.ProposerID == memberId && x.OrderStatus == 1)|| (x.ProposerID == memberId && x.OrderStatus == 2) ).ToList();

            }
            else if (status == 3)
            {
                OrderDB = _repo.GetAll<Order>().Where(x => x.ProposerID == memberId && x.OrderStatus == 3 ).ToList();
            }

            List<OrderViewModel> OrderList = new List<OrderViewModel>();

            foreach (var item in OrderDB)
            {
                if (item.CaseID != null)
                {
                    OrderList.Add(new OrderViewModel
                    {
                        OrderID = item.OrderID,
                        ProposerID = memberId,
                        OrderSetupDay = ((DateTime)item.DealedDate).ToString("yyyy-MM-dd"),
                        PredictDays = CalcLastDate(item.DealedDate, (int)(item.PredictDays * (int)item.Count)),
                        Schedule = GetSchedule(item.DealedDate, (int)(item.PredictDays * (int)item.Count)),
                        Remaindays = GetRemaindays(item.DealedDate, (int)(item.PredictDays * (int)item.Count)),
                        ClientID = (int)item.ClientID,
                        QuotationImg = item.QuotationImg,
                        StudioName = item.StudioName,
                        Count = (int)item.Count,
                        Price = item.Price,
                        Unit = System.Enum.GetName(typeof(UnitEnum), item.Unit),
                        Email = item.Email,
                        Name = item.Name,
                        Tel = item.Tel,
                        LineID = item.LineID,
                        Memo = item.Memo,
                        OrderStatus = System.Enum.GetName(typeof(OrderStatus), item.OrderStatus),
                        Title = item.Title,
                        ProposerEmail = item.ProposerEmail,
                        ProposerCellPhone = item.ProposerPhone,
                        OrderStatusNumber = (int)item.OrderStatus,
                        CaseID = (int)item.CaseID,
                        OrderFinshedDay = ((DateTime)item.CompleteDate).ToString("yyyy-MM-dd")


                    });
                }
                else
                {
                    var QuotationID = item.QuotationID;
                    var ProposerEmail = _repo.GetAll<MemberInfo>().First(x => x.MemberID == memberId).Email;
                    var ProposerCellPhone = _repo.GetAll<MemberInfo>().First(x => x.MemberID == memberId).Cellphone;
                    var ProposerQuotationTitle = _repo.GetAll<Quotation>().First(x => x.QuotationID == (int)QuotationID).QuotationTitle;
                    var ProposerExecuteDate = _repo.GetAll<Quotation>().First(x => x.MemberID == (int)memberId).ExecuteDate;
                    OrderList.Add(new OrderViewModel
                    {
                        OrderID = item.OrderID,
                        ProposerID = memberId,
                        OrderSetupDay = ((DateTime)item.DealedDate).ToString("yyyy-MM-dd"),
                        PredictDays = CalcLastDate(item.DealedDate, ProposerExecuteDate * (int)item.Count),
                        Schedule = GetSchedule(item.DealedDate, ProposerExecuteDate * (int)item.Count),
                        Remaindays = GetRemaindays(item.DealedDate, ProposerExecuteDate * (int)item.Count),
                        ClientID = (int)item.ClientID,
                        QuotationImg = item.QuotationImg,
                        StudioName = item.StudioName,
                        Count = (int)item.Count,
                        Price = (decimal)item.Price,
                        Unit = System.Enum.GetName(typeof(UnitEnum), item.Unit),
                        Email = item.Email,
                        Name = item.Name,
                        Tel = item.Tel,
                        LineID = item.LineID,
                        Memo = item.Memo,
                        OrderStatus = System.Enum.GetName(typeof(OrderStatus), item.OrderStatus),
                        ProposerQuotationTitle = ProposerQuotationTitle,
                        ProposerEmail = ProposerEmail,
                        ProposerCellPhone = ProposerCellPhone,
                        OrderStatusNumber = (int)item.OrderStatus,
                        PaymentCode = item.PaymentCode,
                        QuotationID = (int)item.QuotationID,
                        OrderFinshedDay = ((DateTime)item.CompleteDate).ToString("yyyy-MM-dd")


                    });
                }
            }
            return OrderList;
        }

        public static string CalcLastDate(DateTime? dateTime,int days)
        {
            var one = (DateTime)dateTime;
            return (one.AddDays(days).Date).ToString("yyyy-MM-dd");
        }
        public static decimal GetSchedule(DateTime? dateTime, int days)
        {
            var temp = ((DateTime)dateTime).AddDays(days);
            return (temp - DateTime.UtcNow).Days * 100 / days;
        }
        public static int GetRemaindays(DateTime? dateTime, int days)
        {
            var temp = ((DateTime)dateTime).AddDays(days);
            return (temp - DateTime.UtcNow).Days;
        }



        public string AddOrder(OrderViewModel[] OrderVM)
        {
            //PaymentCode
            string paymentRandomCode = Guid.NewGuid().ToString("N").Substring(5, 10);

            var ClientCart = _repo.GetAll<ClientCart>();
            foreach (var item in OrderVM)
            {

                var Order = new Order()
                {
                    DealedDate = DateTime.UtcNow.AddHours(8),
                    OrderStatus = 0,
                    DepositStatus = 1,
                    ProposerID = item.ProposerID,
                    ClientID = item.ClientID,
                    QuotationImg = item.QuotationImg,
                    StudioName = item.StudioName,
                    Count = item.Count,
                    Price = item.Price,
                    Unit = (int)System.Enum.Parse(typeof(UnitEnum), item.Unit),
                    Email = item.Email,
                    Name = item.Name,
                    Tel = item.Tel,
                    LineID = item.LineID,
                    Memo = item.Memo,
                    ContactTime = item.ContactTime,
                    QuotationID = item.QuotationID,
                    PaymentCode = paymentRandomCode,
                    OrderType = 0
                };
                _repo.Create<Order>(Order);
                var DelCart = ClientCart.First(x => x.CartID == item.CartID);
                _repo.Delete<ClientCart>(DelCart);
            }
            _repo.SaveChanges();
            return paymentRandomCode;

        }


        public string UpdateOrderPaymentCode(int OrderId)
        {
            //PaymentCode
            string paymentRandomCode = Guid.NewGuid().ToString("N").Substring(5, 10);
            _repo.GetAll<Order>().First(x => x.OrderID == OrderId).PaymentCode = paymentRandomCode;
            _repo.SaveChanges();

            return paymentRandomCode;
        }

        public bool DelCart(int MemberId, int OrderId)
        {
            var OrderDBList = _repo.GetAll<Order>().FirstOrDefault(x => (int)x.OrderID == OrderId && x.ClientID == MemberId);
            _repo.Delete<Order>(OrderDBList);
            _repo.SaveChanges();
            return true;
        }

        public List<OrderUnreadCount> UnreadCount(int MemberId)
        {
            return _repo.GetAll<Order>().Where(g => g.ClientID == MemberId && g.OrderType == 0).GroupBy(x => x.OrderStatus).Select(y => new OrderUnreadCount { Status = (int)y.Key, Counts = y.Count() }).ToList();
        }

    }
}