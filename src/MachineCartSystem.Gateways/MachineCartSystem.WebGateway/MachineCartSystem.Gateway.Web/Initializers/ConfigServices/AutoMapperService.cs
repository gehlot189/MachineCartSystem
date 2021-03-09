using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MachineCartSystem.Gateway.Web.Initializer
{
    public class AutoMapperService
    {
        public static void Initialize<T1, T2>(IServiceCollection services)
            where T1 : DbContext
            where T2 : class
        {
            services.AddAutoMapper((serviceProvider, automapper) =>
            {
                automapper.AddCollectionMappers();
                automapper.UseEntityFrameworkCoreModel<T1>(serviceProvider);
            }, typeof(T2).Assembly);
        }
    }
}
