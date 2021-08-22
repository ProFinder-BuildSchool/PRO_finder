using PRO_finder.Models.DBModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PRO_finder.Model.ViewModels
{
    public class WorkPageViewModel
    {
        public int WorkID { get; set; }

        public string WorkName { get; set; }

        public string WorkDescription { get; set; }

        public string Client { get; set; }

        public string Role { get; set; }

        public int YearStarted { get; set; }

        public string WebsiteURL { get; set; }

        public int SubCategoryID { get; set; }

        public int WorkAttachmentID { get; set; }

        public int WorkPictureID { get; set; }

        public int SortNumber { get; set; }

        public string WorkPicture { get; set; }

        public int MemberID { get; set; }

        public byte[] ProfilePicture { get; set; }
        public string NickName { get; set; }
        public int TalentCategoryID { get; set; }

        public int Identity { get; set; }




    }
}