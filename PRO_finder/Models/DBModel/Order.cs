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
        public int SourceID { get; set; }

        public int OrderType { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; }

        [Column(TypeName = "date")]
        public DateTime SubmitDate { get; set; }

        public int DealedTalentMemberID { get; set; }

        public decimal CaseReview { get; set; }

        [StringLength(50)]
        public string CaseMessage { get; set; }

        [StringLength(50)]
        public string CaseReplyMessage { get; set; }

        [StringLength(50)]
        public string CloseReason { get; set; }

        public int OrderStatus { get; set; }

        public int DepositStatus { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Column(TypeName = "date")]
        public DateTime DealedDate { get; set; }

        public virtual MemberInfo MemberInfo { get; set; }
    }
}
