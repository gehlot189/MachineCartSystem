using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

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
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidAudiences = new[] { jwtConfig.Audience },
                        // RoleClaimType = "role",
                        //NameClaimType = "name",
                        // RoleClaimType = "role"
                    };

                    //option.ApiName = "api1";
                    // option.Audience = "api1";
                    //   option.SaveToken = true;
                    //option.TokenValidationParameters = new TokenValidationParameters
                    //{
                    //    ValidateIssuer = true,
                    //    ValidateAudience = true,
                    //    ValidateLifetime = true,
                    //    ValidateIssuerSigningKey = true,

                    //    ValidIssuer = jwtConfig.Issuer,
                    //    ValidAudience = jwtConfig.Issuer,
                    //    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key))
                    //};
                });
            return services;
        }
    }
}
