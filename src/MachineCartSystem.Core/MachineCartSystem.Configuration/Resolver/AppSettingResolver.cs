using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;

namespace MachineCartSystem.Configuration
{
    public abstract class BaseAppSettingResolver
    {
        public abstract string Resolve(AppSetting appSetting);

        public virtual FileSetting BaseResolve(AppSetting appSetting)
        {
            var result = ReadFile(appSetting);
            ResolveJwtSetting(appSetting.Environment, result.FileObject);
            return result;
        }

        private static void ResolveJwtSetting(IWebHostEnvironment hostingEnvironment, JObject jObject)
        {
            var jwtObject = jObject.SelectToken("jwt");

            var jwtConfig = JsonConvert.DeserializeObject<JwtConfig>(jwtObject.ToString());
            jwtConfig.Audiences = jObject["audiences"].Value<string>().Split(",");
            jwtConfig.Scopes = jObject["scope"].Value<string>().Split(",");

            jObject["jwt"] = JToken.FromObject(jwtConfig);
        }

        private FileSetting ReadFile(AppSetting appSetting)
        {
            var file = Directory.GetFiles(appSetting.Environment.ContentRootPath, $"{appSetting.Name}.{ appSetting.Environment.EnvironmentName}.json", SearchOption.AllDirectories).FirstOrDefault();
            var textFile = File.ReadAllText(file);
            return new FileSetting { FileObject = JObject.Parse(textFile), Path = file };
        }

        public string WriteFile(FileSetting fileSetting)
        {
            File.WriteAllText(fileSetting.Path, fileSetting.FileObject.ToString());
            return fileSetting.Path;
        }
    }
}
