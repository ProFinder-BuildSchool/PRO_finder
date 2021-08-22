namespace PRO_finder.Models.DBModel
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
            Works = new HashSet<Works>();
        }

        public int WorkAttachmentID { get; set; }

        [StringLength(50)]
        public string WorkAttachmentName { get; set; }

        public string WorkAttachmentLink { get; set; }

        public int? WorkID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Works> Works { get; set; }
    }
}
