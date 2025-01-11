using Entities.Data;
using Khayati.Core.Domain.UserServiceContracts;
using Khayati.Infrastructure.Common.Options;
using Khayati.Infrastructure.Identity.Entity;
using Khayati.Infrastructure.Identity.UserServices;
using Khayati.Infrastructure.Interceptors;
using Khayati.Infrastructure.Repositories.UserServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Repositories.Base;
using RepositoryContracts.Base;
using System;
using System.Collections.Generic;
using System.IO;


namespace Khayati.Infrastructure.Extension
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection ConfigureInfrastructureService(this IServiceCollection services)
        {
            services.AddScoped<AuditInterceptor>();
            services.ConfigureOptions<DatabaseOptionsSetup>();

            // Configure DbContext for SQLite
            services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
            {

           
                // Retrieves the directory path without the last segment(Khayati.Api).
                var current = Directory.GetCurrentDirectory();

                string parentDirectory = Path.GetDirectoryName(current);

                // Path to store the database inside the Infrastructure project
                var dbPath = Path.Combine(parentDirectory, "Khayati.Infrastructure", "Databases", "mydatabase.db");
                // Ensure the directory exists
                if (!Directory.Exists(Path.GetDirectoryName(dbPath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(dbPath));
                }

                var databaseOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>()!.Value;
                var interceptor = serviceProvider.GetRequiredService<AuditInterceptor>();

                // Configure SQLite database context
                options.UseSqlite($"Data Source={dbPath}",
                    o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
                    .AddInterceptors(interceptor);

                options.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLoggin);
            });

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders()
                .AddUserStore<UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, int>>()
                .AddRoleStore<RoleStore<ApplicationRole, ApplicationDbContext, int>>();

            // Register services
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICurrentUser, CurrentUser>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }

}
