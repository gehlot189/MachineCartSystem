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
                    Scopes=  { "basket.read"},
                 //   UserClaims ={ JwtClaimTypes.Role }
                },
                new ApiResource("order", "Order Api")
                {
                    Scopes= { "order.read" },
                 //   UserClaims ={ JwtClaimTypes.Role }
                   // UserClaims = new List<string> {"family_name" }
                },
                new ApiResource("payment", "Payement Api")
                {
                    Scopes= { "payment.read"},
                 //   UserClaims ={ JwtClaimTypes.Role }
                },
                new ApiResource("catalog","Catalog Api")
                {
                    Scopes={ "catalog.read" },
                 //   UserClaims ={ JwtClaimTypes.Role },
                  //  ShowInDiscoveryDocument
                }
         };
    }
}
