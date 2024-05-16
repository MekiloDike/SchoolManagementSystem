using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.DTO;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Repository.Implementation;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace SchoolManagementSystem.DbContext
{
    public class AppDBContext : IdentityDbContext<Users>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }
        public DbSet<Address> Address { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<NonAcademic> NonAcademics { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        //public DbSet<Users> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Customize the Identity model if needed
            // Add additional configurations, indexes, etc.

        }
    }
}
