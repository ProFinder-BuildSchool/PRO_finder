using System;
using System.Collections.Generic;

#nullable disable

namespace Background_ProFinder.Models.DBModel
{
    public partial class Banner
    {
        public int BannerId { get; set; }
        public string BannerTitle { get; set; }
        public string BannerImgUrl { get; set; }
    }
}
