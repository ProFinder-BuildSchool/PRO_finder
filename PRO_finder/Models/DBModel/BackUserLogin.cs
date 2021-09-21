namespace PRO_finder.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BackUserLogin")]
    public partial class BackUserLogin
    {
        [Key]
        [Column(Order = 0)]
        public string LoginProvider { get; set; }

        [Key]
        [Column(Order = 1)]
        public string ProviderKey { get; set; }

        public string ProviderDisplayName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(450)]
        public string UserId { get; set; }
    }
}
