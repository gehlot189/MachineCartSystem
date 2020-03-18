namespace MachineCartSystem.Configuration
{
    public sealed class JwtConfig
    {
        public string Issuer { get; set; }
        public char[] Key { get; internal set; }
        public string Audience { get; internal set; }
    }
}