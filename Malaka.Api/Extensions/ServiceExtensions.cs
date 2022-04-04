using Malaka.Data.IRepositories;
using Malaka.Data.Repositories;
using Malaka.Service.Interfaces;
using Malaka.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Malaka.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IStudentService, StudentService>();
        }
    }
}
