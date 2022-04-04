using System;
using System.Threading.Tasks;

namespace Malaka.Data.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Students { get; }
        IInstructorRepository Instructors { get; }
        ICourseRepository Courses { get; }
        Task SaveChangesAsync();
    }
}
