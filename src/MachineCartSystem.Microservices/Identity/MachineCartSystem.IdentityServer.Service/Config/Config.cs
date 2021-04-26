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
                new ApiScope("create:events", "Read Access to Basket Api"),
                new ApiScope("update:events", "Write Access to Basket Api"),
                new ApiScope("view:events", "Write Access to Basket Api"),
                new ApiScope("register:events", "Write Access to Basket Api"),

                new ApiScope("basket.read", "Read Access to Basket Api"),

                new ApiScope("order.read", "Read Access to Order Api"),
                new ApiScope("order.write", "Write Access to Order Api"),

                new ApiScope("catalog.read", "Read Access to Catalog Api"),
                new ApiScope("catalog.write", "Write Access to Catalog Api"),
         };
    }
}
