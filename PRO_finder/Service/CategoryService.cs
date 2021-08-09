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
        
        public List<SelectListItem> getCategorySelectList()
        {
            using (ProFinderContext context = new ProFinderContext())
            {
                List<Category> categoriesList = context.Category.ToList();
                List<SelectListItem> SelectCategory = new List<SelectListItem>();
                SelectCategory.Add(new SelectListItem { Text = "---選擇服務類型---" });
                foreach (var item in categoriesList)
                {
                    SelectCategory.Add(new SelectListItem { Value = item.CategoryID.ToString(), Text = item.CategoryName });
                }

                return SelectCategory;
                
            }
        }
        
        
    }
}