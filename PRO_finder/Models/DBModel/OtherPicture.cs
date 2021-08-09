namespace PRO_finder.Models.DBModel
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
            Quotation1 = new HashSet<Quotation>();
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
        public virtual ICollection<Quotation> Quotation1 { get; set; }
    }
}
