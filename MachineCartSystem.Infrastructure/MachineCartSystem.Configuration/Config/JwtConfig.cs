using System.Collections.Generic;

namespace MachineCartSystem.Configuration
{
    public sealed class JwtConfig
    {
        public string Issuer { get; internal set; }
        public char[] Key { get; internal set; }
        public IEnumerable<string> Audiences { get; internal set; }
        public string Authority { get; internal set; }
        public IEnumerable<string> Scopes { get; set; }
    }
}