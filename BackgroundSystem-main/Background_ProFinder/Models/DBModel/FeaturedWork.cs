using System;
using System.Collections.Generic;

#nullable disable

namespace Background_ProFinder.Models.DBModel
{
    public partial class FeaturedWork
    {
        public int FeaturedId { get; set; }
        public int? WorkId { get; set; }
        public string Memo { get; set; }

        public virtual Work Work { get; set; }
    }
}
