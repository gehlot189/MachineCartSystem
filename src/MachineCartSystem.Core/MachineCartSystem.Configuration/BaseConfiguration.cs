using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace MachineCartSystem.Configuration
{
    public abstract class BaseConfiguration
    {
        public BaseConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected IConfiguration Configuration;

        protected (IEnumerable<string>, IEnumerable<string>) GetAllScopesAndAudiences()
        {
            var scopes = new List<string>();
            var audiences = new List<string>();
            var lst = Enum.GetNames(typeof(ApiName));
            for (int i = 0; i < lst.Length; i++)
            {
                for (int j = 0; j < lst.Length; j++)
                {
                    var scope = Configuration[lst[i] + ":Scopes:" + j];
                    if (scope == null)
                        break;
                    scopes.Add(scope);
                    Configuration["Scopes:" + i] = scope;
                }

                for (int j = 0; j < lst.Length; j++)
                {
                    var audience = Configuration[lst[i] + ":Audiences:" + j];
                    if (audience == null)
                        break;
                    audiences.Add(audience);
                    Configuration["Audiences:" + i] = audience;
                }
            }
            //Configuration["Scopes"] = JsonConvert.SerializeObject(scopes);
            //Configuration["Audiences"] = JsonConvert.SerializeObject(audiences);
            return (scopes, audiences);
        }
    }
}