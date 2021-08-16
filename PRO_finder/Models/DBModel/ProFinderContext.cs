using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PRO_finder.Models.DBModel
{
    public partial class ProFinderContext : DbContext
    {
        public ProFinderContext()
            : base("name=ProFinderContext")
        {
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Case> Case { get; set; }
        public virtual DbSet<CaseNotification> CaseNotification { get; set; }
        public virtual DbSet<CaseReference> CaseReference { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Experience> Experience { get; set; }
        public virtual DbSet<HostingDetail> HostingDetail { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<MemberInfo> MemberInfo { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OtherPicture> OtherPicture { get; set; }
        public virtual DbSet<ProposalRecord> ProposalRecord { get; set; }
        public virtual DbSet<Quotation> Quotation { get; set; }
        public virtual DbSet<QuotationDetail> QuotationDetail { get; set; }
        public virtual DbSet<ReplyFrequency> ReplyFrequency { get; set; }
        public virtual DbSet<SaveCase> SaveCase { get; set; }
        public virtual DbSet<SaveStaff> SaveStaff { get; set; }
        public virtual DbSet<ServicePlus> ServicePlus { get; set; }
        public virtual DbSet<ServiceRecord> ServiceRecord { get; set; }
        public virtual DbSet<SubCategory> SubCategory { get; set; }
        public virtual DbSet<ToolCategory> ToolCategory { get; set; }
        public virtual DbSet<ToolSubCategory> ToolSubCategory { get; set; }
        public virtual DbSet<WorkAttachment> WorkAttachment { get; set; }
        public virtual DbSet<WorkPictures> WorkPictures { get; set; }
        public virtual DbSet<Works> Works { get; set; }
        public virtual DbSet<SystemContent> SystemContent { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Case>()
                .HasMany(e => e.CaseNotification)
                .WithRequired(e => e.Case)
                .HasForeignKey(e => e.CaseID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Case>()
                .HasOptional(e => e.CaseNotification1)
                .WithRequired(e => e.Case1);

            modelBuilder.Entity<Case>()
                .HasOptional(e => e.CaseReference)
                .WithRequired(e => e.Case);

            modelBuilder.Entity<Case>()
                .HasMany(e => e.HostingDetail)
                .WithRequired(e => e.Case)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Case>()
                .HasOptional(e => e.SaveCase)
                .WithRequired(e => e.Case);

            modelBuilder.Entity<Case>()
                .HasMany(e => e.ProposalRecord)
                .WithRequired(e => e.Case)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Case>()
                .HasMany(e => e.QuotationDetail)
                .WithRequired(e => e.Case)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryName)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .HasMany(e => e.SubCategory)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HostingDetail>()
                .Property(e => e.HostedAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MemberInfo>()
                .Property(e => e.RegistedTime)
                .IsFixedLength();

            modelBuilder.Entity<MemberInfo>()
                .Property(e => e.Balance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MemberInfo>()
                .HasMany(e => e.Case)
                .WithRequired(e => e.MemberInfo)
                .HasForeignKey(e => e.MemberID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberInfo>()
                .HasMany(e => e.Case1)
                .WithRequired(e => e.MemberInfo1)
                .HasForeignKey(e => e.MemberID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberInfo>()
                .HasOptional(e => e.Experience)
                .WithRequired(e => e.MemberInfo);

            modelBuilder.Entity<MemberInfo>()
                .HasMany(e => e.HostingDetail)
                .WithRequired(e => e.MemberInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberInfo>()
                .HasMany(e => e.Message)
                .WithRequired(e => e.MemberInfo)
                .HasForeignKey(e => e.TargetID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberInfo>()
                .HasMany(e => e.Message1)
                .WithRequired(e => e.MemberInfo1)
                .HasForeignKey(e => e.SourceID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberInfo>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.MemberInfo)
                .HasForeignKey(e => e.DealedTalentMemberID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberInfo>()
                .HasMany(e => e.SaveStaff)
                .WithRequired(e => e.MemberInfo)
                .HasForeignKey(e => e.MemberID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberInfo>()
                .HasMany(e => e.SaveStaff1)
                .WithRequired(e => e.MemberInfo1)
                .HasForeignKey(e => e.SavedTalentID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberInfo>()
                .HasMany(e => e.ServicePlus)
                .WithRequired(e => e.MemberInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberInfo>()
                .HasMany(e => e.ProposalRecord)
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
                .HasMany(e => e.Quotation1)
                .WithOptional(e => e.OtherPicture1)
                .HasForeignKey(e => e.OtherPictureID);

            modelBuilder.Entity<Quotation>()
                .Property(e => e.Evaluation)
                .HasPrecision(2, 0);

            modelBuilder.Entity<Quotation>()
                .HasMany(e => e.OtherPicture)
                .WithRequired(e => e.Quotation)
                .HasForeignKey(e => e.QuotationID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReplyFrequency>()
                .Property(e => e.Degree)
                .HasPrecision(3, 0);

            modelBuilder.Entity<ServicePlus>()
                .Property(e => e.Cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SubCategory>()
                .HasMany(e => e.Case)
                .WithRequired(e => e.SubCategory)
                .HasForeignKey(e => e.SubCategoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubCategory>()
                .HasMany(e => e.Case1)
                .WithRequired(e => e.SubCategory1)
                .HasForeignKey(e => e.SubCategoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubCategory>()
                .HasMany(e => e.Experience)
                .WithRequired(e => e.SubCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubCategory>()
                .HasMany(e => e.Quotation)
                .WithRequired(e => e.SubCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubCategory>()
                .HasMany(e => e.Works)
                .WithRequired(e => e.SubCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ToolCategory>()
                .HasMany(e => e.ToolSubCategory)
                .WithRequired(e => e.ToolCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Works>()
                .Property(e => e.WorkName)
                .IsFixedLength();

            modelBuilder.Entity<Works>()
                .HasMany(e => e.WorkPictures)
                .WithRequired(e => e.Works)
                .WillCascadeOnDelete(false);
        }
    }
}