using Malaka.Data.Contexts;
using Malaka.Data.IRepositories;
using Malaka.Domain.Entities.Students;
using Serilog;

namespace Malaka.Data.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(MalakaDbContext dbContext, ILogger logger) 
            : base(dbContext, logger)
        {
        }
    }
}
