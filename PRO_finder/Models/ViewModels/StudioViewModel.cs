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
        public string NickName { get; set; }
        public int ExpertSubCategoryID { get; set; }
        public int Identity { get; set; }
        public string Description { get; set; }
        public int? LocationID { get; set; }
        public int WorkID { get; set; }
        public string WorkName { get; set; }
        public string WebsiteURL { get; set; }
        public int WorkSubCategoryID { get; set; }
        public int WorkAttachmentID { get; set; }
        public int WorkPictureID { get; set; }
        public int SortNumber { get; set; }
        public string WorkPicture { get; set; }
        public int QuotationId { get; set; }
        public int QuotationCategoryId { get; set; }
        public int QuotationSubcategoryId { get; set; }
        public string SubcategoryName { get; set; }
        public string CategoryName { get; set; }
        public string Price { get; set; }
        public int Unit { get; set; }
        public string QuotationImg { get; set; }

        public int DealedTalentMemberID { get; set; }

        public decimal CaseReview { get; set; }

        public string CaseMessage { get; set; }

        public string CaseReplyMessage { get; set; }




    }
}