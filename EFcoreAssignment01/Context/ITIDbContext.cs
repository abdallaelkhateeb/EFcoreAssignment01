using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcoreAssignment01.Context
{
    //Fluent API
    internal class ITIDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Stud_Course> StudCourses { get; set; }
        public DbSet<Course_Inst> CourseInsts { get; set; }
        //jl
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=myServer;Database=myDB;User Id=myUser;Password=myPassword;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Department>().HasKey(d => d.ID);
            modelBuilder.Entity<Department>().Property(d => d.Name).HasMaxLength(100).IsRequired();


            modelBuilder.Entity<Stud_Course>()
           .HasKey(sc => new { sc.stud_ID, sc.Course_ID });
            modelBuilder.Entity<Course_Inst>().ToTable("Course_Inst");
            modelBuilder.Entity<Course_Inst>().HasKey(ci => new { ci.inst_ID, ci.Course_ID });
        }
    }
}
