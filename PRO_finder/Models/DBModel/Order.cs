namespace PRO_finder.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public int? OrderType { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; }

        public int? ProposerID { get; set; }

        public decimal? CaseReview { get; set; }

        [StringLength(50)]
        public string CaseMessage { get; set; }

        [StringLength(50)]
        public string CaseReplyMessage { get; set; }

        [StringLength(50)]
        public string CloseReason { get; set; }

        public int? OrderStatus { get; set; }

        public int? DepositStatus { get; set; }

        public decimal? Price { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DealedDate { get; set; }

        public int? ClientID { get; set; }

        public string QuotationImg { get; set; }

        [StringLength(50)]
        public string StudioName { get; set; }

        public int? Count { get; set; }

        public int? Unit { get; set; }

        public string Email { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Tel { get; set; }

        [StringLength(50)]
        public string LineID { get; set; }

        public string Memo { get; set; }

        public int? ContactTime { get; set; }

        public int? PredictDays { get; set; }
    }
}
