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

            // Student -> Department (many-to-one)
            modelBuilder.Entity<Student>()
                .HasOne<Department>()
                .WithMany()
                .HasForeignKey(s => s.Dep_Id);

            // Instructor -> Department (many-to-one)
            modelBuilder.Entity<Instructor>()
                .HasOne<Department>()
                .WithMany()
                .HasForeignKey(i => i.Dept_ID);

            // Department -> Manager (Instructor) (one-to-one)
            modelBuilder.Entity<Department>()
                .HasOne<Instructor>()
                .WithMany()
                .HasForeignKey(d => d.Ins_ID)
                .OnDelete(DeleteBehavior.Restrict);

            // Course -> Topic (many-to-one)
            modelBuilder.Entity<Course>()
                .HasOne<Topic>()
                .WithMany()
                .HasForeignKey(c => c.Top_ID);

            // Stud_Course (many-to-many Student <-> Course)
            modelBuilder.Entity<Stud_Course>()
                .HasKey(sc => new { sc.stud_ID, sc.Course_ID });

            modelBuilder.Entity<Stud_Course>()
                .HasOne<Student>()
                .WithMany()
                .HasForeignKey(sc => sc.stud_ID);

            modelBuilder.Entity<Stud_Course>()
                .HasOne<Course>()
                .WithMany()
                .HasForeignKey(sc => sc.Course_ID);

            // Course_Inst (many-to-many Course <-> Instructor)
            modelBuilder.Entity<Course_Inst>()
                .HasKey(ci => new { ci.inst_ID, ci.Course_ID });

            modelBuilder.Entity<Course_Inst>()
                .HasOne<Instructor>()
                .WithMany()
                .HasForeignKey(ci => ci.inst_ID);

            modelBuilder.Entity<Course_Inst>()
                .HasOne<Course>()
                .WithMany()
                .HasForeignKey(ci => ci.Course_ID);
        }
    }
    }

