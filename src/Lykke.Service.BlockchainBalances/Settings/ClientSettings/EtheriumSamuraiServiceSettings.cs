using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.BlockchainBalances.Settings.ClientSettings
{
    public class EtheriumSamuraiServiceSettings
    {
        [HttpCheck("/api/isalive")]
        public string ServiceUrl { get; set; }
    }
}
