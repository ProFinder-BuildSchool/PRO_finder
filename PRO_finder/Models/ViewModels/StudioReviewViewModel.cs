using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Models.ViewModels
{
    public class StudioReviewViewModel
    {
        public int MemberID { get; set; }
        public byte[] ProfilePicture { get; set; }
        public string NickName { get; set; }
        public int DealedTalentMemberID { get; set; }

        public decimal CaseReview { get; set; }

        public string CaseMessage { get; set; }

        public string CaseReplyMessage { get; set; }
    }
}