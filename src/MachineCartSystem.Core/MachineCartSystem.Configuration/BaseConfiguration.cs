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
                var scope = Configuration[lst[i] + ":Scopes"];
                if (!string.IsNullOrEmpty(scope))
                    scopes.Add(scope);
                var audience = Configuration[lst[i] + ":Audiences"];
                if (!string.IsNullOrEmpty(audience))
                    audiences.Add(audience);
            }
            Configuration["Scopes"] = string.Join(",", scopes);
            Configuration["Audiences"] = string.Join(",", audiences);
            return (scopes, audiences);
        }
    }
}