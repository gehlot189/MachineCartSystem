using Microsoft.Extensions.Configuration;

namespace MachineCartSystem.Configuration.Config.FileConfigProvider
{
    public class ApiConfigurationSource : IConfigurationSource
    {
        private int? _period = 60;

        public string ReqUrl { get; set; }
        public int? Period { get => _period; set=> _period=value?? _period; }
        public bool Optional { get; set; }
        public ApiEnv ApiEnv { get; set; }
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new ApiConfigurationProvider(this);
        }
    }

    public class ApiEnv
    {
        public string ApiName { get; set; }
        public string Env { get; set; }
    }
}
