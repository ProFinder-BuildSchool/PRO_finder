using System;
using System.Collections.Generic;

#nullable disable

namespace Background_ProFinder.Models.DBModel
{
    public partial class WorkPicture
    {
        public int WorkPictureId { get; set; }
        public int WorkId { get; set; }
        public int SortNumber { get; set; }
        public string WorkPicture1 { get; set; }

        public virtual Work Work { get; set; }
    }
}
