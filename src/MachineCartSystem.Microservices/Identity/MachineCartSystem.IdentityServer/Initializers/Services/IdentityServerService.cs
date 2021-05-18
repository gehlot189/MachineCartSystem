using IdentityServerHost.Quickstart.UI;
using MachineCartSystem.IdentityServer.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MachineCartSystem.IdentityServer.Initializer
{
    public class IdentityServerService: ServiceInitializer
    {
        public override void Initialize(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews();

            //services.AddAccessTokenManagement();

            services.AddIdentityServer(p =>
                    {
                        p.IssuerUri = configuration.GetValue<string>("Issuer");
                        //p.Caching=new IdentityServer4.Configuration.CachingOptions { }
                    })
                    .AddInMemoryIdentityResources(Config.Ids)
                    .AddInMemoryApiResources(Config.Apis)
                    .AddInMemoryApiScopes(Config.ApiScopes)
                    .AddInMemoryClients(Config.Clients)
                    .AddDeveloperSigningCredential()
                    .AddTestUsers(TestUsers.Users);

            // services.AddScoped<IProfileService, ProfileService>();

            //services.ConfigureApplicationCookie(options =>
            //{
            //    // Cookie settings
            //    options.Cookie.HttpOnly = true;
            //    options.ExpireTimeSpan = TimeSpan.FromSeconds(10);
            //    //options.LoginPath = "/Identity/Account/Login";
            //    //options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            //    options.SlidingExpiration = true;
            //});
        }
    }
}
