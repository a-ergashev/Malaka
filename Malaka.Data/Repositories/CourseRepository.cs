using Malaka.Data.Contexts;
using Malaka.Data.IRepositories;
using Malaka.Domain.Entities.Courses;
using Serilog;

namespace Malaka.Data.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(MalakaDbContext dbContext, ILogger logger)
            : base(dbContext, logger) { }
    }
}
