using MachineCartSystem.Configuration;
using MachineCartSystem.Gateway.WebService.Model.OpenIdConfiguration;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;

namespace MachineCartSystem.Gateway.WebService.Resolver
{
    public class JsonResolver
    {
        public static string ResolveIdentityConfigurationSetting(IWebHostEnvironment hostingEnvironment)
        {
            var identityFile = Directory.GetFiles(hostingEnvironment.ContentRootPath, $"identity.{ hostingEnvironment.EnvironmentName}.json", SearchOption.AllDirectories).FirstOrDefault();
            var textFile = File.ReadAllText(identityFile);
            var jObject = JObject.Parse(textFile);

            ResolveJwtSetting(hostingEnvironment, jObject);
            ResolveOpenIdConfigurationSetting(hostingEnvironment, jObject);

            File.WriteAllText(identityFile, jObject.ToString());
            return identityFile;
        }

        private static void ResolveOpenIdConfigurationSetting(IWebHostEnvironment hostingEnvironment,JObject jObject)
        {
            var openIdConfigObject = jObject.SelectToken("openIdConfiguration");

            var openIdConfiguration = JsonConvert.DeserializeObject<OpenIdConfiguration>(openIdConfigObject.ToString());

            openIdConfiguration.StsServer = jObject["identityServerUrl"].Value<string>();
            openIdConfiguration.RedirectUrl = openIdConfiguration.RedirectUrl.Replace("{redirectUrl}", jObject["clientUrl"].Value<string>());
            openIdConfiguration.PostLogoutRedirectUri = openIdConfiguration.PostLogoutRedirectUri.Replace("{postLogoutRedirectUri}", jObject["clientUrl"].Value<string>());
            openIdConfiguration.SilentRenewUrl = openIdConfiguration.SilentRenewUrl.Replace("{silentRenewUrl}", jObject["clientUrl"].Value<string>());

            openIdConfiguration.Scope = jObject["scope"].Value<string>();

            jObject["openIdConfiguration"] = JToken.FromObject(openIdConfiguration);
        }

        private static void ResolveJwtSetting(IWebHostEnvironment hostingEnvironment, JObject jObject)
        {
            var jwtObject = jObject.SelectToken("jwt");

            var jwtConfig = JsonConvert.DeserializeObject<JwtConfig>(jwtObject.ToString());
            jwtConfig.Audiences = jObject["audiences"].Value<string>().Split(",");
            jwtConfig.Scopes = jObject["scope"].Value<string>().Split(",");

            jObject["jwt"] = JToken.FromObject(jwtConfig);
        }
    }
}
