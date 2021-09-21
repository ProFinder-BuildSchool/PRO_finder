namespace PRO_finder.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BackUserClaim")]
    public partial class BackUserClaim
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(450)]
        public string UserId { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }
    }
}
