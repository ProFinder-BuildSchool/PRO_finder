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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TalentIndexViewModel()
        {
            Cases = new HashSet<Case>();
            Cases1 = new HashSet<Case>();
            HostingDetails = new HashSet<HostingDetail>();
            Messages = new HashSet<Message>();
            Messages1 = new HashSet<Message>();
            Orders = new HashSet<Order>();
            SaveStaffs = new HashSet<SaveStaff>();
            SaveStaffs1 = new HashSet<SaveStaff>();
            ServicePlus = new HashSet<ServicePlus>();
            ProposalRecords = new HashSet<ProposalRecord>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Case> Cases { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Case> Cases1 { get; set; }

        public virtual Experience Experience { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HostingDetail> HostingDetails { get; set; }

        public virtual Locations Location { get; set; }

        public virtual ServiceRecord ServiceRecord { get; set; }

        public virtual SystemContent SystemContent { get; set; }

        public virtual ToolCategory ToolCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaveStaff> SaveStaffs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaveStaff> SaveStaffs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServicePlus> ServicePlus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProposalRecord> ProposalRecords { get; set; }

        public virtual ReplyFrequency ReplyFrequency { get; set; }

        public virtual QuotationDetail QuotationDetail { get; set; }

        public DateTime SentTime { get; set; }

        [Required]
        [StringLength(50)]
        public string EmailTitle { get; set; }

        public string Content { get; set; }

        public virtual MemberInfo MemberInfo { get; set; }
        public List<string> ContentList { get; set; }
    }
}