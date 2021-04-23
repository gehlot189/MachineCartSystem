using MachineCartSystem.Configuration;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;

namespace MachineCartSystem.Configuration
{
    public abstract class AppSettingResolver
    {
        protected abstract void Resolve(IWebHostEnvironment hostingEnvironment, GlobalConfiguration globalConfiguration);

        protected virtual FileSetting BaseResolve(IWebHostEnvironment hostingEnvironment, GlobalConfiguration globalConfiguration)
        {
            var result = ReadFile(hostingEnvironment);
            ResolveJwtSetting(hostingEnvironment, result.FileObject);
            return result;
        }

        private static void ResolveJwtSetting(IWebHostEnvironment hostingEnvironment, JObject jObject)
        {
            var jwtObject = jObject.SelectToken("Jwt");

            var jwtConfig = JsonConvert.DeserializeObject<JwtConfig>(jwtObject.ToString());
            jwtConfig.Audiences = jObject["Audiences"].Value<string>().Split(",");
            jwtConfig.Scopes = jObject["Scope"].Value<string>().Split(",");

            jObject["Jwt"] = JToken.FromObject(jwtConfig);
        }

        private FileSetting ReadFile(IWebHostEnvironment hostingEnvironment)
        {
            var file = Directory.GetFiles(hostingEnvironment.ContentRootPath, $"appsetting.{ hostingEnvironment.EnvironmentName}.json", SearchOption.AllDirectories).FirstOrDefault();
            var textFile = File.ReadAllText(file);
            return new FileSetting { FileObject = JObject.Parse(textFile), Path = file };
        }

        protected string WriteFile(FileSetting fileSetting)
        {
            File.WriteAllText(fileSetting.Path, fileSetting.FileObject.ToString());
            return fileSetting.Path;
        }
    }
}
