using Microsoft.Extensions.DependencyInjection;

namespace MachineCartSystem.Configuration
{
    public class AutoMapperService : PreServiceInitializer
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

        public override void PreInitialize(IServiceCollection services)
        {
            //services.AddAutoMapper(p => p.AddMaps(typeof(Startup), typeof(BaseMapper)));

            //services.AddAutoMapper((serviceProvider, automapper) =>
            //{
            //    automapper.AddCollectionMappers();
            //    automapper.UseEntityFrameworkCoreModel<T1>(serviceProvider);
            //}, typeof(T2).Assembly);
            //return services;
        }
    }
}