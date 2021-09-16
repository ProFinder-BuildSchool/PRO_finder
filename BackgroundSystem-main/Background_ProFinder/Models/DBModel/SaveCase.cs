using System;
using System.Collections.Generic;

#nullable disable

namespace Background_ProFinder.Models.DBModel
{
    public partial class SaveCase
    {
        public DateTime SavedDate { get; set; }
        public int MemberId { get; set; }
        public int? CaseId { get; set; }
        public int SaveCaseId { get; set; }
    }
}
