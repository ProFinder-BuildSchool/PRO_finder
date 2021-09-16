using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PRO_finder.Models.DBModel;
using PRO_finder.ViewModels;
using PRO_finder.Repositories;
using PRO_finder.Models.ViewModels;
using Newtonsoft.Json;

namespace PRO_finder.Service
{
    public class CategoryService
    {
        private readonly GeneralRepository _repo;
        public CategoryService()
        {
            _repo = new GeneralRepository(new ProFinderContext());
        }

        public List<SelectListItem> GetCategorySelectList()
        {
            
                List<Category> categoriesList = _repo.GetAll<Category>().ToList();
                List<SelectListItem> selectCategory = new List<SelectListItem>();
                selectCategory.Add(new SelectListItem { Text = "選擇主類型" , Value = "-1"});
                foreach (var item in categoriesList)
                {
                    selectCategory.Add(new SelectListItem { Value = item.CategoryID.ToString(), Text = item.CategoryName });
                }

                return selectCategory;

        }



        public List<CategoryViewModel> Home_Index_GetCategoryItem()
        {
            var repository = new GeneralRepository(new ProFinderContext());

            var categoriesList = repository.GetAll<Category>().ToList();

            var SubcategoriesList = repository.GetAll<SubCategory>().ToList();


            List<CategoryViewModel> CategoryViewModel = new List<CategoryViewModel>();





            List<Icon> Iconlist = new List<Icon>()
            {
                 new Icon{ Categoryname="平面設計" , Info="fas fa-pencil-ruler"},
                 new Icon{ Categoryname="網頁設計" , Info="far fa-window-restore"},
                 new Icon{ Categoryname="程式開發" , Info="fas fa-code"},
                 new Icon{ Categoryname="翻譯寫作" , Info="far fa-file-alt"},
                 new Icon{ Categoryname="商攝娛樂" , Info="fas fa-camera-retro"},
                 new Icon{ Categoryname="影像製作" , Info="fas fa-photo-video"},
                 new Icon{ Categoryname="空間設計" , Info="fas fa-ruler-combined"},
                 new Icon{ Categoryname="生活服務" , Info="far fa-heart"},
                 new Icon{ Categoryname="活動企劃" , Info="far fa-newspaper"},
                 new Icon{ Categoryname="專業顧問" , Info="fas fa-pencil-ruler"},
                 new Icon{ Categoryname="資訊工程" , Info="fas fa-cogs"},
            };

            foreach (var x in categoriesList)
            {
                CategoryViewModel.Add(new CategoryViewModel
                {
                    Icon = Iconlist.Where(c => c.Categoryname == x.CategoryName.Replace(" ", "")).ToList(),
                    ID = x.CategoryID,
                    CategoryName = x.CategoryName,
                    SubCategories = SubcategoriesList.Where(y => y.CategoryID == x.CategoryID).ToList()
                });
            }

            return CategoryViewModel;
        }

       

        public string GetAllCatAndSubCat()
        {
            var allCategory = _repo.GetAll<Category>();
            var allSubCategory = _repo.GetAll<SubCategory>();
            var all = new List<CategoryViewModel>();
            foreach (var item in allCategory)
            {
                var subList = new List<SubCateData>();
                foreach(var sub in allSubCategory)
                {
                    if(sub.CategoryID == item.CategoryID)
                    {
                        subList.Add(new SubCateData { SubCateID = sub.SubCategoryID, SubCateName = sub.SubCategoryName});
                    }
                }
                all.Add(new CategoryViewModel { CategoryID = item.CategoryID, JsonSubCategoryList = JsonConvert.SerializeObject(subList) });
            }
            return JsonConvert.SerializeObject(all);
            
        }





        public int GetCategoryID(string categoryName)
        {
            int result = 0;
            try
            {

              result = _repo.GetAll<Category>().FirstOrDefault(x => x.CategoryName == categoryName).CategoryID;
               
            }
            catch
            {
                result = -1;
            }
            return result;
       
        }


    }
}