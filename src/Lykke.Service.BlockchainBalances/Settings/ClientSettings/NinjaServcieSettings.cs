using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.BlockchainBalances.Settings.ClientSettings
{
    public class NinjaServcieSettings
    {
        [HttpCheck("")]
        public string ServiceUrl { get; set; }
    }
}
