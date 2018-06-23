using System;
using Lykke.Sdk;
using Lykke.Service.BlockchainBalances.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Lykke.Service.BlockchainBalances
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return services.BuildServiceProvider<AppSettings>(options =>
            {
                options.ApiTitle = "BlockchainBalances API";
                options.Logs = ("BlockchainBalancesLog", ctx => ctx.BlockchainBalancesService.Db.LogsConnString);
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime appLifetime)
        {
            app.UseLykkeConfiguration();
        }
    }
}
