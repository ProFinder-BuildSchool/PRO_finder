namespace PRO_finder.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrdersInformation")]
    public partial class OrdersInformation
    {
        public int? CartID { get; set; }

        public string Email { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Tel { get; set; }

        [StringLength(50)]
        public string LineID { get; set; }

        public string Memo { get; set; }

        public int? ContactTime { get; set; }

        [Key]
        public int OrderInfoID { get; set; }
    }
}
