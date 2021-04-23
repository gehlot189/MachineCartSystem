using MachineCartSystem.Configuration;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;

namespace MachineCartSystem.Configuration
{
    //[Obsolete]
    public class JsonResolver
    {
        public static string ResolveGatewayAppSettingConfiguration(IWebHostEnvironment hostingEnvironment, string name)
        {
            var result = ReadFile(hostingEnvironment, name);
            var resultGlobal = ReadFile(hostingEnvironment, "global");

            // ResolveJwtSetting(hostingEnvironment, result.Item1);
            ResolveOpenIdConfiguration(hostingEnvironment, result.Item1);

            return WriteFile(result);
        }

        public static string ResolveGlobalConfiguration(IWebHostEnvironment hostingEnvironment)
        {
            var identityFile = Directory.GetFiles(hostingEnvironment.ContentRootPath, $"identity.{ hostingEnvironment.EnvironmentName}.json", SearchOption.AllDirectories).FirstOrDefault();
            var textFile = File.ReadAllText(identityFile);
            var jObject = JObject.Parse(textFile);

            ResolveJwtSetting(hostingEnvironment, jObject);
            ResolveOpenIdConfiguration(hostingEnvironment, jObject);

            File.WriteAllText(identityFile, jObject.ToString());
            return identityFile;
        }

        private static void ResolveOpenIdConfiguration(IWebHostEnvironment hostingEnvironment, JObject jObject)
        {
            //var openIdConfigObject = jObject.SelectToken(nameof(OpenIdConfiguration));

            //var openIdConfiguration = JsonConvert.DeserializeObject<OpenIdConfiguration>(openIdConfigObject.ToString());

            //openIdConfiguration.StsServer = jObject["IdentityServerUrl"].Value<string>();
            //openIdConfiguration.RedirectUrl = openIdConfiguration.RedirectUrl.Replace("{redirectUrl}", jObject["clientUrl"].Value<string>());
            //openIdConfiguration.PostLogoutRedirectUri = openIdConfiguration.PostLogoutRedirectUri.Replace("{postLogoutRedirectUri}", jObject["clientUrl"].Value<string>());
            //openIdConfiguration.SilentRenewUrl = openIdConfiguration.SilentRenewUrl.Replace("{silentRenewUrl}", jObject["clientUrl"].Value<string>());

            //openIdConfiguration.Scope = jObject["scope"].Value<string>();

            //jObject[nameof(OpenIdConfiguration)] = JToken.FromObject(openIdConfiguration);
        }

        private static void ResolveJwtSetting(IWebHostEnvironment hostingEnvironment, JObject jObject)
        {
            var jwtObject = jObject.SelectToken("jwt");

            var jwtConfig = JsonConvert.DeserializeObject<JwtConfig>(jwtObject.ToString());
            jwtConfig.Audiences = jObject["audiences"].Value<string>().Split(",");
            jwtConfig.Scopes = jObject["scope"].Value<string>().Split(",");

            jObject["jwt"] = JToken.FromObject(jwtConfig);
        }

        private static (JObject, string) ReadFile(IWebHostEnvironment hostingEnvironment, string name)
        {
            var file = Directory.GetFiles(hostingEnvironment.ContentRootPath, $"{name}.{ hostingEnvironment.EnvironmentName}.json", SearchOption.AllDirectories).FirstOrDefault();
            var textFile = File.ReadAllText(file);
            return (JObject.Parse(textFile), file);
        }

        private static string WriteFile((JObject, string) result)
        {
            File.WriteAllText(result.Item2, result.Item1.ToString());
            return result.Item2;
        }
    }
}
