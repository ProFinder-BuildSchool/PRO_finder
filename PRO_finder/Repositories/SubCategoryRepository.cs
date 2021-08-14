using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PRO_finder.Models;
using PRO_finder.Models.DBModel;

namespace PRO_finder.Repositories
{
    public class SubCategoryRepository
    {
        private readonly ProFinderContext _ctx;

        public SubCategoryRepository()
        {
            _ctx = new ProFinderContext();
        }

        public List<SubCategory> ReadSubCategory()
        {
            List<SubCategory> SubCategories = _ctx.SubCategory.ToList();

            return SubCategories;
        }

    }
}