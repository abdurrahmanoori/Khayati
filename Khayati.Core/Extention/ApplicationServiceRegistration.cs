using Khayati.Service;
using Khayati.ServiceContracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Khayati.Core.Extention
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection ConfigureApplicationService(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IEmbellishmentService, EmbellishmentService>();
            services.AddScoped<EmbellishmentTypeService, EmbellishmentTypeService>();
            // Optionally, you could use a connection string from configuration:
            // options.UseSqlite(configuration.GetConnectionString("SqlLiteCS"));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
