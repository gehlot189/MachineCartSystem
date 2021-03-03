using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace MachineCartSystem.Configuration
{
    public static class AuthenticationExtension
    {
        // TODO : Microsoft.Extensions.Configuration.SecretManager
        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, JwtConfig jwtConfig)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                    option.Authority = jwtConfig.Issuer;
                    option.RequireHttpsMetadata = false;
                    option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidAudience = jwtConfig.Audiences.First()
                    };
                });
            return services;
        }
    }
}
