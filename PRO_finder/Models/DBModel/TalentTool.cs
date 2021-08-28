namespace PRO_finder.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TalentTool")]
    public partial class TalentTool
    {
        public int TalentToolID { get; set; }

        public int MemberID { get; set; }

        public int ToolSubCategoryID { get; set; }

        public string ToolSubCategoryName { get; set; }

        public int ToolCategoryID { get; set; }
    }
}
