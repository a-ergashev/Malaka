using Malaka.Data.Contexts;
using Malaka.Data.IRepositories;
using Malaka.Domain.Entities.Courses;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malaka.Data.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(MalakaDbContext dbContext, ILogger logger)
            : base(dbContext, logger) { }
    }
}
