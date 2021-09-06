﻿using PRO_finder.Models.DBModel;
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
            var Order = _repo.GetAll<Order>().First(x => x.OrderID == OrderID );
            Order.OrderStatus = 2;
            _repo.Update<Order>(Order);
            _repo.SaveChanges();



            return true;

        }

        public List<OrderViewModel> GetOrderList(int memberId)
        {
   

          
            List<OrderViewModel> OrderList = new List<OrderViewModel>();
            var OrderDB = _repo.GetAll<Order>().Where(x => x.ClientID == memberId && x.OrderStatus == 1).ToList();
            foreach (var item in OrderDB)
            {
                

                var ProposerID = item.ProposerID;
                var ProposerEmail = _repo.GetAll<MemberInfo>().First(x => x.MemberID == ProposerID).Email;
                var ProposerCellPhone = _repo.GetAll<MemberInfo>().First(x => x.MemberID == ProposerID).Cellphone;
                var ProposerQuotationTitle = _repo.GetAll<Quotation>().First(x => x.MemberID == (int)ProposerID).QuotationTitle;

                OrderList.Add(new OrderViewModel
                {

                    OrderID = item.OrderID,
                    ProposerID = (int)item.ProposerID,
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
                    ProposerEmail= ProposerEmail,
                    ProposerCellPhone= ProposerCellPhone

                });
            }

            return OrderList;
        }





        public bool AddOrder(OrderViewModel[] OrderVM)
        {
            var ClientCart = _repo.GetAll<ClientCart>();
            foreach (var item in OrderVM)
            {
                var  NewOrderId = _repo.GetAll<Order>().OrderBy(X => X.OrderID).ToList();
                var lastID = 1;
                foreach (var LAST in NewOrderId)
                {
                     lastID = LAST.OrderID;
                }


                var Order = new Order()
                {
                    OrderID = lastID+1,
                    OrderStatus = 1,
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
                    Memo = item.Memo
                    //TODO ContactTime 

                };
                _repo.Create<Order>(Order);
                var DelCart = ClientCart.First(x => x.CartID == item.CartID && x.ClientID == item.ClientID);
                _repo.Delete<ClientCart>(DelCart);
            }
            _repo.SaveChanges();
            return true;

        }

    }
}