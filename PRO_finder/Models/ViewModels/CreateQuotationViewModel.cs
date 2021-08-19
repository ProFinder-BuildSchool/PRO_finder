using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PRO_finder.Models.DBModel;


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

        public TimeSpan UpdateDate { get; set; }

        [Required]
        [StringLength(30)]
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
        public string Description { get; set; }

        public int? OtherPictureID { get; set; }

        public decimal? Evaluation { get; set; }

        [Display(Name = "服務類別")]
        public int SubCategoryID { get; set; }

        public int LocationID { get; set; }

        

        
        public int WorkID { get; set; }

        [Required]
        [StringLength(10)]
        public string WorkName { get; set; }

        [Required]
        public string WorkDescription { get; set; }

        [Required]
        [StringLength(10)]
        public string Client { get; set; }

        [Required]
        [StringLength(10)]
        public string Role { get; set; }

        public int YearStarted { get; set; }

        public string WebsiteURLID { get; set; }

        
        public int? WorkAttachmentID { get; set; }


        [StringLength(50)]
        public string WorkAttachmentName { get; set; }

        public string WorkAttachmentLink { get; set; }

    }
}