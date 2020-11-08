using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MachineCartSystem.Configuration
{
    public static class DbExtension
    {
        public static IServiceCollection AddEFCore<T>(this IServiceCollection services, DbConfig dbConfig) where T : DbContext
        {
            services.AddDbContext<T>(options =>
            {
                options.UseSqlServer(dbConfig.ConnectionString, sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: dbConfig.MaxRetryCount ?? 0,
                        maxRetryDelay: TimeSpan.FromSeconds(dbConfig.MaxRetryDelayInSeconds ?? 0),
                        errorNumbersToAdd: null);
                });
            });
            return services;
        }
    }
}

