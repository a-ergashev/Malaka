using Malaka.Domain.Entities.Courses;
using Malaka.Domain.Entities.Students;
using Malaka.Domain.Entities.Instructors;
using Microsoft.EntityFrameworkCore;

namespace Malaka.Data.Contexts
{
    public class MalakaDbContext : DbContext
    {
        public MalakaDbContext(DbContextOptions<MalakaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
    }
}
