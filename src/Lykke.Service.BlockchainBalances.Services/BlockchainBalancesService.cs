using System;
using System.Numerics;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Lykke.Service.BlockchainBalances.Core.Domain;
using Lykke.Service.BlockchainBalances.Core.Services;
using Nethereum.Util;
using BalanceModel = Lykke.Service.BlockchainBalances.Core.Domain.BalanceModel;

namespace Lykke.Service.BlockchainBalances.Services
{
    public class BlockchainBalancesService : IBlockchainBalanceService
    {
        private const decimal BtcMultiplier = 0.00000001m;
        private readonly string _ninjaUrl;
        private readonly string _samuraiUrl;

        public BlockchainBalancesService(
            string ninjaUrl,
            string samuraiUrl
            )
        {
            _ninjaUrl = ninjaUrl;
            _samuraiUrl = samuraiUrl;
        }

        public async Task<BalanceModel> GetBalanceAsync(string address, Blockchain blockchain)
        {
            var result = new BalanceModel{Asset = blockchain.ToString().ToUpper()};

            switch (blockchain)
            {
                case Blockchain.Btc:
                    var ninjaResponse = await Url.Combine(_ninjaUrl, $"/balances/{address}/summary?colored=true").GetJsonAsync<NinjaBalanceResonse>();
                    result.Balance = Math.Min(ninjaResponse.Spendable.Amount, ninjaResponse.Confirmed.Amount) * BtcMultiplier;
                    break;
                case Blockchain.Eth:
                    var samuraiResponse = await Url.Combine(_samuraiUrl, $"/api/Balance/getBalance/{address}").GetJsonAsync<SamuraiBalanceResponse>();
                    result.Balance = UnitConversion.Convert.FromWei(BigInteger.Parse(samuraiResponse.Amount));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(blockchain), blockchain, null);
            }

            return result;
        }
    }
}
