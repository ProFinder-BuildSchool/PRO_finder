using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Models.ViewModels
{
    public class WorkViewModel
    {
        public string WorkID { get; set; }

        public string[] WorkPicture { get; set; }

        public SubCategoryViewModel SubCategories { get; set; }


        public string Info { get; set; }


        public string studio { get; set; }
    }

    public class SubCategoryName
    {
        public string Name { get; set; }
    }
}