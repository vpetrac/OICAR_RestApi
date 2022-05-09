using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OicarWebApi.Models
{
    

    public partial class User
    {
        public User()
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

        public virtual ICollection<ChatMessage> ChatMessageReceivingUsers { get; set; }
        public virtual ICollection<ChatMessage> ChatMessageSendingUsers { get; set; }
        public virtual ICollection<ProjectPost> ProjectPosts { get; set; }
        public virtual ICollection<Report> ReportReportedUsers { get; set; }
        public virtual ICollection<Report> ReportReportingUsers { get; set; }
        public virtual ICollection<Review> ReviewReviewedUsers { get; set; }
        public virtual ICollection<Review> ReviewReviewingUsers { get; set; }
        public virtual ICollection<ServicePost> ServicePosts { get; set; }
        public virtual ICollection<Suspension> Suspensions { get; set; }
    }
}
