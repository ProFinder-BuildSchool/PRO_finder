using PRO_finder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PRO_finder.Models.DBModel;


namespace PRO_finder.ViewModels
{
    public class CategoryViewModel
    {
        //public List<Cate> Categories { get; set; }
        public List<Icon> Icon { get; set; }

        public List<Models.DBModel.SubCategory> SubCategories { get; set; }

        public int ID { get; set; }
        public string CategoryName { get; set; }

        public int CategoryID;

        public string JsonSubCategoryList;
        public List<SubCateData> SubCateData { get; set; }
        public int TalentCounts { get; set; }
    }

    public class SubCateData
    {
        public int SubCateID { get; set; }
        public string SubCateName { get; set; }
    }

    public class Icon 
    {
        public string Info { get; set; }

        public string Categoryname { get; set; }
    }




}