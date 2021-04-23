using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json.Linq;

namespace MachineCartSystem.Configuration
{
    public class FileSetting
    {
        public JObject FileObject { get; set; }
        public string Path { get; set; }
    }
}