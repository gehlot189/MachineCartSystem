using System.Collections.Generic;

namespace MachineCartSystem.Configuration
{
    public sealed class JwtConfig
    {
        public string Issuer { get; set; }
        public Signing Key { get; set; }
        public IEnumerable<string> Audiences { get; set; }
        public string Authority { get; set; }
        public IEnumerable<string> Scopes { get; set; }
        public ApiName ApiName { get; set; }
    }

    public sealed class Signing
    {
        public string PrivateKey { get; set; }
    }
}