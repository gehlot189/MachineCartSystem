using MachineCartSystem.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace MachineCartSystem.Gateway.Web.Initializer
{
    public class AuthenticationService 
    {
        public static void Initialize(IServiceCollection services, JwtConfig jwtConfig)
        {
            var authenticationProviderKey = "TestKey";
            services.AddAuthentication()
                .AddJwtBearer(authenticationProviderKey, x =>
                {
                    x.Authority = jwtConfig.Authority;
                    x.RequireHttpsMetadata = false;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidAudiences = jwtConfig.Audiences,
                        //ValidIssuer=jwtConfig.Issuer
                    };
                });
        }
    }
}
