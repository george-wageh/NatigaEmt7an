using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NatigaEmt7an.Models.Models;

namespace NatigaEmt7an.Api.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Governorate> Governorates { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<SchoolAdministration> SchoolAdministrations { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentGrade> StudentGrades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School>()
               .HasOne(s => s.SchoolAdministration)
               .WithMany(sa => sa.Schools)
               .HasForeignKey(s => s.SchoolAdministrationId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>()
               .HasOne(s => s.SchoolAdministration)
               .WithMany(sa => sa.Students)
               .HasForeignKey(s => s.SchoolAdministrationId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>()
               .HasOne(s => s.School)
               .WithMany(sa => sa.Students)
               .HasForeignKey(s => s.SchoolId)
               .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Student>().HasIndex(x => x.SeatNumber).IsUnique();
            modelBuilder.Entity<Student>().HasIndex(x => x.TotalGrades);
            modelBuilder.Entity<Student>().HasIndex(x => x.Category);
            modelBuilder.Entity<Student>().HasIndex(x => x.Status);

        }
    }
}
