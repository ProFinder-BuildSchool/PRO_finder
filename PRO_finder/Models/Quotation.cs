namespace PRO_finder.Models
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
            OtherPictures = new HashSet<OtherPicture>();
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

        public virtual Location Location { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OtherPicture> OtherPictures { get; set; }

        public virtual OtherPicture OtherPicture { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}
