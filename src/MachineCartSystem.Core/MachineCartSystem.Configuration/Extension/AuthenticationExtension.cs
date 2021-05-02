using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace MachineCartSystem.Configuration
{
    public static class AuthenticationExtension
    {
        // TODO : Microsoft.Extensions.Configuration.SecretManager
        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, JwtConfig jwtConfig)
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
            return services;
        }
    }
}
