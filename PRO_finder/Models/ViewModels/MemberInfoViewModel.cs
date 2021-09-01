using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PRO_finder.Models.DBModel;

namespace PRO_finder.Models.ViewModels
{

    public class MemberInfoViewModel
    {

        public int MemberID { get; set; }

        public string Cellphone { get; set; }

        public string Email { get; set; }

        public DateTime? LogInTime { get; set; }

        public string Password { get; set; }

        public byte[] RegistedTime { get; set; }

        public TimeSpan? EditedTime { get; set; }

        public bool? isDeleted { get; set; }

        public TimeSpan? CreateUser { get; set; }

        public TimeSpan? UpdateUser { get; set; }

        public decimal? Balance { get; set; }

        public byte[] ProfilePicture { get; set; }

        public bool? Status { get; set; }

        public string NickName { get; set; }

        public enum IdentityStatus
        {
            個人兼職, 專職SOHO, 工作室, 兼職上班族, 公司, 學生
        }
        public IdentityStatus Identity { get; set; }

        public int? LiveCity { get; set; }

        public int? TalentCategoryID { get; set; }

        public enum LocationCity
        {
            宜蘭縣, 基隆市, 臺北市, 新北市, 桃園市, 新竹市, 新竹縣,
            台中市, 苗栗縣, 彰化縣, 雲林縣, 南投縣, 嘉義市, 嘉義縣, 台南市, 高雄市,
            屏東縣, 澎湖縣, 台東縣, 花蓮縣, 其他離島
        }
        public LocationCity LocationID { get; set; }
        public int LocationIDInt { get; set; }

        public int? CategoryID { get; set; }

        public int? SubCategoryID { get; set; }

        public string AllPieceworkExp { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        public string UserId { get; set; }
        public string JsonToolList { get; set; }
        public string JsonExDList { get; set; }
        public List<ExperienceSelectItemViewModel> Experiences { get; set; }
        
    }
    public class ExperienceSelectItemViewModel
    {
        public int MemberID { get; set; }
        public List<SelectListItem> SubCategoryDropdown { get; set; }
        public List<SelectListItem> CategoryDropdown { get; set; }
        public List<SelectListItem> PieceworkDropdown { get; set; }
    }
    public class ExperienceViewModel
    {
        public int MemberID { get; set; }
        public int SubCategoryID { get; set; }
        public string PieceworkExp { get; set; }
        public int CategoryID { get; set; }
    }
}
