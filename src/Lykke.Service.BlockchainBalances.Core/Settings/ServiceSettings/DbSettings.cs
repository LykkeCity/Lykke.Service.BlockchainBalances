using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.BlockchainBalances.Core.Settings.ServiceSettings
{
    public class DbSettings
    {
        [AzureTableCheck]
        public string LogsConnString { get; set; }
    }
}
