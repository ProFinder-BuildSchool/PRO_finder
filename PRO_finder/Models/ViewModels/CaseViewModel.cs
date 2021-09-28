using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PRO_finder.Models.ViewModels
{
    public class CaseViewModel
    {
        public int CaseId { get; set; }
        public string title { get; set; }

       
        public int Price { get; set; }

        public int CaseStatus { get; set; }

        public int LocationID{ get; set; }

        public string LocationName { get;  set; }

        public int SubCategoryID { get; set; }

        public string Description { get; set; }

        public DateTime UpdateDate { get; set; }

        public int SortNum { get; set; }

        public string SubCategoryName { get; set; }

        public string DiffDateTime { get; set; }

        public int CategoryID { get; set; }


        public string PriceToString { get; set; }

        

    }


 











}