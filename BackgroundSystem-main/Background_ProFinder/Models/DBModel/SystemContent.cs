using System;
using System.Collections.Generic;

#nullable disable

namespace Background_ProFinder.Models.DBModel
{
    public partial class SystemContent
    {
        public int MemberId { get; set; }
        public DateTime? SentTime { get; set; }
        public string EmailTitle { get; set; }
        public string Content { get; set; }
    }
}
