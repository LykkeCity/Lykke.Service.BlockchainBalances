using System;
using System.Net.Http;

namespace Lykke.Service.BlockchainBalances.Client.AutorestClient
{
    internal partial class BlockchainBalancesAPI
    {
        /// <inheritdoc />
        /// <summary>
        /// Should be used to prevent memory leak in RetryPolicy
        /// </summary>
        public BlockchainBalancesAPI(Uri baseUri, HttpClient client) : base(client)
        {
            Initialize();

            BaseUri = baseUri ?? throw new ArgumentNullException("baseUri");
        }
    }
}
