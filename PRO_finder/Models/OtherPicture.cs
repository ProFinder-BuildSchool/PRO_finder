namespace PRO_finder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OtherPicture")]
    public partial class OtherPicture
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OtherPicture()
        {
            Quotations = new HashSet<Quotation>();
        }

        public int QuotationID { get; set; }

        [Column("OtherPicture", TypeName = "image")]
        public byte[] OtherPicture1 { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OtherPictureID { get; set; }

        [Required]
        public string MainPicture { get; set; }

        public int SortNumber { get; set; }

        public byte IsDefault { get; set; }

        public virtual Quotation Quotation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quotation> Quotations { get; set; }
    }
}
