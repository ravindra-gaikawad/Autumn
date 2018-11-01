using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Autumn.API.Models
{
    public partial class AutumnDBContext : DbContext
    {
        public AutumnDBContext()
        {
        }

        public AutumnDBContext(DbContextOptions<AutumnDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<BookPage> BookPage { get; set; }
        public virtual DbSet<Diary> Diary { get; set; }
        public virtual DbSet<DiaryPage> DiaryPage { get; set; }
        public virtual DbSet<Episode> Episode { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Wish> Wish { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=AutumnDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [TempSequence])");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Book_User");
            });

            modelBuilder.Entity<BookPage>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [TempSequence])");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Sequence).HasDefaultValueSql("((1))");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookPage)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookPage_Book");
            });

            modelBuilder.Entity<Diary>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [TempSequence])");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Diary)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Diary_User");
            });

            modelBuilder.Entity<DiaryPage>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [TempSequence])");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Sequence).HasDefaultValueSql("((1))");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Diary)
                    .WithMany(p => p.DiaryPage)
                    .HasForeignKey(d => d.DiaryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DiaryPage_Diary");
            });

            modelBuilder.Entity<Episode>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [TempSequence])");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Episode)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Episode_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [TempSequence])");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Lastname).HasMaxLength(50);
            });

            modelBuilder.Entity<Wish>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [TempSequence])");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Wish)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wish_User");
            });

            modelBuilder.HasSequence("TempSequence").HasMin(1);
        }
    }
}
