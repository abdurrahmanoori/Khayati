using Entities.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO; // Ensure this namespace is included for Path and Directory

namespace Repositories.Extension
{
    public static class RepositoryServiceRegistration
    {
        public static IServiceCollection ConfigureRepositoryService(this IServiceCollection services, IConfiguration configuration)
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

            // Optionally, you could use a connection string from configuration:
            // options.UseSqlite(configuration.GetConnectionString("SqlLiteCS"));

            return services;
        }
    }
}
