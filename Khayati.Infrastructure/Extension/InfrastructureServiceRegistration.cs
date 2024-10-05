using Entities.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Base;
using RepositoryContracts.Base;

namespace Khayati.Infrastructure.Extension
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection ConfigureInfrastructureService(this IServiceCollection services)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                // Set your custom path for the SQLite database
                var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "Databases", "mydatabase.db");

                // Ensure the directory exists
                if (!Directory.Exists(Path.GetDirectoryName(dbPath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(dbPath));
                }

                // Configure the SQLite DbContext
                options.UseSqlite($"Data Source={dbPath}");
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;

        }
    }
}
