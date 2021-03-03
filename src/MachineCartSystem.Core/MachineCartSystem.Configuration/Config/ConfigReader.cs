using Microsoft.Extensions.Configuration;
using System.IO;

namespace MachineCartSystem.Configuration
{
    public class ConfigReader
    {
        public static IConfiguration GetConfig(string env)
        {
            var configurationBuilder = new ConfigurationBuilder();
            var dd = Directory.GetCurrentDirectory();
            var path = Path.Combine(Directory.GetCurrentDirectory(), $"identity.{env}.json");

            //var path = Path.Combine(Directory.GetParent("./../..").FullName, @"MachineCartSystem.Core\MachineCartSystem.Configuration", $"identity.{env}.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            return root;
        }
    }
}
