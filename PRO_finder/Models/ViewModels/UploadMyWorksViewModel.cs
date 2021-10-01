using PRO_finder.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRO_finder.Models.ViewModels
{
    [Serializable]
    public class UploadMyWorksViewModel
    {
        public int MemberID { get; set; }
        public int WorkID { get; set; }
        public string WorkName { get; set; }

        [AllowHtml]
        public string WorkDescription { get; set; }
        public string Client { get; set; }
        public string Role { get; set; }
        public int YearStarted { get; set; }
        public string WebsiteURL { get; set; }
        public int SubCategoryID { get; set; }

        public List<WorkAttachmentViewModel> WorkAttachmentList { get; set; }
        public List<WorkPicturesViewModel> WorkPictureList { get; set; }

    }
}