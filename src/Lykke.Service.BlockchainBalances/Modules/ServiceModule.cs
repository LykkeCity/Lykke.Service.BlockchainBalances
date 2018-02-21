using Autofac;
using Common.Log;
using Lykke.Service.BlockchainBalances.Core.Services;
using Lykke.Service.BlockchainBalances.Core.Settings;
using Lykke.Service.BlockchainBalances.Services;
using Lykke.SettingsReader;

namespace Lykke.Service.BlockchainBalances.Modules
{
    public class ServiceModule : Module
    {
        private readonly IReloadingManager<AppSettings> _settings;
        private readonly ILog _log;

        public ServiceModule(IReloadingManager<AppSettings> settings, ILog log)
        {
            _settings = settings;
            _log = log;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_log)
                .As<ILog>()
                .SingleInstance();

            builder.RegisterType<HealthService>()
                .As<IHealthService>()
                .SingleInstance();

            builder.RegisterType<StartupManager>()
                .As<IStartupManager>();

            builder.RegisterType<ShutdownManager>()
                .As<IShutdownManager>();
            
            builder.RegisterType<BlockchainBalancesService>()
                .As<IBlockchainBalanceService>()
                .WithParameter(TypedParameter.From(_settings.CurrentValue.NinjaServiceClient))
                .WithParameter(TypedParameter.From(_settings.CurrentValue.EtheriumSamuraiServiceClient))
                .SingleInstance();
        }
    }
}
