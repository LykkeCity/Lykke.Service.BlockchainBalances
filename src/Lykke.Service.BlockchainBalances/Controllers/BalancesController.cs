using System;
using System.Net;
using System.Threading.Tasks;
using Common.Log;
using Lykke.Service.BlockchainBalances.Core.Domain;
using Lykke.Service.BlockchainBalances.Core.Services;
using Lykke.Service.BlockchainBalances.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Lykke.Service.BlockchainBalances.Controllers
{
    [Route("api/[controller]")]
    public class BalancesController : Controller
    {
        private readonly IBlockchainBalanceService _balanceService;
        private readonly ILog _log;

        public BalancesController(
            IBlockchainBalanceService balanceService,
            ILog log
            )
        {
            _balanceService = balanceService;
            _log = log;
        }

        [HttpGet]
        [Route("{address}/{blockchain}")]
        [SwaggerOperation("GetBalance")]
        [ProducesResponseType(typeof(BalanceModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetBalance(string address, Blockchain blockchain)
        {
            try
            {
                return Ok(await _balanceService.GetBalanceAsync(address, blockchain));
            }
            catch (Exception ex)
            {
                await _log.WriteErrorAsync(nameof(BalancesController), nameof(GetBalance),
                    $"address = {address}, blockchain = {blockchain.ToString().ToUpper()}", ex);

                return StatusCode((int)HttpStatusCode.InternalServerError, ErrorResponse.Create(ex.Message));
            }
        }
    }
}
