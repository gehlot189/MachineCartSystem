using System.Threading.Tasks;

namespace MachineCartSystem.Gateway.WebService.Interface
{
    public interface ITokenConfig
    {
        Task<string> GetToken();
    }
}
