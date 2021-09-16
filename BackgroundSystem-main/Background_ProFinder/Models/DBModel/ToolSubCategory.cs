using System;
using System.Collections.Generic;

#nullable disable

namespace Background_ProFinder.Models.DBModel
{
    public partial class ToolSubCategory
    {
        public int TalentCategoryId { get; set; }
        public int SubTalentCategoryId { get; set; }
        public string SubTalentCategoryName { get; set; }

        public virtual ToolCategory TalentCategory { get; set; }
    }
}
