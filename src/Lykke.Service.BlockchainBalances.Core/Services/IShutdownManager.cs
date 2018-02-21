using System.Threading.Tasks;

namespace Lykke.Service.BlockchainBalances.Core.Services
{
    public interface IShutdownManager
    {
        Task StopAsync();
    }
}