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

        public List<SubCategory> subCategories { get; set; }

        public int ID { get; set; }
        public string CategoryName { get; set; }

        
    }

    public class Icon 
    {
        public string Info { get; set; }

        public string Categoryname { get; set; }
    }




}