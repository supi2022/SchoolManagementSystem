using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem
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
        public virtual DbSet<Student> Student { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.EnrollmentNo);

                entity.ToTable("Student");

                entity.Property(e => e.Studentname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Age)
                    .IsRequired();

                entity.Property(e => e.Birthdate)
                    .IsRequired();
                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(50);

            });
        }
        public DbSet<SchoolManagementSystem.Models.Courses> Courses { get; set; }
        public DbSet<SchoolManagementSystem.Models.Branch> Branch { get; set; }
    }
}
