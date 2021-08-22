﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Models.ViewModels
{
    public class StudioViewModel
    {
        public int MemberID { get; set; }
        public byte[] ProfilePicture { get; set; }
        public DateTime? LogInTime { get; set; }
        public string NickName { get; set; }
        public string ExpertSubCategory { get; set; }
        public int? Identity { get; set; }
        public string Description { get; set; }
        public string LocationName { get; set; }
        public int WorkID { get; set; }
        public string WorkName { get; set; }
        public string WebsiteURL { get; set; }
        public int WorkSubCategoryID { get; set; }
        public int WorkAttachmentID { get; set; }
        public int WorkPictureID { get; set; }
        public int SortNumber { get; set; }
        public string WorkPicture { get; set; }
        public int QuotationId { get; set; }
        public int? QuotationCategoryId { get; set; }
        public int QuotationSubcategoryId { get; set; }
        public string SubcategoryName { get; set; }
        public string CategoryName { get; set; }
        public decimal? Price { get; set; }
        public int Unit { get; set; }
        public string QuotationImg { get; set; }

    

        public int DealedTalentMemberID { get; set; }

        public decimal CaseReview { get; set; }

        public string CaseMessage { get; set; }

        public string CaseReplyMessage { get; set; }




    }
}