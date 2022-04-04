using Malaka.Data.Contexts;
using Malaka.Data.IRepositories;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using System;
using System.Threading.Tasks;

namespace Malaka.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MalakaDbContext context;
        private readonly ILogger logger;
        private readonly IConfiguration config;

        /// <summary>
        /// Repositories
        /// </summary>
        public IStudentRepository Students { get; private set; }
        public IInstructorRepository Instructors { get; private set; }
        public ICourseRepository Courses { get; private set; }
        public UnitOfWork(MalakaDbContext context, IConfiguration config)
        {
            this.context = context;
            this.config = config;
            this.logger = new LoggerConfiguration()
                .WriteTo.File
                (
                    path: "Logs/logs.txt",
                    outputTemplate: config.GetSection("Serilog:OutputTemplate").Value,
                    rollingInterval: RollingInterval.Day,
                    restrictedToMinimumLevel: LogEventLevel.Information
                ).CreateLogger();

            // Object initializing for repositories
            Students = new StudentRepository(context, logger);
            Instructors = new InstructorRepository(context, logger);
            Courses = new CourseRepository(context, logger);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
