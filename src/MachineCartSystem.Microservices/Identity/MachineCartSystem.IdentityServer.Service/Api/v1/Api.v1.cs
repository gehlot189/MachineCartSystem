using System;
using System.Collections.Generic;
using System.Text;
using IdentityModel;
using IdentityServer4.Models;

namespace MachineCartSystem.IdentityServer.Service
{
    public sealed class Apiv1
    {
        private Apiv1()
        {

        }

        public static IEnumerable<ApiResource> getApis() =>
         new List<ApiResource>
         {
                new ApiResource("basket", "Basket Api")
                {
                    Scopes=  { "create:events","basket"},
                    UserClaims ={ JwtClaimTypes.Role }
                },
                new ApiResource("order", "Order Api")
                {
                    Scopes= { "order" },
                    UserClaims ={ JwtClaimTypes.Role }
                   // UserClaims = new List<string> {"family_name" }
                },
                new ApiResource("payment", "Payement Api")
                {
                    Scopes= { "payment"},
                    UserClaims ={ JwtClaimTypes.Role }
                },
                new ApiResource("catalog","Catalog Api")
                {
                    Scopes={ "catalog" },
                    UserClaims ={ JwtClaimTypes.Role },
                  //  ShowInDiscoveryDocument
                }
         };
    }
}
