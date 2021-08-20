using PRO_finder.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PRO_finder.Models.ViewModels;
using System.Globalization;

namespace PRO_finder.Repositories
{
    public class QuotationRepository
    {
        private readonly ProFinderContext _ctx;
        public QuotationRepository()
        {
            _ctx = new ProFinderContext();
        }


        //public IEnumerable<QuotationViewModel> ReadQuotationData()
        //{
        //    var quotationList = (from q in _ctx.Quotation
        //                         join o in _ctx.OtherPicture on q.OtherPictureID equals o.OtherPictureID
        //                         join s in _ctx.SubCategory on q.SubCategoryID equals s.SubCategoryID
        //                         join m in _ctx.MemberInfo on q.MemberID equals m.MemberID
        //                         //join l in _ctx.Locations on q.LocationID equals l.LocationID
        //                         select new QuotationViewModel
        //                         {
        //                             Id = q.QuotationID,
        //                             CategoryName = s.SubCategoryName,
        //                             Price = (q.Price).ToString(),
        //                             Unit = q.QuotationUnit,
        //                             StudioName = m.NickName,
        //                             Img = o.MainPicture,
        //                             CategoryId = s.CategoryID,
        //                             SubcategoryId = s.SubCategoryID,
        //                             SubcategoryName = s.SubCategoryName

        //                         }
        //                         );

        //    return quotationList;
        //}

        //public List<SubCategory> ReadSubCateData()
        //{
        //    List<SubCategory> subCateList = _ctx.SubCategory.ToList();

        //    return subCateList;
        //}
    }
}