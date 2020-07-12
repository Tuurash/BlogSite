using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VlogSite.Models
{
    public partial class BlogContext : DbContext
    {
        public BlogContext()
        {
        }

        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BlogTbl> BlogTbl { get; set; }
        public virtual DbSet<ContactTbl> ContactTbl { get; set; }
        public virtual DbSet<UserTbl> UserTbl { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-G09H2OK\\SQLEXPRESS;Initial Catalog=Blog;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogTbl>(entity =>
            {
                entity.HasKey(e => e.BlogId);

                entity.ToTable("blogTBL");

                entity.Property(e => e.BlogId).HasColumnName("blogID");

                entity.Property(e => e.BlogBody)
                    .HasColumnName("blogBody")
                    .HasMaxLength(3999);

                entity.Property(e => e.BlogName)
                    .IsRequired()
                    .HasColumnName("blogName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BlogPhoto)
                    .HasColumnName("blogPhoto")
                    .HasMaxLength(3000);

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BlogTbl)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_blogTBL_userTBL");
            });

            modelBuilder.Entity<ContactTbl>(entity =>
            {
                entity.HasKey(e => e.ContactId);

                entity.ToTable("contactTBL");

                entity.Property(e => e.ContactId).HasColumnName("contactID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.LinkedinUrl).HasMaxLength(100);

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.WebsiteUrl)
                    .HasColumnName("websiteUrl")
                    .HasMaxLength(100);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ContactTbl)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_contactTBL_userTBL");
            });

            modelBuilder.Entity<UserTbl>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("userTBL");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.UserAbout)
                    .HasColumnName("userAbout")
                    .HasMaxLength(1000);

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasColumnName("userEmail")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("userPassword")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPhoto)
                    .HasColumnName("userPhoto")
                    .HasMaxLength(3000);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
