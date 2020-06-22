using ECommerce.Dependency;
using ECommerce.Market.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Market.Service.Config
{
    public class DependencyModule : IDependencyModule
    {
        public void Configure(IServiceCollection services)
        {
            services.AddModule<Repository.Config.DependencyModule>();
            services.AddSingleton<IProductService, Services.ProductService>();
            services.AddSingleton<IInvoiceApiService, InvoiceApiService>();
        }
    }
}
