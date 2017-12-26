
using System.Threading.Tasks;
using Lykke.Service.BlockchainBalances.Client.AutorestClient.Models;

namespace Lykke.Service.BlockchainBalances.Client
{
    public interface IBlockchainBalancesClient
    {
        Task<BalanceModel> GetBalanceAsync(string address, Blockchain blockchain);
    }
}
