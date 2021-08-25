using PRO_finder.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRO_finder.Models.ViewModels
{
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

        public string WorkAttachmentList { get; set; }
        public string WorkPictureList { get; set; }

        public List<WorkAttachmentData> Attachments { get; set; }
    }

    public class WorkAttachmentData
    {
        public string WorkAttachmentName { get; set; }
        public string WorkAttachmentLink { get; set; }
    }
}