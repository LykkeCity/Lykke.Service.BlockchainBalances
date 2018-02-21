using Lykke.Service.BlockchainBalances.Core.Settings.ClientSettings;
using Lykke.Service.BlockchainBalances.Core.Settings.ServiceSettings;
using Lykke.Service.BlockchainBalances.Core.Settings.SlackNotifications;

namespace Lykke.Service.BlockchainBalances.Core.Settings
{
    public class AppSettings
    {
        public BlockchainBalancesSettings BlockchainBalancesService { get; set; }
        public SlackNotificationsSettings SlackNotifications { get; set; }
        public NinjaServcieSettings NinjaServiceClient { get; set; }
        public EtheriumSamuraiServiceSettings EtheriumSamuraiServiceClient { get; set; }
    }
}
