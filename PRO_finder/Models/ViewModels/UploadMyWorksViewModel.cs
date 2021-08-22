using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Models.ViewModels
{
    public class UploadMyWorksViewModel
    {
        public int MemberID { get; set; }
        public int WorkID { get; set; }
        public string WorkName { get; set; }
        public string WorkDescription { get; set; }
        public string Client { get; set; }
        public string Role { get; set; }
        public int YearStarted { get; set; }
        public string WebsiteURL { get; set; }
        public int SubCategoryID { get; set; }

        public string WorkAttachmentList { get; set; }
        public string WorkPictureList { get; set; }

    }
}