using ECommerce.Data.Configuration;
using ECommerce.Dependency;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Billing.Api.Config
{
    public class DependencyModule : IDependencyModule
    {
        public void Configure(IServiceCollection services)
        {
            services.AddModule<Service.Config.DependencyModule>();
            services.AddSingleton<IDatabaseConfig, DbConfig>();
        }
    }
}
