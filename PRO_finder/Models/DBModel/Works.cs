namespace PRO_finder.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Works
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Works()
        {
            WorkPictures = new HashSet<WorkPictures>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WorkID { get; set; }

        [Required]
        public string WorkName { get; set; }

        [Required]
        public string WorkDescription { get; set; }

        [Required]
        public string Client { get; set; }

        [Required]
        public string Role { get; set; }

        public int YearStarted { get; set; }

        public string WebsiteURL { get; set; }

        public int SubCategoryID { get; set; }

        public int? WorkAttachmentID { get; set; }

        public int? MemberID { get; set; }

        public virtual MemberInfo MemberInfo { get; set; }

        public virtual SubCategory SubCategory { get; set; }

        public virtual WorkAttachment WorkAttachment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkPictures> WorkPictures { get; set; }
    }
}
