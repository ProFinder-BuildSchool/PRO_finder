namespace PRO_finder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Case")]
    public partial class Case
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Case()
        {
            CaseNotifications = new HashSet<CaseNotification>();
            HostingDetails = new HashSet<HostingDetail>();
            ProposalRecords = new HashSet<ProposalRecord>();
            QuotationDetails = new HashSet<QuotationDetail>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CaseID { get; set; }

        public int SortNumber { get; set; }

        [Required]
        [StringLength(30)]
        public string CaseTitle { get; set; }

        public int SubCategoryID { get; set; }

        public TimeSpan UpdateDate { get; set; }

        public int Price { get; set; }

        public int? Location { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CompleteDate { get; set; }

        [Required]
        public string Description { get; set; }

        public int MemberID { get; set; }

        public int Type { get; set; }

        public int CaseStatus { get; set; }

        [Required]
        [StringLength(50)]
        public string Contact { get; set; }

        public byte AnswerPhone { get; set; }

        [StringLength(10)]
        public string LocalCallsCode { get; set; }

        [StringLength(50)]
        public string LocalCalls { get; set; }

        [StringLength(50)]
        public string LocalCallsExtension { get; set; }

        [Required]
        [StringLength(50)]
        public string ContactTime { get; set; }

        [Required]
        [StringLength(50)]
        public string ContactEmail { get; set; }

        [StringLength(50)]
        public string LineID { get; set; }

        public virtual MemberInfo MemberInfo { get; set; }

        public virtual MemberInfo MemberInfo1 { get; set; }

        public virtual SubCategory SubCategory { get; set; }

        public virtual SubCategory SubCategory1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CaseNotification> CaseNotifications { get; set; }

        public virtual CaseNotification CaseNotification { get; set; }

        public virtual CaseReference CaseReference { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HostingDetail> HostingDetails { get; set; }

        public virtual SaveCase SaveCase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProposalRecord> ProposalRecords { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuotationDetail> QuotationDetails { get; set; }
    }
}
