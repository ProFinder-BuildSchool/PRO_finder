namespace PRO_finder.Models.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BackUserData")]
    public partial class BackUserData
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(450)]
        public string Id { get; set; }

        [StringLength(256)]
        public string UserName { get; set; }

        [StringLength(256)]
        public string NormalizedUserName { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        [StringLength(256)]
        public string NormalizedEmail { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string ConcurrencyStamp { get; set; }

        public string PhoneNumber { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool PhoneNumberConfirmed { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool TwoFactorEnabled { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool LockoutEnabled { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AccessFailedCount { get; set; }
    }
}
