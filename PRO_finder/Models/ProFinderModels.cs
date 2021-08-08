using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PRO_finder.Models
{
    public partial class ProFinderModels : DbContext
    {
        public ProFinderModels()
            : base("name=ProFinderContext")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Case> Cases { get; set; }
        public virtual DbSet<CaseNotification> CaseNotifications { get; set; }
        public virtual DbSet<CaseReference> CaseReferences { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<HostingDetail> HostingDetails { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<MemberInfo> MemberInfoes { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
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
        public virtual DbSet<SystemContent> SystemContents { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<ToolCategory> ToolCategories { get; set; }
        public virtual DbSet<ToolSubCategory> ToolSubCategories { get; set; }
        public virtual DbSet<WorkAttachment> WorkAttachments { get; set; }
        public virtual DbSet<WorkPicture> WorkPictures { get; set; }
        public virtual DbSet<Work> Works { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Case>()
                .HasMany(e => e.CaseNotifications)
                .WithRequired(e => e.Case)
                .HasForeignKey(e => e.CaseID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Case>()
                .HasOptional(e => e.CaseNotification)
                .WithRequired(e => e.Case1);

            modelBuilder.Entity<Case>()
                .HasOptional(e => e.CaseReference)
                .WithRequired(e => e.Case);

            modelBuilder.Entity<Case>()
                .HasMany(e => e.HostingDetails)
                .WithRequired(e => e.Case)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Case>()
                .HasOptional(e => e.SaveCase)
                .WithRequired(e => e.Case);

            modelBuilder.Entity<Case>()
                .HasMany(e => e.ProposalRecords)
                .WithRequired(e => e.Case)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Case>()
                .HasMany(e => e.QuotationDetails)
                .WithRequired(e => e.Case)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryName)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .HasMany(e => e.SubCategories)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HostingDetail>()
                .Property(e => e.HostedAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.MemberInfoes)
                .WithRequired(e => e.Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Quotations)
                .WithRequired(e => e.Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberInfo>()
                .Property(e => e.RegistedTime)
                .IsFixedLength();

            modelBuilder.Entity<MemberInfo>()
                .Property(e => e.Balance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MemberInfo>()
                .HasMany(e => e.Cases)
                .WithRequired(e => e.MemberInfo)
                .HasForeignKey(e => e.MemberID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberInfo>()
                .HasMany(e => e.Cases1)
                .WithRequired(e => e.MemberInfo1)
                .HasForeignKey(e => e.MemberID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberInfo>()
                .HasOptional(e => e.Experience)
                .WithRequired(e => e.MemberInfo);

            modelBuilder.Entity<MemberInfo>()
                .HasMany(e => e.HostingDetails)
                .WithRequired(e => e.MemberInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberInfo>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.MemberInfo)
                .HasForeignKey(e => e.TargetID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberInfo>()
                .HasMany(e => e.Messages1)
                .WithRequired(e => e.MemberInfo1)
                .HasForeignKey(e => e.SourceID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberInfo>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.MemberInfo)
                .HasForeignKey(e => e.DealedTalentMemberID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberInfo>()
                .HasMany(e => e.SaveStaffs)
                .WithRequired(e => e.MemberInfo)
                .HasForeignKey(e => e.MemberID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberInfo>()
                .HasMany(e => e.SaveStaffs1)
                .WithRequired(e => e.MemberInfo1)
                .HasForeignKey(e => e.SavedTalentID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberInfo>()
                .HasMany(e => e.ServicePlus)
                .WithRequired(e => e.MemberInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberInfo>()
                .HasMany(e => e.ProposalRecords)
                .WithRequired(e => e.MemberInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberInfo>()
                .HasOptional(e => e.ReplyFrequency)
                .WithRequired(e => e.MemberInfo);

            modelBuilder.Entity<MemberInfo>()
                .HasOptional(e => e.QuotationDetail)
                .WithRequired(e => e.MemberInfo);

            modelBuilder.Entity<Order>()
                .Property(e => e.CaseReview)
                .HasPrecision(3, 0);

            modelBuilder.Entity<Order>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OtherPicture>()
                .HasMany(e => e.Quotations)
                .WithOptional(e => e.OtherPicture)
                .HasForeignKey(e => e.OtherPictureID);

            modelBuilder.Entity<Quotation>()
                .Property(e => e.Evaluation)
                .HasPrecision(2, 0);

            modelBuilder.Entity<Quotation>()
                .HasMany(e => e.OtherPictures)
                .WithRequired(e => e.Quotation)
                .HasForeignKey(e => e.QuotationID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReplyFrequency>()
                .Property(e => e.Degree)
                .HasPrecision(3, 0);

            modelBuilder.Entity<ServicePlu>()
                .Property(e => e.Cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ServiceRecord>()
                .HasOptional(e => e.MemberInfo)
                .WithRequired(e => e.ServiceRecord);

            modelBuilder.Entity<SubCategory>()
                .HasMany(e => e.Cases)
                .WithRequired(e => e.SubCategory)
                .HasForeignKey(e => e.SubCategoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubCategory>()
                .HasMany(e => e.Cases1)
                .WithRequired(e => e.SubCategory1)
                .HasForeignKey(e => e.SubCategoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubCategory>()
                .HasMany(e => e.Experiences)
                .WithRequired(e => e.SubCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubCategory>()
                .HasMany(e => e.Quotations)
                .WithRequired(e => e.SubCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubCategory>()
                .HasMany(e => e.Works)
                .WithRequired(e => e.SubCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SystemContent>()
                .HasOptional(e => e.MemberInfo)
                .WithRequired(e => e.SystemContent);

            modelBuilder.Entity<Test>()
                .Property(e => e.Unit)
                .IsFixedLength();

            modelBuilder.Entity<Test>()
                .Property(e => e.StudioName)
                .IsFixedLength();

            modelBuilder.Entity<ToolCategory>()
                .HasMany(e => e.MemberInfoes)
                .WithRequired(e => e.ToolCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ToolCategory>()
                .HasMany(e => e.ToolSubCategories)
                .WithRequired(e => e.ToolCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Work>()
                .Property(e => e.WorkName)
                .IsFixedLength();

            modelBuilder.Entity<Work>()
                .HasMany(e => e.WorkPictures)
                .WithRequired(e => e.Work)
                .WillCascadeOnDelete(false);
        }
    }
}
