using System;
using System.Collections.Generic;

#nullable disable

namespace Background_ProFinder.Models.DBModel
{
    public partial class MemberInfo
    {
        public MemberInfo()
        {
            Cases = new HashSet<Case>();
            Experiences = new HashSet<Experience>();
            HostingDetails = new HashSet<HostingDetail>();
            MessageSources = new HashSet<Message>();
            MessageTargets = new HashSet<Message>();
            Orders = new HashSet<Order>();
            ProposalRecords = new HashSet<ProposalRecord>();
            QuotationDetails = new HashSet<QuotationDetail>();
            SaveStaffMembers = new HashSet<SaveStaff>();
            SaveStaffSavedTalents = new HashSet<SaveStaff>();
            ServicePlus = new HashSet<ServicePlu>();
        }

        public int MemberId { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public DateTime? LogInTime { get; set; }
        public string Password { get; set; }
        public byte[] RegistedTime { get; set; }
        public DateTime? EditedTime { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreateUser { get; set; }
        public DateTime? UpdateUser { get; set; }
        public decimal? Balance { get; set; }
        public bool? Status { get; set; }
        public string NickName { get; set; }
        public int? Identity { get; set; }
        public int? LiveCity { get; set; }
        public int? TalentCategoryId { get; set; }
        public int? LocationId { get; set; }
        public int? SubCategoryId { get; set; }
        public string AllPieceworkExp { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public bool? IsThirdLogin { get; set; }
        public string ProfilePicture { get; set; }
        public string BankCode { get; set; }
        public string BankAccount { get; set; }

        public virtual ReplyFrequency ReplyFrequency { get; set; }
        public virtual ICollection<Case> Cases { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }
        public virtual ICollection<HostingDetail> HostingDetails { get; set; }
        public virtual ICollection<Message> MessageSources { get; set; }
        public virtual ICollection<Message> MessageTargets { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ProposalRecord> ProposalRecords { get; set; }
        public virtual ICollection<QuotationDetail> QuotationDetails { get; set; }
        public virtual ICollection<SaveStaff> SaveStaffMembers { get; set; }
        public virtual ICollection<SaveStaff> SaveStaffSavedTalents { get; set; }
        public virtual ICollection<ServicePlu> ServicePlus { get; set; }
    }
}
