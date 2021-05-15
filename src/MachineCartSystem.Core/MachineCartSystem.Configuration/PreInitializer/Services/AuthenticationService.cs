using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace MachineCartSystem.Configuration
{
    public class AuthenticationService : PreServiceInitializer
    {
        public override void PreInitialize(IServiceCollection services, JwtConfig jwtConfig)
        {
            if (jwtConfig.ApiName == ApiName.Gateway)
            {
                services.AddAuthentication()
                .AddJwtBearer(AuthSchemes.ApiScheme, x =>
                {
                    x.Authority = jwtConfig.Authority;
                    x.RequireHttpsMetadata = false;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidAudiences = jwtConfig.Audiences,
                        RequireAudience = true,
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidIssuer = jwtConfig.Issuer
                    };
                })
                .AddJwtBearer(AuthSchemes.GatewayScheme, x =>
                {
                    x.Authority = jwtConfig.Authority;
                    x.RequireHttpsMetadata = false;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        RequireSignedTokens = false,
                        ValidateIssuerSigningKey = false,
                        RequireExpirationTime = false,
                    };
                });
                //.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, option =>
                //{
                //    option.Authority = jwtConfig.Authority;
                //    option.RequireHttpsMetadata = false;
                //    option.TokenValidationParameters = new TokenValidationParameters
                //    {
                //        ValidAudiences = jwtConfig.Audiences,
                //        RequireAudience = true,
                //        ValidateAudience = true,
                //        ValidateIssuer = true,
                //        ValidIssuer = jwtConfig.Issuer
                //    };
                //});
            }
            else if (jwtConfig.ApiName == ApiName.Identity)
            {
                //ToDo: Will be added later on
            }
            else
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
}
