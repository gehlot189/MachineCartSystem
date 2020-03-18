namespace MachineCartSystem.Gateway.WebService
{
    public sealed class DbConfig
    {
        public string ConnectionString { get; set; }
        public int? MaxRetryCount { get; set; }
        public int? MaxRetryDelayInSeconds { get; set; }
    }
}



