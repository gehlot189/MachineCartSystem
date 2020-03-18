using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace MachineCartSystem.Gateway.WebService.Initializers.Services
{
    public class AuthenticationService
    {
        public static void Initialize(IServiceCollection services, JwtConfig jwtConfig)
        {
            var authenticationProviderKey = "TestKey";

            services.AddAuthentication()
                .AddIdentityServerAuthentication(authenticationProviderKey, x =>
                {
                    x.Authority = jwtConfig.Authority;
                    x.RequireHttpsMetadata = false;
                    //// x.Audience = "basket";

                    //x.TokenValidationParameters = new TokenValidationParameters
                    //{
                    //    ValidAudiences = new[] { "basket" }
                    //};
                    // x.Audience = "openid";
                    //x.TokenValidationParameters = new TokenValidationParameters
                    //{

                    //    ValidateIssuer = true,
                    //    ValidateAudience = true,
                    //    ValidateLifetime = true,
                    //    ValidateIssuerSigningKey = true,
                    ////    validissuer = jwtconfig.issuer,
                    //   // validaudience = jwtconfig.audience,
                    //    ValidAudiences = new[] { "api1" },
                    //    //   issuersigningkey = new symmetricsecuritykey(encoding.utf8.getbytes(configuration["jwt:key"]))
                    //};
                });
        }
    }
}
