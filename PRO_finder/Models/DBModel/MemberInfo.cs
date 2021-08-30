namespace PRO_finder.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MemberInfo")]
    public partial class MemberInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MemberInfo()
        {
            Case = new HashSet<Case>();
            Case1 = new HashSet<Case>();
            Experience = new HashSet<Experience>();
            HostingDetail = new HashSet<HostingDetail>();
            Message = new HashSet<Message>();
            Message1 = new HashSet<Message>();
            Order = new HashSet<Order>();
            SaveStaff = new HashSet<SaveStaff>();
            SaveStaff1 = new HashSet<SaveStaff>();
            ServicePlus = new HashSet<ServicePlus>();
            ProposalRecord = new HashSet<ProposalRecord>();
            QuotationDetail = new HashSet<QuotationDetail>();
        }

        [Key]
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

        public DateTime? EditedTime { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? CreateUser { get; set; }

        public DateTime? UpdateUser { get; set; }

        [Column(TypeName = "money")]
        public decimal? Balance { get; set; }

        [Column(TypeName = "image")]
        public byte[] ProfilePicture { get; set; }

        public bool? Status { get; set; }

        [StringLength(50)]
        public string NickName { get; set; }

        public int? Identity { get; set; }

        public int? LiveCity { get; set; }

        public int? TalentCategoryID { get; set; }

        public int? LocationID { get; set; }

        public int? SubCategoryID { get; set; }

        [StringLength(50)]
        public string AllPieceworkExp { get; set; }

        public string Description { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        public bool? IsThirdLogin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Case> Case { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Case> Case1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Experience> Experience { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HostingDetail> HostingDetail { get; set; }

        public virtual Works Works { get; set; }

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

        public virtual Works Works1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProposalRecord> ProposalRecord { get; set; }

        public virtual ReplyFrequency ReplyFrequency { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuotationDetail> QuotationDetail { get; set; }
    }
}
