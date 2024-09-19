using Microsoft.Extensions.DependencyInjection;
using Repositories.Base;
using RepositoryContracts.Base;

namespace Khayati.Service.Extention
{
    public static class ServiceServiceRegistration
    {
        public static IServiceCollection ConfigureServiceService(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;

        }
    }
}
