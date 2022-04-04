using System;
using System.Threading.Tasks;

namespace Malaka.Data.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Students { get; }
        Task SaveChangesAsync();
    }
}
