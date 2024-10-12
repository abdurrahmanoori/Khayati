using Khayati.Service;
using Khayati.ServiceContracts;

namespace Khayati.Mvc.Extenstion
{
    public static class PresentionServiceRegistration

    {
        public static IServiceCollection ConfigurePresentionService(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IEmbellishmentTypeService, EmbellishmentTypeService>();

            return services;
        }
    }
}
