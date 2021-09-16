using System;
using System.Collections.Generic;

#nullable disable

namespace Background_ProFinder.Models.DBModel
{
    public partial class WorkAttachment
    {
        public WorkAttachment()
        {
            Works = new HashSet<Work>();
        }

        public int WorkAttachmentId { get; set; }
        public string WorkAttachmentName { get; set; }
        public string WorkAttachmentLink { get; set; }
        public int? WorkId { get; set; }

        public virtual ICollection<Work> Works { get; set; }
    }
}
