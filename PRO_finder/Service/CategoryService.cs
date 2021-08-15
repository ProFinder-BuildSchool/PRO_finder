using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PRO_finder.Models.DBModel;
using PRO_finder.ViewModels;

namespace PRO_finder.Service
{
    public class CategoryService
    {
        
        public List<SelectListItem> GetCategorySelectList()
        {
            using (ProFinderContext context = new ProFinderContext())
            {
                List<Category> categoriesList = context.Category.ToList();
                List<SelectListItem> selectCategory = new List<SelectListItem>();
                selectCategory.Add(new SelectListItem { Text = "選擇服務類型" });
                foreach (var item in categoriesList)
                {
                    selectCategory.Add(new SelectListItem { Value = item.CategoryID.ToString(), Text = item.CategoryName });
                }

                return selectCategory;
                
            }
        }
        
        
    }
}