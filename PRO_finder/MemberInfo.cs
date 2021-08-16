namespace PRO_finder
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
        public virtual ICollection<Case> Case { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Case> Case1 { get; set; }

        public virtual Experience Experience { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HostingDetail> HostingDetail { get; set; }

        public virtual Locations Locations { get; set; }

        public virtual ServiceRecord ServiceRecord { get; set; }

        public virtual SystemContent SystemContent { get; set; }

        public virtual ToolCategory ToolCategory { get; set; }

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
