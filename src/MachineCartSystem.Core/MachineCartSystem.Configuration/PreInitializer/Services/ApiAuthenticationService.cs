using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace MachineCartSystem.Configuration
{
    public class ApiAuthenticationService : PreServiceInitializer
    {
        public override void PreInitialize(IServiceCollection services, JwtConfig jwtConfig)
        {
            services.AddAuthentication()
           .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, option =>
           {
               option.Authority = jwtConfig.Authority;
               option.RequireHttpsMetadata = false;
               option.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidAudiences = jwtConfig.Audiences,
                   RequireAudience = true,
                   ValidateAudience = true,
                   ValidateIssuer = true,
                   ValidIssuer = jwtConfig.Issuer
               };
           });
        }
    }
}
