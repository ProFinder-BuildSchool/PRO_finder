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

        public int GetMemberID(string userID)
        {
            var memberId = _repo.GetAll<MemberInfo>().FirstOrDefault(x => x.UserId == userID).MemberID;

            return memberId;
        }
        public bool DelCart(int Id, int cartId)
        {
            var CartDBList = _repo.GetAll<ClientCart>().FirstOrDefault(x => (int)x.MemberID == Id  && x.CartID == cartId);

            _repo.Delete<ClientCart>(CartDBList);
            _repo.SaveChanges();
            return true;

        }


        public List<ClientCartViewModel> GetCart(int memberId)
        {
         

            var CartDBList = _repo.GetAll<ClientCart>().Where(x => (int)x.MemberID == memberId);

            List<ClientCartViewModel> CartList = new List<ClientCartViewModel>();

            foreach (var item in CartDBList)
            {
                CartList.Add(new ClientCartViewModel
                {
                    CartID=item.CartID,
                    MemberID = (int)item.MemberID,
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

            
            var CartDBList = _repo.GetAll<ClientCart>().Where(x => (int)x.MemberID == Id).FirstOrDefault(y => y.CartID == VM.CartID);

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


    }
}