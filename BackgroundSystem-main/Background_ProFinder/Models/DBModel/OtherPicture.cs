using System;
using System.Collections.Generic;

#nullable disable

namespace Background_ProFinder.Models.DBModel
{
    public partial class OtherPicture
    {
        public int QuotationId { get; set; }
        public int OtherPictureId { get; set; }
        public int SortNumber { get; set; }
        public bool? IsDefault { get; set; }
        public string OtherPictureLink { get; set; }
    }
}
