using ECommerce.Data.Configuration;
using ECommerce.Dependency;
using ECommerce.Market.Service.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Market.Api.Config
{
    public class DependencyModule : IDependencyModule
    {
        public void Configure(IServiceCollection services)
        {
            services.AddModule<Service.Config.DependencyModule>();
            services.AddSingleton<IDatabaseConfig, DbConfig>();
            services.AddSingleton<IInvoiceConnectionConfig, InvoiceConnectionConfig>();

        }
    }
}
