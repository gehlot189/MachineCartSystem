using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineCartSystem.Configuration
{
    public class AppSetting
    {
        public IWebHostEnvironment Environment { get; set; }
        public string Name { get; set; }
    }

    public class FileSetting
    {
        public JObject FileObject  { get; set; }
        public string Path { get; set; }
    }


}
