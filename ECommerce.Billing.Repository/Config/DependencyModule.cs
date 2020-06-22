using ECommerce.Data.Configuration;
using ECommerce.Dependency;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Billing.Repository.Config
{
    public class DependencyModule : IDependencyModule
    {
        private static IMongoCollection<TCollection> GetMongoCollection<TCollection>(IServiceProvider serviceProvider, string collectionName)
        {
            var config = serviceProvider.GetService<IDatabaseConfig>();
            var client = serviceProvider.GetService<IMongoClient>();
            var db = client.GetDatabase(config.DatabaseName);
            return db.GetCollection<TCollection>(collectionName);
        }
        public void Configure(IServiceCollection services)
        {
            services.AddSingleton<IMongoClient>(service => new MongoClient(service.GetService<IDatabaseConfig>().ConnectionString));
            services.AddSingleton(service =>
                GetMongoCollection<Entities.Invoice>(service, service.GetService<IDatabaseConfig>().Table));
            services.AddSingleton<IInvoiceRepository, Repositories.InvoiceRepository>();
        }
    }
}
