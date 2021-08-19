using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PRO_finder.Models.DBModel;

namespace PRO_finder.Models.ViewModels
{

    [Table("MemberInfo")]
    public class MemberInfoViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MemberInfoViewModel()
        {
            Case = new HashSet<Case>();
            Case1 = new HashSet<Case>();
            HostingDetail = new HashSet<HostingDetail>();
            Message = new HashSet<Message>();
            Message1 = new HashSet<Message>();
            Order = new HashSet<Order>();
            SaveStaff = new HashSet<SaveStaff>();
            SaveStaff1 = new HashSet<SaveStaff>();
            ServicePlus = new HashSet<ServicePlus>();
            ProposalRecord = new HashSet<ProposalRecord>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MemberID { get; set; }

        [StringLength(50)]
        public string Cellphone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LogInTime { get; set; }

        public string Password { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] RegistedTime { get; set; }

        public TimeSpan? EditedTime { get; set; }

        public byte? isDeleted { get; set; }

        public TimeSpan? CreateUser { get; set; }

        public TimeSpan? UpdateUser { get; set; }

        [Column(TypeName = "money")]
        public decimal? Balance { get; set; }

        [Column(TypeName = "image")]
        public byte[] ProfilePicture { get; set; }

        public byte? Status { get; set; }

        [StringLength(50)]
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

        public int? CategoryID { get; set; }

        public int? SubCategoryID { get; set; }

        [StringLength(50)]
        public string AllPieceworkExp { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Case> Case { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Case> Case1 { get; set; }

        public virtual Experience Experience { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HostingDetail> HostingDetail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Message { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Message1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaveStaff> SaveStaff { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaveStaff> SaveStaff1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServicePlus> ServicePlus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProposalRecord> ProposalRecord { get; set; }

        public virtual ReplyFrequency ReplyFrequency { get; set; }

        public virtual QuotationDetail QuotationDetail { get; set; }
    }
}
