using System.Threading.Tasks;
using Lykke.Service.BlockchainBalances.Core.Domain;

namespace Lykke.Service.BlockchainBalances.Core.Services
{
    public interface IBlockchainBalanceService
    {
        Task<BalanceModel> GetBalanceAsync(string address, Blockchain blockchain);
    }
}
