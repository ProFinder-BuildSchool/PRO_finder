using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PRO_finder.Models.DBModel;
using PRO_finder.Models.ViewModel;

namespace PRO_finder.ViewModels
{
    public class CreateQuotationViewModel
    {
        [Key]
        public int QuotationID { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "服務名稱")]
        public string QuotationTitle { get; set; }

        public DateTime UpdateDate { get; set; }

        [Required]
        [Display(Name = "服務訂價")]
        public decimal Price { get; set; }

        public enum UnitEnum
        {
            件, 張, 頁, 份, 字, 個, 天, 時, 坪, 才, 秒, 月, 則, 幅
        }

        public UnitEnum QuotationUnit { get; set; }

        [Display(Name = "製作天數")]
        public int ExecuteDate { get; set; }

        public int MemberID { get; set; }

        [Required]
        [Display(Name = "服務内容")]
        [AllowHtml]
        public string Description { get; set; }

        [Display(Name = "服務類別")]
        public int SubCategoryID { get; set; }

        public string MainPicture { get; set; }

        public string OtherPictureList { get; set; }
        public List<OtherPictureViewModel> OtherPicList {get;set;}

        public int CategoryID { get; set; }
    }
    
}