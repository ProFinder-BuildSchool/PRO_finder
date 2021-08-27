using PRO_finder.Models.DBModel;
using PRO_finder.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRO_finder.Models.ViewModels
{

    public class QuotationViewModel
    {
        public int QuotationId { get; set; } //QuotationId
        public int Id { get; set; } 
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }
        public string SubcategoryName { get; set; }
        public string CategoryName { get; set; }
        public string Price { get; set; }
        public int Unit { get; set; }
        public string StudioName { get; set; }
        public string Img { get; set; }
        public string Location { get; set; }

        //報價細節
        public int MemberID { get; set; }
        
    }
}

public class QuotationDetailViewModel
{
    public int QuotationId { get; set; } 
    public int CategoryId { get; set; }
    public int SubcategoryId { get; set; }
    public string SubcategoryName { get; set; }
    public string CategoryName { get; set; }
    public string Price { get; set; }

    public enum UnitEnum
    {
        件,張,頁,份,字,個,天,時,坪,才,秒,月,則,幅
    }
    public UnitEnum Unit { get; set; }

    //public string StudioName { get; set; }
    public string MainPicture { get; set; }

    public int MemberID { get; set; }
    public string NickName { get; set; }

    public string LogInTime { get; set; }

    public enum IdentityStatus
    {
        個人兼職, 專職SOHO, 工作室, 兼職上班族, 公司, 學生
    }
    public IdentityStatus Identity { get; set; }
    public enum LocationCity
    {
        宜蘭縣, 基隆市, 臺北市, 新北市, 桃園市, 新竹市, 新竹縣,
        台中市, 苗栗縣, 彰化縣, 雲林縣, 南投縣, 嘉義市, 嘉義縣, 台南市, 高雄市,
        屏東縣, 澎湖縣, 台東縣, 花蓮縣, 其他離島
    }
    public LocationCity Location { get; set; }

    public string QuotationTitle { get; set; }

    public IEnumerable<OtherPictureViewModel> OtherPicture { get; set; }
    public string UpdateDate { get; set; }
    public int ExecuteDate { get; set; }

    public string Description { get; set; }
    public decimal Evaluation { get; set; }

    public IEnumerable<QuotationReview> QuotationReview { get; set; }

}

public class QuotationReview
    {
        public string ReviewName { get; set; }
        public string SubmitDate { get; set; }
        public decimal CaseReview { get; set; }
        public string CaseMessage { get; set; }

    }
