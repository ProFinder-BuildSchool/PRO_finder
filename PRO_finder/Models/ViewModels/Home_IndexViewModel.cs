using PRO_finder.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Models.ViewModels
{
    public class Home_IndexViewModel
    {
        public List<Icon> Icon { get; set; }
        public List<CategoryViewModel> Categories { get; set; }

 

        public List<CaseViewModel>Cases { get; set; }



    }

   
}