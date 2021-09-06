using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Models.ViewModels
{
    public class WorkDetailViewModel
    {
        public int WorkID { get; set; }

        public string WorkName { get; set; }

        public string WorkDescription { get; set; }

        public string Client { get; set; }

        public string Role { get; set; }

        public int YearStarted { get; set; }

        public string WebsiteURL { get; set; }

        public int SubCategoryID { get; set; }

        public IEnumerable<WorkPicturesViewModel> WorkPicture { get; set; }


        //工作室
        public int MemberID { get; set; }

        public string ProfilePicture { get; set; }
        public string NickName { get; set; }
        public int TalentCategoryID { get; set; }

        public int? Identity { get; set; }

        public enum IdentityStatus
        {
            個人兼職, 專職SOHO, 工作室, 兼職上班族, 公司, 學生
        }

    }
}