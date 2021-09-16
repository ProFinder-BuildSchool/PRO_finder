using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PRO_finder.Models.DBModel;
using PRO_finder.ViewModels;
using PRO_finder.Repositories;
using PRO_finder.Models.ViewModels;
using Dapper;
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;

namespace PRO_finder.Service
{
    public class Home_IndexService
    {
        private GeneralRepository ctx_;

        public Home_IndexService()
        {
            ctx_ = new GeneralRepository(new ProFinderContext());
        }


        public Home_IndexViewModel Home_Index_GetALL()
        {
         

            var categoriesList = ctx_.GetAll<Category>().ToList();

            var SubcategoriesList = ctx_.GetAll<SubCategory>().ToList();


            Home_IndexViewModel Home_IndexViewModel = new Home_IndexViewModel();



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
                Home_IndexViewModel.Categories.Add(new CategoryViewModel
                {
                    Icon = Iconlist.Where(c => c.Categoryname == x.CategoryName.Replace(" ", "")).ToList(),
                    ID = x.CategoryID,
                    CategoryName = x.CategoryName,
                    SubCategories = SubcategoriesList.Where(y => y.CategoryID == x.CategoryID).ToList()
                });

                Home_IndexViewModel.Cases.Add(new CaseViewModel
                {
                    
                });



            }

            return Home_IndexViewModel;
        }

        public List<T> Test()
        {
            var TalentCount = (from q in ctx_.GetAll<Quotation>()
                               join s in ctx_.GetAll<SubCategory>() on q.SubCategoryID equals s.SubCategoryID
                               group q by s.CategoryID into g
                               select new T { category = g.Key, Count = g.Distinct().Count() }
                               ).ToList();

            return TalentCount;
        }
        
        public class T
        {
            public int Count { get; set; }
            public int category { get; set; }
        }






    }
}