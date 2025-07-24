

using System.Text;
using Entities.Data;
using Khayati.Core.Domain.UserServiceContracts;
using Khayati.Infrastructure.Common.Options;
using Khayati.Infrastructure.Identity.Entity;
using Khayati.Infrastructure.Identity.IdentityDTO;
using Khayati.Infrastructure.Identity.UserServices;
using Khayati.Infrastructure.Interceptors;
using Khayati.Infrastructure.Repositories.Base;
using Khayati.Infrastructure.Repositories.UserServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RepositoryContracts.Base;

namespace Khayati.Infrastructure.Extension
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection ConfigureInfrastructureService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<AuditInterceptor>();
            services.ConfigureOptions<DatabaseOptionsSetup>();
            services.ConfigureOptions<JwtSettingsOptions>();

            services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
            {
           
                // Retrieves the directory path without the last segment(Khayati.Api).
                var current = Directory.GetCurrentDirectory();

                string parentDirectory = Path.GetDirectoryName(current);

                // Path to store the database inside the Infrastructure project
                var dbPath = Path.Combine(parentDirectory, "Khayati.Infrastructure", "Databases", "mydatabase.db");

                if (!Directory.Exists(Path.GetDirectoryName(dbPath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(dbPath));
                }

                var databaseOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>()!.Value;
                var interceptor = serviceProvider.GetRequiredService<AuditInterceptor>();

                //options.UseLazyLoadingProxies();

                // Configure SQLite database context
                options.UseSqlite($"Data Source={dbPath}",
                    o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
                    .AddInterceptors(interceptor);

                options.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLoggin);
            });

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 4;
                    options.Password.RequiredUniqueChars = 0;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders()
                .AddUserStore<UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, int>>()
                .AddRoleStore<RoleStore<ApplicationRole, ApplicationDbContext, int>>();
            




            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
                    };
                });

            services.AddAuthorization();











            // Register services
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICurrentUser, CurrentUser>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }

}
