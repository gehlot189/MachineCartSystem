namespace MachineCartSystem.Gateway.WebService
{
    public sealed class JwtConfig
    {
        public string Issuer { get; internal set; }
        public char[] Key { get; internal set; }
        public string Audience { get; internal set; }
        public string Authority { get; internal set; }
    }
}