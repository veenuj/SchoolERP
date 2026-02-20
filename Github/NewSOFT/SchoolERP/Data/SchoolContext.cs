using Microsoft.EntityFrameworkCore;
using SchoolERP.Models;

namespace SchoolERP.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        // These DbSets represent the actual tables in your PostgreSQL database
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
    }
}