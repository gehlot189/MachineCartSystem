using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MachineCartSystem.IdentityServer.Service
{
    public sealed class ClientOwner
    {
        public static IEnumerable<Client> getClient()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "angular",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireConsent = false,
                    AllowRememberConsent=false,
                    RequirePkce = true,
                    AllowAccessTokensViaBrowser=true,
                    RequireClientSecret=false,
                    // where to redirect to after login
                    RedirectUris =
                    {
                        "http://machinecartsystem.gateway.web:80/signin-oidc",
                        "http://localhost:4200/auth-callback",
                        "http://localhost:4200",
                        "http://localhost:4200/login",
                        "http://localhost:4200/silent-refresh",
                        "http://localhost:4200/silent-refresh.html",
                        "http://localhost:4200/assets/silent-refresh.html",

                        "http://localhost:2002/swagger/oauth2-redirect.html",
                        "http://localhost:2001/swagger/oauth2-redirect.html",
                        "http://host.docker.internal:5001/swagger/oauth2-redirect.html"
                    },
                    // where to redirect to after logout
                    PostLogoutRedirectUris =
                    {
                        "http://host.docker.internal:5001/signout-callback-oidc" ,
                        "http://localhost:4200",
                        "http://localhost:4200/login",
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "read:basket",
                        "write:basket",
                        "upload:basket",
                        "delete:basket",
                        "read:order",
                        "write:order",
                        "read:catalog",
                        "write:catalog"
                    },
                    AllowOfflineAccess=true,
                    AccessTokenLifetime=1200,
                   // AlwaysIncludeUserClaimsInIdToken=true,
             }
            };
        }
    };
}
