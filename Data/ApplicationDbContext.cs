using Microsoft.EntityFrameworkCore;
using StudentGPAApp.Models;

namespace StudentGPAApp.Data
{


    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<CourseGrade> CourseGrades { get; set; }
    }

}
