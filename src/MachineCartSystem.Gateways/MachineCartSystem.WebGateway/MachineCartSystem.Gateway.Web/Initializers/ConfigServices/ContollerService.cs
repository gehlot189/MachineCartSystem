using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace MachineCartSystem.Gateway.Web.Initializer
{
    public class ContollerService : IServiceInitializer
    {
        public void Initialize(IServiceCollection services, IConfiguration configuration)
        {
            // services.AddControllers().AddNewtonsoftJson();
            services.AddControllers().AddNewtonsoftJson(P =>
            {
                P.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                P.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.All;
            });
                //.AddJsonOptions(o => o.JsonSerializerOptions
                //       .ReferenceHandler = ReferenceHandler.Preserve);
        }
    }
}
