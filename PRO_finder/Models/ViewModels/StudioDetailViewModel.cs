using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Models.ViewModels
{
    public class StudioDetailViewModel
    {
        public int MemberID { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime? LogInTime { get; set; }
        public string NickName { get; set; }
        public string ExpertSubCategory { get; set; }
        
        public enum IdentityStatus
        {
            個人兼職, 專職SOHO, 工作室, 兼職上班族, 公司, 學生
        }
        public IdentityStatus Identity { get; set; }

        public string Description { get; set; }
        public string LocationName { get; set; }

        public IEnumerable<StudioQuotationViewModel> StudioQuotation { get; set; }
        public IEnumerable<StudioworksViewModel> Studioworks { get; set; }
        public IEnumerable<WorkSubcategoryViewModel> WorkSubcategory { get; set; }
        public IEnumerable<StudioReviewViewModel> StudioReview { get; set; }




        //收藏人才
        public int SavedTalentID { get; set; }

        public DateTime SavedDate { get; set; }

        public int SaveStaffID { get; set; }

    }
}