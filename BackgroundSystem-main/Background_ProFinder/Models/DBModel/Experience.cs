using System;
using System.Collections.Generic;

#nullable disable

namespace Background_ProFinder.Models.DBModel
{
    public partial class Experience
    {
        public int MemberId { get; set; }
        public int SubCategoryId { get; set; }
        public string PieceworkExp { get; set; }
        public int ExpId { get; set; }
        public int CategoryId { get; set; }

        public virtual MemberInfo Member { get; set; }
        public virtual SubCategory SubCategory { get; set; }
    }
}
