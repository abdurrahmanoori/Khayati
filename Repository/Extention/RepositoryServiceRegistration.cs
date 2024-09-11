using Entities.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Repositories.Extention
{
    public static class RepositoryServiceRegistration
    {
        public static IServiceCollection ConfigureRepositoryService(this IServiceCollection services, IConfiguration configuration)
        {
           services.AddDbContext<ApplicationDbContext>(option =>
            {
                //    option.UseInMemoryDatabase("server=.;Database=SMSDb;Trusted_Connection=True;TrustServerCertificate=Yes;");
                //option.UseSqlite("Data Source=Khayati.db");
                option.UseSqlite(configuration.GetConnectionString("SqlLiteCS"));
            });


            return services;
        }

    }
}
