using System;
using System.Collections.Generic;

#nullable disable

namespace Background_ProFinder.Models.DBModel
{
    public partial class TalentTool
    {
        public int TalentToolId { get; set; }
        public int MemberId { get; set; }
        public int ToolSubCategoryId { get; set; }
        public string ToolSubCategoryName { get; set; }
        public int ToolCategoryId { get; set; }
    }
}
