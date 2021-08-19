﻿using PRO_finder.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Models.ViewModels
{

    public class QuotationViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }
        public string SubcategoryName { get; set; }
        public string CategoryName { get; set; }
        public string Price { get; set; }
        public int Unit { get; set; }
        public string StudioName { get; set; }
        public string Img { get; set; }

        
        public MemberInfoViewModel MemInfo { get; set; }

        public IEnumerable<OtherPictureViewModel> OtherPicture { get; set; }


    }
}