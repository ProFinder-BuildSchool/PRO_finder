using System;
using System.Collections.Generic;

#nullable disable

namespace Background_ProFinder.Models.DBModel
{
    public partial class SaveStaff
    {
        public int MemberId { get; set; }
        public int SavedTalentId { get; set; }
        public DateTime SavedDate { get; set; }
        public int SaveStaffId { get; set; }

        public virtual MemberInfo Member { get; set; }
        public virtual MemberInfo SavedTalent { get; set; }
    }
}
