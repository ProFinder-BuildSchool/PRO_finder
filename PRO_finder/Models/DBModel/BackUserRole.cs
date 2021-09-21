namespace PRO_finder.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BackUserRole")]
    public partial class BackUserRole
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(450)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(450)]
        public string RoleId { get; set; }
    }
}
