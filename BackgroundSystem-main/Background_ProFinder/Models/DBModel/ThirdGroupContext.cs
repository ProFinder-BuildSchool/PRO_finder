using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Background_ProFinder.Models.DBModel
{
    public partial class ThirdGroupContext : DbContext
    {
        public ThirdGroupContext()
        {
        }

        public ThirdGroupContext(DbContextOptions<ThirdGroupContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<BackAccount> BackAccounts { get; set; }
        public virtual DbSet<BackRole> BackRoles { get; set; }
        public virtual DbSet<BackUserClaim> BackUserClaims { get; set; }
        public virtual DbSet<BackUserDatum> BackUserData { get; set; }
        public virtual DbSet<BackUserLogin> BackUserLogins { get; set; }
        public virtual DbSet<BackUserRole> BackUserRoles { get; set; }
        public virtual DbSet<BackUserRoleClaim> BackUserRoleClaims { get; set; }
        public virtual DbSet<BackUserToken> BackUserTokens { get; set; }
        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<Case> Cases { get; set; }
        public virtual DbSet<CaseNotification> CaseNotifications { get; set; }
        public virtual DbSet<CaseReference> CaseReferences { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ClientCart> ClientCarts { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<FeaturedWork> FeaturedWorks { get; set; }
        public virtual DbSet<HostingDetail> HostingDetails { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<MemberInfo> MemberInfos { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OtherPicture> OtherPictures { get; set; }
        public virtual DbSet<ProposalRecord> ProposalRecords { get; set; }
        public virtual DbSet<Quotation> Quotations { get; set; }
        public virtual DbSet<QuotationDetail> QuotationDetails { get; set; }
        public virtual DbSet<ReplyFrequency> ReplyFrequencies { get; set; }
        public virtual DbSet<SaveCase> SaveCases { get; set; }
        public virtual DbSet<SaveStaff> SaveStaffs { get; set; }
        public virtual DbSet<ServicePlu> ServicePlus { get; set; }
        public virtual DbSet<ServiceRecord> ServiceRecords { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<Sysdiagram> Sysdiagrams { get; set; }
        public virtual DbSet<SystemContent> SystemContents { get; set; }
        public virtual DbSet<TalentTool> TalentTools { get; set; }
        public virtual DbSet<ToolCategory> ToolCategories { get; set; }
        public virtual DbSet<ToolSubCategory> ToolSubCategories { get; set; }
        public virtual DbSet<Work> Works { get; set; }
        public virtual DbSet<WorkAttachment> WorkAttachments { get; set; }
        public virtual DbSet<WorkPicture> WorkPictures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("data source=bs-2021-hsz-summer.database.windows.net;Database=ThirdGroup;user id=bs;password=3U7hzk5f8Bzm;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AspNetUserClaims_AspNetUsers");
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AspNetUserLogins_AspNetUsers");
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetRoles");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetUsers");
            });

            modelBuilder.Entity<BackAccount>(entity =>
            {
                entity.HasKey(e => e.AdminId);

                entity.ToTable("BackAccount");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(100);
            });

            modelBuilder.Entity<BackRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BackRole");

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<BackUserClaim>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BackUserClaim");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<BackUserDatum>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.LockoutEnd).HasColumnType("sql_variant");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<BackUserLogin>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BackUserLogin");

                entity.Property(e => e.LoginProvider)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.ProviderKey)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<BackUserRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BackUserRole");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<BackUserRoleClaim>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BackUserRoleClaim");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<BackUserToken>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BackUserToken");

                entity.Property(e => e.LoginProvider)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<Banner>(entity =>
            {
                entity.ToTable("Banner");

                entity.Property(e => e.BannerId).HasColumnName("BannerID");

                entity.Property(e => e.BannerTitle).HasMaxLength(50);
            });

            modelBuilder.Entity<Case>(entity =>
            {
                entity.ToTable("Case");

                entity.HasIndex(e => e.MemberId, "IX_MemberID");

                entity.Property(e => e.CaseId).HasColumnName("CaseID");

                entity.Property(e => e.CaseTitle).HasMaxLength(30);

                entity.Property(e => e.Contact).HasMaxLength(50);

                entity.Property(e => e.ContactEmail).HasMaxLength(50);

                entity.Property(e => e.ContactTime).HasMaxLength(50);

                entity.Property(e => e.LineId)
                    .HasMaxLength(50)
                    .HasColumnName("LineID");

                entity.Property(e => e.LocalCalls).HasMaxLength(50);

                entity.Property(e => e.LocalCallsCode).HasMaxLength(10);

                entity.Property(e => e.LocalCallsExtension).HasMaxLength(50);

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.SubCategoryId).HasColumnName("SubCategoryID");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Cases)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_Case_MemberInfo");
            });

            modelBuilder.Entity<CaseNotification>(entity =>
            {
                entity.HasKey(e => e.InvitedTalentId);

                entity.ToTable("CaseNotification");

                entity.Property(e => e.InvitedTalentId)
                    .ValueGeneratedNever()
                    .HasColumnName("InvitedTalentID");

                entity.Property(e => e.CaseId).HasColumnName("CaseID");

                entity.Property(e => e.InvitedDate).HasColumnType("date");
            });

            modelBuilder.Entity<CaseReference>(entity =>
            {
                entity.HasKey(e => e.CaseId);

                entity.ToTable("CaseReference");

                entity.Property(e => e.CaseId)
                    .ValueGeneratedNever()
                    .HasColumnName("CaseID");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<ClientCart>(entity =>
            {
                entity.HasKey(e => e.CartId)
                    .HasName("PK_dbo.ClientCart");

                entity.ToTable("ClientCart");

                entity.Property(e => e.CartId).HasColumnName("CartID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.LineId)
                    .HasMaxLength(50)
                    .HasColumnName("LineID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProposerId).HasColumnName("ProposerID");

                entity.Property(e => e.QuotationId).HasColumnName("QuotationID");

                entity.Property(e => e.StudioName).HasMaxLength(50);

                entity.Property(e => e.Tel).HasMaxLength(50);
            });

            modelBuilder.Entity<Experience>(entity =>
            {
                entity.HasKey(e => e.ExpId);

                entity.ToTable("Experience");

                entity.Property(e => e.ExpId).HasColumnName("ExpID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.PieceworkExp)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SubCategoryId).HasColumnName("SubCategoryID");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Experiences)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Experience_MemberInfo");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.Experiences)
                    .HasForeignKey(d => d.SubCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Experience_SubCategory");
            });

            modelBuilder.Entity<FeaturedWork>(entity =>
            {
                entity.HasKey(e => e.FeaturedId);

                entity.ToTable("FeaturedWork");

                entity.Property(e => e.FeaturedId).HasColumnName("FeaturedID");

                entity.Property(e => e.WorkId).HasColumnName("WorkID");

                entity.HasOne(d => d.Work)
                    .WithMany(p => p.FeaturedWorks)
                    .HasForeignKey(d => d.WorkId)
                    .HasConstraintName("FK_FeaturedWork_Works");
            });

            modelBuilder.Entity<HostingDetail>(entity =>
            {
                entity.HasKey(e => e.HostId);

                entity.ToTable("HostingDetail");

                entity.Property(e => e.HostId)
                    .ValueGeneratedNever()
                    .HasColumnName("HostID");

                entity.Property(e => e.CaseId).HasColumnName("CaseID");

                entity.Property(e => e.HostedAmount).HasColumnType("money");

                entity.Property(e => e.HostedTime).HasColumnType("datetime");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.HostingDetails)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HostingDetail_MemberInfo");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.LocationId)
                    .ValueGeneratedNever()
                    .HasColumnName("LocationID");

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<MemberInfo>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .HasName("PK_MemberInfo會員資料");

                entity.ToTable("MemberInfo");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.AllPieceworkExp).HasMaxLength(50);

                entity.Property(e => e.Balance).HasColumnType("money");

                entity.Property(e => e.BankCode).HasMaxLength(50);

                entity.Property(e => e.Cellphone).HasMaxLength(50);

                entity.Property(e => e.CreateUser).HasColumnType("datetime");

                entity.Property(e => e.EditedTime).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.LogInTime).HasColumnType("date");

                entity.Property(e => e.NickName).HasMaxLength(50);

                entity.Property(e => e.RegistedTime)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.SubCategoryId).HasColumnName("SubCategoryID");

                entity.Property(e => e.TalentCategoryId).HasColumnName("TalentCategoryID");

                entity.Property(e => e.UpdateUser).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(128);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.CaseId);

                entity.ToTable("Message");

                entity.Property(e => e.CaseId)
                    .ValueGeneratedNever()
                    .HasColumnName("CaseID");

                entity.Property(e => e.ChatTime).HasColumnType("datetime");

                entity.Property(e => e.SourceId).HasColumnName("SourceID");

                entity.Property(e => e.TargetId).HasColumnName("TargetID");

                entity.HasOne(d => d.Source)
                    .WithMany(p => p.MessageSources)
                    .HasForeignKey(d => d.SourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_MemberInfo1");

                entity.HasOne(d => d.Target)
                    .WithMany(p => p.MessageTargets)
                    .HasForeignKey(d => d.TargetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_MemberInfo");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CaseId).HasColumnName("CaseID");

                entity.Property(e => e.CaseMessage).HasMaxLength(50);

                entity.Property(e => e.CaseReplyMessage).HasMaxLength(50);

                entity.Property(e => e.CaseReview).HasColumnType("decimal(3, 1)");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.CloseReason).HasMaxLength(50);

                entity.Property(e => e.CompleteDate).HasColumnType("datetime");

                entity.Property(e => e.DealedDate).HasColumnType("date");

                entity.Property(e => e.LineId)
                    .HasMaxLength(50)
                    .HasColumnName("LineID");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PaymentCode).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProposerId).HasColumnName("ProposerID");

                entity.Property(e => e.QuotationId).HasColumnName("QuotationID");

                entity.Property(e => e.StudioName).HasMaxLength(50);

                entity.Property(e => e.Tel).HasMaxLength(50);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_Order_MemberInfo");
            });

            modelBuilder.Entity<OtherPicture>(entity =>
            {
                entity.ToTable("OtherPicture");

                entity.Property(e => e.OtherPictureId).HasColumnName("OtherPictureID");

                entity.Property(e => e.QuotationId).HasColumnName("QuotationID");
            });

            modelBuilder.Entity<ProposalRecord>(entity =>
            {
                entity.ToTable("ProposalRecord");

                entity.Property(e => e.ProposalRecordId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProposalRecordID");

                entity.Property(e => e.CaseId).HasColumnName("CaseID");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.SavedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.ProposalRecords)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_主動提案記錄_MemberInfo");
            });

            modelBuilder.Entity<Quotation>(entity =>
            {
                entity.ToTable("Quotation");

                entity.Property(e => e.QuotationId).HasColumnName("QuotationID");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Evaluation).HasColumnType("decimal(2, 1)");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.QuotationTitle)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.SubCategoryId).HasColumnName("SubCategoryID");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.Quotations)
                    .HasForeignKey(d => d.SubCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Quotation_SubCategory");
            });

            modelBuilder.Entity<QuotationDetail>(entity =>
            {
                entity.HasKey(e => e.QuotaionDetailId)
                    .HasName("PK_QuotationDetail_1");

                entity.ToTable("QuotationDetail");

                entity.Property(e => e.QuotaionDetailId).HasColumnName("QuotaionDetailID");

                entity.Property(e => e.CaseId).HasColumnName("CaseID");

                entity.Property(e => e.ProposeDate).HasColumnType("datetime");

                entity.Property(e => e.ProposeDescription).IsRequired();

                entity.Property(e => e.ProposePrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProposerId).HasColumnName("ProposerID");

                entity.HasOne(d => d.Proposer)
                    .WithMany(p => p.QuotationDetails)
                    .HasForeignKey(d => d.ProposerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_提案報價表格/人才報價記錄_MemberInfo");
            });

            modelBuilder.Entity<ReplyFrequency>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.ToTable("ReplyFrequency");

                entity.Property(e => e.MemberId)
                    .ValueGeneratedNever()
                    .HasColumnName("MemberID");

                entity.Property(e => e.Degree).HasColumnType("decimal(3, 1)");

                entity.Property(e => e.OnlineTime).HasColumnType("date");

                entity.HasOne(d => d.Member)
                    .WithOne(p => p.ReplyFrequency)
                    .HasForeignKey<ReplyFrequency>(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_案主積極度_MemberInfo");
            });

            modelBuilder.Entity<SaveCase>(entity =>
            {
                entity.ToTable("SaveCase");

                entity.Property(e => e.SaveCaseId).HasColumnName("SaveCaseID");

                entity.Property(e => e.CaseId).HasColumnName("CaseID");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.SavedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<SaveStaff>(entity =>
            {
                entity.ToTable("SaveStaff");

                entity.Property(e => e.SaveStaffId).HasColumnName("SaveStaffID");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.SavedDate).HasColumnType("date");

                entity.Property(e => e.SavedTalentId).HasColumnName("SavedTalentID");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.SaveStaffMembers)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaveStaff_MemberInfo");

                entity.HasOne(d => d.SavedTalent)
                    .WithMany(p => p.SaveStaffSavedTalents)
                    .HasForeignKey(d => d.SavedTalentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaveStaff_MemberInfo1");
            });

            modelBuilder.Entity<ServicePlu>(entity =>
            {
                entity.HasKey(e => e.ServicePlusId);

                entity.Property(e => e.ServicePlusId)
                    .ValueGeneratedNever()
                    .HasColumnName("ServicePlusID");

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.ServicePlus)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServicePlus_MemberInfo");
            });

            modelBuilder.Entity<ServiceRecord>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.ToTable("ServiceRecord");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(128)
                    .HasColumnName("MemberID");

                entity.Property(e => e.CaseId).HasColumnName("CaseID");

                entity.Property(e => e.CaseReview).HasMaxLength(50);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Message).HasMaxLength(50);

                entity.Property(e => e.SavedDate).HasColumnType("date");
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.ToTable("SubCategory");

                entity.Property(e => e.SubCategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("SubCategoryID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.SubCategoryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SubCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubCategory_Category");
            });

            modelBuilder.Entity<Sysdiagram>(entity =>
            {
                entity.HasKey(e => e.DiagramId)
                    .HasName("PK_dbo.sysdiagrams");

                entity.ToTable("sysdiagrams");

                entity.Property(e => e.DiagramId).HasColumnName("diagram_id");

                entity.Property(e => e.Definition).HasColumnName("definition");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("name");

                entity.Property(e => e.PrincipalId).HasColumnName("principal_id");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<SystemContent>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SystemContent");

                entity.Property(e => e.EmailTitle)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.SentTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TalentTool>(entity =>
            {
                entity.ToTable("TalentTool");

                entity.Property(e => e.TalentToolId).HasColumnName("TalentToolID");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.ToolCategoryId).HasColumnName("ToolCategoryID");

                entity.Property(e => e.ToolSubCategoryId).HasColumnName("ToolSubCategoryID");

                entity.Property(e => e.ToolSubCategoryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ToolCategory>(entity =>
            {
                entity.HasKey(e => e.TalentCategoryId)
                    .HasName("PK_SoftwareTool");

                entity.ToTable("ToolCategory");

                entity.Property(e => e.TalentCategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("TalentCategoryID");

                entity.Property(e => e.TalentCategoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<ToolSubCategory>(entity =>
            {
                entity.HasKey(e => e.SubTalentCategoryId);

                entity.ToTable("ToolSubCategory");

                entity.Property(e => e.SubTalentCategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("SubTalentCategoryID");

                entity.Property(e => e.SubTalentCategoryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TalentCategoryId).HasColumnName("TalentCategoryID");

                entity.HasOne(d => d.TalentCategory)
                    .WithMany(p => p.ToolSubCategories)
                    .HasForeignKey(d => d.TalentCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ToolSubCategory_ToolCategory");
            });

            modelBuilder.Entity<Work>(entity =>
            {
                entity.HasIndex(e => e.WorkId, "IX_WorkID");

                entity.Property(e => e.WorkId)
                    .ValueGeneratedNever()
                    .HasColumnName("WorkID");

                entity.Property(e => e.Client).IsRequired();

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.Role).IsRequired();

                entity.Property(e => e.SubCategoryId).HasColumnName("SubCategoryID");

                entity.Property(e => e.WebsiteUrl).HasColumnName("WebsiteURL");

                entity.Property(e => e.WorkAttachmentId).HasColumnName("WorkAttachmentID");

                entity.Property(e => e.WorkDescription).IsRequired();

                entity.Property(e => e.WorkName).IsRequired();

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.Works)
                    .HasForeignKey(d => d.SubCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Works_SubCategory");

                entity.HasOne(d => d.WorkAttachment)
                    .WithMany(p => p.Works)
                    .HasForeignKey(d => d.WorkAttachmentId)
                    .HasConstraintName("FK_Works_WorkAttachment");
            });

            modelBuilder.Entity<WorkAttachment>(entity =>
            {
                entity.ToTable("WorkAttachment");

                entity.Property(e => e.WorkAttachmentId).HasColumnName("WorkAttachmentID");

                entity.Property(e => e.WorkAttachmentName).HasMaxLength(50);

                entity.Property(e => e.WorkId).HasColumnName("WorkID");
            });

            modelBuilder.Entity<WorkPicture>(entity =>
            {
                entity.Property(e => e.WorkPictureId)
                    .ValueGeneratedNever()
                    .HasColumnName("WorkPictureID");

                entity.Property(e => e.WorkId).HasColumnName("WorkID");

                entity.Property(e => e.WorkPicture1)
                    .IsRequired()
                    .HasColumnName("WorkPicture");

                entity.HasOne(d => d.Work)
                    .WithMany(p => p.WorkPictures)
                    .HasForeignKey(d => d.WorkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkPictures_Works");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
