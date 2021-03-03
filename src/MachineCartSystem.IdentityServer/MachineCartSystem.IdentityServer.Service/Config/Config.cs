using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace MachineCartSystem.IdentityServer.Service
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
               new IdentityResources.OpenId(),
               new IdentityResources.Profile(),
               new IdentityResources.Email(),
            };
        public static IEnumerable<ApiResource> Apis => Apiv1.getApis();
        public static IEnumerable<Client> Clients => ClientOwner.getClient();
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("basket", "Read Access to Basket Api"),
                new ApiScope("order", "Read Access to Order Api"),
                new ApiScope("catalog", "Read Access to Catalog Api"),

         };
    }
}
