using ECommerce.Dependency;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Billing.Service.Config
{
    public class DependencyModule : IDependencyModule
    {
        public void Configure(IServiceCollection services)
        {
            services.AddModule<Repository.Config.DependencyModule>();
            services.AddSingleton<IInvoiceService, Services.InvoiceService>();
        }
    }
}
