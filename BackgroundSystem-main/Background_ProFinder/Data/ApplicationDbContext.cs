using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Background_ProFinder.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityUser>().ToTable("BackUserData");
            builder.Entity<IdentityUserRole<string>>().ToTable("BackUserRole");
            builder.Entity<IdentityUserClaim<string>>().ToTable("BackUserClaim");
            builder.Entity<IdentityUserToken<string>>().ToTable("BackUserToken");
            builder.Entity<IdentityUserLogin<string>>().ToTable("BackUserLogin");
            builder.Entity<IdentityRole>().ToTable("BackRole");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("BackUserRoleClaim");
        }
    }
}
