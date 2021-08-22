namespace PRO_finder.Models.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class OtherPictureViewModel
    {
        public int QuotationID { get; set; }

        public int OtherPictureID { get; set; }

        public string MainPicture { get; set; }

        public int SortNumber { get; set; }

        public bool IsDefault { get; set; }

        public string OtherPicture { get; set; }
    }
}
