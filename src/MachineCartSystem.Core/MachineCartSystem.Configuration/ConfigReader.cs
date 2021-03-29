using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

namespace MachineCartSystem.Shared
{
    public class ConfigReader
    {
        public static IConfiguration GetConfig(string env)
        {
            var configurationBuilder = new ConfigurationBuilder();
            var dcInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            var path = dcInfo.GetFiles($"identity.{env}.json", SearchOption.AllDirectories).FirstOrDefault().FullName;
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            return root;
        }
    }
}
