using System;
using System.Collections.Generic;

#nullable disable

namespace Background_ProFinder.Models.DBModel
{
    public partial class ReplyFrequency
    {
        public int MemberId { get; set; }
        public decimal? Degree { get; set; }
        public int Readed { get; set; }
        public int Replyed { get; set; }
        public int Propose { get; set; }
        public DateTime OnlineTime { get; set; }

        public virtual MemberInfo Member { get; set; }
    }
}
