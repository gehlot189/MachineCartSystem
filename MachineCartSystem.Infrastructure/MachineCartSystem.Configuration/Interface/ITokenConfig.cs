using System.Threading.Tasks;

namespace MachineCartSystem.Configuration.Interface
{
    public interface ITokenConfig
    {
        Task<string> GetToken();
    }
}
