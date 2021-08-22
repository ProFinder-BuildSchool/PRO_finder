using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PRO_finder.Models;
using PRO_finder.Models.DBModel;
using PRO_finder.Models.ViewModels;

namespace PRO_finder.Repositories
{
    public class CaseRepository
    {
        private readonly ProFinderContext _ctx;

        public CaseRepository()
        {
            _ctx = new ProFinderContext();
        }

        //public IEnumerable<CaseViewModel> ReadCase()
        //{
        //    var casesList = (from c in _ctx.Case
        //                     join m in _ctx.MemberInfo on c.MemberID equals m.MemberID
        //                     join s in _ctx.SubCategory on c.SubCategoryID equals s.SubCategoryID
        //                     join l in _ctx.Locations on c.Location equals l.LocationID
        //                     select new CaseViewModel
        //                     {
        //                         title = c.CaseTitle,
        //                         Price = (int)c.Price,
        //                         LocationID = (int)c.Location,
        //                         LocationName = l.LocationName,
        //                         SubCategoryID = s.SubCategoryID,
        //                         Description = c.Description,
        //                         UpdateDate = (DateTime)c.UpdateDate,

        //                         SubCategoryName = s.SubCategoryName,
        //                     });


        //    return casesList;
        //}





    }
}