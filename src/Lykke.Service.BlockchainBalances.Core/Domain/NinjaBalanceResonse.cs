using System;
using System.Collections.Generic;
using System.Text;

namespace Lykke.Service.BlockchainBalances.Core.Domain
{
    public class NinjaBalanceResonse
    {
        public BalanceSummaryDetails Spendable { get; set; }
        public BalanceSummaryDetails Confirmed { get; set; }
    }

    public class BalanceSummaryDetails
    {
        public decimal Amount { get; set; }
    }
}
