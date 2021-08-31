using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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


    }
}