using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Models.ViewModels
{
    public class StudioworksViewModel
    {
        public int WorkID { get; set; }
        public string WorkName { get; set; }
        public string WebsiteURL { get; set; }
        public string WorkSubCategory { get; set; }
        public int SubCategoryID { get; set; }
        public int WorkAttachmentID { get; set; }
        public int WorkPictureID { get; set; }
        public int SortNumber { get; set; }
        public string WorkPicture { get; set; }
    }
}