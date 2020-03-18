using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;

namespace MachineCartSystem.Configuration
{
    public static class CommonExtension
    {
        public static IServiceCollection AddAutoMapper<T1, T2>(this IServiceCollection services) where T1 : DbContext where T2 : class
        {
            services.AddAutoMapper((serviceProvider, automapper) =>
            {
                automapper.AddCollectionMappers();
                automapper.UseEntityFrameworkCoreModel<T1>(serviceProvider);
            }, typeof(T2).Assembly);
            return services;
        }
    }
}
