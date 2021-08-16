namespace PRO_finder
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Quotation")]
    public partial class Quotation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quotation()
        {
            OtherPicture = new HashSet<OtherPicture>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QuotationID { get; set; }

        [Required]
        [StringLength(30)]
        public string QuotationTitle { get; set; }

        public TimeSpan UpdateDate { get; set; }

        [Required]
        [StringLength(30)]
        public string Price { get; set; }

        public int QuotationUnit { get; set; }

        public int ExecuteDate { get; set; }

        public int MemberID { get; set; }

        [Required]
        public string Description { get; set; }

        public int? OtherPictureID { get; set; }

        public decimal? Evaluation { get; set; }

        public int SubCategoryID { get; set; }

        public int LocationID { get; set; }

        public virtual Locations Locations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OtherPicture> OtherPicture { get; set; }

        public virtual OtherPicture OtherPicture1 { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}
