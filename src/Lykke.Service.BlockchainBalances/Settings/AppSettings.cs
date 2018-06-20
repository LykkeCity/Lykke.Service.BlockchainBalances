using JetBrains.Annotations;
using Lykke.Sdk.Settings;
using Lykke.Service.BlockchainBalances.Settings.ClientSettings;
using Lykke.Service.BlockchainBalances.Settings.ServiceSettings;

namespace Lykke.Service.BlockchainBalances.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AppSettings : BaseAppSettings
    {
        public BlockchainBalancesSettings BlockchainBalancesService { get; set; }
        public NinjaServcieSettings NinjaServiceClient { get; set; }
        public EtheriumSamuraiServiceSettings EtheriumSamuraiServiceClient { get; set; }
    }
}
