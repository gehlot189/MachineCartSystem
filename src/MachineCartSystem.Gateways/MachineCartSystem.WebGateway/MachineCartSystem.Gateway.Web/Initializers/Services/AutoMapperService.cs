using MachineCartSystem.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MachineCartSystem.Gateway.Web.Initializer
{
    public class AutoMapperService : ServiceInitializer
    {
        //public override void Initialize<T>(IServiceCollection services) where T : DbContext
        //{
        //    //_ = services.AddAutoMapper(p =>
        //    //  {
        //    //      p.AddMaps(GetType().Assembly);
        //    //  });

        //    //services.AddAutoMapper((serviceProvider, automapper) =>
        //    //{
        //    //    automapper.AddCollectionMappers();
        //    //    automapper.UseEntityFrameworkCoreModel<T1>(serviceProvider);
        //    //}, typeof(T2).Assembly);
        //}

        public override void Initialize(IServiceCollection services)
        {
            services.AddAutoMapper(p => p.AddMaps(typeof(Startup), typeof(BaseMapper)));
        }
    }
}