using System;
using System.Collections.Generic;

#nullable disable

namespace Background_ProFinder.Models.DBModel
{
    public partial class SubCategory
    {
        public SubCategory()
        {
            Experiences = new HashSet<Experience>();
            Quotations = new HashSet<Quotation>();
            Works = new HashSet<Work>();
        }

        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }
        public virtual ICollection<Quotation> Quotations { get; set; }
        public virtual ICollection<Work> Works { get; set; }
    }
}
