using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OicarWebApi.Models
{
    public partial class AppUser
    {
        public AppUser()
        {
            ChatMessageReceivingUsers = new HashSet<ChatMessage>();
            ChatMessageSendingUsers = new HashSet<ChatMessage>();
            ProjectPosts = new HashSet<ProjectPost>();
            ReportReportedUsers = new HashSet<Report>();
            ReportReportingUsers = new HashSet<Report>();
            ReviewReviewedUsers = new HashSet<Review>();
            ReviewReviewingUsers = new HashSet<Review>();
            ServicePosts = new HashSet<ServicePost>();
            Suspensions = new HashSet<Suspension>();
        }
        [Key]
        public int IdappUser { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
        public Guid Salt { get; set; }
        public bool Deleted { get; set; }
        public int UserLevelId { get; set; }

        [JsonIgnore]
        public virtual UserLevel UserLevel { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<ChatMessage> ChatMessageReceivingUsers { get; set; }
        [JsonIgnore]
        public virtual ICollection<ChatMessage> ChatMessageSendingUsers { get; set; }
        [JsonIgnore]
        public virtual ICollection<ProjectPost> ProjectPosts { get; set; }
        [JsonIgnore]
        public virtual ICollection<Report> ReportReportedUsers { get; set; }
        [JsonIgnore]
        public virtual ICollection<Report> ReportReportingUsers { get; set; }
        [JsonIgnore]
        public virtual ICollection<Review> ReviewReviewedUsers { get; set; }
        [JsonIgnore]
        public virtual ICollection<Review> ReviewReviewingUsers { get; set; }
        [JsonIgnore]
        public virtual ICollection<ServicePost> ServicePosts { get; set; }
        [JsonIgnore]
        public virtual ICollection<Suspension> Suspensions { get; set; }
    }
}
