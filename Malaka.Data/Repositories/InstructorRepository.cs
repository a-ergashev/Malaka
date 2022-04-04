using Malaka.Data.Contexts;
using Malaka.Data.IRepositories;
using Malaka.Domain.Entities.Instructors;
using Serilog;

namespace Malaka.Data.Repositories
{
    public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(MalakaDbContext dbContext, ILogger logger)
            : base(dbContext, logger) { }
    }
}
