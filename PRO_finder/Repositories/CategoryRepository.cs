using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PRO_finder.Models;
using PRO_finder.Models.DBModel;

namespace PRO_finder.Repositories
{
    public class CategoryRepository
    {
        private readonly ProFinderContext _ctx;

        public CategoryRepository()
        {
            _ctx = new ProFinderContext();
        }

        public List<Category> ReadCategory()
        {
            var Categories = _ctx.Category.ToList();
      

            return Categories;
        }





    }
}