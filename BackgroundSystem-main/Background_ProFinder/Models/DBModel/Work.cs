using System;
using System.Collections.Generic;

#nullable disable

namespace Background_ProFinder.Models.DBModel
{
    public partial class Work
    {
        public Work()
        {
            FeaturedWorks = new HashSet<FeaturedWork>();
            WorkPictures = new HashSet<WorkPicture>();
        }

        public int WorkId { get; set; }
        public string WorkName { get; set; }
        public string WorkDescription { get; set; }
        public string Client { get; set; }
        public string Role { get; set; }
        public int YearStarted { get; set; }
        public string WebsiteUrl { get; set; }
        public int SubCategoryId { get; set; }
        public int? WorkAttachmentId { get; set; }
        public int? MemberId { get; set; }
        public int? Featured { get; set; }

        public virtual SubCategory SubCategory { get; set; }
        public virtual WorkAttachment WorkAttachment { get; set; }
        public virtual ICollection<FeaturedWork> FeaturedWorks { get; set; }
        public virtual ICollection<WorkPicture> WorkPictures { get; set; }
    }
}
