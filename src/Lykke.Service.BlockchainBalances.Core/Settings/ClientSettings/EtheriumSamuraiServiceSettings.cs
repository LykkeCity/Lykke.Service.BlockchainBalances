using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.BlockchainBalances.Core.Settings.ClientSettings
{
    public class EtheriumSamuraiServiceSettings
    {
        [HttpCheck("/api/isalive")]
        public string ServiceUrl { get; set; }
    }
}
