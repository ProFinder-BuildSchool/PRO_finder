using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PRO_finder.Models.DBModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PRO_finder.ViewModels
{
    public class TalentIndexViewModel
    {

        public int MemberID { get; set; }

        [Required]
        [StringLength(50)]
        public string Cellphone { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Column(TypeName = "date")]
        public DateTime LogInTime { get; set; }

        [Required]
        public string Password { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RegistedTime { get; set; }

        public TimeSpan EditedTime { get; set; }

        public byte isDeleted { get; set; }

        public TimeSpan CreateUser { get; set; }

        public TimeSpan UpdateUser { get; set; }

        [Column(TypeName = "money")]
        public decimal Balance { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] ProfilePicture { get; set; }

        public byte Status { get; set; }

        [Required]
        [StringLength(50)]
        public string NickName { get; set; }

        public int Identity { get; set; }

        public int LiveCity { get; set; }

        public int TalentCategoryID { get; set; }

        public int LocationID { get; set; }

        public int CategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string AllPieceworkExp { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public DateTime SentTime { get; set; }

        [Required]
        [StringLength(50)]
        public string EmailTitle { get; set; }

        public string Content { get; set; }

        public List<string> ContentList { get; set; }
    }
}