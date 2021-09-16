using System;
using System.Collections.Generic;

#nullable disable

namespace Background_ProFinder.Models.DBModel
{
    public partial class ToolCategory
    {
        public ToolCategory()
        {
            ToolSubCategories = new HashSet<ToolSubCategory>();
        }

        public int TalentCategoryId { get; set; }
        public string TalentCategoryName { get; set; }

        public virtual ICollection<ToolSubCategory> ToolSubCategories { get; set; }
    }
}
