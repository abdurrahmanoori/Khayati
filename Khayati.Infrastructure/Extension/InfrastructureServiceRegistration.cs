﻿using Entities.Data;
using Khayati.Core.Domain.UserServiceContracts;
using Khayati.Infrastructure.Common.Options;
using Khayati.Infrastructure.Interceptors;
using Khayati.Infrastructure.Repositories.UserServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Repositories.Base;
using RepositoryContracts.Base;
using System;

namespace Khayati.Infrastructure.Extension
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection ConfigureInfrastructureService(this IServiceCollection services)
        {

            services.AddScoped<AuditInterceptor>();
            services.ConfigureOptions<DatabaseOptionsSetup>();
            services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
            {
                // Set your custom path for the SQLite database
                var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "Databases", "mydatabase.db");

                // Ensure the directory exists
                if (!Directory.Exists(Path.GetDirectoryName(dbPath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(dbPath));
                }
                var databaseOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>()!.Value;
                
                var interceptor = serviceProvider.GetRequiredService<AuditInterceptor>();
                // Configure the SQLite DbContext
                options.UseSqlite($"Data Source={dbPath}")
                .AddInterceptors(interceptor);
                options.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLoggin);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICurrentUser, CurrentUser>();

            return services;

        }
    }
}
