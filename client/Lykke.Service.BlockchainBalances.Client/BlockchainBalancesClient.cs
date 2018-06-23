using System;
using System.Net.Http;
using System.Threading.Tasks;
using Common.Log;
using Lykke.Service.BlockchainBalances.Client.AutorestClient;
using Lykke.Service.BlockchainBalances.Client.AutorestClient.Models;

namespace Lykke.Service.BlockchainBalances.Client
{
    public class BlockchainBalancesClient : IBlockchainBalancesClient, IDisposable
    {
        private readonly ILog _log;
        private IBlockchainBalancesAPI _service;

        public BlockchainBalancesClient(string serviceUrl, ILog log)
        {
            _log = log;
            _service = new BlockchainBalancesAPI(new Uri(serviceUrl), new HttpClient());  
        }

        public void Dispose()
        {
            if (_service == null)
                return;
            _service.Dispose();
            _service = null;
        }

        public async Task<BalanceModel> GetBalanceAsync(string address, Blockchain blockchain)
        {
            try
            {
                var result = await _service.GetBalanceAsync(address, blockchain);

                switch (result)
                {
                    case BalanceModel response:
                        return response;
                    case ErrorResponse errorResponse:
                        return new BalanceModel{Asset = blockchain.ToString().ToUpper()};
                }
            }
            catch (Exception ex)
            {
                await _log.WriteErrorAsync(nameof(BlockchainBalancesClient), nameof(GetBalanceAsync),
                    $"address = {address}, blockchain = {blockchain.ToString().ToUpper()}", ex);
            }
            
            return new BalanceModel{Asset = blockchain.ToString().ToUpper()};
        }
    }
}
