namespace PRO_finder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WorkAttachment")]
    public partial class WorkAttachment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WorkAttachment()
        {
            Works = new HashSet<Work>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WorkAttachmentID { get; set; }

        [StringLength(50)]
        public string WorkAttachmentName { get; set; }

        public string WorkAttachmentLink { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Work> Works { get; set; }
    }
}
