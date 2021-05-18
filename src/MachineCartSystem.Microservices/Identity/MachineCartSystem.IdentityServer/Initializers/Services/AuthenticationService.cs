using MachineCartSystem.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;

namespace MachineCartSystem.IdentityServer.Initializer
{
    public class AuthenticationService : ServiceInitializer
    {
        public override void Initialize(IServiceCollection services, JwtConfig jwtConfig)
        {
            services.AddAuthentication()
                     .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, x =>
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
            //services.AddAuthentication("MyCookie")
                       //.AddCookie("MyCookie", options =>
                       //{
                       //    options.Cookie.HttpOnly = true;
                       //    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                       //    //options.LoginPath = "/Identity/Account/Login";
                       //    //options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                       //    options.SlidingExpiration = true;
                       //    //options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Lax;
                       //    //options.Events.OnSigningOut = async p =>
                       //    //   {
                       //    //     await  p.HttpContext.RevokeUserRefreshTokenAsync();
                       //    //   };
                       //});
        }
    }
}
