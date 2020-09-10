using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolManagementSystem.Models
{
    public partial class SchoolManagementSystemDBContext : DbContext
    {
        public SchoolManagementSystemDBContext()
        {
        }

        public SchoolManagementSystemDBContext(DbContextOptions<SchoolManagementSystemDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Branch> Branch { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentCourse> StudentCourse { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=SchoolManagementSystemDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Branchname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__Course__A25C5AA62CBE7751");

                entity.Property(e => e.Code)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CourseName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("fk_Id");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.EnrollmentNo)
                    .HasName("PK__Student__ACFE49E99161BB58");

                entity.Property(e => e.EnrollmentNo)
                    .HasColumnName("enrollmentNo")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Birthdate)
                    .HasColumnName("birthdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Studentname)
                    .HasColumnName("studentname")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.StdCourseId)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.StudentId)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.StdCourse)
                    .WithMany(p => p.StudentCourse)
                    .HasForeignKey(d => d.StdCourseId)
                    .HasConstraintName("FK__StudentCo__StdCo__4222D4EF");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentCourse)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__StudentCo__Stude__412EB0B6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
