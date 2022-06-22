using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OicarWebApi.Models
{
    public partial class OicarAppDatabaseContext : DbContext
    {
        public OicarAppDatabaseContext()
        {
        }

        public OicarAppDatabaseContext(DbContextOptions<OicarAppDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppUser> AppUsers { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<ChatMessage> ChatMessages { get; set; } = null!;
        public virtual DbSet<ProjectPost> ProjectPosts { get; set; } = null!;
        public virtual DbSet<Report> Reports { get; set; } = null!;
        public virtual DbSet<ReportReason> ReportReasons { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<ServicePost> ServicePosts { get; set; } = null!;
        public virtual DbSet<ServicePostImage> ServicePostImages { get; set; } = null!;
        public virtual DbSet<Suspension> Suspensions { get; set; } = null!;
        public virtual DbSet<UserLevel> UserLevels { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=sql.bsite.net\\MSSQL2016;Initial Catalog=ved99_oicar;User ID=ved99_oicar;Password=Oicar2022Algebra;Persist Security Info=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.HasKey(e => e.IdappUser);

                entity.ToTable("AppUser");

                entity.HasIndex(e => e.Email, "UQ_AppUser_Email")
                    .IsUnique();

                entity.Property(e => e.IdappUser).HasColumnName("IDAppUser");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(64)
                    .IsFixedLength();

                entity.Property(e => e.UserLevelId)
                    .HasColumnName("UserLevelID")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.UserLevel)
                    .WithMany(p => p.AppUsers)
                    .HasForeignKey(d => d.UserLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppUser_UserLevel");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Idcategory);

                entity.ToTable("Category");

                entity.HasIndex(e => e.Title, "UQ_Category_Title")
                    .IsUnique();

                entity.Property(e => e.Idcategory).HasColumnName("IDCategory");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<ChatMessage>(entity =>
            {
                entity.HasKey(e => e.IdchatMessage);

                entity.ToTable("ChatMessage");

                entity.Property(e => e.IdchatMessage).HasColumnName("IDChatMessage");

                entity.Property(e => e.ReceivingUserId).HasColumnName("ReceivingUserID");

                entity.Property(e => e.SendingUserId).HasColumnName("SendingUserID");

                entity.Property(e => e.SentDateTime)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ReceivingUser)
                    .WithMany(p => p.ChatMessageReceivingUsers)
                    .HasForeignKey(d => d.ReceivingUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChatMessage_ReceivingUser");

                entity.HasOne(d => d.SendingUser)
                    .WithMany(p => p.ChatMessageSendingUsers)
                    .HasForeignKey(d => d.SendingUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChatMessage_SendingUser");
            });

            modelBuilder.Entity<ProjectPost>(entity =>
            {
                entity.HasKey(e => e.IdprojectPost);

                entity.ToTable("ProjectPost");

                entity.Property(e => e.IdprojectPost).HasColumnName("IDProjectPost");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.AppUserId).HasColumnName("AppUserID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.DateOfCreation)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Place).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.AppUser)
                    .WithMany(p => p.ProjectPosts)
                    .HasForeignKey(d => d.AppUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectPost_AppUser");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProjectPosts)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectPost_Category");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasKey(e => e.Idreport);

                entity.ToTable("Report");

                entity.Property(e => e.Idreport).HasColumnName("IDReport");

                entity.Property(e => e.ReportReasonId).HasColumnName("ReportReasonID");

                entity.Property(e => e.ReportedUserId).HasColumnName("ReportedUserID");

                entity.Property(e => e.ReportingUserId).HasColumnName("ReportingUserID");

                entity.HasOne(d => d.ReportReason)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.ReportReasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Report_ReportReason");

                entity.HasOne(d => d.ReportedUser)
                    .WithMany(p => p.ReportReportedUsers)
                    .HasForeignKey(d => d.ReportedUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Report_ReportedUser");

                entity.HasOne(d => d.ReportingUser)
                    .WithMany(p => p.ReportReportingUsers)
                    .HasForeignKey(d => d.ReportingUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Report_ReportingUser");
            });

            modelBuilder.Entity<ReportReason>(entity =>
            {
                entity.HasKey(e => e.IdreportReason);

                entity.ToTable("ReportReason");

                entity.HasIndex(e => e.Title, "UQ_ReportReason_Title")
                    .IsUnique();

                entity.Property(e => e.IdreportReason).HasColumnName("IDReportReason");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.Idreview);

                entity.ToTable("Review");

                entity.Property(e => e.Idreview).HasColumnName("IDReview");

                entity.Property(e => e.DateOfCreation)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ReviewedUserId).HasColumnName("ReviewedUserID");

                entity.Property(e => e.ReviewingUserId).HasColumnName("ReviewingUserID");

                entity.HasOne(d => d.ReviewedUser)
                    .WithMany(p => p.ReviewReviewedUsers)
                    .HasForeignKey(d => d.ReviewedUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Review_ReviewedUser");

                entity.HasOne(d => d.ReviewingUser)
                    .WithMany(p => p.ReviewReviewingUsers)
                    .HasForeignKey(d => d.ReviewingUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Review_ReviewingUser");
            });

            modelBuilder.Entity<ServicePost>(entity =>
            {
                entity.HasKey(e => e.IdservicePost);

                entity.ToTable("ServicePost");

                entity.Property(e => e.IdservicePost).HasColumnName("IDServicePost");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.AppUserId).HasColumnName("AppUserID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.DateOfCreation)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Place).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.AppUser)
                    .WithMany(p => p.ServicePosts)
                    .HasForeignKey(d => d.AppUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServicePost_AppUser");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ServicePosts)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServicePost_Category");
            });

            modelBuilder.Entity<ServicePostImage>(entity =>
            {
                entity.HasKey(e => e.IdservicePostImage);

                entity.ToTable("ServicePostImage");

                entity.Property(e => e.IdservicePostImage).HasColumnName("IDServicePostImage");

                entity.Property(e => e.ServicePostId).HasColumnName("ServicePostID");

                entity.HasOne(d => d.ServicePost)
                    .WithMany(p => p.ServicePostImages)
                    .HasForeignKey(d => d.ServicePostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServicePostImage_ServicePost");
            });

            modelBuilder.Entity<Suspension>(entity =>
            {
                entity.HasKey(e => e.Idsuspension);

                entity.ToTable("Suspension");

                entity.Property(e => e.Idsuspension).HasColumnName("IDSuspension");

                entity.Property(e => e.AppUserId).HasColumnName("AppUserID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.ReportReasonId).HasColumnName("ReportReasonID");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.AppUser)
                    .WithMany(p => p.Suspensions)
                    .HasForeignKey(d => d.AppUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Suspension_AppUser");

                entity.HasOne(d => d.ReportReason)
                    .WithMany(p => p.Suspensions)
                    .HasForeignKey(d => d.ReportReasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Suspension_ReportReason");
            });

            modelBuilder.Entity<UserLevel>(entity =>
            {
                entity.HasKey(e => e.IduserLevel);

                entity.ToTable("UserLevel");

                entity.HasIndex(e => e.Title, "UQ_UserLevel_Title")
                    .IsUnique();

                entity.Property(e => e.IduserLevel).HasColumnName("IDUserLevel");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
