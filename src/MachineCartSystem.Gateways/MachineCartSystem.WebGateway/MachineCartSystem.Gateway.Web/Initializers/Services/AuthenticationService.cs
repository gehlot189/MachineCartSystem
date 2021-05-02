using MachineCartSystem.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace MachineCartSystem.Gateway.Web.Initializer
{
    public class AuthenticationService : ServiceInitializer
    {
        public override void Initialize(IServiceCollection services, JwtConfig jwtConfig)
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
        }
    }
}
